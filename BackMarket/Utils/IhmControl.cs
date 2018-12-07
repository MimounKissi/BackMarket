using OpenQA.Selenium;
using System;

namespace BackMarket.Utils
{
    public class IhmControl : AbstractPage
    {
        // Is Element present in the web page 
        public bool IsPresent(string _label)
        {
            bool _isPresent = false;

            try
            {
                _webDriver.FindElement(By.CssSelector("div.container")).Text.Contains(_label);
                _isPresent = true;
            }
            catch (Exception e)
            {
                _isPresent = false;
            }

            return _isPresent;
        }


        // Placeholder Text 
        public string GetPlaceholder(string _field)
        {
            string _text = "";

            _text = _webDriver.FindElement(By.Id(_field)).GetAttribute("placeholder");

            return _text;
        }
    }
}
