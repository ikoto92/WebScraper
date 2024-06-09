using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace WebScraper
{
    public static class LinkExtractor
    {
        public static List<string> ExtractLinks(HtmlDocument doc, string baseUrl)
        {
            var links = new List<string>();

            foreach (var link in doc.DocumentNode.SelectNodes("//a[@href]"))
            {
                var href = link.GetAttributeValue("href", string.Empty);

                if (!string.IsNullOrEmpty(href))
                {
                    Uri absoluteUri;
                    if (Uri.TryCreate(new Uri(baseUrl), href, out absoluteUri))
                    {
                        links.Add(absoluteUri.AbsoluteUri);
                    }
                    else
                    {
                        Console.WriteLine($"Unable to create absolute URI for '{href}'");
                    }
                }
            }

            return links;
        }
    }
}
