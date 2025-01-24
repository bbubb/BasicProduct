using FluentValidation;
using BasicProduct.DTOs.Requests;

namespace BasicProduct.DTOs.Validators
{
    public class ProductUpdateRequestDtoValidator : AbstractValidator<ProductUpdateRequestDto>
    {
        public ProductUpdateRequestDtoValidator()
        {
            RuleFor(product => product.Guid )
                .NotEmpty().WithMessage("Guid is required");

            RuleFor(product => product.Name )
                .NotEmpty().WithMessage("Name is required");

            RuleFor(product => product.Description )
                .MaximumLength(1000).WithMessage("Description must not exceed 1000 characters");

            RuleFor(product => product.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
}
