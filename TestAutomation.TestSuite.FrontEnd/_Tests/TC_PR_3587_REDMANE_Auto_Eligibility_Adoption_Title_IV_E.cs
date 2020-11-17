using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestAutomation.BaseFramework;

namespace TestAutomation.TestSuite.FrontEnd
{
    [TestClass]
    public class TC_PR_3587_REDMANE_Auto_Eligibility_Adoption_Title_IV_E : AutomationTestCase
    {
        [TestMethod]
        [TestCategory(Category.Regression)]
        [TestCategory(Category.MAGI)]
        [DeploymentItem("TestData\\TC_PR_3587_REDMANE_Auto_Eligibility_Adoption_Title_IV_E.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "TC_PR_3587_REDMANE_Auto_Eligibility_Adoption_Title_IV_E.csv", "TC_PR_3587_REDMANE_Auto_Eligibility_Adoption_Title_IV_E#csv", DataAccessMethod.Sequential)]
        public void TestCase_PR_3587_REDMANE_Auto_Eligibility_Adoption_Title_IV_E()
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

            var person2Data = ExcelFileServer.ReadExcelFileWithHeaders(testDataFileFullPath, "Person2");
            SharedSteps.executeTestStepsBasedOnTestData(person2Data);

            var person3Data = ExcelFileServer.ReadExcelFileWithHeaders(testDataFileFullPath, "Person3");
            SharedSteps.executeTestStepsBasedOnTestData(person3Data);

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

            var logoffTestData = ExcelFileServer.ReadExcelFileWithHeaders(testDataFileFullPath, "Logoff");
            SharedSteps.executeTestStepsBasedOnTestData(logoffTestData);

            GlobalReporter.TakeScreenShot("Final screen");
        }
    }
}