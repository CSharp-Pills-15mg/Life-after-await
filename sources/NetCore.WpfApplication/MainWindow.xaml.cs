using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace NetCore.WpfApplication
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

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            // Display SynchronizationContext's type

            Type synchronizationContextType = SynchronizationContext.Current?.GetType();
            sb.AppendLine("Synchronization Context Type: " + (synchronizationContextType?.FullName ?? " < null>"));

            //await Task.Delay(1000).ConfigureAwait(true);

            //TextBoxResults.Text = "asd";

            Task<Result>[] tasks = Enumerable.Range(1, 100)
                .Select(Something.DoSomething)
                .ToArray();

            foreach (Task<Result> task in tasks)
                await task;
            //Task.WaitAll(tasks);

            List<Result> results = tasks
                .Select(x => x.Result)
                .ToList();

            sb.AppendLine("Count: " + results.Count);
            sb.AppendLine("Is same synchronization context: " + results.All(x => x.IsSameSynchronizationContext));
            sb.AppendLine("Is same thread id: " + results.All(x => x.IsSameThreadId));
            sb.AppendLine("Is same execution context: " + results.All(x => x.IsSameExecutionContext));
            sb.AppendLine("Is same dispatcher: " + results.All(x => x.IsSameDispatcher));

            TextBoxResults.Text += sb.ToString();
        }
    }
}