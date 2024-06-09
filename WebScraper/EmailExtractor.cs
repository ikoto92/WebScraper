using System.Collections.Generic;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace WebScraper
{
    public static class EmailExtractor
    {
        public static HashSet<string> ExtractEmails(HtmlDocument doc)
        {
            var emails = new HashSet<string>();

            var emailRegex = new Regex(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}");
            var matches = emailRegex.Matches(doc.Text);

            foreach (Match match in matches)
            {
                emails.Add(match.Value);
            }

            return emails;
        }
    }
}
