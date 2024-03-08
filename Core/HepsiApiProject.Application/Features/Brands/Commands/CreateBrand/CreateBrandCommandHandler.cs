﻿using Bogus;
using HepsiApiProject.Application.Bases;
using HepsiApiProject.Application.Interfaces.AutoMapper;
using HepsiApiProject.Application.Interfaces.UnitOfWorks;
using HepsiApiProject.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApiProject.Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandHandler : BaseHandler, IRequestHandler<CreateBrandCommandRequest, Unit>
    {
        public CreateBrandCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            Faker faker = new("tr");
            List<Brand> brands = new();

            for (int i = 0; i < 1000000; i++)
            {
                brands.Add(new(faker.Commerce.Department(1)));
            }

            await _unitOfWork.GetWriteRepository<Brand>().AddRangeAsync(brands);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
