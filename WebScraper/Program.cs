using System;
using System.Collections.Generic;

namespace WebScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            string startUrl = "child1.html"; // URL de départ
            int maxDepth = 10; // Profondeur maximale de recherche

            WebCrawler crawler = new WebCrawler(maxDepth);
            var emails = crawler.Crawl("C:/TestHtml/", startUrl);

            Console.WriteLine("Emails trouvés :");
            foreach (var email in emails)
            {
                Console.WriteLine(email);
            }
        }
    }
}
