using System;
using System.Text;
using System.Threading;
using System.Windows;

namespace NetFramework.WpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            // Display SynchronizationContext's type

            Type synchronizationContextType = SynchronizationContext.Current?.GetType();
            sb.AppendLine("Synchronization Context Type: " + (synchronizationContextType?.FullName ?? " < null>"));

            // Display results

            TextBoxResults.Text = sb.ToString();
        }
    }
}