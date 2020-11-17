using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestAutomation.BaseFramework;

namespace TestAutomation.TestSuite.FrontEnd
{
    [TestClass]
    public class TC_00002_REDMANE_HappyPath: AutomationTestCase
    {
        [TestMethod]
        [TestCategory(Category.SmokeTest)]
        [DeploymentItem("TestData\\TC_00002_REDMANE_HappyPath.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "TC_00002_REDMANE_HappyPath.csv", "TC_00002_REDMANE_HappyPath#csv", DataAccessMethod.Sequential)]
        public void TestCase_00002_REDMANE_HappyPath()
        {
            ExecuteTest();
        }


        protected override void ExecuteTest()
        {
            //DataDriver.OverrideEnvironmentValueForKey("BROWSER", Browser.Firefox.ToString());

            var testDataFilePath = DataDriver.GetConfigurationValueInSectionByName("GlobalSettings", "TestDataFilePath");
            var testDataFileName = DataDriver.GetTestCaseDataValueByName("TestDataFile");
            string testDataFileFullPath = testDataFilePath + testDataFileName;

            string homePageUrl = DataDriver.GetConfigurationValueInSectionByName("GlobalSettings", "HomePageURL");
            TestDriver.Actions_NavigateToURL(homePageUrl);
            
            var loginTestData = ExcelFileServer.ReadExcelFileWithHeaders(testDataFileFullPath, "Login");
            SharedSteps.executeTestStepsBasedOnTestData(loginTestData);

            var registerPersonTestData = ExcelFileServer.ReadExcelFileWithHeaders(testDataFileFullPath, "RegisterPerson");
            SharedSteps.executeTestStepsBasedOnTestData(registerPersonTestData);

            var newApplicationTestData = ExcelFileServer.ReadExcelFileWithHeaders(testDataFileFullPath, "NewApplication");
            SharedSteps.executeTestStepsBasedOnTestData(newApplicationTestData);

            var submitApplicationTestData = ExcelFileServer.ReadExcelFileWithHeaders(testDataFileFullPath, "SubmitApplication");
            SharedSteps.executeTestStepsBasedOnTestData(submitApplicationTestData);

            var activateTestData = ExcelFileServer.ReadExcelFileWithHeaders(testDataFileFullPath, "Activate");
            SharedSteps.executeTestStepsBasedOnTestData(activateTestData);

            var logoffTestData = ExcelFileServer.ReadExcelFileWithHeaders(testDataFileFullPath, "Logoff");
            SharedSteps.executeTestStepsBasedOnTestData(logoffTestData);

            GlobalReporter.TakeScreenShot("Final screen");
        }
    }
}