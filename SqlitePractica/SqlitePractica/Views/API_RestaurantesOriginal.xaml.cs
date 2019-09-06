using SqlitePractica.Models;
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
	public partial class API_RestaurantesOriginal : ContentPage
	{
        RestaurantesViewModel viewmodel;

        public API_RestaurantesOriginal()
        {

            InitializeComponent();
            viewmodel = new RestaurantesViewModel();
            BindingContext = viewmodel;

        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as restaurante;
            if (item == null)
                return;
            //Toast.MakeText(Android.App.Application.Context, item.nombre, ToastLength.Short).Show();

            await Navigation.PushAsync(new API_RestauranteDetailPage(item));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }



        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewmodel.LoadItemsCommand.Execute(null);

        }
    }
}