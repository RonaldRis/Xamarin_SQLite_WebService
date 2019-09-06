using SqlitePractica.Models;
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
	public partial class API_RestauranteDetailPage : ContentPage
	{
        restaurante resSelected { get; set; }

		public API_RestauranteDetailPage (restaurante res)
		{
			InitializeComponent ();
            resSelected = res;
            this.BindingContext = res;

		}
	}
}