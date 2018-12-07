using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BackMarket
{
    public class DetailsBuy : AbstractPage
    {
        public void SelectTypeDelivery()
        {
            
        }

        public void SelectTypeSecurity(string _securityMaturity)
        {
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div.margin-active")));

            int i = 0;
            int j = 0;

            //_webDriver.FindElement(By.XPath("//*[@id=\"cart_container\"]/div/div[2]/section/div[2]/div[2]/div[2]/label/div")).Click();


            //var bloc = _webDriver.FindElements(By.CssSelector("div.margin-active"));

            //foreach (var b in bloc)
            //{
            //    if (b.Text.Contains("Garantie panne"))
            //    {
            //        //var label = _webDriver.FindElements(By.CssSelector("div.label-container"));

            //        //var parent = node.FindElement(By.XPath("../.."));


            //        //foreach (var l in label)
            //        //{
            //        //    if (l.Text.Contains(_securityMaturity))
            //        //    {
            //        //        label.ElementAt(j).Click();
            //        //        break;
            //        //    }
            //        //    j++;
            //        //}
            //        break;
            //    }
            //    i++;
            //}

            //_webDriver.FindElement(By.CssSelector("label.lineLabel")).Click();
        }

        public void SelectTypeInsurance(string _insuranceMaturity)
        {
            var bloc = _webDriver.FindElements(By.CssSelector("div.margin-active"));
            int i = 0;
            int j = 0;

            foreach (var b in bloc)
            {
                if (b.Text.Contains("Assurance casse vol"))
                {
                    var label = _webDriver.FindElements(By.CssSelector("div.label-container"));

                    foreach (var l in label)
                    {
                        if (l.Text.Contains(_insuranceMaturity))
                        {
                            label.ElementAt(j).Click();
                            break;
                        }

                        j++;
                    }
                    break;
                }
                i++;
            }

            _webDriver.FindElement(By.CssSelector("label.lineLabel")).Click();
        }

        public void ValidateCommand()
        {
            _webDriver.FindElement(By.CssSelector("button.a-button.red-fu.maxwidth.gotonext-bottom")).Click();
        }

        public void DeleteCommand()
        {
            _webDriver.FindElement(By.CssSelector("button.delete-button.a-button.transparent.ghost xs")).Click();
        }

        public void AddProduct(string _numberOfProduct)
        {
            // select the drop down list
            var Service = _webDriver.FindElement(By.CssSelector("select"));
            //create select element object 
            var selectElement = new SelectElement(Service);
            //select by value
            selectElement.SelectByText(_numberOfProduct);
        }

        public void GoToBack()
        {

        }
    }
}
