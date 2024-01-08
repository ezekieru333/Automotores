using Automotores.DTOs;
using FluentValidation;

namespace Automotores.Validators
{
    public class VehiculoUpdateValidator : AbstractValidator<VehiculoUpdateDto>
    {
        public VehiculoUpdateValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.MarcaId).NotEmpty().WithMessage("La marca es obligatoria");
            RuleFor(x => x.MarcaId).GreaterThan(0).WithMessage("Error con el valor de marca");
            RuleFor(x => x.Modelo).NotEmpty().WithMessage("El modelo es obligatorio");
            RuleFor(x => x.Año).NotEmpty().WithMessage("El año es obligatorio");
            RuleFor(x => x.Año).GreaterThan(2005).WithMessage("El vehículo es demasiado viejo");
            RuleFor(x => x.Motor).NotEmpty().WithMessage("La cilindrada es obligatoria");
            RuleFor(x => x.TipoMotorId).NotEmpty().WithMessage("El tipo de motor es obligatorio");
            RuleFor(x => x.TransmisionId).NotEmpty().WithMessage("La transmisión es obligatoria");
            RuleFor(x => x.CantidadPuertas).NotEmpty().WithMessage("La candidad de puertas es obligatoria");
            RuleFor(x => x.Dominio).NotEmpty().WithMessage("El dominio es obligatorio");
            RuleFor(x => x.Observaciones).NotEmpty().WithMessage("Ingrese observaciones acerca del vehículo");
            RuleFor(x => x.Color).NotEmpty().WithMessage("El color es obligatorio");
            RuleFor(x => x.IndividuoId).NotEmpty().WithMessage("El dueño anterior es obligatorio");
            RuleFor(x => x.PrecioRevista).NotEmpty().WithMessage("El precio de revista es obligatorio");
            RuleFor(x => x.PrecioToma).NotEmpty().WithMessage("El precio de toma es obligatorio");
            RuleFor(x => x.EntregaMinima).NotEmpty().WithMessage("La entrega mínima es obligatoria");
            RuleFor(x => x.PrecioVenta).NotEmpty().WithMessage("El precio de venta es obligatorio");
            RuleFor(x => x.PrecioLista).NotEmpty().WithMessage("El precio de lista es obligatorio");
            RuleFor(x => x.PrecioUSD).NotEmpty().WithMessage("El precio en dólares es obligatorio");
            RuleFor(x => x.EstadoId).NotEmpty().WithMessage("El estado es obligatorio");
        }
    }
}
