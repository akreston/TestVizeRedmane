using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TestAutomation.BaseFramework;

namespace TestAutomation.TestSuite.FrontEnd
{

    public enum testFileDataTabs
    {
        Action,
        Element,
        VariableName,
        VariableValue,
        Optional,
        Modifier

    }

    static class Constants
    {
        public const string dateFormat = "dd/MM/yyyy";
    }

    public static class FunctionRunner
    {

        public static void ExecuteFunctionSteps(Dictionary<string, List<string>> testData)
        {
            //Acquire number of test data rows to process
            var numberOfRows = testData.ContainsKey(testFileDataTabs.Action.ToString()) ? testData[testFileDataTabs.Action.ToString()].Count : 0;


            //Loop through all data rows
            for (var row = 0; row < numberOfRows; ++row)
            {
                //Get necessary object attributes and test data from current row
                var action = testData[testFileDataTabs.Action.ToString()][row];
                var elementName = testData[testFileDataTabs.Element.ToString()][row];
                var variableName = testData[testFileDataTabs.VariableName.ToString()][row] != null ? testData[testFileDataTabs.VariableName.ToString()][row] : "";
                var variableValue = testData[testFileDataTabs.VariableValue.ToString()][row];
                var modifier = testData[testFileDataTabs.Modifier.ToString()][row];

                var optional = false;
                if (testData[testFileDataTabs.Optional.ToString()][row].Length > 0)
                {
                    optional = bool.Parse(testData[testFileDataTabs.Optional.ToString()][row]);
                }

                var stepDescription = action + ": " + elementName + (variableValue.Length > 0 ? ", with data: " + variableValue : ".");


                //Get variable value by name if exists
                if (DataDriver.IsRuntimeDataValuePresent(variableName))
                {
                    GlobalReporter.ReportSuccess("Retreiving variable with name: " + variableName + ", and value: " + variableValue);
                    variableValue = DataDriver.GetRuntimeDataValueByName(variableName);
                }

                //Execute action based on incoming data: Actionable steps
                switch (action)
                {
                    case "Navigate To":
                        {
                            TestDriver.Actions_NavigateToURL(variableValue);
                            break;
                        }

                    case "Click":
                        {
                            var ids = ObjectRepositoryManager.CombineElementIdentifiers(elementName);
                            TestDriver.Utilities_WaitForObjectToBecomeClickable(ids, 5);
                            TestDriver.Actions_ClickOnObject(ids, "Click on: " + elementName, optional);
                            break;
                        }

                    case "Right Click":
                        {
                            var ids = ObjectRepositoryManager.CombineElementIdentifiers(elementName);
                            TestDriver.Actions_RightClickOnObject(ids, "Right Click on: " + elementName, optional);
                            break;
                        }

                    case "Enter Text":
                        {
                            var ids = ObjectRepositoryManager.CombineElementIdentifiers(elementName);
                            TestDriver.Actions_EnterText(ids, variableValue, "Enter text: " + variableValue + ", into: " + elementName, optional);
                            break;
                        }

                    case "Enter Text In Window And Press Enter":
                        {
                            TestDriver.Actions_EnterTextInActiveWindowAndPressEnter(variableValue);
                            break;
                        }

                    case "Enter Text In Window And Press Tab":
                        {
                            TestDriver.Actions_EnterTextInActiveWindowAndPressTab(variableValue);
                            break;
                        }

                    case "Press Tab":
                        {
                            TestDriver.Actions_PressTab();
                            break;
                        }

                    case "Select Drop Down Option":
                        {
                            var ids = ObjectRepositoryManager.CombineElementIdentifiers(elementName);
                            if (TryAction(() =>
                            {
                                TestDriver.Actions_SelectOptionFromDropDownByText(ids, variableValue, stepDescription, optional);

                            }) == false)
                            {
                                TestDriver.Actions_SelectOptionFromDropDownByValue(ids, variableValue, stepDescription, optional);
                                break;
                            }
                            break;
                        }

                    case "Select Drop Down Option By Index":
                        {
                            var ids = ObjectRepositoryManager.CombineElementIdentifiers(elementName);
                            TestDriver.Actions_SelectOptionFromDropDownByIndex(ids, int.Parse(variableValue), stepDescription, optional);
                            break;
                        }

                    case "Delay Test Execution":
                        {
                            TestDriver.Utilities_DelayTestExecution(int.Parse(variableValue));
                            break;
                        }

                    case "Execute Shared Function":
                        {
                            //Load shared functions file
                            var sharedFunctionData = ExcelFileServer2010.ReadExcelFileWithHeaders("C:\\TestAutomationResults\\FunctionLibrary.xlsx", variableValue);

                            if (sharedFunctionData.Count != 0)
                            {
                                ExecuteFunctionSteps(sharedFunctionData);
                            }

                            break;
                        }


                    case "Create Random Text Value":
                        {
                            var newRandomString = Utilities.Utility_GenerateRandomStringWithLengthInRange(4, 8);
                            DataDriver.AddRuntimeDataValueByName(variableName, newRandomString);
                            stepDescription = "Generated random value: " + newRandomString + ", with variable name: " + variableName;
                            GlobalReporter.ReportSuccess(stepDescription);
                            break;
                        }


                    case "Create Date Value":
                        {
                            var newDateString = CustomUtilities.GenerateDateBasedOnParameter(variableValue);
                            DataDriver.AddRuntimeDataValueByName(variableName, newDateString);
                            stepDescription = "Generated random date: " + newDateString + ", with variable name: " + variableName;
                            GlobalReporter.ReportSuccess(stepDescription);
                            break;
                        }

                    case "Create Random Date Value With Age":
                        {
                            try
                            {
                                int year = Utilities.Utility_GetCurrentDate().AddYears(int.Parse(variableValue)).Year;
                                var month = Utilities.Utility_GenerateRandomNumberInRange(1, 12);
                                var date = Utilities.Utility_GenerateRandomNumberInRange(1, 28);
                                var newDate = string.Format("{0}/{1}/{2}", date, month, year);
                                DataDriver.AddRuntimeDataValueByName(variableName, newDate);
                                stepDescription = "Generated random date with age: " + newDate + ", variable name: " + variableName;
                                GlobalReporter.ReportSuccess(stepDescription);
                            }
                            catch (Exception e)
                            {
                                stepDescription = "Could not generate date with age uding variable value: " + variableValue + ". Exception message: " + e;
                            }

                            break;
                        }

                    case "Set Variable Value":
                        {
                            DataDriver.AddRuntimeDataValueByName(variableName, variableValue);
                            stepDescription = "Saved variable: " + variableName + ", with value: " + variableValue;
                            GlobalReporter.ReportSuccess(stepDescription);
                            break;
                        }

                    case "Set FilePath Variable Value":
                        {
                            variableName = "FilePath";
                            DataDriver.AddRuntimeDataValueByName(variableName, variableValue);
                            stepDescription = "Saved variable: " + variableName + ", with value: " + variableValue;
                            GlobalReporter.ReportSuccess(stepDescription);
                            break;
                        }

                    case "Check Element Present":
                        {
                            var ids = ObjectRepositoryManager.CombineElementIdentifiers(elementName);
                            if (TestDriver.Surveys_DoesObjectExist(ids))
                            {
                                if (modifier.Equals("not"))
                                {
                                    GlobalReporter.ReportFailure(stepDescription, !optional);
                                }
                                else
                                {
                                    GlobalReporter.ReportSuccess(stepDescription);
                                }
                            }
                            else
                            {
                                if (!modifier.Equals("not"))
                                {
                                    GlobalReporter.ReportFailure(stepDescription, !optional);
                                }
                                else
                                {
                                    GlobalReporter.ReportSuccess(stepDescription);
                                }
                            }
                            break;
                        }

                    case "Check Element Visible":
                        {
                            var ids = ObjectRepositoryManager.CombineElementIdentifiers(elementName);
                            if (TestDriver.Surveys_IsObjectVisible(ids))
                            {
                                if (modifier.Equals("not"))
                                {
                                    GlobalReporter.ReportFailure(stepDescription, !optional);
                                }
                                else
                                {
                                    GlobalReporter.ReportSuccess(stepDescription);
                                }
                            }
                            else
                            {
                                if (!modifier.Equals("not"))
                                {
                                    GlobalReporter.ReportFailure(stepDescription, !optional);
                                }
                                else
                                {
                                    GlobalReporter.ReportSuccess(stepDescription);
                                }
                            }
                            break;
                        }

                    case "Check Element Text":
                        {
                            var ids = ObjectRepositoryManager.CombineElementIdentifiers(elementName);
                            if (TestDriver.Retrievers_GetObjectText(ids).Equals(variableValue))
                            {
                                if (modifier.Equals("not"))
                                {
                                    GlobalReporter.ReportFailure(stepDescription, !optional);
                                }
                                else
                                {
                                    GlobalReporter.ReportSuccess(stepDescription);
                                }


                            }
                            else
                            {
                                if (!modifier.Equals("not"))
                                {
                                    GlobalReporter.ReportFailure(stepDescription, !optional);
                                }
                                else
                                {
                                    GlobalReporter.ReportSuccess(stepDescription);
                                }
                            }
                            break;
                        }

                    case "Check For Text On Page":
                        {
                            if (TestDriver.Surveys_DoesTextExistsOnPageByFullTextValue(variableValue))
                            {
                                if (modifier.Equals("not"))
                                {
                                    GlobalReporter.ReportFailure(stepDescription, !optional);
                                }
                                else
                                {
                                    GlobalReporter.ReportSuccess(stepDescription);
                                }


                            }
                            else
                            {
                                if (!modifier.Equals("not"))
                                {
                                    GlobalReporter.ReportFailure(stepDescription, !optional);
                                }
                                else
                                {
                                    GlobalReporter.ReportSuccess(stepDescription);
                                }

                            }
                            break;
                        }

                    case "Verify Text Present In Pdf File":
                        {
                            if (!DataDriver.IsRuntimeDataValuePresent("FilePath"))
                            {
                                GlobalReporter.ReportFailure("In oder to execute PDF file text verification function you need to first set value of special variable [FilePath].", true, false);
                            }

                            var filePath = DataDriver.GetRuntimeDataValueByName("FilePath");

                            if (modifier.Equals("not"))
                            {
                                PDFFileTestEngine.VerifyTextExistsInPdfFile(filePath, variableValue, false, optional);
                            }
                            else
                            {
                                PDFFileTestEngine.VerifyTextExistsInPdfFile(filePath, variableValue, true, optional);
                            }

                            break;
                        }

                    case "Capture Element Text":
                        {
                            var ids = ObjectRepositoryManager.CombineElementIdentifiers(elementName);
                            var elementText = TestDriver.Retrievers_GetObjectText(ids, optional);

                            if (elementText.Length > 0)
                            {
                                DataDriver.AddRuntimeDataValueByName(variableName, elementText);
                            }
                            else
                            {
                                if (optional)
                                {
                                    GlobalReporter.ReportInfo("Text could not be caputed for element: " + elementName);
                                }
                                else
                                {
                                    GlobalReporter.ReportFailure("Text could not be caputed for element: " + elementName);
                                }

                            }

                            break;
                        }

                    case "Capture Element Attribute Value":
                        {
                            var ids = ObjectRepositoryManager.CombineElementIdentifiers(elementName);
                            var attributeValue = TestDriver.Retrievers_GetObjectAttributeByName(ids, variableValue, optional);

                            if (attributeValue.Length > 0)
                            {
                                DataDriver.AddRuntimeDataValueByName(variableName, attributeValue);
                            }
                            else
                            {
                                if (optional)
                                {
                                    GlobalReporter.ReportInfo("Value of attribute: " + variableValue + ", could not be caputed for element: " + elementName);
                                }
                                else
                                {
                                    GlobalReporter.ReportFailure("Value of attribute: " + variableValue + ", could not be caputed for element: " + elementName);
                                }

                            }

                            break;
                        }

                    default:
                        {
                            GlobalReporter.ReportWarning("Current action:  " + action + ", has not been mapped to an executable step. Please make sure you are using correct test template.");
                            break;
                        }
                }
            }
        }

        private static bool TryAction(Action action)
        {
            try
            {
                action.Invoke();
                return true;
            }
            catch (Exception)
            {
                //Do Nothing
            }

            return false;
        }

    }

    public static class CustomUtilities
    {

        public static string GenerateDateBasedOnParameter(string parameter)
        {

            if (string.IsNullOrEmpty(parameter))
            {
                return Utilities.Utility_GetCurrentDateAsStandardFormattedString(Constants.dateFormat);
            }

            if (parameter.Equals("eom"))
            {
                return moveToEndOfMonthToString(DateTime.Now);
            }

            var quantity = parameter.Substring(0, 1);
            var direction = parameter.Substring(1, 1);
            Int32.TryParse(parameter.Substring(2), out int amount);

            var returnDate = "";
            if (direction.Equals("-"))
            {
                amount = amount * -1;
            }

            //GlobalReporter.ReportInfo(">>>>>>>> quantity: " + quantity + ", direction: "  + direction + ", amount: " + amount);
            switch (quantity)
            {
                case "d":
                    {
                        returnDate = Utilities.Utility_GetCurrentDate().AddDays(amount).ToString(Constants.dateFormat);
                        break;
                    }

                case "m":
                    {
                        returnDate = Utilities.Utility_GetCurrentDate().AddMonths(amount).ToString(Constants.dateFormat);
                        break;
                    }

                case "y":
                    {
                        returnDate = Utilities.Utility_GetCurrentDate().AddYears(amount).ToString(Constants.dateFormat);
                        break;
                    }

                default:
                    {
                        returnDate = Utilities.Utility_GetCurrentDateAsStandardFormattedString(Constants.dateFormat);
                        break;
                    }
            }

            return returnDate;
        }


        public static string generateDate(int age, string value)
        {

            int year = Utilities.Utility_GetCurrentDate().AddYears(age).Year;

            var newValue = "";
            if (DataDriver.IsRuntimeDataValuePresent(value))
            {
                newValue = DataDriver.GetRuntimeDataValueByName(value);
                value = newValue;
            }
            else
            {
                var _month = Utilities.Utility_GenerateRandomNumberInRange(1, 12);
                var _date = Utilities.Utility_GenerateRandomNumberInRange(1, 28);
                var _year = Utilities.Utility_GenerateRandomNumberInRange(year, year);

                newValue = string.Format("{0}/{1}/{2}", _date, _month, _year);
                DataDriver.AddRuntimeDataValueByName(value, newValue);
                value = newValue;
            }

            return value;
        }

        public static String moveToEndOfMonthToString(DateTime date)
        {
            DateTime endDate = new DateTime(date.Year, date.Month,
                    DateTime.DaysInMonth(date.Year, date.Month));
            return endDate.ToString("d/M/yyyy").Trim();
        }

        public static String moveToFirstOfMonthToString(DateTime date)
        {
            DateTime startDate = new DateTime(date.Year, date.Month, 1);
            return startDate.ToString("d/M/yyyy").Trim();

        }

    }
}

