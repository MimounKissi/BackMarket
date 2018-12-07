using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace BackMarket
{
    public class ChooseProduct : AbstractPage
    {
        public bool IsCorrectProduct(string _nameProduct)
        {
            bool IsCorrectProduct = false;
            
            wait.Until(ExpectedConditions.ElementExists((By.CssSelector("div.overlay"))));
            
            var productTitle = _webDriver.FindElements(By.CssSelector("h2.a-sav-title"));

            foreach (var o in productTitle)
            {
                if (o.Text.Contains("Iphone 8"))
                {
                    IsCorrectProduct = true;
                }
            }

            return IsCorrectProduct;
        }


        public int NumberOfProduct(string _nameProduct)
        {
            int NumberOfProduct = 0;
            
            var productTypeP1 = _webDriver.FindElements(By.CssSelector("div.overlay"));

            NumberOfProduct = productTypeP1.Count;

            return NumberOfProduct; 
        }

        public void GoToPage(string _numberPage)
        {

            var numberOfPages = _webDriver.FindElements(By.CssSelector("div.pages.ng-scope"));

            foreach (var o in numberOfPages)
            {
                if (o.Text.Contains("_numberPage"))
                {
                    _webDriver.FindElements(By.CssSelector("div.pages.ng-scope")).ElementAt(1).Click();
                    break;
                }
            }

        }


        public void SlideBar()
        {
            IWebElement slider = _webDriver.FindElement(By.CssSelector("div.rangeSlider__fill"));

            var size_bar = slider.Size;

            Actions move = new Actions(_webDriver);

            IAction action = move.DragAndDropToOffset(slider, 136 + 10, 0).Build();

            action.Perform();
        }

    }
}
