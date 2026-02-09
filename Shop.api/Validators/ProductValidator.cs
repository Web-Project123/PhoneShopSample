

using FluentValidation;
using PhoneShop.Application.DTOs;



namespace Shop.api.Validators
{
    public class CreateProductValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("نام محصول اجباری است")
                .MinimumLength(3).WithMessage("نام محصول حداقل ۳ کاراکتر باشد");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("قیمت باید بزرگتر از صفر باشد");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("توضیحات نمی‌تواند خالی باشد");
        }
    }
}