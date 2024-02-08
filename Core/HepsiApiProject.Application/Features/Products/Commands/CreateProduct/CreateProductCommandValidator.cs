using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApiProject.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty();

            RuleFor(x => x.Description).NotEmpty();

            RuleFor(x => x.BrandId).GreaterThan(0);

            RuleFor(x => x.Price).GreaterThan(0);

            RuleFor(x => x.Discount).GreaterThanOrEqualTo(0);

            RuleFor(x => x.CategoryIds).NotEmpty().Must(categories => categories.Any());
        }
    }
}
