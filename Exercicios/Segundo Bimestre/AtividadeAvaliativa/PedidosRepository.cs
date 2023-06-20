using AtividadeAvaliativa.Database;
using AtividadeAvaliativa.Models;
using Microsoft.Data.Sqlite;
namespace AtividadeAvaliativa.Repositories;

class PedidosRepository {
    private readonly DatabaseConfig _databaseConfig;
    public PedidosRepository(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }

    public List<Pedidos> Listar()
    {
        var Pedidos = new List<Pedidos>();

        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Pedidos";

        var reader = command.ExecuteReader();

        while(reader.Read())
        {
            var CodPedido = reader.GetInt32(0);
            var PrazoEntrega = reader.GetDateTime(1);
            var DataPedido = reader.GetDateTime(2);
            var PedidoCodCliente = reader.GetInt32(3); 
            var PedidoCodVendedor = reader.GetInt32(4); 
            var Pedido =  ReaderToPedidos(reader);
            Pedidos.Add(Pedido);
        }

        connection.Close();
        
        return Pedidos;
    }

    public Pedidos Inserir(Pedidos pedido)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Pedidos VALUES($CodPedido, $PrazoEntrega, $DataPedido, $PedidoCodCliente, $PedidoCodVendedor)";
        command.Parameters.AddWithValue("$CodPedido", pedido.CodPedido);
        command.Parameters.AddWithValue("$PrazoEntrega", pedido.PrazoEntrega);
        command.Parameters.AddWithValue("$DataPedido", pedido.DataPedido);
        command.Parameters.AddWithValue("$PedidoCodCliente", pedido.PedidoCodCliente);
        command.Parameters.AddWithValue("$PedidoCodVendedor", pedido.PedidoCodVendedor);

        command.ExecuteNonQuery();
        connection.Close();

        return pedido;
    }     


     public bool Apresentar(int CodPedido)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT count(CodPedido) FROM Pedidos WHERE (CodPedido = $id)";
        command.Parameters.AddWithValue("$id", CodPedido);

        var reader = command.ExecuteReader();
        reader.Read();
        var result = reader.GetBoolean(0);

        return result;
    }


    public Pedidos GetById(int CodPedido)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Pedidos WHERE (CodPedido = $CodPedido)";
        command.Parameters.AddWithValue("$CodPedido", CodPedido);

        var reader = command.ExecuteReader();
        reader.Read();

        var pedido = ReaderToPedidos(reader);

        connection.Close(); 

        return pedido;
    }

    private Pedidos ReaderToPedidos(SqliteDataReader reader)
    {
        var Pedido = new Pedidos(reader.GetInt32(0), reader.GetDateTime(1), reader.GetDateTime(2), reader.GetInt32(3), reader.GetInt32(4));

        return Pedido;
    }






}