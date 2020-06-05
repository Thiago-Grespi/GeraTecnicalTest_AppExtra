

using Infrastructure;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using static Infrastructure.Settings;

namespace Infrastructure
{
    public class WebDriverManagement
    {
        public static IWebDriver driver { get; private set; }

        public static void Navigate(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public static void InitDriver()
        {
            if (driver == null)
            {
                IWebDriver initialDriver;

                switch (BROWSER)
                {
                    case Enums.Browsers.FIREFOX:
                        initialDriver = new FirefoxDriver();
                        break;
                    default:
                        initialDriver = new ChromeDriver(EXECUTION_PATH + @"\Driver");
                        break;
                }
                driver = initialDriver;
                MaximizeBrowserWindow();
            }
        }

        public static void KillDriver(bool browser_close_validation)
        {
            if (driver != null)
            {
                if (browser_close_validation)
                {
                    driver.Dispose();
                    driver = null;
                }
            }
        }

        public static void MaximizeBrowserWindow()
        {
            driver.Manage().Window.Maximize();
        }

    }
}
