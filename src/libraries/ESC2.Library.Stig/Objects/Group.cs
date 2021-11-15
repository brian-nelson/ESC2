using System.Collections.Generic;

namespace ESC2.Library.Stig.Objects
{
    public class Group
    {
        public Group()
        {
            Rules = new List<Rule>();
        }

        public string Id { get; set; }
        public string Title { get; set; }

        public List<Rule> Rules { get; set; }
    }
}
