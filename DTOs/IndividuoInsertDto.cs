using System.Numerics;

namespace Automotores.DTOs
{
    public class IndividuoInsertDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int TipoDocumentoId { get; set; }
        public BigInteger Documento { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Domicilio { get; set; }
        public string Email { get; set; }
        public int ProvinciaId { get; set; }
        public int LocalidadId { get; set; }
        public int CP { get; set; }
        public int Sexo { get; set; }
    }
}
