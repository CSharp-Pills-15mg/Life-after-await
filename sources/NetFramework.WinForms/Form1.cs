using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetFramework.WinForms
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

            Job job = new Job();

            // Before async
            job.SynchronizationContext1 = SynchronizationContext.Current;
            job.ExecutionContext1 = Thread.CurrentThread.ExecutionContext;
            job.ThreadId1 = Thread.CurrentThread.ManagedThreadId;

            // In order to execute correctly we need to restore the context after the await.
            // - Do not call ConfigureAwait(...) method. By default the await keyword will restore the context.
            // - Or call ConfigureAwait(true) to explicitly ask to restore the context.
            await Task.Delay(1000).ConfigureAwait(false);

            // After async
            job.SynchronizationContext2 = SynchronizationContext.Current;
            job.ExecutionContext2 = Thread.CurrentThread.ExecutionContext;
            job.ThreadId2 = Thread.CurrentThread.ManagedThreadId;

            string results = SerializeResults(job);

            try
            {
                textBoxResults.Text = results;
            }
            catch (Exception ex)
            {
                DisplayResult(ex + Environment.NewLine + Environment.NewLine + results);
            }
        }

        public string SerializeResults(Job job)
        {
            StringBuilder sb = new StringBuilder();

            string synchronizationContext1Text = job.SynchronizationContext1?.ToString() ?? "<null>";
            sb.AppendLine($"    - Synchronization context 1: {synchronizationContext1Text}");

            string synchronizationContext2Text = job.SynchronizationContext2?.ToString() ?? "<null>";
            sb.AppendLine($"    - Synchronization context 2: {synchronizationContext2Text}");

            sb.AppendLine($"    - Is same synchronization context: {job.IsSameSynchronizationContext}");

            sb.AppendLine($"    - Thread id 1: {job.ThreadId1}");
            sb.AppendLine($"    - Thread id 2: {job.ThreadId2}");
            sb.AppendLine($"    - Is same thread id: {job.IsSameThreadId}");

            string executionContext1Text = job.ExecutionContext1?.ToString() ?? "<null>";
            sb.AppendLine($"    - Execution context 1: {executionContext1Text}");

            string executionContext2Text = job.ExecutionContext2?.ToString() ?? "<null>";
            sb.AppendLine($"    - Execution context 2: {executionContext2Text}");

            sb.AppendLine($"    - Is same execution context: {job.IsSameExecutionContext}");

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