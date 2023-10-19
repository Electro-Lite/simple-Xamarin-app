using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TescoSWTestApp.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "Úvod";
            ChangeColor = new Command(ChangeColor_f);
        }

        public ICommand ChangeColor { get; set; }

        public void ChangeColor_f()
        {
            Random Rnd = new Random();
            App.Current.Resources["Primary"] = Color.FromRgb(Rnd.Next(255), Rnd.Next(255), Rnd.Next(255));
        }
    }
}