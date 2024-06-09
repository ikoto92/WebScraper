using System;
using System.Collections.Generic;
using System.IO;
using HtmlAgilityPack;

namespace WebScraper
{
    public class WebCrawler
    {
        private int _maxDepth;
        private HashSet<string> _visitedUrls;
        private HashSet<string> _emails; // Ajouter un HashSet pour stocker les e-mails

        public WebCrawler(int maxDepth)
        {
            _maxDepth = maxDepth;
            _visitedUrls = new HashSet<string>();
            _emails = new HashSet<string>(); // Initialiser le HashSet pour les e-mails
        }

        public HashSet<string> Crawl(string startUrl)
        {
            CrawlPage(startUrl, 0);
            return _emails; // Retourner les e-mails récupérés
        }

        private void CrawlPage(string url, int currentDepth)
        {
            if (currentDepth > _maxDepth || _visitedUrls.Contains(url))
            {
                return;
            }

            var doc = PageFetcher.LoadHtmlDocument(url);
            if (doc == null)
            {
                return;
            }

            _visitedUrls.Add(url);

            // Extraire les e-mails de la page actuelle
            _emails.UnionWith(EmailExtractor.ExtractEmails(doc));

            if (currentDepth < _maxDepth)
            {
                foreach (var link in LinkExtractor.ExtractLinks(doc, url))
                {
                    CrawlPage(link, currentDepth + 1);
                }
            }
        }
    }
}
