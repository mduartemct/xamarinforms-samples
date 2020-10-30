using System.IO;
using SQLite;
using SqlLite.Droid.Persistence;
using SqlLite.Persistence;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDb))]
namespace SqlLite.Droid.Persistence
{
    
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "MySQLite.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}