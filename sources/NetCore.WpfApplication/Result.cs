namespace NetCore.WpfApplication
{
    public struct Result
    {
        public bool IsSameSynchronizationContext { get; set; }

        public bool IsSameThreadId { get; set; }

        public bool IsSameExecutionContext { get; set; }
        
        public bool IsSameDispatcher { get; set; }
    }
}