namespace ESC2.Library.Stig.Objects
{
    public class Rule
    {
        public string Id { get; set; }
        public double Weight { get; set; }
        public string Severity { get; set; }
        public string Version { get; set; }
        public string Title { get; set; }
        public string Discussion { get; set; }
        public string CCI { get; set; }
        public string Fix { get; set; }
        public string Check { get; set; }
    }
}
