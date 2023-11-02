using AutomationFrameWork.Helpers;
using OpenQA.Selenium;

namespace ebay.Pages
{
    public class AdvertisementPage : Driver
    {
        private string _xpathColorSelectionDropDown;
        private string _xpathQuantityTxtBox;
        private string _xpathPriceLabel;
        private string _xpathAddtoCartBtn;
        private string _xpathGoToCartButton;
        private string _xpathCheckOutAsGuestBtn;

        public IWebElement AddtoCart => driver.FindElement(By.XPath(_xpathAddtoCartBtn));
        public IWebElement QuantityTxtBox => driver.FindElement(By.XPath(_xpathQuantityTxtBox));
        public IWebElement PriceLabel => driver.FindElement(By.XPath(_xpathPriceLabel));
        public IWebElement GoToCartBtn => driver.FindElement(By.XPath(_xpathGoToCartButton));

        /// <summary>
        /// some of the item doesnot have color choice
        /// </summary>
        /// <returns></returns>
        public IWebElement ColorDropDown()
        {
            try
            {
                return driver.FindElement(By.XPath(_xpathColorSelectionDropDown));
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// some times checkout as guest btn appears
        /// </summary>
        /// <returns></returns>
        public void CheckOutAsGuestORLoginPageBtn()
        {
            try
            {
                driver.FindElement(By.XPath(_xpathCheckOutAsGuestBtn)).Click();
            }
            catch
            {
                //if Login page do nothing
            }
            finally
            {
                WaitForPageLoad();
                //press back
                driver.Navigate().Back();
                WaitForPageLoad();
               
            }
        }

        public AdvertisementPage() 
        {
            _xpathColorSelectionDropDown = "//select[@id='x-msku__select-box-1000']";
            _xpathQuantityTxtBox = "//input[@id='qtyTextBox']";
            _xpathPriceLabel = "//div[@data-testid='x-price-primary']/span";
            _xpathAddtoCartBtn = "//a[@data-testid='ux-call-to-action']//span[text()='Add to cart']";
            _xpathGoToCartButton = "//div[@class='ux-overlay__content']//span[text()='Go to cart']";
            _xpathCheckOutAsGuestBtn = "//a[@data-testid'ux-call-to-action']";


        }
    }
}
