using Microsoft.Data.Sqlite;
using AtividadeAvaliativa.Database;
using AtividadeAvaliativa.Repositories;
using AtividadeAvaliativa.Models;

var databaseConfig = new DatabaseConfig();
var databaseSetup = new DatabaseSetup(databaseConfig);

var clientesRepository = new ClientesRepository(databaseConfig);
var pedidosRepository = new PedidosRepository(databaseConfig);
var itenspedidosRepository = new ItensPedidosRepository(databaseConfig);
var vendedoresRepository = new VendedoresRepository(databaseConfig);
var produtosRepository = new ProdutosRepository(databaseConfig);