using HepsiApiProject.Application.DTOs;
using HepsiApiProject.Application.Interfaces.AutoMapper;
using HepsiApiProject.Application.Interfaces.UnitOfWorks;
using HepsiApiProject.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApiProject.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper IMapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = IMapper;
        }
        public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.GetReadRepository<Product>().GetAllAsync(include:x => x.Include(b => b.Brand));

            //List<GetAllProductsQueryResponse> response = new();

            //foreach (var product in products)
            //    response.Add(new GetAllProductsQueryResponse
            //    {
            //        Title = product.Title,
            //        Description = product.Description,
            //        Discount = product.Discount,
            //        Price = product.Price - (product.Price * product.Discount / 100),
            //    });

            _mapper.Map<BrandDTO, Brand>(new Brand());

            var map = _mapper.Map<GetAllProductsQueryResponse, Product>(products);

            foreach(var item in map)
                item.Price -= (item.Price * item.Discount / 100);

            return map;
        }
    }
}
