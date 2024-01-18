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
            public string Name { get; set; }
/*            public string ReferenceNum { get; set; }
*/        }
        static void Main(string[] args)
        {
            var html = @"https://acrylicosvallejo.com/en/category/hobby/game-color-en/";

            HtmlWeb web = new HtmlWeb();
            //targeting first paint color element name
            var htmlDoc = web.Load(html);
            var paintNamesNodeList = htmlDoc.DocumentNode.QuerySelectorAll("h2[class='woocommerce-loop-product__title']");
            var paintReferencesNodeList = htmlDoc.DocumentNode.QuerySelectorAll("div[class='referencia']");

            string[] p
            foreach (var paintName in paintNames)
                {
                    Console.WriteLine(paintName.InnerText);
                }

            foreach (var paintReference in paintReferences)
            {
                Console.WriteLine(paintReference.InnerText);
            }
        }
    }

}
