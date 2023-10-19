using System;
using System.Collections.Generic;
using System.ComponentModel;
using TescoSWTestApp.Models;
using TescoSWTestApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TescoSWTestApp.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}