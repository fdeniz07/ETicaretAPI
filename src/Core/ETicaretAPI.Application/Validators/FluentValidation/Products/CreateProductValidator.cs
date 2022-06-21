using ETicaretAPI.Application.ViewModels.Products;
using FluentValidation;

namespace ETicaretAPI.Application.Validators.FluentValidation.Products
{
    public class CreateProductValidator:AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotNull().WithMessage("Lütfen ürün adini bos gecmeyiniz.")
                .MaximumLength(150)
                .MinimumLength(3).WithMessage("Lütfen ürün adini 5 ile 150 karakter arasinda giriniz.");

            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull().WithMessage("Lütfen stok bilgisini bos gecmeyiniz.")
                .Must(s => s >= 0).WithMessage("Stok bilgisi negatif olamaz.");

            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull().WithMessage("Lütfen fiyat bilgisini bos gecmeyiniz.")
                .Must(f => f >= 0).WithMessage("Fiyat bilgisi negatif olamaz.");
        }
    }
}
