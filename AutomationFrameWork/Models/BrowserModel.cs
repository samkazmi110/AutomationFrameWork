namespace AutomationFrameWork.Models
{
    public class BrowserModel
    {
        /// <summary>
        /// Setting Default Value To Chrome
        /// </summary>
        public string BrowserName { get; set; } 

        /// <summary>
        /// Addition Additional switches and Capabilities for Chrome
        /// To avoid being detected using Automation/Selenium
        /// otherwise they will send captcha request more often
        /// or sometimes ban IP
        /// </summary>
        public bool DisableAutomationControlledFeature;
        public bool DisableNotification;
        public bool DisablePopupBlocking;
        public bool IncognitoMode;
        public bool HeadLess;
        public bool StartMaximize;
        public bool ExcludeAutomation;
        
        public BrowserModel(string browserName, bool disableAutomationControlledFeature = false, bool disableNotification = false, bool disablePopupBlocking = false, bool incognitoMode = false, bool headLess = false, bool startMaximize = false, bool excludeAutomation = false) 
        {
            BrowserName = browserName;
            DisableAutomationControlledFeature = disableAutomationControlledFeature;
            DisableNotification = disableNotification;
            DisablePopupBlocking = disablePopupBlocking;
            IncognitoMode = incognitoMode;
            HeadLess = headLess;
            StartMaximize = startMaximize;
            ExcludeAutomation = excludeAutomation;
        }
    }
}
