namespace CholitosAppFront.Infrastructure.Queries
{
    public class ClientQuery
    {
        public static string GetAllClients() {
            return @"SELECT 
						CLIENTE				[Codigo_Cliente],
						CODIGO_GENERACION	[Codigo_Gimnasio],
						PRIMER_NOMBRE		[Primer_Nombre],
						SEGUNDO_NOMBRE		[Segundo_Nombre],
						PRIMER_APELLIDO		[Primer_Apellido],
						SEGUNDO_APELLIDO	[Segundo_Apellido],
						APELLIDO_CASADA		[Apellido_Casada],
						FECHA_PAGO			[Fecha_Pago_Modalidad],
						FECHA_INICIO		[Fecha_Inicio_Modalidad],
						FECHA_FIN			[Fecha_Fin_Modalidad],
						FIRMA				[Firma_Cliente],
						TIPO_MODALIDAD		[Tipo_Modalidad_Gym]
					FROM 
						CHOLITOS_GYM_CLIENTE;";
        }
    }
}
