using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestAutomation.BaseFramework;

namespace TestAutomation.TestSuite.FrontEnd
{
    [TestClass]
    public class TC_00001_REDMANE_RegisterPerson : AutomationTestCase
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

            //Test date time change
            //TestDriver.Utilities_ShiftDateBy(0, 0, 5);
            //TestDriver.Utilities_ResetDate();


            //DataDriver.OverrideEnvironmentValueForKey("BROWSER", Browser.Firefox.ToString());

            var homePageUrl = DataDriver.GetTestCaseDataValueByName("HomePageURL");
            var testDataFilePath = DataDriver.GetTestCaseDataValueByName("TestDataFile");

            TestDriver.Actions_NavigateToURL(homePageUrl);
            
            var loginTestData = ExcelFileServer.ReadExcelFileWithHeaders(testDataFilePath, "Login");
            //SharedSteps.executeTestStepsBasedOnTestData(loginTestData);

            var registerPersonTestData = ExcelFileServer.ReadExcelFileWithHeaders(testDataFilePath, "RegisterPerson");
            //SharedSteps.executeTestStepsBasedOnTestData(registerPersonTestData);

            //var registerPersonTestData = ExcelFileServer.ReadExcelFileWithHeaders(testDataFilePath, "SearchForPerson");
            //SharedSteps.executeTestStepsBasedOnTestData(registerPersonTestData);

            var newApplicationTestData = ExcelFileServer.ReadExcelFileWithHeaders(testDataFilePath, "NewApplication");
            //SharedSteps.executeTestStepsBasedOnTestData(newApplicationTestData);

            GlobalReporter.TakeScreenShot("Final screen");
        }
    }
}