using Entities;
using FluentValidation;
using System.Security.Policy;

namespace API
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.height).GreaterThan(0);
            RuleFor(p =>p.width).GreaterThan(0);
            RuleFor(p => p.Name).NotEmpty();
        }

    }
}
