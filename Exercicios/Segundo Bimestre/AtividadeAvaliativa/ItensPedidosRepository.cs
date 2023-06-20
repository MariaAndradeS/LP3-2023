using AtividadeAvaliativa.Database;
using AtividadeAvaliativa.Models;
using Microsoft.Data.Sqlite;
namespace AtividadeAvaliativa.Repositories;

class ItensPedidosRepository 
{
    private readonly DatabaseConfig _databaseConfig;
    public ItensPedidosRepository(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }


    public List<ItensPedidos> Listar()
    {
        var itensPedidos = new List<ItensPedidos>();

        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM ItensPedidos";

        var reader = command.ExecuteReader();

        while(reader.Read())
        {
            var coditempedido = reader.GetInt32(0);
            var itempedidocodpedido = reader.GetString(1);
            var itempedidocodproduto = reader.GetString(2);
            var quantidade = reader.GetString(3);            
            var itemPedido =  ReaderToItensPedidos(reader);
            itensPedidos.Add(itemPedido);
        }

        connection.Close();
        
        return itensPedidos;

    }


        public ItensPedidos Inserir(ItensPedidos itensPedidos)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO ItensPedidos VALUES($coditempedido, $itempedidocodpedido, $itempedidocodproduto, $quantidade)";
        command.Parameters.AddWithValue("$coditempedido", itensPedidos.CodItemPedido);
        command.Parameters.AddWithValue("$itempedidocodpedido", itensPedidos.ItemPedidoCodPedido);
        command.Parameters.AddWithValue("$itempedidocodproduto", itensPedidos.ItemPedidoCodProduto);
        command.Parameters.AddWithValue("$quantidade", itensPedidos.Quantidade);
       

        command.ExecuteNonQuery();
        connection.Close();

        return itensPedidos;
    }

    public bool Apresentar(int coditempedido)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT count(coditempedido) FROM ItensPedidos WHERE (coditempedido = $id)";
        command.Parameters.AddWithValue("$id", coditempedido);

        var reader = command.ExecuteReader();   
        reader.Read();
        var result = reader.GetBoolean(0);

        return result;
    }



     public ItensPedidos GetById(int coditempedido)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM ItensPedidos WHERE (coditempedido = $coditempedido)";
        command.Parameters.AddWithValue("$coditempedido", coditempedido);

        var reader = command.ExecuteReader();
        reader.Read();

        var itemPedido = ReaderToItensPedidos(reader);

        connection.Close(); 

        return itemPedido;
    }




    private ItensPedidos ReaderToItensPedidos(SqliteDataReader reader)
    {
        var ItemPedido = new ItensPedidos(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3));

        return ItemPedido;
    }
    }