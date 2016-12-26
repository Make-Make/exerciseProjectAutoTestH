using System;
using OpenQA.Selenium;

namespace ConsoleApplication1.Pages
{
    public class LoginPage
    {
        private const string LoginBtn = "login";
        public string BaseUrl = "https://wayneenterprisesinc.shiftplanning.com/app/";
        public string EmailUserName = "email";
        public string EmptyPasswordMessage = "Please enter password";
        public string ManagerEmail = "aleksandar.mirko.nikolic@gmail.com";
        public string ManagerPassword = "Password1!";
        public string PageTitle = "Online Employee Scheduling Software | Workforce Management";
        public string Password = "password";
        public string ValidEmail = "valid_email";
        public string ValidEmailMessage = "Please enter valid Email Address";
        public string ValidPassword = "valid_password";

        /// <summary>
        ///     Click on login button
        /// </summary>
        /// <param name="driver"></param>
        public void LoginButtonClick(IWebDriver driver)
        {
            var linkToOpen = driver.FindElement(By.Name(LoginBtn));
            Console.WriteLine("Click on: " + linkToOpen.Text);
            linkToOpen.Click();
        }

        /// <summary>
        ///     Submit username, pass, enter Dashboard
        /// </summary>
        /// <param name="driver"></param>
        public void LoginIntoDashboard(IWebDriver driver)
        {
            EnterEmail(driver);
            EnterPassword(driver);
            LoginButtonClick(driver);
        }

        /// <summary>
        ///     Enter email
        /// </summary>
        /// <param name="driver"></param>
        public void EnterEmail(IWebDriver driver)
        {
            var email = driver.FindElement(By.Id(EmailUserName));
            email.SendKeys(ManagerEmail);
        }

        /// <summary>
        ///     Enter pass
        /// </summary>
        /// <param name="driver"></param>
        public void EnterPassword(IWebDriver driver)
        {
            var password = driver.FindElement(By.Id(Password));
            password.SendKeys(ManagerPassword);
        }

        /// <summary>
        ///     Clear pass
        /// </summary>
        /// <param name="driver"></param>
        public void ClearPassword(IWebDriver driver)
        {
            var password = driver.FindElement(By.Id(Password));
            password.Clear();
        }
    }
}