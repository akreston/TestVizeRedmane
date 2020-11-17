using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestAutomation.BaseFramework;

namespace TestAutomation.TestSuite.FrontEnd
{
    [TestClass]
    public class TS_00001_SmokeTest: AutomationTestCase_ExternalData
    {
        [TestMethod]
        [TestCategory(Category.SmokeTest)]
        [DeploymentItem("TestData\\TS_0001_SmokeTest.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "TS_0001_SmokeTest.csv", "TS_0001_SmokeTest#csv", DataAccessMethod.Sequential)]
        public void TestSuite_00001_REDMANE_SmokeTest()
        {
            ExecuteTest();
        }


        protected override void ExecuteTest()
        {
            GlobalReporter.CloseTestCase();
            //Test date time change
            //TestDriver.Utilities_ShiftDateBy(0, 0, 5);
            //TestDriver.Utilities_ResetDate();


            //DataDriver.OverrideEnvironmentValueForKey("BROWSER", Browser.Firefox.ToString());

            var testSuiteName = DataDriver.GetTestCaseDataValueByName("TestSuiteName");
            var testSuiteDataFilePath = DataDriver.GetTestCaseDataValueByName("TestSuiteDataFile");



            //Load test suite data file
            var tests = ExcelFileServer2010.ReadExcelFileWithHeaders(testSuiteDataFilePath, "TestCases");
            var numberOfTests = tests.ContainsKey("Name") ? tests["Name"].Count : 0;

            //Execute all tests
            for (int testRow = 0; testRow < numberOfTests; ++ testRow)
            {
                var testName = tests["Name"][testRow];
                var homePageURL = tests["HomePageURL"][testRow];
                var testDataFilePath = tests["Path"][testRow];

                GlobalReporter.StartTestCase(testSuiteName + " - " + testName);

                //Navigate to home page
                TestDriver.Actions_NavigateToURL(homePageURL);

                //Load current test data file
                var testData = ExcelFileServer2010.LoadExcelWorkbookFromExternalFileByFilePath(testDataFilePath);

                //Exeute functions from each section
                var numberOfSheets = testData.NumberOfSheets;

                for (int sheetIndex = 0; sheetIndex < numberOfSheets; ++ sheetIndex)
                {
                    var sheetReference = testData.GetSheetAt(sheetIndex);
                    var sectionName = sheetReference.SheetName;

                    //Skip utility sections
                    if (sectionName.Equals("Elements") || sectionName.Equals("Actions")) { continue; }

                    var sectionData = ExcelFileServer2010.ParseWorkbookSheet(sheetReference, 0);

                    GlobalReporter.ReportInfo("Executing steps for: " + testName + ", function: " + sectionName);
                    FunctionRunner.ExecuteFunctionSteps(sectionData);
                    GlobalReporter.ReportInfo("Completed steps for: " + testName + ", function: " + sectionName);
                }

                GlobalReporter.TakeScreenShot("Final screen");
                GlobalReporter.CloseTestCase();
            }

            
        }
    }
}