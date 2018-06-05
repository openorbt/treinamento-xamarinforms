using System.Windows.Input;
using Xamarin.Forms;

namespace AppInicial.Controls
{
    public class CustomListView : ListView
    {
        public static readonly BindableProperty ItemTappedCommandProperty =
          BindableProperty.Create(nameof(ItemTappedCommand),
                            typeof(ICommand),
                            typeof(ListView),
                            null);
        public ICommand ItemTappedCommand
        {
            get { return (ICommand)GetValue(ItemTappedCommandProperty); }
            set { SetValue(ItemTappedCommandProperty, value); }
        }

        public CustomListView() : base()
        {
            Initialize();
        }

        private void Initialize()
        {
            ItemTapped += ListView_ItemTapped;

            ItemSelected += CustomListView_ItemSelected;
        }

        private void CustomListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;
            ((ListView)sender).SelectedItem = null;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (ItemTappedCommand != null && ItemTappedCommand.CanExecute(null))
                ItemTappedCommand.Execute(e.Item);
        }
    }
}
