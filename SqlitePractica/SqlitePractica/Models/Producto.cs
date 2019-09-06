

namespace SqlitePractica.Models
{
    using SQLite;
    using System;
    public class Producto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public String Descripcion { get; set; }

        public Producto(){  }
    }
}
