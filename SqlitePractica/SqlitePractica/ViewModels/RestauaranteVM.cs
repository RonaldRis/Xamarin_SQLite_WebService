namespace SqlitePractica.ViewModels
{
    using SqlitePractica.Models;
    using SqlitePractica.Services;
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    public class RestaurantesViewModel : BaseViewModel
    {

        public ObservableCollection<restaurante> Items { get; set; }
        public Command LoadItemsCommand { get; set; }


        public RestaurantesViewModel()
        {
            DataStore = new Rest();
            Items = new ObservableCollection<restaurante>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

        }


        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetAll<restaurante>("restaurantes");
                foreach (var item in items)
                {
                    Items.Add(item);
                }
                IsBusy = false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
                if (Items.Count == 0)
                {
                    
                    //Toast.MakeText(Android.App.Application.Context, "Verifique su conexión a internet", ToastLength.Short).Show();
                }
            }
        }

    }
}
