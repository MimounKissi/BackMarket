using System.Net.Mail;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using System.Net;
using System.Net.Pop3;
using System;

namespace BackMarket
{
    public class Test : AbstractPage
    {
        /// <summary>
        /// TEST NEW ACCOUNT
        /// </summary>

        [Test]
        public void Test_IHM_AccountRegistration()
        {
            // Go to registration page 
            _openBrowser.GoToUrl();

            // Text is Present
            Assert.IsTrue(_ihmControl.IsPresent("Nouveau Backer ?"), "Texte absent");
            Assert.IsTrue(_ihmControl.IsPresent("J'accepte les conditions générales"), "Texte absent");
            Assert.IsTrue(_ihmControl.IsPresent("J'accepte de recevoir des emails (rares et précieux) de la part de Back Market"), "Texte absent");
            Assert.IsTrue(_ihmControl.IsPresent("Enchanté !"), "Texte absent");

            // Placeholder is Present
            Assert.IsTrue(_ihmControl.GetPlaceholder("id_last_name") == "Nom", "Placeholder nom KO !");
            Assert.IsTrue(_ihmControl.GetPlaceholder("id_first_name") == "Prénom", "Placeholder prénom KO !");
            Assert.IsTrue(_ihmControl.GetPlaceholder("id_email") == "Adresse email", "Placeholder mail KO !");
            Assert.IsTrue(_ihmControl.GetPlaceholder("id_password") == "Mot de passe", "Placeholder mot de passe KO !");
            Assert.IsTrue(_ihmControl.GetPlaceholder("id_birthdate") == "Date de naissance (ex 13/03/1990)", "Placeholder date de naissance KO !");
        }

        [Test]
        public void Test_Ok_AccountRegistration()
        {
            // Go to registration page 
            _openBrowser.GoToUrl();
            // Set Last Name
            _accountCreation.SetLastName();
            // Set First Name
            _accountCreation.SetFirstName();
            // Set Mail 
            _accountCreation.SetMail();
            // Set PassWord 
            _accountCreation.SetPassWord();
            // Set BirthDay 
            _accountCreation.SetBirthDay();
            // Set Optin 
            _accountCreation.CheckConditions();
            // Set Newsletter
            _accountCreation.CheckNewsLetter();
            // Validate
            _accountCreation.SubmitSubscription();
            
            Assert.IsTrue(_accountCreation.IsRegistrationOk(), "Registration is KO !");
        }

        [Test]
        public void Test_AccountRegistration_TooYoung()
        {
            // Go to registration page 
            _openBrowser.GoToUrl();
            // Set Last Name
            _accountCreation.SetLastName();
            // Set First Name
            _accountCreation.SetFirstName();
            // Set Mail 
            _accountCreation.SetMail();
            // Set PassWord 
            _accountCreation.SetPassWord();
            // Set BirthDay 
            _accountCreation.SetBirthDay();
            // Set Optin 
            _accountCreation.CheckConditions();
            // Set Newsletter
            _accountCreation.CheckNewsLetter();
            // Validate
            _accountCreation.SubmitSubscription();

            Assert.IsTrue(_ihmControl.IsPresent("Vous devez avoir plus de 16 ans."), "Texte absent");

            // Close web page 
            _webDriver.Close();
        }

        [Test]
        public void Test_AccountRegistration_BirthDay_Ko()
        {
            // Go to registration page 
            _openBrowser.GoToUrl();
            // Set Last Name
            _accountCreation.SetLastName();
            // Set First Name
            _accountCreation.SetFirstName();
            // Set Mail 
            _accountCreation.SetMail();
            // Set PassWord 
            _accountCreation.SetPassWord();
            // Set BirthDay 
            _accountCreation.SetBirthDay();
            // Set Optin 
            _accountCreation.CheckConditions();
            // Set Newsletter
            _accountCreation.CheckNewsLetter();
            // Validate
            _accountCreation.SubmitSubscription();

            Assert.IsTrue(_ihmControl.IsPresent("Saisissez une date valide."), "Texte absent");

            // Close web page 
            _webDriver.Close();
        }

        [Test]
        public void Test_AccountRegistration_PassWord_Ko()
        {
            // Go to registration page 
            _openBrowser.GoToUrl();
            // Set Last Name
            _accountCreation.SetLastName();
            // Set First Name
            _accountCreation.SetFirstName();
            // Set Mail 
            _accountCreation.SetMail();
            // Set PassWord 
            _accountCreation.SetPassWord();
            // Set BirthDay 
            _accountCreation.SetBirthDay();
            // Set Optin 
            _accountCreation.CheckConditions();
            // Set Newsletter
            _accountCreation.CheckNewsLetter();
            // Validate
            _accountCreation.SubmitSubscription();

            Assert.IsTrue(_ihmControl.IsPresent("Au moins 8 caractères, dont 1 majuscule, 1 minuscule et 1 chiffre. Parce qu'on sait jamais."), "Texte absent");

            // Close web page 
            _webDriver.Close();
        }

        [Test]
        public void Test_AccountRegistration_MailExist()
        {
            // Go to registration page 
            _openBrowser.GoToUrl();
            // Set Last Name
            _accountCreation.SetLastName();
            // Set First Name
            _accountCreation.SetFirstName();
            // Set Mail 
            _accountCreation.SetMail();
            // Set PassWord 
            _accountCreation.SetPassWord();
            // Set BirthDay 
            _accountCreation.SetBirthDay();
            // Set Optin 
            _accountCreation.CheckConditions();
            // Set Newsletter
            _accountCreation.CheckNewsLetter();
            // Validate
            _accountCreation.SubmitSubscription();

            Assert.IsTrue(_ihmControl.IsPresent("Un utilisateur avec cette adresse email existe déjà"), "Texte absent");

            // Close web page 
            _webDriver.Close();
        }

        /// <summary>
        /// TEST CLIENT CONNECTION 
        /// </summary>

        [Test]
        public void Test_IHM_AccountClient()
        {
            // Go to registration page 
            _openBrowser.GoToUrl();

            // Text is Present
            Assert.IsTrue(_ihmControl.IsPresent("Ola, qui va là ?"), "Texte absent");
            Assert.IsTrue(_ihmControl.IsPresent("Déjà Backer ?"), "Texte absent");
            Assert.IsTrue(_ihmControl.IsPresent("Mot de passe oublié ?"), "Texte absent");
            Assert.IsTrue(_ihmControl.IsPresent("Welcome back !"), "Texte absent");

            // Placeholder is Present
            Assert.IsTrue(_ihmControl.GetPlaceholder("id_username") == "Adresse email", "Placeholder mail KO !");
            Assert.IsTrue(_ihmControl.GetPlaceholder("id_password") == "Mot de passe", "Placeholder mot de passe KO !");            
        }

        [Test]
        public void Test_Connection_Ok_AccountClient()
        {
            // Go to registration page 
            _openBrowser.GoToUrl();

            // Set Mail & PassWord OK 
            _connection.SetIdUsername();
            _connection.SetPassWord();
            _connection.Submit();

            // Check connection is ok 
            Assert.IsTrue(_connection.IsConnectionOk(), "Connection KO !"); 

            // Close web page 
            _webDriver.Close();
        }

        [Test]
        public void Test_Connection_Ko_AccountClient()
        {
            // Go to registration page 
            _openBrowser.GoToUrl();

            // Set Mail & PassWord OK 
            _connection.SetIdUsername();
            _connection.SetPassWord();
            _connection.Submit();

            // Check error msg is ok 
            Assert.IsTrue(_connection.ErrorMsgConnection(), "Error message is KO !");

            // Close web page 
            _webDriver.Close(); 
        }

        [Test]
        public void Test_PassWordReset_AccountClient()
        {
            // Go to registration page 
            _openBrowser.GoToUrl();

            // PassWordReset
            _connection.PassWordReset();
            _connection.SetIdUsername();
            _connection.ClickPassWordReset();

            // Check error msg is ok 
            Assert.IsTrue(_connection.ValidMsgResetPassWord(), "Valid message is KO !");

            // Check reception mail          
            Assert.IsTrue(_mailReceive.IsReceiveMail("Nouveau mot de passe"));

            // Close web page 
            _webDriver.Close();
        }
    }
}
 