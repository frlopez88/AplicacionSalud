using AppSalud.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AppSalud.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}