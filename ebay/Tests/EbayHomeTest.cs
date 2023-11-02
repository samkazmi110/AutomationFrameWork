using AutomationFrameWork.Helpers;
using ebay.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ebay.Tests
{
    public class EbayHomeTest : Driver
    {

        [Test]
        public void SearchandAddItemToCart()
        {
            string searchKeyWord = "iphone 14 pro max 128gb";
            EbayHome ehome = new EbayHome();
            driver.Navigate().GoToUrl("https://www.ebay.com");
            ehome.SearchTxtBox.SendKeys(searchKeyWord);
            ehome.SearchSubmitBtn.Click();
            //add page Load
            bool found = false;
            IWebElement result = null;
            foreach (var v in ehome.SearchResults)
            {
                if (!string.IsNullOrEmpty(v.Text))
                { 
                    if(ContainsAllWords(v.Text, searchKeyWord))
                    {
                        found = true;
                        result = v;
                        break; 
                    }
                }
                
            }

            if(!found)
            {
                Assert.Fail($"unable to find '{searchKeyWord}' in searchresult");
            }
            else
            {
                result.Click();
            }
        }

        private bool ContainsAllWords(string Title, string keywords)
        {
            string[] TitleWords = Title.ToLower().Split(new string[] { " ", "-" },StringSplitOptions.RemoveEmptyEntries);
            string[] words = keywords.ToLower().Split(new string[] { " ", "-" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                if (!TitleWords.Contains(word))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
