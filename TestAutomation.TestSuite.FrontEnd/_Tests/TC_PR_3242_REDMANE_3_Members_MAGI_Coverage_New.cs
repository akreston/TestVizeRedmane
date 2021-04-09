using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestAutomation.BaseFramework;

namespace TestAutomation.TestSuite.FrontEnd
{
    [TestClass]
    public class TC_PR_3242_REDMANE_3_Members_MAGI_Coverage_New : AutomationTestCase_ExternalData
    {
        [TestMethod]
        [TestCategory(Category.Regression)]
        [TestCategory(Category.SmokeTest)]
        [TestCategory(Category.MAGI)]
        //[DeploymentItem("TestData\\TC_PR_3242_REDMANE_3_Members_MAGI_Coverage_New.csv")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "TC_PR_3242_REDMANE_3_Members_MAGI_Coverage_New.csv", "TC_PR_3242_REDMANE_3_Members_MAGI_Coverage_New#csv", DataAccessMethod.Sequential)]
        public void TestCase_PR_03242_REDMANE_3_Members_MAGI_Coverage_New()
        {
            ExecuteTest();
        }


        protected override void ExecuteTest()
        {

            //Pdf document tester
            //PDFFileTestEngine.VerifyTextExistsInPdfFile(@"C:\TestAutomationResults\Notice+of+Decision+-+256.pdf", "Abella END-TO-END-17");


            GlobalReporter.ReportInfo(TestContext.TestName);

            var testDataFilePath = DataDriver.GetConfigurationValueInSectionByName("GlobalSettings", "TestCaseFilePath");
            var testDataFileName = TestContext.TestName + ".xlsx";
            string testDataFileFullPath = testDataFilePath + testDataFileName;
            var testName = TestContext.TestName;


            //Navigate to home page
            string homePageUrl = DataDriver.GetConfigurationValueInSectionByName("GlobalSettings", "HomePageURL");
            TestDriver.Actions_NavigateToURL(homePageUrl);


            //Load current test data file
            var testData = ExcelFileServer2010.LoadExcelWorkbookFromExternalFileByFilePath(testDataFileFullPath);

            //Exeute functions from each section
            var numberOfSheets = testData.NumberOfSheets;

            for (int sheetIndex = 0; sheetIndex < numberOfSheets; ++sheetIndex)
            {
                var sheetReference = testData.GetSheetAt(sheetIndex);
                var sectionName = sheetReference.SheetName;

                //Skip utility sections
                if (sectionName.Equals("Elements") || sectionName.Equals("Actions")) { continue; }

                var sectionData = ExcelFileServer2010.ParseWorkbookSheet(sheetReference, 0);

                GlobalReporter.ReportInfo("Executing steps for: " + testName + ", function: " + sectionName);
                FunctionRunner.ExecuteFunctionSteps(sectionData);
                GlobalReporter.ReportInfo("Completed steps for: " + testName + ", function: " + sectionName);
                GlobalReporter.TakeScreenShot("Final screen - " + sectionName);
            }

            
        }
    }
}