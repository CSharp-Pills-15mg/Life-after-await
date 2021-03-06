// C# Pills 15mg
// Copyright (C) 2021 Dust in the Wind
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

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
            _ = Execute();
        }

        private async Task Execute()
        {
            TextBoxResults.Text = "Running ...";

            Result result = new Result();

            // Before async
            result.SynchronizationContext1 = SynchronizationContext.Current;
            result.ExecutionContext1 = Thread.CurrentThread.ExecutionContext;
            result.ThreadId1 = Thread.CurrentThread.ManagedThreadId;
            result.Dispatcher1 = Dispatcher.CurrentDispatcher;

            // In order to execute correctly we need to restore the context after the await.
            // - Do not call ConfigureAwait(...) method. By default the await keyword will restore the context.
            // - Or call ConfigureAwait(true) to explicitly ask to restore the context.
            await Task.Delay(1000).ConfigureAwait(false);

            // After async
            result.SynchronizationContext2 = SynchronizationContext.Current;
            result.ExecutionContext2 = Thread.CurrentThread.ExecutionContext;
            result.ThreadId2 = Thread.CurrentThread.ManagedThreadId;
            result.Dispatcher2 = Dispatcher.CurrentDispatcher;

            string serializedResult = SerializeResults(result);

            try
            {
                TextBoxResults.Text = serializedResult;
            }
            catch (Exception ex)
            {
                DisplayResult(ex + Environment.NewLine + Environment.NewLine + serializedResult);
            }
        }

        public string SerializeResults(Result result)
        {
            StringBuilder sb = new StringBuilder();

            string synchronizationContext1Text = result.SynchronizationContext1?.ToString() ?? "<null>";
            sb.AppendLine($"    - Synchronization context 1: {synchronizationContext1Text}");

            string synchronizationContext2Text = result.SynchronizationContext2?.ToString() ?? "<null>";
            sb.AppendLine($"    - Synchronization context 2: {synchronizationContext2Text}");

            sb.AppendLine($"    - Is same synchronization context: {result.IsSameSynchronizationContext}");

            sb.AppendLine($"    - Thread id 1: {result.ThreadId1}");
            sb.AppendLine($"    - Thread id 2: {result.ThreadId2}");
            sb.AppendLine($"    - Is same thread id: {result.IsSameThreadId}");

            string executionContext1Text = result.ExecutionContext1?.ToString() ?? "<null>";
            sb.AppendLine($"    - Execution context 1: {executionContext1Text}");

            string executionContext2Text = result.ExecutionContext2?.ToString() ?? "<null>";
            sb.AppendLine($"    - Execution context 2: {executionContext2Text}");

            sb.AppendLine($"    - Is same execution context: {result.IsSameExecutionContext}");

            string dispatcher1Text = result.Dispatcher1?.ToString() ?? "<null>";
            sb.AppendLine($"    - Dispatcher 1: {dispatcher1Text}");

            string dispatcher2Text = result.Dispatcher2?.ToString() ?? "<null>";
            sb.AppendLine($"    - Dispatcher 2: {dispatcher2Text}");

            sb.AppendLine($"    - Is same dispatcher: {result.IsSameDispatcher}");

            return sb.ToString();
        }

        private void DisplayResult(string result)
        {
            Dispatcher.Invoke(() =>
            {
                TextBoxResults.Text = result;
            });
        }
    }
}