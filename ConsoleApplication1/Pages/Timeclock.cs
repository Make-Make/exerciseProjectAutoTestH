using System.Threading;
using OpenQA.Selenium;

namespace ConsoleApplication1.Pages
{
    public class Timeclock
    {
        public string ClockedIn = "clockedIn";
        public string ClockIn = "tc_tl_ci";
        public string ClockOut = "tc_tl_co";
        public string TimeList = "timeSList";

        /// <summary>
        ///     Locate and click on Clock in
        /// </summary>
        /// <param name="driver"></param>
        public void ClockInClick(IWebDriver driver)
        {
            WaitToAppear.WaitElementToApear(driver, By.Id(ClockIn), 10);
            var clockIn = driver.FindElement(By.Id(ClockIn));
            clockIn.Click();
        }

        /// <summary>
        ///     Locate and click on Clock in
        /// </summary>
        /// <param name="driver"></param>
        public void ClockOutClick(IWebDriver driver)
        {
            Thread.Sleep(5000);
            var clockOut = driver.FindElement(By.Id(ClockOut));
            clockOut.Click();
        }

        /// <summary>
        ///     Get Click in Time;
        /// </summary>
        /// <param name="driver"></param>
        public string GetClickInTime(IWebDriver driver)
        {
            WaitToAppear.WaitElementToApear(driver, By.ClassName(ClockedIn), 10);
            var clickInTime = driver.FindElement(By.ClassName(ClockedIn));
            var time = clickInTime.Text;
            return time;
        }

        /// <summary>
        ///     Select last entry by the time; trim 16 chars first
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="time"></param>
        public bool SelectLastEntryFromTheTimeList(IWebDriver driver, string time)
        {
            time = time.Substring(0, time.Length - 16);
            var timeList = driver.FindElement(By.XPath("//*[contains(@title, '" + time + "')]"));
            if (timeList.Displayed)
                return true;
            return false;
        }
    }
}