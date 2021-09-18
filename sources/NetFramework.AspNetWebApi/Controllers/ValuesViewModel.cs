namespace NetFramework.AspNetWebApi.Controllers
{
    public class ValuesViewModel
    {
        public string SynchronizationContextType { get; set; }
        public int ThreadId1 { get; set; }
        public int ThreadId2 { get; set; }
        public string CurrentCulture1 { get; set; }
        public string CurrentCulture2 { get; set; }
        public bool HttpContextExists1 { get; set; }
        public bool HttpContextExists2 { get; set; }
        public bool IsSameHttpContext { get; set; }
    }
}