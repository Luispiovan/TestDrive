using Microsoft.Data.Sqlite;

namespace TestDrive.Data
{
    public interface ISQLite
    {
        SqliteConnection PegarConexao();
    }
}
