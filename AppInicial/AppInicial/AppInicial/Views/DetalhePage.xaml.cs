using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppInicial.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalhePage : ContentPage
	{
		public DetalhePage ()
		{
			InitializeComponent ();
            BindingContext = new ViewModels.DetalhePageViewModel();
		}
	}
}