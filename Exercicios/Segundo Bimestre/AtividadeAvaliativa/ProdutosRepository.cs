using AtividadeAvaliativa.Database;
using AtividadeAvaliativa.Models;
using Microsoft.Data.Sqlite;
namespace AtividadeAvaliativa.Repositories;

class ProdutosRepository{
    private readonly DatabaseConfig _databaseConfig;
    public ProdutosRepository(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }


    public List<Produtos> Listar()
    {
        var Produtos = new List<Produtos>();

        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Produtos";

        var reader = command.ExecuteReader();

        while(reader.Read())
        {
            var CodProduto = reader.GetInt32(0);
            var Descricao = reader.GetString(1);
            var ValorUnitario = reader.GetDecimal(2);
           
           
            var Produto = ReadertoProdutos(reader);
            Produtos.Add(Produto);
        }

        connection.Close();
        
        return Produtos;
    }

    public Produtos Inserir(Produtos produto)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Produtos VALUES($CodProduto, $Descricao, $ValorUnitario)";
        command.Parameters.AddWithValue("$CodProduto", produto.CodProduto);
        command.Parameters.AddWithValue("$Descricao", produto.Descricao);
        command.Parameters.AddWithValue("$ValorUnitario", produto.ValorUnitario);

        command.ExecuteNonQuery();
        connection.Close();

        return produto;
    }     

    public bool Apresentar(int CodProduto)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT count(CodProduto) FROM Produtos WHERE (CodProduto = $id)";
        command.Parameters.AddWithValue("$id", CodProduto);

        var reader = command.ExecuteReader();
        reader.Read();
        var result = reader.GetBoolean(0);

        return result;
    }


    public Produtos GetById(int CodProduto)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Produtos WHERE (CodProduto = $CodProduto)";
        command.Parameters.AddWithValue("$CodProduto", CodProduto);

        var reader = command.ExecuteReader();
        reader.Read();

        var produto = ReadertoProdutos(reader);

        connection.Close(); 

        return produto;
    }









     private Produtos ReadertoProdutos(SqliteDataReader reader)
    {
        var Produto = new Produtos(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2));

        return Produto;
    }

}