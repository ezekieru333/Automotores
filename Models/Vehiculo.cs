using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Automotores.Models
{
    public class Vehiculo : Base
    {        
        public int MarcaId { get; set; }
        public string Modelo { get; set; }
        public int Año { get; set; }

        [Column(TypeName = "float(6, 1)")]
        public float Motor { get; set; }
        public int TipoMotorId { get; set; }
        public int TransmisionId { get; set; }
        public int CantidadPuertas { get; set; }
        public string Dominio { get; set; }
        public string Observaciones { get; set; }
        public string Color { get; set; }
        public int IndividuoId { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal PrecioRevista { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal PrecioToma { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal EntregaMinima { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal PrecioVenta { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal PrecioLista { get; set; }
        public int PrecioUSD { get; set; }
        public int EstadoId { get; set; }

        [ForeignKey("IndividuoId")]
        public virtual Individuo Exowner { get; set; }

        [ForeignKey("MarcaId")]
        public virtual Marca Marca { get; set; }

        [ForeignKey("EstadoId")]
        public virtual VehiculoEstado Estado { get; set; }

        [ForeignKey("TipoMotorId")]
        public virtual MotorTipo TipoMotor { get; set; }

        [ForeignKey("TransmisionId")]
        public virtual Transmision Transmision { get; set; }
    }
}
