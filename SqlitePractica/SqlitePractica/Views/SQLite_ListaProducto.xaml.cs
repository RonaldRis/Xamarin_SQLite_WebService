

namespace SqlitePractica.Views
{

    using SqlitePractica.Models;
    using System;
    using System.Collections.ObjectModel;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SQLite_ListaProducto : ContentPage
	{
        public ProductoDBContext db;
        public ObservableCollection<Producto> listaP;


        public SQLite_ListaProducto ()
		{
			InitializeComponent ();
            this.db = new ProductoDBContext();
            cargarProductos();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.cargarProductos();
        }

        public void cargarProductos()
        {
            Producto oProd = new Producto();
            listaP = new ObservableCollection<Producto>();

            var productos = db.connection.QueryAsync<Producto>("select * from [Producto]").Result;
            if (!(productos is null))
            {
                foreach (var item in productos)
                {
                    listaP.Add(item);
                }
            }
            LP.ItemsSource = listaP;
        }
        private void LP_Refreshing(object sender, EventArgs e)
        {
            cargarProductos();
            LP.EndRefresh();
        }

        private async void LP_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
            {
                return;
            }
            
            bool res = await DisplayAlert("Modificar", "Modificar producto", "Sí", "No");
            if (res)
            {
                Producto oPro = e.Item as Producto;
                await Navigation.PushAsync(new SQLiteActualizarProducto(oPro));
            }
            LP.SelectedItem = null; 
        }
    }
}