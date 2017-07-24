﻿using CB_5e.ViewModels;
using Character_Builder;
using PCLStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CB_5e.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayPage : TabbedPage
    {
        public PlayPage()
        {
            InitializeComponent();
            Children.Add(
                    new NavigationPage(new PlayerOverview())
                    {
                        Title = "Stats",
                        Icon = Device.OnPlatform("tab_feed.png", null, null)
                    });
            Children.Add(
                    new NavigationPage(new AboutPage())
                    {
                        Title = "Spells",
                        Icon = Device.OnPlatform("tab_about.png", null, null)
                    });
            Children.Add(
                    new NavigationPage(new AboutPage())
                    {
                        Title = "Shop",
                        Icon = Device.OnPlatform("tab_about.png", null, null)
                    });
            Children.Add(
                    new NavigationPage(new AboutPage())
                    {
                        Title = "Journal",
                        Icon = Device.OnPlatform("tab_about.png", null, null)
                    });
        }
        protected override bool OnBackButtonPressed()
        {
            if (App.AutoSaveDuringPlay)
            {
                PlayerViewModel.Saving.WaitForAll();
            } else if (Player.UnsavedChanges > 0)
            {
                if (DisplayAlert("Unsaved Changes", "You have " + Player.UnsavedChanges + " unsaved changes. Do you want to save them before leaving?", "Yes", "No").Result)
                {
                    PlayerViewModel.Instance.DoSave();
                }
            }
            Player.Current = null;
            CharactersViewModel.Instance.LoadItemsCommand.Execute(null);
            return base.OnBackButtonPressed();
        }
    }
}