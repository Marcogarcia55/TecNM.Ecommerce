using System.Data.Common;
using MySqlConnector;
using TecNM.Ecommrce.Api.DataAcces.Interfaces;

namespace TecNM.Ecommrce.Api.DataAcces;

public class DbContext : IDbContext
{
    private readonly string _connectionString = "server=localhost;user=root;password=021417nym;database=twm;port=3306";
    private MySqlConnection _connection;

    public DbContext()
    {
        try
        {
            _connection = new MySqlConnection(_connectionString);
            _connection.Open();
            Console.WriteLine("Conexión establecida con éxito.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("No se pudo conectar a la base de datos. Error: " + ex.Message);
        }
    }

    public DbConnection Connection
    {
        get
        {
            if (_connection == null)
            {
                _connection = new MySqlConnection(_connectionString);
            }
            return _connection;
        }
    }
}
