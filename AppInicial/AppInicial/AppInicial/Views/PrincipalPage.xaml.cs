using AppInicial.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppInicial.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PrincipalPage : ContentPage
	{
        PrincipalPageViewModel _viewModel;
		public PrincipalPage ()
		{
			InitializeComponent ();
            _viewModel = new PrincipalPageViewModel();
            BindingContext = _viewModel;
		}
    }
}