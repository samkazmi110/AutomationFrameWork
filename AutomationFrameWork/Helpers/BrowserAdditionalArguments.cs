using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFrameWork.Helpers
{
    public static class BrowserAdditionalArguments
    {

        public static readonly string DisableAutomationControlledFeature = " --disable-blink-features=AutomationControlled";
        public static readonly string DisableNotification = " --disable-notifications";
        public static readonly string DisablePopupBlocking = " --disable-popup-blocking";
        public static readonly string IncognitoMode = " --incognito";
        public static readonly string HeadLess = " --headless";
        public static readonly string StartMaximize = " --start-maximized";
        public static readonly string ExcludeAutomation = "enable-automation";

    }
}
