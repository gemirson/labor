using FluentValidation;
using labor.Domain.VehiclesE;
using System;
using System.Collections.Generic;
using System.Text;

namespace labor.Domain.Validate
{
    public class VehiclesValidate: AbstractValidator<Vehicle>
    {
        public VehiclesValidate()
        {
            RuleFor(x => x.Name)
                .Matches(@"^[a-zA-Z\s]+$")
                .WithMessage("Campo nome aceita apenas letras");

            RuleFor(x => x.Name)
                .MinimumLength(8)
                .WithMessage("Campo nome aceita no minimo 8 caracteres");

            RuleFor(x => x.Name)
                .MaximumLength(40)
                .WithMessage("Campo nome aceita no maximo 40 caracteres");

            RuleFor(x => x.Value)
               .LessThan(0)
               .WithMessage("Campo nome aceita no maximo 40 caracteres");

            RuleFor(x => x.BrandId)
               .Equal(0)
               .WithMessage("Campo nome aceita no maximo 40 caracteres");

            RuleFor(x => x.ModelsId)
               .Equal(0)
               .WithMessage("Campo nome aceita no maximo 40 caracteres");

            RuleFor(x => x.YearModel)
               .Equal(0)
               .WithMessage("Campo nome aceita no maximo 40 caracteres");

            RuleFor(x => x.Fuel)
               .Equal(0)
               .WithMessage("Campo nome aceita no maximo 40 caracteres");
            

        }
    }
}
