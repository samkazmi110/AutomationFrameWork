using AutomationFrameWork.Actions;
using AutomationFrameWork.Helpers;
using ebay.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            string TitleFound = string.Empty;
            foreach (var item in ehome.SearchResults)
            {
                if (!string.IsNullOrEmpty(item.Text))
                { 
                    if(ContainsAllWords(item.Text, searchKeyWord))
                    {
                        found = true;
                        result = item;
                        TitleFound = item.Text;
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
                SwitchToPopupWindow(driver.CurrentWindowHandle);
                Assert.IsTrue(ContainsAllWords(driver.Title , TitleFound));

                AdvertisementPage adpage = new AdvertisementPage();
                //select the color if available
                SeleniumAction.SelectElementFromDropDown(adpage.ColorDropDown(), "Gold");

                //select the Quantity
                SeleniumAction.ClearAndSendKeys(adpage.QuantityTxtBox,"1");


                string Price = adpage.PriceLabel.Text.Replace(",","");

                Price = Price.Replace("US $", "");
                //add to cart
                adpage.AddtoCart.Click();

                WaitForPageLoad();

                //Unexpected page handle here
                // checkout as guest?
                //or is sign in then press back and click on cart again
               //    adpage.CheckOutAsGuestORLoginPageBtn();
                //   adpage.AddtoCart.Click();
                //   WaitForPageLoad();

                adpage.GoToCartBtn.Click();

                ShoppingCart shpCart = new ShoppingCart();
                
                Assert.IsTrue(SeleniumAction.SelectedOptionDropDown(shpCart.QuantityDropDownCart) == "1");
                Assert.IsTrue(shpCart.PriceLabelCart.Text == Price);
                Assert.IsTrue(shpCart.PriceLabelBeforeShipping.Text == Price);
                Assert.IsTrue(shpCart.PriceLabelAfterShipping.Text == Price);


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
