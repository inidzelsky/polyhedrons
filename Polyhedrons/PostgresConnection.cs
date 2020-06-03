using Npgsql;

namespace Polyhedrons
{
    public class PostgresConnection
    {
        private static PostgresConnection _instance;
        private NpgsqlConnection _connection;

        private PostgresConnection(string connectionString)
        {
            _connection = new NpgsqlConnection(connectionString);
        }

        public static NpgsqlConnection GetInstance()
        {
            if (_instance == null)
            {
                string connectionString = ConfigReader.ReadConnectionString();
                _instance = new PostgresConnection(connectionString);
            }

            return _instance._connection;
        }
    }
}