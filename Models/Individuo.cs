using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace Automotores.Models
{
    public class Individuo : Base
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int TipoDocumentoId { get; set; }
        [Column(TypeName = "bigint(20)")]
        public BigInteger Documento { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Domicilio { get; set; }
        public string Email { get; set; }
        public int ProvinciaId { get; set; }
        public int LocalidadId { get; set; }
        public int CP { get; set; }
        public int Sexo { get; set; }


        [ForeignKey("TipoDocumentoId")]
        public virtual DocumentoTipo TipoDocumento { get; set; }

        [ForeignKey("ProvinciaId")]
        public virtual Provincia Provincia { get; set; }

        [ForeignKey("LocalidadId")]
        public virtual Localidad Localidad { get; set; }
    }
}
