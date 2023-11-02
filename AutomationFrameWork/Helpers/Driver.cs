using AutomationFrameWork.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
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


        [SetUp]
        public void InitializeTest()
        {
            driver = GetWebDriver(new BrowserModel("Chrome", excludeAutomation: true, incognitoMode: true, startMaximize: true));

        }

        [TearDown]
        public void CloseTest()
        {
            driver.Quit();
        }
    }
}
