using AutomationFrameWork.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFrameWork.Actions
{
    public class SeleniumAction : Driver
    {
        public static void SelectElementFromDropDown(IWebElement dropdown, string value)
        {
            if (dropdown != null)
            {
                //check if the option we need to select is enabled
                bool enabled = false;
                IReadOnlyCollection<IWebElement> options = dropdown.FindElements(By.TagName("option"));
                foreach (IWebElement option in options)
                {
                    if (option.Text == value)
                    {
                        string enabledValue = option.GetAttribute("disabled");
                        if (string.IsNullOrEmpty(enabledValue))
                        {
                            enabled = true;
                            break;
                        }
                    }
                    if (!enabled)
                        Assert.Fail($"value {value} is disabled in dropdown");

                    SelectElement element = new SelectElement(dropdown);
                    element.SelectByText(value);
                }

            }
        }

        public static void ClearAndSendKeys(IWebElement TextboxElement, string value)
        {
            if(TextboxElement!=null)
            {
                TextboxElement.Clear();
                TextboxElement.SendKeys(value);
            }
        }
        public string SelectedOptionDropDown()
        {
            return string.Empty;
        }
    }
}

