using AtividadeAvaliativa.Database;
using AtividadeAvaliativa.Models;
using Microsoft.Data.Sqlite;
namespace AtividadeAvaliativa.Repositories;

class ItensPedidosRepository {
    private readonly DatabaseConfig _databaseConfig;
    public ItensPedidosRepository(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }
}