using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackMarket
{
    public class DetailsDelivery : AbstractPage
    {

        public void SetAddress(string _address)
        {
            wait.Until(ExpectedConditions.ElementExists(By.Name("address-line1")));
            _webDriver.FindElement(By.Name("address-line1")).SendKeys(_address);
        }

        public void SetComplment(string _complment)
        {
            _webDriver.FindElement(By.Name("address-line2")).SendKeys(_complment);
        }

        public void SetCity(string _city)
        {
            _webDriver.FindElement(By.Name("city")).SendKeys(_city);
        }

        public void SetZipCode(string _zipcode)
        {
            _webDriver.FindElement(By.Name("postal-code")).SendKeys(_zipcode);
        }

        public void SetCountry(string _country)
        {
            _webDriver.FindElement(By.Name("shippingAdressCountry"));
            // select the drop down list
            var Service = _webDriver.FindElement(By.Name("shippingAdressCountry"));
            //create select element object 
            var selectElement = new SelectElement(Service);
            //select by value
            selectElement.SelectByText(_country);
        }

        public void SetPhoneNumber(string _phonenumber)
        {
            _webDriver.FindElement(By.Name("phone")).SendKeys(_phonenumber);
        }

        public void SetNotSameAddress()
        {
            // To do 
            _webDriver.FindElement(By.Name("phone")).Click(); ;
        }

        public void PressContinue()
        {
            _webDriver.FindElement(By.CssSelector("button.a-button.primary")).Click();
        }
    }
}
