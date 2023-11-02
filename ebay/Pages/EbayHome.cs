using AutomationFrameWork.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ebay.Pages
{
    public class EbayHome : Driver
    {
        private string _xpathTxtBoxSearchBar;
        private string _xpathBtnSearchSubmit;
        private string _xpathSearchContent;
        public IWebElement SearchTxtBox => driver.FindElement(By.XPath(_xpathTxtBoxSearchBar));
        public IWebElement SearchSubmitBtn => driver.FindElement(By.XPath(_xpathBtnSearchSubmit));
        public IWebElement SearchResultContents => driver.FindElement(By.XPath(_xpathSearchContent));
       
        public IWebElement[] SearchResults =>driver.FindElements(By.XPath("//div[@id='mainContent']//li[contains(@class,'s-item s-item__pl-on-bottom')]//a/div/span")).ToArray();
        public EbayHome() 
        {
            _xpathTxtBoxSearchBar = "//input[@id='gh-ac']";
            _xpathBtnSearchSubmit = "//input[@id='gh-btn']";
            _xpathSearchContent = "//div[@id='mainContent']";
        }
    }
}
