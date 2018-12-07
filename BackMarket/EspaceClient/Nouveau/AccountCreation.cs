using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace BackMarket.EspaceClient.Nouveau
{
    public class AccountCreation : AbstractPage
    {
        public void SelectGender()
        {
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("svg.bmico-k-dir-bottom.icon.arrow")));

            var svg = _webDriver.FindElements(By.CssSelector("svg.bmico-k-dir-bottom.icon.arrow"));

            svg.ElementAt(2).Click();
            _webDriver.FindElement(By.CssSelector("div.desktop")).SendKeys(Keys.ArrowDown);
        }

        public void SetLastName()
        {
            wait.Until(ExpectedConditions.ElementExists(By.Id("id_last_name")));
            _webDriver.FindElement(By.Id("id_last_name")).SendKeys(_lastName);
        }

        public void SetFirstName()
        {
            _webDriver.FindElement(By.Id("id_first_name")).SendKeys(_firstName);
        }

        public void SetMail()
        {
            _webDriver.FindElement(By.Id("id_email")).SendKeys(_mail);
        }

        public void SetPassWord()
        {
            var password = _webDriver.FindElements(By.Id("id_password"));
            password.ElementAt(1).SendKeys(_passWord);
        }

        public void SetBirthDay()
        {
            _webDriver.FindElement(By.Id("id_birthdate")).SendKeys(_birthDay);
        }

        public void SelectCountry()
        {
            var Service = _webDriver.FindElement(By.Id("id_country"));
            var selectElement = new SelectElement(Service);
            selectElement.SelectByText(_country);
        }

        public void SubmitSubscription()
        {
            _webDriver.FindElement(By.Id("registration_form_btn")).Click();
        }

        public void CheckConditions()
        {
            _webDriver.FindElement(By.Id("id_gts")).Click();
        }

        public void CheckNewsLetter()
        {
            _webDriver.FindElement(By.Id("id_newsletter")).Click();
        }

        public bool IsRegistrationOk()
        {
            bool _isRegistrationOk = false;

            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div.no-order")));

            try
            {
                _webDriver.FindElement(By.CssSelector("div.a-icon-headerblock.connect")).Text.Contains(_firstName);
                _isRegistrationOk = true;
            }
            catch (Exception e)
            {
                _isRegistrationOk = false;
            }

            return _isRegistrationOk;
        }
    }
}
