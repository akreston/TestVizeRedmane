using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestAutomation.BaseFramework;

namespace TestAutomation.TestSuite.FrontEnd
{
    [TestClass]
    public class TC_PR_3303_REDMANE_Applicant_Is_Temporary_Resident : AutomationTestCase
    {
        [TestMethod]
        [TestCategory(Category.Regression)]
        [TestCategory(Category.MAGI)]
        [DeploymentItem("TestData\\TC_PR_3303_REDMANE_Applicant_Is_Temporary_Resident.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "TC_PR_3303_REDMANE_Applicant_Is_Temporary_Resident.csv", "TC_PR_3303_REDMANE_Applicant_Is_Temporary_Resident#csv", DataAccessMethod.Sequential)]
        public void TestCase_PR_3303_REDMANE_Applicant_Is_Temporary_Resident()
        {
            ExecuteTest();
        }


        protected override void ExecuteTest()
        {

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

            var relationshipData = ExcelFileServer.ReadExcelFileWithHeaders(testDataFileFullPath, "Relationship");
            SharedSteps.executeTestStepsBasedOnTestData(relationshipData);

            var benefitData = ExcelFileServer.ReadExcelFileWithHeaders(testDataFileFullPath, "Benefit");
            SharedSteps.executeTestStepsBasedOnTestData(benefitData);

            var employmentData = ExcelFileServer.ReadExcelFileWithHeaders(testDataFileFullPath, "Employment");
            SharedSteps.executeTestStepsBasedOnTestData(employmentData);

            var incomeData = ExcelFileServer.ReadExcelFileWithHeaders(testDataFileFullPath, "Income");
            SharedSteps.executeTestStepsBasedOnTestData(incomeData);

            var submitApplicationpData = ExcelFileServer.ReadExcelFileWithHeaders(testDataFileFullPath, "SubmitApplication");
            SharedSteps.executeTestStepsBasedOnTestData(submitApplicationpData);


            var verify = ExcelFileServer.ReadExcelFileWithHeaders(testDataFileFullPath, "Verify");
            SharedSteps.executeTestStepsBasedOnTestData(verify);

            var applyChanges = ExcelFileServer.ReadExcelFileWithHeaders(testDataFileFullPath, "ApplyChanges");
            SharedSteps.executeTestStepsBasedOnTestData(applyChanges);


            var logoffTestData = ExcelFileServer.ReadExcelFileWithHeaders(testDataFileFullPath, "Logoff");
            SharedSteps.executeTestStepsBasedOnTestData(logoffTestData);

            GlobalReporter.TakeScreenShot("Final screen");
        }
    }
}