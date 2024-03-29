﻿using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApiProject.Application.Behaviors
{
    public class FluentValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validator;

        public FluentValidationBehavior(IEnumerable<IValidator<TRequest>> validator)
        {
            _validator = validator;
        }
        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var failtures = _validator.Select(v => v.Validate(context)).SelectMany(result => result.Errors).GroupBy(v => v.ErrorMessage).Select(v => v.First()).Where(v => v != null).ToList();

            if (failtures.Any())
            {
                throw new ValidationException(failtures);
            }

            return next();
        }
    }
}
