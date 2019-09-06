using SqlitePractica.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqlitePractica.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SQLiteActualizarProducto : ContentPage
	{
        ProductoDBContext db { get; set; }
        Producto ProductoSeleccionado { get; set; }

        public SQLiteActualizarProducto (Producto pro)
		{
			InitializeComponent ();
            this.db = new ProductoDBContext();
            ProductoSeleccionado = pro;
            txtDescripcion.Text = pro.Descripcion;
            txtNombre.Text = pro.Nombre;
            txtPrecio.Text = pro.Precio.ToString();
        }

       
        private async void BtnActualizar_Clicked(object sender, EventArgs e)
        {

            double Precio=-10;
            try
            {
                Precio = Convert.ToDouble(txtPrecio.Text);
                if (Precio < 0)
                {
                    Precio = -10;
                }
            }
            catch (Exception)
            {
                ProductoSeleccionado.Precio = -10;
            }
            if (!String.IsNullOrEmpty(txtNombre.Text) && Precio > 0 && !String.IsNullOrEmpty(txtDescripcion.Text))
            {
                if (await DisplayAlert("Actualizar", "¿Estás seguro?", "Sí", "No"))
                {
                    ProductoSeleccionado.Nombre = txtNombre.Text;
                    ProductoSeleccionado.Precio = Convert.ToDouble(txtPrecio.Text);
                    ProductoSeleccionado.Descripcion = txtDescripcion.Text;


                    if (db.connection.UpdateAsync(ProductoSeleccionado).Result == 1)
                    {
                        await DisplayAlert("Exito", "El producto ha sido actualizado exitosamente", "Aceptar");
                        await Navigation.PopAsync(); //Regresa a la pagina anterior
                    }
                    else
                    {
                        await DisplayAlert("Error", "El producto no se ha podido actualizar", "Aceptar");
                    }
                }
            }
            else
            {
                await DisplayAlert("Error", "Producto no agreagdo, verifique los campos ingresados", "Ok");
            }

            
        }

        private async void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Eliminar", "¿Estás seguro?", "Sí", "No"))
            {
                    if (db.connection.DeleteAsync(ProductoSeleccionado).Result == 1)
                {
                    await DisplayAlert("Exito", "El producto ha sido eliminado exitosamente", "Aceptar");
                    await Navigation.PopAsync(); //Regresa a la pagina anterior
                }
                else
                {
                    await DisplayAlert("Error", "El producto no se ha podido eliminar", "Aceptar");
                }
            }
        }
        
    }
}