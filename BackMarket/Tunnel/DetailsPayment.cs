using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackMarket
{
    public class DetailsPayment : AbstractPage
    {
        public void SetCardNumber(string _cardNumber)
        {
            wait.Until(ExpectedConditions.ElementExists(By.Id("card-number")));
            _webDriver.FindElement(By.Id("card-number")).SendKeys(_cardNumber);
        }

        public void SetMonth(string _month)
        {
            // select the drop down list
            var Service = _webDriver.FindElement(By.Id("months"));
            //create select element object 
            var selectElement = new SelectElement(Service);
            //select by value
            selectElement.SelectByText(_month);
        }

        public void SetYear(string _year)
        {
            // select the drop down list
            var Service = _webDriver.FindElement(By.Id("years"));
            //create select element object 
            var selectElement = new SelectElement(Service);
            //select by value
            selectElement.SelectByText(_year);
        }

        public void SetCVV(string _cvv)
        {
            _webDriver.FindElement(By.Id("cvv")).SendKeys(_cvv);
        }

        public void ValidatePayment()
        {
            _webDriver.FindElement(By.CssSelector("button.a-button.primary")).Click();
        }

    }
}
