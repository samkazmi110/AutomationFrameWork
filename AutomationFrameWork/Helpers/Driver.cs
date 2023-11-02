using AutomationFrameWork.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFrameWork.Helpers
{
    public class Driver
    {
        public static IWebDriver driver { get; set; }

        public IWebDriver GetWebDriver (BrowserModel browser) {
            switch (Enum.Parse(typeof(BrowserType), browser.BrowserName))
            {

                case BrowserType.Chrome:
                    driver = new ChromeDriver(AddChromeOptions(browser));
                    break;
                default:
                    throw new NotImplementedException($"Browser Type: {browser.BrowserName} is not Implemented");
            }
        
            return driver;
        
        }

        private ChromeOptions AddChromeOptions(BrowserModel browser)
        { 
            ChromeOptions _chromeOption= new ChromeOptions();
            
            if(browser.DisableAutomationControlledFeature)
               _chromeOption.AddArgument(BrowserAdditionalArguments.DisableAutomationControlledFeature);
            
            if(browser.DisableNotification)
                _chromeOption.AddArgument(BrowserAdditionalArguments.DisableNotification);
            
            if (browser.DisablePopupBlocking)
                _chromeOption.AddArgument(BrowserAdditionalArguments.DisablePopupBlocking);
            
            if (browser.IncognitoMode)
                _chromeOption.AddArgument(BrowserAdditionalArguments.IncognitoMode);
            
            if (browser.HeadLess)
                _chromeOption.AddArgument(BrowserAdditionalArguments.HeadLess);
            
            if (browser.StartMaximize)
                _chromeOption.AddArgument(BrowserAdditionalArguments.StartMaximize);
            
            if(browser.ExcludeAutomation)
                _chromeOption.AddExcludedArgument(BrowserAdditionalArguments.ExcludeAutomation);

            return _chromeOption;
        }


      

        public void SwitchToPopupWindow(string existingWindowHandle)
        {
            string popupHandle = string.Empty;

            ReadOnlyCollection<string> windowHandles = driver.WindowHandles;

            foreach (string handle in windowHandles)
            {
                if (handle != existingWindowHandle)
                {
                    popupHandle = handle;
                    break;
                }
            }

            if (!string.IsNullOrEmpty(popupHandle))
            {
                driver.SwitchTo().Window(popupHandle);
            }
            else
            {
                throw new Exception("Popup window not found");
            }
        }

        public void WaitForPageLoad()
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            try {
                // Wait for document.readyState to be 'complete'
                wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));

                // Optional: Add a wait for document load event
                wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("interactive"));
            }
            catch
            {

            }
         }

    }
}

