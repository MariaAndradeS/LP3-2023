using AtividadeAvaliativa.Database;
using AtividadeAvaliativa.Models;
using Microsoft.Data.Sqlite;
namespace AtividadeAvaliativa.Repositories;

class VendedoresRepository {
    private readonly DatabaseConfig _databaseConfig;
    public VendedoresRepository(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }
}