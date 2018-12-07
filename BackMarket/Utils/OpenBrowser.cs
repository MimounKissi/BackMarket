
namespace BackMarket
{
    public class OpenBrowser : AbstractPage
    {
        public void GoToUrl()
        {
            _webDriver.Url = _url;
            _webDriver.Manage().Window.Maximize(); 
        }       
        
        
    }
}
