using BackMarket.EspaceClient.Client;
using BackMarket.EspaceClient.Nouveau;
using BackMarket.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace BackMarket
{
    public class AbstractPage
    {
        // Driver
        public static IWebDriver _webDriver = new ChromeDriver();
        public static WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(50));
        public static Connection _connection = new Connection();
        public static Mail _mailReceive = new Mail(); 
       
        // Variables
        public static string _url = "https://ppr.backmarket.fr/register"; 
        public static string _idUserName = "backmarket.test@gmail.com";
        public static string _passWord = "Kissi";
        public static string _gender = "Madame";
        public static string _lastName = "Kissi";
        public static string _firstName = "Mimoun";
        public static string _mail = "backmarket.test@gmail.com";
        public static string _birthDay = "17/10/2010";
        public static string _country = "Belgique";

        // Object 
        public static OpenBrowser _openBrowser = new OpenBrowser();
        public static IhmControl _ihmControl = new IhmControl();
        public static AccountCreation _accountCreation = new AccountCreation(); 

    }
}
