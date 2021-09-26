using System;
using System.Text;
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

            Job job = new Job(1, 1000);

            // In order to execute correctly we need to restore the context after the await.
            // - Do not call ConfigureAwait(...) method. By default the await keyword will restore the context.
            // - Or call ConfigureAwait(true) to explicitly ask to restore the context.
            await job.ExecuteAsync().ConfigureAwait(true);

            try
            {
                textBoxResults.Text = SerializeResults(job);
            }
            catch (Exception ex)
            {
                DisplayResult(ex.ToString());
            }
        }

        public string SerializeResults(Job job)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Job {job.Id}");
            sb.AppendLine($"    - Execution time: {job.MillisecondsDelay}");

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