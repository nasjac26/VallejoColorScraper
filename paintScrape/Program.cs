using System;
using CsvHelper;
using HtmlAgilityPack;
using Fizzler.Systems.HtmlAgilityPack;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

namespace VallejoColorScraper
{
    class Program
    {   
        public class Row
        {
/*            public string Title { get; set; }
*/        }
        static void Main(string[] args)
        {
            var html = @"https://acrylicosvallejo.com/en/category/hobby/game-color-en/";

            HtmlWeb web = new HtmlWeb();
            //targeting first paint color element name
            var htmlDoc = web.Load(html);
            var node = htmlDoc.DocumentNode.QuerySelector("h2[class='woocommerce-loop-product__title']");

            Console.WriteLine(node.InnerText);
        }
    }

}
