using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Sockets;
using TestAutomation.BaseFramework;

namespace TestAutomation.TestSuite.FrontEnd
{
    [TestClass]
    public class Refactor_CreateODs : AutomationTestCase
    {
        [TestMethod]
        [TestCategory(Category.RegisterPerson)]
        [DeploymentItem("TestData\\TC_00002_REDMANE_HappyPath.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "TC_00002_REDMANE_HappyPath.csv", "TC_00002_REDMANE_HappyPath#csv", DataAccessMethod.Sequential)]
        public void Refactor_CreateODs_001()
        {
            ExecuteTest();
        }


        protected override void ExecuteTest()
        {
            //ObjectRepositoryManager.PopulateElementNames();

            ////Test date time change
            ////TestDriver.Utilities_ShiftDateBy(0, 0, 5);
            ////TestDriver.Utilities_ResetDate();

            ////DataDriver.OverrideEnvironmentValueForKey("BROWSER", Browser.Firefox.ToString());

            //var testDataFilePath = DataDriver.GetConfigurationValueInSectionByName("GlobalSettings", "TestDataFilePath");
            //var testDataFileName = DataDriver.GetTestCaseDataValueByName("TestDataFile");
            //string testDataFileFullPath = testDataFilePath + testDataFileName;

            //var testDataExcelFile = ExcelFileServer.LoadExcelWorkbookFromExternalFileByFilePath(testDataFileFullPath);
            //var numOfSheets = testDataExcelFile.NumberOfSheets;

            //for (int ind = 0; ind < numOfSheets; ++ind)
            //{
            //    var currentSheet = testDataExcelFile.GetSheetAt(ind);
            //    var sheetName = currentSheet.SheetName;
            //    var sheetContents = ExcelFileServer.ReadExcelFileWithHeaders(testDataFileFullPath, sheetName);
            //    TestExecutor.Temp_BuildObjects(sheetContents, sheetName);
            //}

            //ObjectRepositoryManager.SaveRunTimeRepositoryIntoStorage();
            //ObjectRepositoryManager.PopulateElementNames();
        }
    }
}