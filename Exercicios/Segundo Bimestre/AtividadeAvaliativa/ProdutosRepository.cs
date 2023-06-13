using AtividadeAvaliativa.Database;
using AtividadeAvaliativa.Models;
using Microsoft.Data.Sqlite;
namespace AtividadeAvaliativa.Repositories;

class ProdutosRepository {
    private readonly DatabaseConfig _databaseConfig;
    public ProdutosRepository(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }
}