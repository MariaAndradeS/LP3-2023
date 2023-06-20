using AtividadeAvaliativa.Database;
using AtividadeAvaliativa.Models;
using Microsoft.Data.Sqlite;
namespace AtividadeAvaliativa.Repositories;

class ClientesRepository {
    private readonly DatabaseConfig _databaseConfig;
    public ClientesRepository(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }

    public List<Clientes> Listar()
    {
        var clientes = new List<Clientes>();

        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Clientes";

        var reader = command.ExecuteReader();

        while(reader.Read())
        {
            var codcliente = reader.GetInt32(0);
            var nome = reader.GetString(1);
            var endereco = reader.GetString(2);
            var cidade = reader.GetString(3);
            var cep = reader.GetString(4);
            var uf = reader.GetString(5);
            var ie = reader.GetString(6);
            var cliente =  ReaderToCliente(reader);
            clientes.Add(cliente);
        }

        connection.Close();
        
        return clientes;
    }

    public Clientes Inserir(Clientes clientes)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Clientes VALUES($codcliente, $nome, $endereco, $cidade, $cep, $uf, $ie)";
        command.Parameters.AddWithValue("$codcliente", clientes.CodCliente);
        command.Parameters.AddWithValue("$nome", clientes.Nome);
        command.Parameters.AddWithValue("$endereco", clientes.Endereco);
        command.Parameters.AddWithValue("$cidade", clientes.Cidade);
        command.Parameters.AddWithValue("$cep", clientes.Cep);
        command.Parameters.AddWithValue("$uf", clientes.Uf);
        command.Parameters.AddWithValue("$ie", clientes.Ie);

        command.ExecuteNonQuery();
        connection.Close();

        return clientes;
    }
    public bool Apresentar(int codcliente)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT count(codcliente) FROM Clientes WHERE (codcliente = $id)";
        command.Parameters.AddWithValue("$id", codcliente);

        var reader = command.ExecuteReader();
        reader.Read();
        var result = reader.GetBoolean(0);

        return result;
    }

    public Clientes GetById(int codcliente)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Clientes WHERE (codcliente = $codcliente)";
        command.Parameters.AddWithValue("$codcliente", codcliente);

        var reader = command.ExecuteReader();
        reader.Read();

        var cliente = ReaderToCliente(reader);

        connection.Close(); 

        return cliente;
    }
    private Clientes ReaderToCliente(SqliteDataReader reader)
    {
        var clientes = new Clientes(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6));

        return clientes;
    }
}