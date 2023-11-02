using AutomationFrameWork.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFrameWork.Helpers
{
    public class TestSetup :Driver
    {
        public static string URL;
        public static string BrowserName;
        public static string searchKeyWord;
        public static string color;
        public static string quantity;

        [OneTimeSetUp]
        public void Init()
        {
            URL = "https://www.ebay.com";
            BrowserName = "Chrome";
            searchKeyWord = "iphone 14 pro max 128gb";
            color = "Gold";
            quantity = "1";
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
