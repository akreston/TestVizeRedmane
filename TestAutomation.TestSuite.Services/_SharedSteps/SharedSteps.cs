using System.Collections.Generic;
using System.Text.RegularExpressions;
using TestAutomation.BaseFramework;

namespace TestAutomation.TestSuite.Services
{
    public static class SharedSteps
    {
        public static string GetBaseUrl()
        {
            var testEnvironment = DataDriver.GetTestEnvironment();
            var iterationEnvironment = DataDriver.GetTestCaseDataValueByName(TestDataParameters.Environment.ToString());

            if (!testEnvironment.ToUpper().Equals(iterationEnvironment.ToUpper()))
            {
                GlobalReporter.ReportInfo($"Current iteration target environment {iterationEnvironment} does not equal to current actual environment {testEnvironment}. Skiping iteration.");
                return "SKIP";
            }

            var baseURL = DataDriver.GetTestCaseDataValueByName(TestDataParameters.BaseUrl.ToString());

            return baseURL;
        }

        public static string GenerateExpectedFilePath()
        {
            var expectedFileName = DataDriver.GetTestCaseDataValueByName(TestDataParameters.ExpectedResultsFileName.ToString());
            var expectedFilesPath = DataDriver.GetConfigurationValueInSectionByName("GlobalSettings", "TestDataSourcePath") + "\\ExpectedFiles";

            return expectedFilesPath + "\\" + expectedFileName;
        }

        public static void RegenerateApiExpectedData(string actualResult)
        {
            if (!DataDriver.GetSystemPropertyString("REGENERATEDATA").Contains("YES")) return;
            ExternalFileServer.SaveStringAsTextFile(actualResult, GenerateExpectedFilePath());
        }

        public static void VerifyValuesFromJsonResponseBasedOnGivenParameters(Dictionary<string, string> verificationParameters, string response)
        {
            foreach(var parameter in verificationParameters)
            {
                if (parameter.Value.Length == 0) continue;
                var convertedValue = Utilities.Utility_AttemptConversion_StringToDateTimeStringBasedOnFormat(parameter.Value, "yyyy-MM-ddTHH:mm:ssZ");
                var parameterValue = convertedValue.Length > 0 ? convertedValue : parameter.Value;
                var matchPattern = $"{parameter.Key}.*{parameterValue.ToLower()}";
                if (Regex.Match(response.ToLower(), matchPattern.ToLower()).Success)
                {
                    GlobalReporter.ReportSuccess($"Successfuly found match for pattern: {matchPattern}");
                } else
                {
                    GlobalReporter.ReportFailure($"Match for expected pattern: {matchPattern} , - was not found in Json response message", false, false);
                }
            }
        }
    }
}