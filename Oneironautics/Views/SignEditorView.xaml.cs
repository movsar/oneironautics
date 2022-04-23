using Data.Interfaces;
using DesktopApp.Models;
using DesktopApp.Stores;
using DesktopApp.ViewModels;
using MahApps.Metro.Controls;
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

namespace DesktopApp.Views
{
    /// <summary>
    /// Interaction logic for SignEditView.xaml
    /// </summary>
    public partial class SignEditorView : MetroWindow
    {
        public SignEditorView(JournalStore journalStore, ISign? sign= null)
        {
            InitializeComponent();
            DataContext = new SignEditorViewModel(journalStore, sign);
        }
    }
}
