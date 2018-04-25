using PortManager.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortManager.Database
{
    public class Database
    {
        private readonly AsyncLock _lock = new AsyncLock();

        SQLiteAsyncConnection database;

        public Database()
        {
            // Get an absolute path to the database file
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyData.db");

            database = new SQLiteAsyncConnection(databasePath);


            database.GetConnection().CreateTable<Protocol>();
            database.GetConnection().CreateTable<Component>();
            database.GetConnection().CreateTable<ResponseElement>();


        }

        public SQLiteAsyncConnection GetDatabase()
        {
            return database;
        }

        public AsyncLock GetLock()
        {
            return this._lock;
        }
        private async void createTables()
        {

            //database.GetConnection().CreateTable<User>();



        }
    }
}
