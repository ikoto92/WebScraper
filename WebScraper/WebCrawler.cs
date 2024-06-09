using System;
using System.Collections.Generic;
using System.IO;
using HtmlAgilityPack;

namespace WebScraper
{
    public class WebCrawler
    {
        private int _maxDepth;
        private HashSet<string> _emails;
        private HashSet<string> _visitedUrls;

        public WebCrawler(int maxDepth)
        {
            _maxDepth = maxDepth;
            _emails = new HashSet<string>();
            _visitedUrls = new HashSet<string>();
        }

        public HashSet<string> Crawl(string basePath, string startUrl)
        {
            CrawlPage(basePath, startUrl, 0);
            return _emails;
        }

        private void CrawlPage(string basePath, string url, int currentDepth)
        {
            if (currentDepth > _maxDepth || _visitedUrls.Contains(url))
            {
                return;
            }

            _visitedUrls.Add(url);

            var doc = PageFetcher.LoadHtmlDocument(basePath, url);
            if (doc == null)
            {
                return;
            }

            EmailExtractor.ExtractEmails(doc, _emails);

            if (currentDepth < _maxDepth)
            {
                foreach (var link in LinkExtractor.ExtractLinks(doc))
                {
                    CrawlPage(basePath, link, currentDepth + 1);
                }
            }
        }
    }
}
