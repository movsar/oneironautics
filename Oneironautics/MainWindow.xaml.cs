using ControlzEx.Theming;
using Data;
using Data.Models;
using MahApps.Metro.Controls;
using MahApps.Metro.Theming;
using Oneironautics.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Oneironautics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            ThemeManager.Current.ChangeTheme(this, "Dark.Olive");
        }

        private void SetCustomTheme()
        {
            ThemeManager.Current.AddLibraryTheme(
               new LibraryTheme(
                   new Uri("pack://application:,,,/DesktopApp;component/Views/CustomLightTheme.xaml"),
                   MahAppsLibraryThemeProvider.DefaultInstance
                   )
               );
        }
    }
}
