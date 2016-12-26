using ConsoleApplication1.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ConsoleApplication1
{
    public class Program
    {
        private readonly Dashboard _dashboard = new Dashboard();

        private readonly IWebDriver _driver = new ChromeDriver();

        //initialize pages we will work with
        private readonly LoginPage _loginPage = new LoginPage();
        private readonly ShiftPlanning _shiftPlanninng = new ShiftPlanning();
        private readonly Timeclock _timeclock = new Timeclock();

        private static void Main(string[] args)
        {
            var test = new Program();
            test.TestSetUp();
            test.AddNewEmployeeTest();
            test.LoginPageTest();
            test.ClockInClockOutTest();
        }

        public void TestSetUp()
        {
            _driver.Manage().Window.Maximize();
        }

        public void LoginPageTest()
        {
            //Navigate to base url
            _driver.Navigate().GoToUrl(_loginPage.BaseUrl);

            //Verify we are on the right place
            Verification.VerifyBoolean(_driver.Title == _loginPage.PageTitle, true, "Page title OK", true);

            //Find elements and submit
            _loginPage.LoginIntoDashboard(_driver);

            //Wait dashbord to apear
            WaitToAppear.WaitElementToApear(_driver, By.Id(_dashboard.NavigationLabel), 10);

            //Verify Dashboard
            Verification.VerifyBoolean(_driver.FindElement(By.Id(_dashboard.NavigationLabel)).Text == "Dashboard", true,
                "Dashbord label exists", true);

            //Logout
            _dashboard.SignOut(_driver);

            //Login without email and password
            _loginPage.LoginButtonClick(_driver);
            Verification.VerifyBoolean(
                _driver.FindElement(By.Id(_loginPage.ValidEmail)).Text == _loginPage.ValidEmailMessage, true,
                "Empty email message OK", true);
            Verification.VerifyBoolean(
                _driver.FindElement(By.Id(_loginPage.ValidPassword)).Text == _loginPage.EmptyPasswordMessage, true,
                "Empty password message OK", true);

            //Login without email
            _loginPage.EnterPassword(_driver);
            _loginPage.LoginButtonClick(_driver);
            Verification.VerifyBoolean(
                _driver.FindElement(By.Id(_loginPage.ValidEmail)).Text == _loginPage.ValidEmailMessage, true,
                "Empty email message OK", true);

            //Login without password
            _loginPage.ClearPassword(_driver);
            _loginPage.EnterEmail(_driver);
            _loginPage.LoginButtonClick(_driver);
            Verification.VerifyBoolean(
                _driver.FindElement(By.Id(_loginPage.ValidPassword)).Text == _loginPage.EmptyPasswordMessage, true,
                "Empty password message OK", true);

            TestCleanUp();
        }

        public void AddNewEmployeeTest()
        {
            //Navigate to base url
            _driver.Navigate().GoToUrl(_loginPage.BaseUrl);

            //Verify we are on the right place
            Verification.VerifyBoolean(_driver.Title == _loginPage.PageTitle, true, "Page title OK", true);

            //Find elements and submit
            _loginPage.LoginIntoDashboard(_driver);

            //Wait dashbord to apear
            WaitToAppear.WaitElementToApear(_driver, By.Id(_dashboard.NavigationLabel), 10);

            //Verify Dashboard
            Verification.VerifyBoolean(_driver.FindElement(By.Id(_dashboard.NavigationLabel)).Text == "Dashboard", true,
                "Dashbord label exists", true);

            //Click on shift planing
            _dashboard.ShiftPlaningClick(_driver);
            Verification.VerifyBoolean(_driver.FindElement(By.Id(_dashboard.NavigationLabel)).Text == "ShiftPlanning",
                true,
                "ShiftPlanning label exists", true);

            //Add Employee
            _shiftPlanninng.AddEmployeeClick(_driver);

            //Enter details and get identifier
            var sufix = _shiftPlanninng.InsertEmployee(_driver);

            //Wait for role header
            WaitToAppear.WaitElementToApear(_driver, By.ClassName(_shiftPlanninng.RoleFormTitle), 10);

            //Select Role
            _shiftPlanninng.SelectRoleAndSave(_driver);

            Verification.VerifyBoolean(_shiftPlanninng.LocateEmployeeInGrid(_driver, sufix), true, "Employee exists",
                true);

            //Logout
            _dashboard.SignOut(_driver);

            TestCleanUp();
        }

        public void ClockInClockOutTest()
        {
            //Navigate to base url
            _driver.Navigate().GoToUrl(_loginPage.BaseUrl);

            //Verify we are on the right place
            Verification.VerifyBoolean(_driver.Title == _loginPage.PageTitle, true, "Page title OK", true);

            //Find elements and submit
            _loginPage.LoginIntoDashboard(_driver);

            //Wait dashbord to apear
            WaitToAppear.WaitElementToApear(_driver, By.Id(_dashboard.NavigationLabel), 10);

            //Verify Dashboard
            Verification.VerifyBoolean(_driver.FindElement(By.Id(_dashboard.NavigationLabel)).Text == "Dashboard", true,
                "Dashbord label exists", true);

            //Click on Timeclock
            _dashboard.TimeclockClick(_driver);
            Verification.VerifyBoolean(_driver.FindElement(By.Id(_dashboard.NavigationLabel)).Text == "Timeclock", true,
                "Timeclock label exists", true);

            //Click on ClickIn
            _timeclock.ClockInClick(_driver);

            //Get the clickIn Time
            var clickInTime = _timeclock.GetClickInTime(_driver);

            //Click Clock Out; wait 5 sec to have some time diff
            _timeclock.ClockOutClick(_driver);

            //Verify we have Clock in time entry
            var isEntryExistsinMyTimeSheets = _timeclock.SelectLastEntryFromTheTimeList(_driver, clickInTime);
            Verification.VerifyBoolean(isEntryExistsinMyTimeSheets, true, "Entry exists in My Timesheets", true);

            //Logout
            _dashboard.SignOut(_driver);

            TestCleanUp();
        }

        public void TestCleanUp()
        {
            //Quit driver
            _driver.Quit();
        }
    }
}