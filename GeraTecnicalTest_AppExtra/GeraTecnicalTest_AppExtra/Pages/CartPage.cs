using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure;
using OpenQA.Selenium;

namespace GeraTecnicalTest_AppExtra.Pages
{
    public class CartPage : BasePage
    {
        public string GetUrl(string userEmail)
        {
            return "https://carrinho.extra.com.br/Checkout?Pagina=cadastrar&ReturnUrl=https://carrinho.extra.com.br&Email=" + userEmail + "#login";
        }

        #region Web Elements Mapping

        public IWebElement EmptyCartMessage()
        {
            return FindElement(By.XPath("//div[@class='innerCart' and descendant::em[text()='Não há produtos em seu carrinho.']"));
        }

        #endregion

        #region Web Elements Iteraction

        #endregion

        #region Page Behaviors

        #endregion
    }
}
