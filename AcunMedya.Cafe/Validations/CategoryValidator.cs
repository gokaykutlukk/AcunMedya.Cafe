using AcunMedya.Cafe.Entities;
using FluentValidation;

namespace AcunMedya.Cafe.Validations
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Category name cannot be empty");
            RuleFor(x => x.CategoryName).Length(2, 50).WithMessage("Category name must be between 2 and 50 characters");
        }
    }
    
    
}
