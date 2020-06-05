using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using static Infrastructure.WebDriverManagement;

namespace Infrastructure
{
    public class BasePage
    {

        public static IWebElement FindElement(By selector)
        {
            try
            {
                return DriverWaiter().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(selector));
            }
            catch (WebDriverTimeoutException)
            {
                return DriverWaiter().Until(drv => drv.FindElement(selector));
            }
        }

        private static WebDriverWait DriverWaiter()
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(Settings.SECONDS_TO_WAIT));
        }

        public static void SelectItemOnDropDownOptionList(IWebElement element, string itemText)
        {
            SelectElement oSelect = new SelectElement(element);
            oSelect.SelectByText(itemText);
        }        
    }
}
