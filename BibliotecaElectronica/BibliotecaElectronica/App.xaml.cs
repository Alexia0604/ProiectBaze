﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BibliotecaElectronica.Stores;
using BibliotecaElectronica.ViewModel;


namespace BibliotecaElectronica
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private readonly NavigationStore _navigationStore;

        public App ()
        {
            _navigationStore = new NavigationStore ();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel=new LoginViewModel (_navigationStore);
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)

            };

            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
