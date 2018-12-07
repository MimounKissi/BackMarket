using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackMarket
{
    public class DetailsAccount : AbstractPage
    {
        public void SetMail(string _mail)
        {
            wait.Until(ExpectedConditions.ElementExists(By.Name("email")));
            _webDriver.FindElement(By.Name("email")).SendKeys(_mail); 
        }

        public void SetFirstName(string _firstName)
        {
            wait.Until(ExpectedConditions.ElementExists(By.Name("first_name")));
            _webDriver.FindElement(By.Name("first_name")).SendKeys(_firstName);
        }

        public void SetLastName(string _lastName)
        {
            _webDriver.FindElement(By.Name("last_name")).SendKeys(_lastName);
        }

        public void SetPassword(string _password)
        {
            _webDriver.FindElement(By.Name("password")).SendKeys(_password);
        }

        public void PressContinue()
        {
            _webDriver.FindElement(By.CssSelector("button.a-button.primary")).Click();
        }

        public void AcceptConditions()
        {
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("label")));
            var conditions = _webDriver.FindElements(By.CssSelector("label"));
            conditions.ElementAt(4).Click();
            conditions.ElementAt(5).Click();
        }

        public void PressEnter()
        {
            // To Do
        }
    }
}
