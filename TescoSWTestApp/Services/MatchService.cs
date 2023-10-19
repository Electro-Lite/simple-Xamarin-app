using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;

namespace TescoSWTestApp.Services
{
    public static class MatchService
    {
        static SQLiteConnection Db;
        static async Task Init()
        {
            if (Db == null) return;
            var DatabasePath = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "MyDb.db");
            Db = new SQLiteConnection(DatabasePath);
            Console.WriteLine("Db Path Created");
            Db.CreateTable<Models.Item>();
        }
        public static async Task<IEnumerable<Models.Item>> GetMatches()
        {
            await Init();
            var Matches = Db.Table<Models.Item>().ToList();
            return Matches;
        }

    }
}
