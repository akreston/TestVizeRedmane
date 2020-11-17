using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestAutomation.BaseFramework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace TestAutomation.TestSuite.FrontEnd
{
    [TestClass]
    public class TC_99999_Exploratory : AutomationTestCase
    {
        [TestMethod]
        [TestCategory(Category.RegisterPerson)]
        [DeploymentItem("TestData\\TC_00001_REDMANE_Application.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "TC_00001_REDMANE_Application.csv", "TC_00001_REDMANE_Application#csv", DataAccessMethod.Sequential)]
        public void TestCase_00001_REDMANE_RegisterPerson()
        {
            ExecuteTest();
        }


        protected override void ExecuteTest()
        {
            var homePageUrl = "https://www.amazon.com";
            
            TestDriver.Actions_NavigateToURL(homePageUrl);
            TestDriver.Actions_ClickOnObject(By.XPath("//a[@href='/ref=nav_logo']"), "Test");
            TestDriver.Utilities_DelayTestExecution(5);
            
        }
    }
}