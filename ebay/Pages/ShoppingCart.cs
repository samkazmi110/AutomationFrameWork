using AutomationFrameWork.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ebay.Pages
{
    public class ShoppingCart :Driver
    {
        private string _xpathQuantityDropDown;
        private string _xpathPriceLabelCart;
        private string _xpathPriceLabelBeforeShipping;
        private string _xpathPriceLabelAfterShipping;

        public IWebElement QuantityDropDownCart => driver.FindElement(By.XPath(_xpathQuantityDropDown));
        public IWebElement PriceLabelCart => driver.FindElement(By.XPath(_xpathPriceLabelCart));
        public IWebElement PriceLabelBeforeShipping => driver.FindElement(By.XPath(_xpathPriceLabelBeforeShipping));
        public IWebElement PriceLabelAfterShipping => driver.FindElement(By.XPath(_xpathPriceLabelAfterShipping));

        public ShoppingCart() 
        {
            _xpathQuantityDropDown = "//select[@data-test-id='qty-dropdown']";
            _xpathPriceLabelCart = "//div[@class='item-price font-title-3']//span/span";
                _xpathPriceLabelBeforeShipping = "//div[@data-test-id='ITEM_TOTAL']//span/span";
                _xpathPriceLabelAfterShipping = "//div[@data-test-id='SUBTOTAL']//span/span";

        }
    }
}
