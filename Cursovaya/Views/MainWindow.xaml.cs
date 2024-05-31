using System.Windows;
using Cursovaya.Model;
using Cursovaya.ViewModel;
using Cursovaya;
using Cursovaya.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Cursovaya.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindowLoaded;
        }

        private void MainWindowLoaded(object sender, RoutedEventArgs e)
        {
            DataContext = DIContainer.GetService<MainWindowVM>();
        }
    }
}