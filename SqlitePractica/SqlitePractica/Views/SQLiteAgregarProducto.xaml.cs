using SqlitePractica.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqlitePractica.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SQLiteAgregarProducto : ContentPage
	{
        private ProductoDBContext db;
        
		public SQLiteAgregarProducto ()
		{
			InitializeComponent ();
            this.db = new ProductoDBContext();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Producto oPro = new Producto();
            oPro.Nombre = txtNombre.Text;
            oPro.Descripcion = txtDescripcion.Text;
            try
            {
                oPro.Precio = Convert.ToDouble(txtPrecio.Text);
                if (oPro.Precio < 0)
                {
                    oPro.Precio = -10;
                }
            }
            catch (Exception)
            {
                oPro.Precio = -10;
            }
            if (!String.IsNullOrEmpty(txtNombre.Text) && oPro.Precio > 0 && !String.IsNullOrEmpty(oPro.Descripcion))
            {


                if (db.connection.InsertAsync(oPro).Result==1)
                {
                    await DisplayAlert("Exito", txtNombre.Text + " agregado", "Ok");
                    txtDescripcion.Text = "";
                    txtPrecio.Text = "";
                    txtNombre.Text = "";
                }
                else
                {
                    await DisplayAlert("Error", "Producto no agreagdo", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Error", "Producto no agreagdo, verifique los campos ingresados", "Ok");
            }
        }

    }
}