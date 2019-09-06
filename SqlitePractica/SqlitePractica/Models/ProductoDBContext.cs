
namespace SqlitePractica.Models
{
    using SQLite;
    using System;
    using System.Diagnostics;
    using System.IO;

    public class ProductoDBContext
    {
        public SQLiteAsyncConnection connection { get; set; }

        public ProductoDBContext()
        {
            String DBName = "dbProducto.db3";
            String sqlitePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DBName);
        
            try
            {
                this.connection = new SQLiteAsyncConnection(sqlitePath);
                this.connection.CreateTableAsync<Producto>().Wait();
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
            }
        }
    }
}
