using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı boş geçilemez.");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar soyadı boş bırakılamaz.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda boş bırakılamaz.");
            RuleFor(x => x.WriterSurName).MinimumLength(2).WithMessage("Yazar soyadı en az 2 içermelidir.");
            RuleFor(x => x.WriterSurName).MaximumLength(20).WithMessage("Yazar soyadı en fazla 20 karakter içermelidir.");
           // RuleFor(x => x.WriterSurName).Must(StartWithA).WithMessage("Yazar soyadı 'A'  harfi içermelidir.");
        }
        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
