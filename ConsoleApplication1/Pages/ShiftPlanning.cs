using System;
using System.Linq;
using OpenQA.Selenium;

namespace ConsoleApplication1.Pages
{
    public class ShiftPlanning
    {
        public string AddEmployeeBtn = "addEmployee";
        public string AddEmployeeForm = "addemployeepop";
        public string Cells = "jump";
        public string CheckBoxRole = "os_sch";
        public string EmployeeEmail = "_ns_email";
        public string EmployeeFrstName = "_ns_fname"; //_ns_lname
        public string EmployeeLastName = "_ns_lname";
        public string EmployeeRole = "Employee";
        public string RoleFormTitle = "rtitle";
        public string SaveEmployeeBtn = "add_employee_btn";
        public string TestEmail = "TEmail@";
        public string TestLastName = "TLast";
        public string TestName = "TName";

        /// <summary>
        ///     Locate and click on add employee
        /// </summary>
        /// <param name="driver"></param>
        public void AddEmployeeClick(IWebDriver driver)
        {
            var addEmployee = driver.FindElement(By.ClassName(AddEmployeeBtn));
            addEmployee.Click();
        }

        /// <summary>
        ///     Insert test employee with name lastname email; returns random sufix so it can be indetify later
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        public int InsertEmployee(IWebDriver driver)
        {
            var rnd = new Random();
            var randomSufix = rnd.Next(7000);
            var eName = TestName + randomSufix;
            var eLastName = TestLastName + randomSufix;
            var eEmail = TestEmail + randomSufix + ".com";
            var employeeFrstName = driver.FindElement(By.ClassName(EmployeeFrstName));
            employeeFrstName.SendKeys(eName);
            var employeeLastName = driver.FindElement(By.ClassName(EmployeeLastName));
            employeeLastName.SendKeys(eLastName);
            var employeeEmail = driver.FindElement(By.ClassName(EmployeeEmail));
            employeeEmail.SendKeys(eEmail);
            SaveEmployeeClick(driver);
            return randomSufix;
        }

        /// <summary>
        ///     Click on check box index 0; save emplyee with role.
        /// </summary>
        /// <param name="driver"></param>
        public void SelectRoleAndSave(IWebDriver driver)
        {
            var checkBoxes = driver.FindElements(By.ClassName(CheckBoxRole));
            var o = checkBoxes[0];
            o.Click();
            SaveEmployeeClick(driver);
        }

        /// <summary>
        ///     Locate eployee in grid; send sufix
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="randomSufix"></param>
        /// <returns></returns>
        public bool LocateEmployeeInGrid(IWebDriver driver, int randomSufix)
        {
            var eName = TestName + randomSufix;
            var eLastName = TestLastName + randomSufix;
            var rows = driver.FindElements(By.ClassName(Cells));
            var row = rows.FirstOrDefault(t => t.Text.Contains(eName));
            if (row.Text == null)
                return false;
            return true;
        }

        /// <summary>
        ///     Save employee
        /// </summary>
        /// <param name="driver"></param>
        public void SaveEmployeeClick(IWebDriver driver)
        {
            var saveEmployeeBtn = driver.FindElement(By.Id(SaveEmployeeBtn));
            saveEmployeeBtn.Click();
        }
    }
}