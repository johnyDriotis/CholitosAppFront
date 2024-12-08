using CholitosAppFront.Configuration.Interfaces;
using CholitosAppFront.Repository.Interfaces;
using System.Data.SqlClient;

namespace CholitosAppFront.Repository
{
    public class TestConnection : ITestConnection
    {
        private readonly IProperties _properties;

        public TestConnection(IProperties properties)
        {
            this._properties = properties ?? throw new ArgumentNullException(nameof(properties));
        }

        public string ConnectToDatabase()
        {
            string estadoConexion = string.Empty;

            try
            {
                SqlConnection connection = new SqlConnection(_properties.ConnectionString);
                connection.Open();
                estadoConexion = connection != null || connection.State == System.Data.ConnectionState.Open ? "Exito: Conectado a base de datos CHOLITOS_GYM" :
                    "Error: No se pudo conectar a la base de datos solicitada";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return estadoConexion;
        }
    }
}
