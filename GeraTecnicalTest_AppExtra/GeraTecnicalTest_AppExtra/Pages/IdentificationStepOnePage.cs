using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Infrastructure;
using OpenQA.Selenium;

namespace GeraTecnicalTest_AppExtra.Pages
{
    public class IdentificationStepOnePage : BasePage
    {

        private string url = "https://carrinho.extra.com.br/Checkout?ReturnUrl=//www.extra.com.br#login";

        #region Web Elements Mapping

        private IWebElement EmailInput()
        {
            return FindElement(By.Id("Email"));
        }

        private IWebElement FirstPurchaseRadioOption()
        {
            return FindElement(By.Id("rbNaoCadastrado"));
        }

        private IWebElement ContinuarButton()
        {
            return FindElement(By.Id("btnClienteLogin"));
        }

        private IWebElement ContinuarLink()
        {
            return FindElement(By.Id("btnClienteCadastrar"));
        }

        #endregion

        #region Web Elements Iteraction

        public void InsertEmail(string email)
        {
            EmailInput().SendKeys(email);
        }

        public void SelectFirstPurchaseRadioOption()
        {
            FirstPurchaseRadioOption().Click();
        }

        public void ClickContinuarButton()
        {
            ContinuarButton().Click();
        }

        public void ClickContinuarLink()
        {
            ContinuarLink().Click();
        }


        #endregion

        #region Page Behaviors

        public void IdentifyForFirstPurchase(string email)
        {
            InsertEmail(email);
            SelectFirstPurchaseRadioOption();
        }

        public void ConfirmIdentification()
        {
            try
            {
                ClickContinuarLink();
            }
            catch (Exception)
            {
                ClickContinuarButton();
                throw;
            }
            
        }

        #endregion
    }
}
