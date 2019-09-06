
namespace SqlitePractica.ViewModels
{
    using CiboMarket.Models;
    using SqlitePractica.Models;
    using SqlitePractica.Services;
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    public class UsuariosVM : BaseViewModel
    {

        public ObservableCollection<usuario> Items { get; set; }
        public Command LoadItemsCommand { get; set; }


        public UsuariosVM()
        {
            DataStore = new Rest();
            Items = new ObservableCollection<usuario>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

        }


        public async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetAll<usuario>("usuarios");
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
