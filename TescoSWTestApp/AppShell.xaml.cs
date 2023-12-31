﻿using System;
using System.Collections.Generic;
using TescoSWTestApp.ViewModels;
using TescoSWTestApp.Views;
using Xamarin.Forms;

namespace TescoSWTestApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(EditItemPage), typeof(EditItemPage));

        }

    }
}
