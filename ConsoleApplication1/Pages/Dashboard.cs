using OpenQA.Selenium;

namespace ConsoleApplication1.Pages
{
    public class Dashboard
    {
        private readonly LoginPage _loginPage = new LoginPage();
        public string AvatarLink = "tr_avatar";
        public string LogOut = "Sign Out";
        public string NavigationLabel = "_topnavLabel";
        public string ShiftPlanning = "icon-shiftPlanning";
        public string Timeclock = "icon-timeclock";

        /// <summary>
        ///     Log out left nav; Find avatart click, find logout clik
        /// </summary>
        /// <param name="driver"></param>
        public void SignOut(IWebDriver driver)
        {
            WaitToAppear.WaitElementToApear(driver, By.Id(AvatarLink), 10);
            var avatar = driver.FindElement(By.Id(AvatarLink));
            avatar.Click();
            var signOut = driver.FindElement(By.LinkText(LogOut));
            signOut.Click();
            WaitToAppear.WaitElementToApear(driver, By.Id(_loginPage.Password), 10);
        }

        /// <summary>
        ///     Shift planing click on left nav
        /// </summary>
        /// <param name="driver"></param>
        public void ShiftPlaningClick(IWebDriver driver)
        {
            var shiftPlanning = driver.FindElement(By.ClassName(ShiftPlanning));
            shiftPlanning.Click();
        }

        /// <summary>
        ///     Time clock click on left nav
        /// </summary>
        /// <param name="driver"></param>
        public void TimeclockClick(IWebDriver driver)
        {
            var timeclock = driver.FindElement(By.ClassName(Timeclock));
            timeclock.Click();
        }
    }
}