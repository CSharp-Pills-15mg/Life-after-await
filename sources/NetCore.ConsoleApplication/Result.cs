namespace NetCore.ConsoleApplication
{
    public struct Result
    {
        public bool IsSameSynchronizationContext { get; set; }

        public bool IsSameThreadId { get; set; }

        public bool IsSameContext { get; set; }
    }
}