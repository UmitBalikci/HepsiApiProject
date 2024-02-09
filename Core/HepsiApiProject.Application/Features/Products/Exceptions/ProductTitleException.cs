using HepsiApiProject.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApiProject.Application.Features.Products.Exceptions
{
    public class ProductTitleException : BaseExceptions
    {
        public ProductTitleException() : base("Product Title exist!")
        {
            
        }
    }
}
