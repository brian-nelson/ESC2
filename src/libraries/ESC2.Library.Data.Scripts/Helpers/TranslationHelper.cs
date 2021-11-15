using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESC2.Library.Stig.Objects;

namespace ESC2.Library.Data.Scripts.Helpers
{
    public static class TranslationHelper
    {
        public static string GetVersionStatusCode(string status)
        {
            if (status.Equals("accepted", StringComparison.InvariantCultureIgnoreCase))
            {
                return "A";
            }

            if (status.Equals("deprecated", StringComparison.InvariantCultureIgnoreCase))
            {
                return "DP";
            }

            if (status.Equals("draft", StringComparison.InvariantCultureIgnoreCase))
            {
                return "DR";
            }

            if (status.Equals("incomplete", StringComparison.InvariantCultureIgnoreCase))
            {
                return "IC";
            }

            if (status.Equals("interim", StringComparison.InvariantCultureIgnoreCase))
            {
                return "IN";
            }

            throw new Exception("Unknown version status");
        }

        public static string GetRuleSeverity(string severity)
        {
            if (severity.Equals("high", StringComparison.InvariantCultureIgnoreCase))
            {
                return "H";
            }

            if (severity.Equals("medium", StringComparison.InvariantCultureIgnoreCase))
            {
                return "M";
            }

            if (severity.Equals("low", StringComparison.InvariantCultureIgnoreCase))
            {
                return "L";
            }

            throw new Exception("Unknown version status");
        }
    }
}
