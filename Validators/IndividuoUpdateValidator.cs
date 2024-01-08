using Automotores.DTOs;
using FluentValidation;

namespace Automotores.Validators
{
    public class IndividuoUpdateValidator : AbstractValidator<IndividuoUpdateDto>
    {
        public IndividuoUpdateValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El nombre es obligatorio");
            RuleFor(x => x.Apellido).NotEmpty().WithMessage("El apellido es obligatoria");
            RuleFor(x => x.TipoDocumentoId).NotEmpty();
            RuleFor(x => x.Documento).NotEmpty().WithMessage("El número de documento es obligatorio");
            RuleFor(x => x.FechaNacimiento).NotEmpty().WithMessage("La fecha de nacimiento es obligatoria");
            RuleFor(x => x.Telefono).NotEmpty().WithMessage("El teléfono es obligatori");
            RuleFor(x => x.Domicilio).NotEmpty().WithMessage("El domicilio es obligatorio");
            RuleFor(x => x.Email).NotEmpty().WithMessage("El email es obligatorio");
            RuleFor(x => x.ProvinciaId).NotEmpty();
            RuleFor(x => x.LocalidadId).NotEmpty();
            RuleFor(x => x.CP).NotEmpty().WithMessage("El código postal es obligatorio");
            RuleFor(x => x.Sexo).NotEmpty().WithMessage("El sexo es obligatori");
        }
    }
}
