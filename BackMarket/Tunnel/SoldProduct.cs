using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace BackMarket
{
    public class SoldProduct : AbstractPage
    {
        public void SelectProduct()
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(20));

            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div.product-title.ng-binding")));
            _webDriver.FindElements(By.CssSelector("div.overlay")).ElementAt(0).Click();
        }

        public void AddToBuy()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("button.a-button.red-fu.buy-button.maxwidth.cta-bottom.cta-variation1")));
            _webDriver.FindElement(By.CssSelector("button.a-button.red-fu.buy-button.maxwidth.cta-bottom.cta-variation1")).Click();            
        }
    }
}
