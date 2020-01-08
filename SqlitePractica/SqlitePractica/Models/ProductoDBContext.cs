
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
            String DBname = "dbProducto.db3";
            
            string _Path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            if (Xamarin.Forms.Device.iOS == Xamarin.Forms.Device.RuntimePlatform)
            {
                _Path = Path.Combine(_Path, "..", "Library");
            }
            _Path = Path.Combine(_Path, DBname);
            
            try
            {
                this.connection = new SQLiteAsyncConnection(_Path);
                this.connection.CreateTableAsync<Producto>().Wait();
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
            }
        }
    }
}
