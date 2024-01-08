namespace Automotores.DTOs
{
    public class VehiculoInsertDto
    {
        public int MarcaId { get; set; }
        public string Modelo { get; set; }
        public int Año { get; set; }
        public float Motor { get; set; }
        public int TipoMotorId { get; set; }
        public int TransmisionId { get; set; }
        public int CantidadPuertas { get; set; }
        public string Dominio { get; set; }
        public string Observaciones { get; set; }
        public string Color { get; set; }
        public int IndividuoId { get; set; }
        public decimal PrecioRevista { get; set; }
        public decimal PrecioToma { get; set; }
        public decimal EntregaMinima { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal PrecioLista { get; set; }
        public int PrecioUSD { get; set; }
        public int EstadoId { get; set; }
    }
}
