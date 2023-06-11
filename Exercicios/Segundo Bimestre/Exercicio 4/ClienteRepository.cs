using Aula10DB.Database;
using Aula10DB.Models;
using Microsoft.Data.Sqlite;
namespace Aula10DB.Repositories;
class ClienteRepository
{
    private readonly DatabaseConfig _databaseConfig;
    public ClienteRepository(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }

    public List<Cliente> Listar()
    {
        var clientes = new List<Cliente>();
        

        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Cliente";

        var reader = command.ExecuteReader();

        while(reader.Read())
        {
            var clienteid = reader.GetInt32(0);
            var endereco = reader.GetString(1);
            var cidade = reader.GetString(2);
            var regiao = reader.GetString(3);
            var codigopostal = reader.GetString(4);
            var pais = reader.GetString(5);
            var telefone = reader.GetString(6);
            var cliente = ReaderToCliente(reader);
            clientes.Add(cliente);
        }

        connection.Close();
        
        return clientes;
    }

    public Cliente Inserir(Cliente cliente)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Cliente VALUES($clienteid, $endereco, $cidade, $regiao, $codigopostal, $pais, $telefone)";
        command.Parameters.AddWithValue("$clienteid", cliente.ClienteId);
        command.Parameters.AddWithValue("$endereco", cliente.Endereco);
        command.Parameters.AddWithValue("$cidade", cliente.Cidade);
        command.Parameters.AddWithValue("$regiao", cliente.Regiao);
        command.Parameters.AddWithValue("$codigopostal", cliente.CodigoPostal);
        command.Parameters.AddWithValue("$pais", cliente.Pais);
        command.Parameters.AddWithValue("$telefone", cliente.Telefone);

        command.ExecuteNonQuery();
        connection.Close();

        return cliente;
    }
    public bool Apresentar(int clienteid)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT count(id) FROM Cliente WHERE (id = $id)";
        command.Parameters.AddWithValue("$id", clienteid);

        var reader = command.ExecuteReader();
        reader.Read();
        var result = reader.GetBoolean(0);

        return result;
    }

    public Cliente GetById(int clienteid)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Cliente WHERE (id = $id)";
        command.Parameters.AddWithValue("$id", clienteid);

        var reader = command.ExecuteReader();
        reader.Read();

        var cliente = ReaderToCliente(reader);

        connection.Close(); 

        return cliente;
    }
private Cliente ReaderToCliente(SqliteDataReader reader)
    {
        var cliente = new Cliente(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6));

        return cliente;
    }
}