using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using static Infrastructure.WebDriverManagement;
using static Infrastructure.Settings;
using static Infrastructure.BasePage;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Infrastructure.Base
{
    public class BaseStep
    {
        public int GetRandomInt()
        {
            Random rnd = new Random();
            return rnd.Next(9999);
        }

        public string GetRandomEmailUsingTableData(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            return data.BaseEmail + "+" + GetRandomInt() + "@" + data.EmailProvider;
        }
    }
}
