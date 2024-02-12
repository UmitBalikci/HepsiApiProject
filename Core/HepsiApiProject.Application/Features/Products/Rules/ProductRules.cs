using HepsiApiProject.Application.Bases;
using HepsiApiProject.Application.Features.Products.Exceptions;
using HepsiApiProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApiProject.Application.Features.Products.Rules
{
    public class ProductRules : BaseRules
    {
        public Task ProductTitle(IList<Product> products, string productTitle)
        {
            if (products.Any(x => x.Title == productTitle)) throw new ProductTitleException();
            return Task.CompletedTask;
        }
    }
}
