using System.ComponentModel;
using TescoSWTestApp.ViewModels;
using Xamarin.Forms;

namespace TescoSWTestApp.Views
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