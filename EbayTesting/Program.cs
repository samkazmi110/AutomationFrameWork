using OpenQA.Selenium;
using AutomationFrameWork.Helpers;
using AutomationFrameWork.Models;

internal class Program
{
    public static IWebDriver _driver;
    /// <summary>
    /// I will use this console app project to test my webdriver and framework.
    /// will create separate NUnit project for testing later
    /// </summary>
    /// <param name="args"></param>
    private static void Main(string[] args)
    {
               Driver driver = new Driver();

            // read these from App.Config
            _driver =  driver.GetWebDriver(new BrowserModel("Chrome",excludeAutomation:true, incognitoMode:true, startMaximize:true));


            _driver.Navigate().GoToUrl("https://www.ebay.com");
        Console.ReadLine();
        _driver.Quit();
        _driver.Dispose();
    }
}