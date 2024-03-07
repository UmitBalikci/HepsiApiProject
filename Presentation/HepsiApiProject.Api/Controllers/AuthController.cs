using HepsiApiProject.Application.Features.Auth.Commands.Login;
using HepsiApiProject.Application.Features.Auth.Commands.RefreshToken;
using HepsiApiProject.Application.Features.Auth.Commands.Register;
using HepsiApiProject.Application.Features.Auth.Commands.Revoke;
using HepsiApiProject.Application.Features.Auth.Commands.RevokeAll;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HepsiApiProject.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommandRequest request)
        {
            await _mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPost]
        public async Task<IActionResult> RefreshToken(RefreshTokenCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPost]
        public async Task<IActionResult> Revoke(RevokeCommandRequest request)
        {
            await _mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost]
        public async Task<IActionResult> RevokeAll()
        {
            await _mediator.Send(new RevokeAllCommandRequest());
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
