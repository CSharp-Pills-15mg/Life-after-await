using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetCore.WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            _ = Execute();
        }

        private async Task Execute()
        {
            textBoxResults.Text = "Running ...";

            Result result = new Result();

            // Before async
            result.SynchronizationContext1 = SynchronizationContext.Current;
            result.ExecutionContext1 = Thread.CurrentThread.ExecutionContext;
            result.ThreadId1 = Thread.CurrentThread.ManagedThreadId;

            // In order to execute correctly we need to restore the context after the await.
            // - Do not call ConfigureAwait(...) method. By default the await keyword will restore the context.
            // - Or call ConfigureAwait(true) to explicitly ask to restore the context.
            await Task.Delay(1000).ConfigureAwait(true);

            // After async
            result.SynchronizationContext2 = SynchronizationContext.Current;
            result.ExecutionContext2 = Thread.CurrentThread.ExecutionContext;
            result.ThreadId2 = Thread.CurrentThread.ManagedThreadId;

            string results = SerializeResults(result);

            try
            {
                textBoxResults.Text = results;
            }
            catch (Exception ex)
            {
                DisplayResult(ex + Environment.NewLine + Environment.NewLine + results);
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

            return sb.ToString();
        }

        private void DisplayResult(string result)
        {
            if (InvokeRequired)
                Invoke(new DisplayResultDelegate(DisplayResult), result);
            else
                textBoxResults.Text = result;
        }

        private delegate void DisplayResultDelegate(string result);
    }
}