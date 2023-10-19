using System;
using TescoSWTestApp.Services;
using TescoSWTestApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TescoSWTestApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
