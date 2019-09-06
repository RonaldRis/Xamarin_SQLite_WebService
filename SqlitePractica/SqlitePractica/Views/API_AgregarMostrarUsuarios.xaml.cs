using CiboMarket.Models;
using SqlitePractica.Models;
using SqlitePractica.Services;
using SqlitePractica.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqlitePractica.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class API_AgregarMostrarUsuarios : ContentPage
    {

        private ProductoDBContext db;
        private UsuariosVM viewmodel;
    
        public API_AgregarMostrarUsuarios ()
		{
			InitializeComponent ();
            this.db = new ProductoDBContext();
            viewmodel = new UsuariosVM();
            this.BindingContext = viewmodel;

        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            usuario oUser = new usuario();
            oUser.NumTelefono =txtNum.Text;
            oUser.nombre = txtNombre.Text;
            
            if (!String.IsNullOrEmpty(oUser.nombre) &&  !String.IsNullOrEmpty(oUser.NumTelefono))
            {

                Rest enlaceServidor = new Rest();
                var resultado = await enlaceServidor.Post<usuario>("usuarios", oUser);
                if (resultado != default(usuario)) //Un default(usuario) es lo que retorna la funcion POST del rest en caso de que no publique exitosamente
                {
                    await DisplayAlert("Exito", oUser.nombre + " agregado", "Ok");
                    txtNum.Text = "";
                    txtNombre.Text = "";
                    //Ahora actualizo la lista
                    await viewmodel.ExecuteLoadItemsCommand();
                }
                else
                {
                    await DisplayAlert("Error", "Usuario no agreagdo", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Error", "Usuario no agreagdo, verifique los campos ingresados", "Ok");
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewmodel.LoadItemsCommand.Execute(null);

        }


    }
}