using System.Collections.Generic;
using HtmlAgilityPack;

namespace WebScraper
{
    public static class LinkExtractor
    {
        public static List<string> ExtractLinks(HtmlDocument doc)
        {
            var links = new List<string>();

            foreach (var link in doc.DocumentNode.SelectNodes("//a[@href]"))
            {
                var href = link.GetAttributeValue("href", string.Empty);

                if (Uri.IsWellFormedUriString(href, UriKind.Relative))
                {
                    links.Add(href);
                }
            }

            return links;
        }
    }
}
