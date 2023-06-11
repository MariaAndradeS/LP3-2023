using Aula10DB.Database;
using Aula10DB.Models;
using Microsoft.Data.Sqlite;
namespace Aula10DB.Repositories;
class PedidoRepository
{
    private readonly DatabaseConfig _databaseConfig;
    public PedidoRepository(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }

    public List<Pedido> Listar()
    {
        var pedidos = new List<Pedido>();
        

        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Pedido";

        var reader = command.ExecuteReader();

        while(reader.Read())
        {
            var pedidoid = reader.GetInt32(0);
            var empregadoid = reader.GetInt32(1);
            var datapedido = reader.GetString(2);
            var peso = reader.GetString(3);
            var codtransportadora = reader.GetInt32(4);
            var pedidoclienteid = reader.GetInt32(5);
            var pedido = ReaderToPedido(reader);
            pedidos.Add(pedido);
        }

        connection.Close();
        
        return pedidos;
    }

    public Pedido Inserir(Pedido pedido)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Pedido VALUES($pedidoid, $empregadoid, $datapedido, $peso, $codtransportadora, $pedidoclienteid)";
        command.Parameters.AddWithValue("$pedidoid", pedido.PedidoId);
        command.Parameters.AddWithValue("$empregadoid", pedido.EmpregadoId);
        command.Parameters.AddWithValue("$datapedido", pedido.DataPedido);
        command.Parameters.AddWithValue("$peso", pedido.Peso);
        command.Parameters.AddWithValue("$codtransportadora", pedido.CodTransportadora);
        command.Parameters.AddWithValue("$pedidoclienteid", pedido.PedidoClienteId);

        command.ExecuteNonQuery();
        connection.Close();

        return pedido;
    }

    public bool Apresentar(int pedidoid)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT count(id) FROM Pedido WHERE (id = $id)";
        command.Parameters.AddWithValue("$id", pedidoid);

        var reader = command.ExecuteReader();
        reader.Read();
        var result = reader.GetBoolean(0);

        return result;
    }

    public bool MostrarPedidosCliente(int clienteid)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT count(pedidoclienteid) FROM Pedido WHERE (pedidoclienteid = $id)";
        command.Parameters.AddWithValue("$id", clienteid);

        var reader = command.ExecuteReader();
        reader.Read();
        var result = reader.GetBoolean(0);

        return result;
    }

    public Pedido GetById(int pedidoid)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Pedido WHERE (id = $id)";
        command.Parameters.AddWithValue("$id", pedidoid);

        var reader = command.ExecuteReader();
        reader.Read();

        var pedido = ReaderToPedido(reader);

        connection.Close(); 

        return pedido;
    }

    public List<Pedido> GetByClienteId(int clienteid)
    {
        var pedidos = new List<Pedido>();
    
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Pedido WHERE (pedidoclienteid = $id)";
        command.Parameters.AddWithValue("$id", clienteid);

        var reader = command.ExecuteReader();

        while(reader.Read())
        {
            var pedidoid = reader.GetInt32(0);
            var empregadoid = reader.GetInt32(1);
            var datapedido = reader.GetString(2);
            var peso = reader.GetString(3);
            var codtransportadora = reader.GetInt32(4);
            var pedidoclienteid = reader.GetInt32(5);
            var pedido = ReaderToPedido(reader);
            pedidos.Add(pedido);
        }

        connection.Close(); 

        return pedidos;
    }
private Pedido ReaderToPedido(SqliteDataReader reader)
    {
        var pedido = new Pedido(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetInt32(5));
        return pedido;
    }
}