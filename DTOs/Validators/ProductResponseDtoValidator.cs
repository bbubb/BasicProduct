using FluentValidation;
using BasicProduct.DTOs.Responses;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BasicProduct.DTOs.Validators
{
    public class ProductResponseDtoValidator : AbstractValidator<ProductResponseDto>
    {
        public ProductResponseDtoValidator()
        {
            RuleFor(proudct => proudct.Guid)
                .NotEmpty().WithMessage("Guid is required");

            RuleFor(proudct => proudct.Name)
                .NotEmpty().WithMessage("Name is required");

            RuleFor(proudct => proudct.Description)
                .MaximumLength(1000).WithMessage("Description must not exceed 1000 characters");

            RuleFor(proudct => proudct.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");

            RuleFor(proudct => proudct.CreatedAt)
                .NotEmpty().WithMessage("CreatedAt is required")
                .LessThanOrEqualTo(System.DateTime.Now).WithMessage("CreatedAt must be less than or equal to current date");

            When(product => product.UpdatedAt != null, () =>
            {
                RuleFor(proudct => proudct.UpdatedAt)
                .LessThanOrEqualTo(System.DateTime.Now).WithMessage("UpdatedAt must be less than or equal to current date")
                .GreaterThanOrEqualTo(proudct => proudct.CreatedAt).WithMessage("UpdatedAt must be greater than or equal to CreatedAt");
            });
        }
    }
}
