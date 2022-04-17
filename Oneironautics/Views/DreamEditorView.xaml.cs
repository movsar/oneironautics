using ControlzEx.Theming;
using Data.Models;
using DesktopApp.Models;
using DesktopApp.Stores;
using MahApps.Metro.Controls;
using Oneironautics.Stores;
using Oneironautics.ViewModels;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Oneironautics.Views
{
    /// <summary>
    /// Interaction logic for DreamEditor.xaml
    /// </summary>
    public partial class DreamEditorView : MetroWindow
    {
        public DreamEditorView(NavigationStore navigationStore, JournalStore journalStore, IDream? dream = null)
        {
            InitializeComponent();
            ThemeManager.Current.ChangeTheme(this, "Dark.Olive");
            WindowActions windowActions = new WindowActions(() => { this.Close(); });
            DataContext = new DreamEditorViewModel(navigationStore, journalStore, windowActions, dream);
        }
    }
}
