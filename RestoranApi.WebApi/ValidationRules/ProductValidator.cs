using FluentValidation;
using RestoranApi.WebApi.Entities;

namespace RestoranApi.WebApi.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün adı boş geçilemez");
            RuleFor(x => x.ProductName).MinimumLength(2).WithMessage("Ürün adı en az 2 karakter olmalıdır");
            RuleFor(x=>x.ProductName).MaximumLength(100).WithMessage("Ürün adı en fazla 100 karakter olabilir");
            
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat boş geçilemez").GreaterThan(0).WithMessage("Ürün fiyatı 0 dan küçük olamaz").LessThan(1000).WithMessage("Ürün Fiyatı Çok Yüksek tekrar gözden geçiriniz!");
            RuleFor(x => x.ProductDescription).NotEmpty().WithMessage("Ürün açıklaması boş olamaz !");
        }
    }
}
