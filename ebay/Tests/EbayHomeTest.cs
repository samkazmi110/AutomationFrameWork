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
    public class EbayHomeTest : TestSetup
    {

        [Test]
        public void SearchandAddItemToCart()
        {

            bool found = false;
            IWebElement result = null;
            string TitleFound = string.Empty;


            EbayHome ehome = new EbayHome();
            driver.Navigate().GoToUrl(URL);
            ehome.SearchTxtBox.SendKeys(searchKeyWord);
            ehome.SearchSubmitBtn.Click();
           
            
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
                SeleniumAction.SelectElementFromDropDown(adpage.ColorDropDown(), color);

                //select the Quantity
                SeleniumAction.ClearAndSendKeys(adpage.QuantityTxtBox,quantity);


                string Price = adpage.PriceLabel.Text.Replace(",","");

                Price = Price.Replace("US $", "");
                //add to cart
                adpage.AddtoCart.Click();
                WaitForPageLoad();

                adpage.GoToCartBtn.Click();

                ShoppingCart shpCart = new ShoppingCart();
                
                Assert.IsTrue(SeleniumAction.SelectedOptionDropDown(shpCart.QuantityDropDownCart) == quantity);
                Assert.IsTrue(shpCart.PriceLabelCart.Text.Replace("$","") == Price, $"Price mismatch on cart expected:{Price} actual: {shpCart.PriceLabelCart.Text.Replace("$", "")}");
                Assert.IsTrue(shpCart.PriceLabelBeforeShipping.Text.Replace("$", "") == Price, $"Price mismatch on cart expected:{Price} actual: {shpCart.PriceLabelBeforeShipping.Text.Replace("$", "")}");
                Assert.IsTrue(shpCart.PriceLabelAfterShipping.Text.Replace("$", "") == Price, $"Price mismatch on cart expected:{Price} actual: {shpCart.PriceLabelAfterShipping.Text.Replace("$", "")}");


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
