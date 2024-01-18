using System;
using CsvHelper;
using HtmlAgilityPack;
using Fizzler.Systems.HtmlAgilityPack;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Drawing;

namespace VallejoColorScraper
{
    class Program
    {
        /*public class Row
        {
            *//*public string Name { get; set; }
            public string ReferenceNum { get; set; }*//*
        }

        public class Paint
        {
            public string Name { get; set; }
            public string Reference { get; set; }
            
            public Paint(string name, string reference)
            {
                Name = name;
                Reference = reference;
            }
        }*/

        static void Main(string[] args)
        {
            var html = @"https://acrylicosvallejo.com/en/category/hobby/game-color-en/";

            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);
            var paintNamesNodeList = htmlDoc.DocumentNode.QuerySelectorAll("h2[class='woocommerce-loop-product__title']");
            var paintReferencesNodeList = htmlDoc.DocumentNode.QuerySelectorAll("div[class='referencia']");
            int count = 0;
            
            Stack<string> paintNameStack = new Stack<string>();
            Stack<string> paintReferenceStack = new Stack<string>();
            Stack<string> combinedStack = new Stack<string>();

            string[] arr = new string[paintNameStack.Count*2];

            //Making a stack from nodelist of color names
            foreach (var item in paintNamesNodeList)
            {
                count++;
                string stringifiedInfo = item.InnerText;
                paintNameStack.Push(stringifiedInfo);
            }

            //Making a stack from nodelist of color reference numbers
            foreach (var item in paintReferencesNodeList)
            {
                string stringifiedInfo = item.InnerText.Trim();
                paintReferenceStack.Push(stringifiedInfo);
            }

            //Combining two stacks so in reference number > name format
            while (paintNameStack.Count > 0 || paintReferenceStack.Count > 0)
            {
                if (paintNameStack.Count > 0)
                { 
                    combinedStack.Push(paintNameStack.Pop());
                }

                if (paintReferenceStack.Count > 0)
                {
                    combinedStack.Push(paintReferenceStack.Pop());
                }
            }

            foreach (var item in combinedStack)
            {
                Console.WriteLine(item);
            }
        }
    }

}
