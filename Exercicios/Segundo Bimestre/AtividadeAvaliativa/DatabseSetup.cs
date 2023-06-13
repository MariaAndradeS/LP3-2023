using AtividadeAvaliativa.Database;
using AtividadeAvaliativa.Models;
using Microsoft.Data.Sqlite;
namespace AtividadeAvaliativa.Repositories;

class DatabaseSetup {
    private readonly DatabaseConfig _databaseConfig;

    public DatabaseSetup(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
        CreateClientesTable();
        CreatePedidosTable();
        CreateItensPedidosTable();
        CreateVendedoresTable();
        CreateProdutosTable();
    }

    private void CreateClientesTable() {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Clientes(
                codcliente int not null primary key,
                nome varchar(45) not null,
                endereco varchar(45) not null,
                cidade varchar(45) not null,
                cep varchar(11) not null,
                uf varchar(02) not null,
                ie varchar(12) not null);
            );
        ";

        command.ExecuteNonQuery();
        connection.Close();
    }

    private void CreatePedidosTable() {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Pedidos(
                codpedido int not null primary key,
                prazoentrega datetime not null,
                datapedido datetime not null,
                pedidocodcliente int not null,
                pedidocodvendedor int not null
            );
        ";

        command.ExecuteNonQuery();
        connection.Close();
    }

    private void CreateItensPedidosTable() {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS ItensPedidos(
                coditempedido int not null primary key,
                itempedidocodpedido int not null,
                itempedidocodproduto int not null,
                quantidade int not null
            );
        ";

        command.ExecuteNonQuery();
        connection.Close();
        
    }

    private void CreateVendedoresTable() {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Vendedores(
                codvendedor int not null primary key,
                nome varchar(45) not null,
                salariofixo decimal not null,
                faixacomissao varchar(5) not null
            );
        ";

        command.ExecuteNonQuery();
        connection.Close();
        
    }

    private void CreateProdutosTable() {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Produtos(
                codproduto int not null primary key,
                descricao varchar(45) not null,
                valorunitario decimal not null
            );
        ";

        command.ExecuteNonQuery();
        connection.Close();
        
    }
    
}