using System.Windows;

using MouseControls.ViewModels;

namespace MouseControls.Views
{
    public partial class MouseControlsView : Window
    {
        public MouseControlsView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MouseControlsPanel.DataContext = new MouseControlsViewModel();
        }
    }
}
