using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using static Infrastructure.Settings;
using static Infrastructure.WebDriverManagement;

namespace GeraTecnicalTest_AppExtra
{
    [Binding]
    public sealed class Hooks
    {

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            GetConfig();
            if (!CLOSE_BROWSER_AFTER_SCENARIO)
            {
                InitDriver();
            }

        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            KillDriver(CLOSE_BROWSER_AFTER_ALL_SCENARIO);
        }
    }
}
