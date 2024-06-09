using System.IO;
using HtmlAgilityPack;

namespace WebScraper
{
    public static class PageFetcher
    {
        public static HtmlDocument LoadHtmlDocument(string basePath, string url)
        {
            var doc = new HtmlDocument();
            var filePath = Path.Combine(basePath, url);

            if (!File.Exists(filePath))
            {
                return null;
            }

            doc.Load(filePath);
            return doc;
        }
    }
}
