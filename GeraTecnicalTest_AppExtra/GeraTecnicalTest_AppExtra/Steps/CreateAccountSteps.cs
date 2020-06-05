using static Infrastructure.WebDriverManagement;
using static Infrastructure.Settings;
using Infrastructure.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using TechTalk.SpecFlow;
using GeraTecnicalTest_AppExtra.Pages;
using static Infrastructure.Base.BaseStep;
using System.Threading;
using TechTalk.SpecFlow.Assist;
using NUnit.Framework;

namespace GeraTecnicalTest_AppExtra.Steps
{

    [Binding]
    public sealed class CreateAccountSteps : BaseStep
    {
        IdentificationStepOnePage _identificationStepOnePage = null;
        IdentificationStepTwoPage _identificationStepTwoPage = null;
        CartPage _cartPage = null;

        [BeforeScenario]
        public void ScenarioSetUp()
        {
            _identificationStepOnePage = new IdentificationStepOnePage();
            _identificationStepTwoPage = new IdentificationStepTwoPage();
            _cartPage = new CartPage();
        }

        [Given(@"I accessed the identification page")]
        public void GivenIAccessedTheIdentificationPage()
        {
            Navigate("https://carrinho.extra.com.br/Checkout?ReturnUrl=//www.extra.com.br#login");
        }

        [When(@"I identify myself for my first purchase")]
        public void WhenIIdentifyMyselfForMyFirstPurchase(Table table)
        {
            dynamic data = table.CreateDynamicInstance(); //Colocar no Before Step
            ScenarioContext.Current.Add("UserEmail", GetRandomEmailUsingTableData(table));
            _identificationStepOnePage.IdentifyForFirstPurchase(ScenarioContext.Current["UserEmail"].ToString());
        }

        [When(@"I click the Continuar button")]
        public void WhenIClickTheContinuarButton()
        {
            _identificationStepOnePage.ConfirmIdentification();
        }

        [When(@"I access the second step to create my account")]
        public void WhenIAccessTheSecondStepToCreateMyAccount()
        {
            Navigate(_cartPage.GetUrl(ScenarioContext.Current["UserEmail"].ToString()));
        }


        [When(@"fill all the information to create my account")]
        public void WhenFillAllTheInformationToCreateMyAccount(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _identificationStepTwoPage.FullfillAllFormFields(
                data.AccountType.ToString(),
                data.FullName.ToString(),
                ScenarioContext.Current["UserEmail"].ToString(),
                data.Document.ToString(),
                data.PhoneType.ToString(),
                data.PhoneDDD.ToString(),
                data.Phone.ToString(),
                data.Phone2Type.ToString(),
                data.Phone2DDD.ToString(),
                data.Phone2.ToString(),
                data.Pass.ToString(),
                data.BirthdateDay.ToString(),
                data.BirthdateMonth.ToString(),
                data.BirthdateYear.ToString(),
                data.Gender.ToString());
        }

        [When(@"click the Continuar button")]
        public void WhenClickTheContinuarButton()
        {
            _identificationStepTwoPage.ConfirmAccountCreation();
        }

        [Then(@"the Cart page should be displayed with no items on it")]
        public void ThenTheCartPageShouldBeDisplayedWithNoItemsOnIt()
        {
            Assert.AreEqual(_cartPage.GetUrl(ScenarioContext.Current["UserEmail"].ToString()), driver.Url, "URL incorreta");
            Assert.IsTrue(_cartPage.EmptyCartMessage().Displayed, "Mensagem de Carrinho Vazio não foi exibida");
            
        }
    }
}
