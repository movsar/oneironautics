using ControlzEx.Theming;
using MahApps.Metro.Controls;
using System.Windows.Input;

namespace DesktopApp.Views
{
    /// <summary>
    /// Interaction logic for DreamListingView.xaml
    /// </summary>
    public partial class DreamListingView : MetroWindow
    {
        public DreamListingView()
        {
            InitializeComponent();
            ThemeManager.Current.ChangeTheme(this, "Dark.Olive");

            // Move focus from window to the view
            Loaded += (sender, e) => MoveFocus(new TraversalRequest(FocusNavigationDirection.Last));
        }
    }
}
