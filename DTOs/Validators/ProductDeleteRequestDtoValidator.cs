using FluentValidation;
using BasicProduct.DTOs.Requests;

namespace BasicProduct.DTOs.Validators
{
    public class ProductDeleteRequestDtoValidator : AbstractValidator<ProductDeleteRequestDto>
    {
        public ProductDeleteRequestDtoValidator()
        {
            RuleFor(product => product.Guid)
                .NotEmpty().WithMessage("Guid is required");
        }
    }
}