using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TestAutomation.BaseFramework;
using TestAutomation.BaseFramework.DAL;
using System.Linq;

namespace TestAutomation.TestSuite.Services
{
    [TestClass]
    public class TC_00001_API_Country : AutomationTestCase
    {
        [TestMethod]
        [TestCategory(Category.API_SmokeTest)]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "TC_00001_API_Test.csv", "TC_00001_API_Test#csv", DataAccessMethod.Sequential), DeploymentItem("TestData\\TC_00001_API_Test.csv")]
        public void TestCase_00001_API_Test()
        {
            ExecuteTest();
        }


        protected override void ExecuteTest()
        {
            //DataDriver.OverrideEnvironmentValueForKey("REGENERATEDATA", "YES");

            //Get API test data
            var baseUrl = SharedSteps.GetBaseUrl();
            var uri = DataDriver.GetTestCaseDataValueByName(TestDataParameters.URI.ToString());

            ServiceDriver.InitializeRestClient(baseUrl + uri, HttpVerb.GET);
            var actualResult = ServiceDriver.ExecuteRequestAndReadIntoString();
            
            SharedSteps.RegenerateApiExpectedData(actualResult);

            var expectedResults = ExternalFileServer.ReadFileAsString(SharedSteps.GenerateExpectedFilePath());

            //ServiceDriver.Assertions_CompareStringMessages(expectedResults, actualResult);
            ServiceDriver.Assertions_CompareJsonMessages(expectedResults, actualResult);
            
        }
    }
}