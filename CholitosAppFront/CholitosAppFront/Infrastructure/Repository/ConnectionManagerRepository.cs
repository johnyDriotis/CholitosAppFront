﻿using CholitosAppFront.Core.Domain;
using CholitosAppFront.Core.DTOs;
using CholitosAppFront.Core.Interfaces;
using Dapper;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;

namespace CholitosAppFront.Infrastructure.Repository
{
    public class ConnectionManagerRepository : IConnectionManagerRepository
    {
        private readonly IProperties _properties;

        private readonly IDbConnection _dbConnection;

        [Obsolete]
        public ConnectionManagerRepository(IProperties properties)
        {
            _properties = properties ?? throw new ArgumentNullException(nameof(properties));

            _dbConnection = new SqlConnection(_properties.ConnectionString);
        }

        public string ConnectToDatabaseWithMessage()
        {
            string estadoConexion = string.Empty;

            try
            {
                _dbConnection.Open();
                estadoConexion = _dbConnection != null || _dbConnection.State == System.Data.ConnectionState.Open ? "Exito: Conectado a base de datos CHOLITOS_GYM" :
                    "Error: No se pudo conectar a la base de datos solicitada";
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Ocurrio un error al conectarse a la base de datos: " + ex.Message);
                throw;
            }
            return estadoConexion;
        }

        public IDbConnection OpenAndReturnConnectionOfDatabase()
        {
            try
            {
                _dbConnection.Open();
                return _dbConnection;
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Ocurrio un error al conectarse a la base de datos: " + ex.Message);
                throw;
            }
        }

        public void CloseConnectionToDatabase()
        {
            try
            {
                if (_dbConnection.State == System.Data.ConnectionState.Open) {
                    _dbConnection.Close();
                    _dbConnection.Dispose();
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Ocurrio un error al cerrar la conexion a la base de datos: " + ex.Message);
                throw;
            }
        }
    }
}
