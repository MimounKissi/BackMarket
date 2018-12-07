

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace BackMarket.EspaceClient.Client
{
    public class Connection : AbstractPage
    {
        public void SetIdUsername()
        {
            wait.Until(ExpectedConditions.ElementExists(By.Id("id_username")));
            _webDriver.FindElement(By.Id("id_username")).SendKeys(_idUserName); 
        }

        public void SetPassWord()
        {
            _webDriver.FindElement(By.Id("id_password")).SendKeys(_passWord);
        }

        public void Submit()
        {
            _webDriver.FindElement(By.CssSelector("button.a-button.primary")).Click();
        }

        public void PassWordReset()
        {
            _webDriver.FindElement(By.CssSelector("a.pull-left")).Click();
        }


        public void ClickPassWordReset()
        {
            _webDriver.FindElement(By.CssSelector("button.btn.btn-default.pull-right")).Click();
        }

        public bool ValidMsgResetPassWord()
        {
            string _validMsg = "";
            bool _validMsgIsOk = false;

            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div.alert.alert-success")));
            _validMsg = _webDriver.FindElement(By.CssSelector("div.alert.alert-success")).Text;

            _validMsgIsOk = (_validMsg == "Vous allez recevoir un mail à l'adresse " + _idUserName + " vous permettant de changer votre mot de passe.") ? true : false;

            return _validMsgIsOk;
        }


        public bool ErrorMsgConnection()
        {
            string _errorMsg = "";
            bool _errorMsgIsOk = false;

            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div.alert.alert-danger")));
            _errorMsg = _webDriver.FindElement(By.CssSelector("div.alert.alert-danger")).Text;

            _errorMsgIsOk  = (_errorMsg == "Mauvaise combinaison email/mot de passe") ? true : false;

            return _errorMsgIsOk; 
        }

        public bool IsConnectionOk()
        {
            bool _isConnectionOk = false;

            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div.no-order")));

            try
            {
                _webDriver.FindElement(By.CssSelector("div.a-icon-headerblock.connect")).Text.Contains(_firstName);
                _isConnectionOk = true;
            }
            catch (Exception e)
            {
                _isConnectionOk = false;
            }

            return _isConnectionOk;
        }
    }
}
