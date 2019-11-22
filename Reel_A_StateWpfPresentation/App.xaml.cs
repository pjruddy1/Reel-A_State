
using Reel_A_State.BusinessLayer;
using Reel_A_StateWpfPresentation.ViewModels;
using Reel_A_StateWpfPresentation.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Reel_A_StateWpfPresentation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MongoCRUD db = new MongoCRUD("PropertyDB");

            MainViewModel mainViewModel = new MainViewModel(db);

            MainView mainView = new MainView();
            mainView.DataContext = mainViewModel;
            mainView.Show();
        }
    }
}
