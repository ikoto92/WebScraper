using System.Collections.Generic;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace WebScraper
{
    public static class EmailExtractor
    {
        public static void ExtractEmails(HtmlDocument doc, HashSet<string> emails)
        {
            var emailRegex = new Regex(@"mailto:(?<email>[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,})", RegexOptions.IgnoreCase);

            foreach (var link in doc.DocumentNode.SelectNodes("//a[@href]"))
            {
                var href = link.GetAttributeValue("href", string.Empty);
                var match = emailRegex.Match(href);

                if (match.Success)
                {
                    emails.Add(match.Groups["email"].Value);
                }
            }
        }
    }
}
