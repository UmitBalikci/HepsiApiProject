﻿using HepsiApiProject.Application.Features.Products.Queries.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HepsiApiProject.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await _mediator.Send(new GetAllProductsQueryRequest());

            return Ok(response);
        }
    }
}
