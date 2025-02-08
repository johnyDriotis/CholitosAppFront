
namespace CholitosAppFront.Core.Domain
{
    public class ClientDomain
    {
        public int Codigo_Cliente { get; set; }
        public string Codigo_Gimnasio { get; set; }
        public string Primer_Nombre { get; set; }
        public string? Segundo_Nombre { get; set; }
        public string Primer_Apellido { get; set; }
        public string? Segundo_Apellido { get; set; }
        public string? Apellido_Casada { get; set; }
        public string Fecha_Pago_Modalidad { get; set; }
        public string Fecha_Inicio_Modalidad { get; set; }
        public string Fecha_Fin_Modalidad { get; set; }
        public char? Firma_Cliente { get; set; }
        public char? Tipo_Modalidad_Gym { get; set; }
    }
}
