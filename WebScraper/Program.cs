using System;
using System.Collections.Generic;

namespace WebScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            string startUrl = "file:///D:/Web/index.html"; // URL de départ
            int maxDepth = 2; // Profondeur maximale de recherche

            WebCrawler crawler = new WebCrawler(maxDepth);
            var emails = crawler.Crawl(startUrl);

            Console.WriteLine("Emails trouvés :");
            foreach (var email in emails)
            {
                Console.WriteLine(email);
            }
        }
    }
}
