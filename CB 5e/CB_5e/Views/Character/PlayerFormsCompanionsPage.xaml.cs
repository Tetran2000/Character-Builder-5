﻿using CB_5e.ViewModels;
using CB_5e.ViewModels.Character;
using CB_5e.ViewModels.Character.Play;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CB_5e.Views.Character
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerFormsCompanionsPage : ContentPage
    {
        public PlayerFormsCompanionsPage(FormsCompanionsViewModel model)
        {
            BindingContext = model;
            model.Navigation = Navigation;
            InitializeComponent();
        }
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (sender is ListView lv) lv.SelectedItem = null;
        }
    }
}