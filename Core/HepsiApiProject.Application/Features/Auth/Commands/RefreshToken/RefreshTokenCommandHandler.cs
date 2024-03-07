using HepsiApiProject.Application.Bases;
using HepsiApiProject.Application.Features.Auth.Rules;
using HepsiApiProject.Application.Interfaces.AutoMapper;
using HepsiApiProject.Application.Interfaces.Tokens;
using HepsiApiProject.Application.Interfaces.UnitOfWorks;
using HepsiApiProject.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HepsiApiProject.Application.Features.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommandHandler : BaseHandler, IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly AuthRules _authRules;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;

        public RefreshTokenCommandHandler(IMapper mapper, AuthRules authRules, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, ITokenService tokenService) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _mapper = mapper;
            _authRules = authRules;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
        {
            var principal = _tokenService.GetPrincipalFromExpiredToken(request.AccessToken);

            string email = principal.FindFirstValue(ClaimTypes.Email);

            var user = await _userManager.FindByEmailAsync(email);

            var roles = await _userManager.GetRolesAsync(user);

            await _authRules.RefreshTokenShouldNotBeExpired(user.RefreshTokenExpiryDate);

            var newAccessToken = await _tokenService.CreateToken(user, roles);

            string newRefreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;

            await _userManager.UpdateAsync(user);

            return new()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                RefreshToken = newRefreshToken
            };
        }
    }
}
