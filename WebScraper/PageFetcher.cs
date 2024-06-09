using System.IO;
using HtmlAgilityPack;

namespace WebScraper
{
    public static class PageFetcher
    {
        public static HtmlDocument LoadHtmlDocument(string url)
        {
            var doc = new HtmlDocument();
            string filePath = new Uri(url).LocalPath;

            if (!File.Exists(filePath))
            {
                return null;
            }

            doc.Load(filePath);
            return doc;
        }
    }
}
