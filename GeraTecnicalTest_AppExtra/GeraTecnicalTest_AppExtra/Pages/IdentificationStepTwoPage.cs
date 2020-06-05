using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure;
using OpenQA.Selenium;

namespace GeraTecnicalTest_AppExtra.Pages
{
    public class IdentificationStepTwoPage : BasePage
    {
        #region Web Element Mapping
        private IWebElement PessoaFisicaRadioOption()
        {
            return FindElement(By.XPath("//p[@class='pFisica']/label/input"));
        }

        private IWebElement PessoaJuridicaRadioOption()
        {
            return FindElement(By.XPath("//p[@class='pJuridica']/label/input"));
        }

        private IWebElement NomeCompletoInput()
        {
            return FindElement(By.Id("NomeCompleto"));
        }

        private IWebElement EmailInput()
        {
            return FindElement(By.Id("Email"));
        }

        private IWebElement ConfirmarEmailInput()
        {
            return FindElement(By.Id("ConfirmarEmail"));
        }

        private IWebElement DocumentInput()
        {
            return FindElement(By.Id("Cpf"));
        }

        private IWebElement SenhaInput()
        {
            return FindElement(By.Id("Senha"));
        }

        private IWebElement ConfirmarSenhaInput()
        {
            return FindElement(By.Id("ConfirmarSenha"));
        }

        private IWebElement TelefoneTypeDropDown()
        {
            return FindElement(By.Id("TipoFone1"));
        }

        private IWebElement TelefoneDDDInput()
        {
            return FindElement(By.Id("Telefone1DDDPF"));
        }

        private IWebElement TelefoneInput()
        {
            return FindElement(By.Id("Telefone1PF"));
        }

        private IWebElement Telefone2TypeDropDown()
        {
            return FindElement(By.Id("TipoFone2"));
        }

        private IWebElement Telefone2DDDInput()
        {
            return FindElement(By.Id("Telefone2DDDPF"));
        }

        private IWebElement Telefone2Input()
        {
            return FindElement(By.Id("Telefone2PF"));
        }

        private IWebElement DataNascimentoDiaInput()
        {
            return FindElement(By.Id("DataNascimentoDia"));
        }

        private IWebElement DataNascimentoMesInput()
        {
            return FindElement(By.Id("DataNascimentoMes"));
        }

        private IWebElement DataNascimentoAnoInput()
        {
            return FindElement(By.Id("DataNascimentoAno"));
        }

        private IWebElement GeneroMasculinoRadioOption()
        {
            return FindElement(By.XPath("//label[@class='sexoM']/input"));
        }

        private IWebElement GeneroFemininoRadioOption()
        {
            return FindElement(By.XPath("//label[@class='sexoF']/input"));
        }

        private IWebElement ContinuarButton()
        {
            return FindElement(By.Id("btnClienteSalvarComCaptcha"));
        }
        #endregion


        #region Web Element Iteraction

        public void SelectAccountType(string accountType)
        {
            if (accountType.Equals("PessoaFisica"))
            {
                PessoaFisicaRadioOption().Click();
                return;
            }
            PessoaJuridicaRadioOption().Click();
        }

        public void InsertFullName(string fullName)
        {
            NomeCompletoInput().SendKeys(fullName);
        }

        public void InsertEmail(string email)
        {
            EmailInput().Clear();
            EmailInput().SendKeys(email);
        }

        public void InsertEmailConfirmation(string email)
        {
            ConfirmarEmailInput().SendKeys(email);
        }

        public void InsertDocument(string document)
        {
            DocumentInput().SendKeys(document);
        }

        public void SelectPhoneType(string phoneType)
        {
            SelectItemOnDropDownOptionList(TelefoneTypeDropDown(), phoneType);
        }

        public void InsertPhoneDDD(string phoneDDD)
        {
            TelefoneDDDInput().SendKeys(phoneDDD);
        }

        public void InsertPhone(string phone)
        {
            TelefoneInput().SendKeys(phone);
        }

        public void SelectPhone2Type(string phone2Type)
        {
            SelectItemOnDropDownOptionList(Telefone2TypeDropDown(), phone2Type);
        }

        public void InsertPhone2DDD(string phone2DDD)
        {
            Telefone2DDDInput().SendKeys(phone2DDD);
        }

        public void InsertPhone2(string phone2)
        {
            Telefone2Input().SendKeys(phone2);
        }

        public void InsertPass(string pass)
        {
            SenhaInput().SendKeys(pass);
        }

        public void InsertPassConfirmation(string pass)
        {
            ConfirmarSenhaInput().SendKeys(pass);
        }

        public void InsertBirthdateDay(string birthdateDay)
        {
            DataNascimentoDiaInput().SendKeys(birthdateDay);
        }

        public void InsertBirthdateMonth(string birthdateMonth)
        {
            DataNascimentoMesInput().SendKeys(birthdateMonth);
        }

        public void InsertBirthdateYear(string birthdateYear)
        {
            DataNascimentoAnoInput().SendKeys(birthdateYear);
        }

        public void SelectGender(string gender)
        {
            if (gender.Equals("Masculino"))
            {
                GeneroMasculinoRadioOption().Click();
                return;
            }
            GeneroFemininoRadioOption().Click();
        }

        public void ContinueButtonClick()
        {
            ContinuarButton().Click();
        }

        #endregion

        #region Page Behaviors

        public void FullfillAllFormFields(
            string accountType,
            string fullName,
            string email,
            string document,
            string phoneType,
            string phoneDDD,
            string phone,
            string phone2Type,
            string phone2DDD,
            string phone2,
            string pass,
            string birthdateDay,
            string birthdateMonth,
            string birthdateYear,
            string gender)
        {
            SelectAccountType(accountType);
            InsertFullName(fullName);
            InsertEmail(email);
            InsertEmailConfirmation(email);
            InsertDocument(document);
            SelectPhoneType(phoneType);
            InsertPhoneDDD(phoneDDD);
            InsertPhone(phone);
            SelectPhone2Type(phone2Type);
            InsertPhone2DDD(phone2DDD);
            InsertPhone2(phone2);
            InsertPass(pass);
            InsertPassConfirmation(pass);
            InsertBirthdateDay(birthdateDay);
            InsertBirthdateMonth(birthdateMonth);
            InsertBirthdateYear(birthdateYear);
            SelectGender(gender);
        }

        public void ConfirmAccountCreation()
        {
            ContinueButtonClick();
        }


        #endregion
    }
}
