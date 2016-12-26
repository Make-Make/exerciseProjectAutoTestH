using System;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace ConsoleApplication1
{
    public static class WaitToAppear
    {
        public static IWebElement WaitElementToApear(IWebDriver driver, By by, int timeoutInSeconds)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds)).Until(ExpectedConditions.ElementExists((by)));
            return driver.FindElement(by);
        }
    }
    
}
