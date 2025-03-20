using System.IO;
using SQLite;
using EngeTerraPlan.Models;

namespace EngeTerraPlan.Data
{
    public static class DatabaseService
    {
        private static readonly string DatabasePath = Path.Combine(FileSystem.AppDataDirectory, "DensidadeInSitu.db");

        private static SQLiteConnection _database;

        public static SQLiteConnection Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new SQLiteConnection(DatabasePath);
                    _database.CreateTable<DensidadeInSituModel>(); // Criação da tabela
                }
                return _database;
            }
        }
    }
}
