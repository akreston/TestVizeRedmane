using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TestAutomation.BaseFramework;

namespace TestAutomation.TestSuite.FrontEnd
{
    public static class SharedSteps
    {

        public static void executeTestStepsBasedOnTestData(Dictionary<string, List<string>> testData)
        {

            ////Acquire number of test data rows to process
            //var numberOfRows = testData.ContainsKey(testFileDataTabs.Locator.ToString()) ? testData[testFileDataTabs.Locator.ToString()].Count : 0;

            ////Loop through all data rows
            //for (var row = 0; row < numberOfRows; ++row)
            //{
            //    //Get necessary object attributes and test data from current row
            //    var stepDescription = testData[testFileDataTabs.StepDescription.ToString()][row];
            //    stepDescription = stepDescription.Length > 0 ? stepDescription : "Please provide step description.";
            //    var tagName = testData[testFileDataTabs.TagName.ToString()][row];
            //    var attribute = testData[testFileDataTabs.Attribute.ToString()][row];
            //    var locator = testData[testFileDataTabs.Locator.ToString()][row];
            //    var parameter = testData.ContainsKey(testFileDataTabs.Parameter.ToString()) ? testData[testFileDataTabs.Parameter.ToString()][row] : "";
            //    var value = testData[testFileDataTabs.Value.ToString()][row];
            //    var index = testData[testFileDataTabs.Index.ToString()][row];
            //    var special = testData[testFileDataTabs.Special.ToString()][row];

            //    //Gather verification infromation from current row
            //    var verificationText = testData[testFileDataTabs.VerificationText.ToString()][row];
            //    var verificationAttribute = testData[testFileDataTabs.VerificationAttribute.ToString()][row];
            //    var verificationLocator = testData[testFileDataTabs.VerificationLocator.ToString()][row];

            //    // If a secial function is marked as conditional
            //    // first check if the locator exists
            //    bool isConditional = false;
            //    if (special.StartsWith("?"))
            //    {
            //        isConditional = true;
            //        special = special.Remove(0, 1);
            //    }

            //    switch (special)
            //    {
            //        //Delay test execution if a keyword is found
            //        case "DelayTest":
            //            {
            //                TestDriver.Utilities_DelayTestExecution(Utilities.Utility_ExtractIntegerValueFromString(value));
            //                continue;
            //            }

            //        //Generate and save random string for future reuse
            //        case "RandomValue":
            //            {
            //                var newValue = "";
            //                if (DataDriver.IsRuntimeDataValuePresent(value))
            //                {
            //                    newValue = DataDriver.GetRuntimeDataValueByName(value);
            //                    value = newValue;
            //                }
            //                else
            //                {
            //                    newValue = Utilities.Utility_GenerateRandomStringWithLengthInRange(4, 8);
            //                    DataDriver.AddRuntimeDataValueByName(value, newValue);
            //                    value = newValue;
            //                }
            //                GlobalReporter.ReportInfo("Using random value: " + value);
            //                break;
            //            }

            //        // *****************************
            //        // START - LNel

            //        //Generate and save random date
            //        case "RandomDate":
            //            {

            //                var newValue = "";
            //                if (DataDriver.IsRuntimeDataValuePresent(value))
            //                {
            //                    newValue = DataDriver.GetRuntimeDataValueByName(value);
            //                    value = newValue;
            //                }
            //                else
            //                {
            //                    newValue = MyUtilities.getDateFromParameter(parameter);
            //                    DataDriver.AddRuntimeDataValueByName(value, newValue);
            //                    value = newValue;
            //                }

            //                GlobalReporter.ReportInfo("Using random date: " + value);
            //                break;
            //            }


            //        case "Tab":
            //            {
            //                TestDriver.Actions_PressTab();
            //                continue;
            //            }

            //        case "RandomValueAge2":
            //            {
            //                value = MyUtilities.generateDate(-2, value);
            //                GlobalReporter.ReportInfo("Using random value: " + value);
            //                break;
            //            }
            //        case "RandomValueAge24":
            //            {
            //                value = MyUtilities.generateDate(-24, value);
            //                GlobalReporter.ReportInfo("Using random value: " + value);
            //                break;
            //            }
            //        case "RandomValueAge22":
            //            {
            //                value = MyUtilities.generateDate(-22, value);
            //                GlobalReporter.ReportInfo("Using random value: " + value);
            //                break;
            //            }

            //        // END - LNel
            //        // *****************************

            //        //Take custom screen shot
            //        case "TakeScreenshot":
            //            {
            //                GlobalReporter.TakeScreenShot(stepDescription);
            //                continue;
            //            }

            //    }


            //    //This portion will execute actionable steps or skip of locator value is missing
            //    if (locator.Length == 0) { continue; }

            //    //Create xpath locator to find object on page
            //    var objectXPath = Utilities.Utilities_BuildXpathByAttributeNameAndValue(attribute, locator, tagName.Length > 0 ? tagName : "*");

            //    //Create locator to find element by text
            //    if (attribute.Equals("text"))
            //    {
            //        objectXPath = Utilities.Utilities_BuildXpathByTextValueAndTagName(locator, tagName.Length > 0 ? tagName : "*");
            //    }

            //    //Update locator if it needs to find partial match for attribute value or text
            //    if (special.Equals("PartialMatch"))
            //    {
            //        if (attribute.Equals("text"))
            //        {
            //            objectXPath = Utilities.Utilities_BuildXpathByPartialTextValueAndTagName(locator, tagName.Length > 0 ? tagName : "*");
            //        }
            //        else
            //        {
            //            objectXPath = Utilities.Utilities_BuildPartialMatchXpathByAttributeNameAndValue(attribute, locator, tagName.Length > 0 ? tagName : "*");
            //        }
            //    }

            //    //Overwite with custom locator if necessary
            //    if (attribute.Equals("CustomLocator"))
            //    {
            //        // ****************
            //        // start LNel
            //        if (value.Length > 0 && DataDriver.IsRuntimeDataValuePresent(value))
            //        {
            //            locator = locator.Replace(value, DataDriver.GetRuntimeDataValueByName(value));
            //            //lobalReporter.ReportInfo("********Locator: " + locator + " , objectXPath: " + objectXPath);
            //        }

            //        // end LNel
            //        // ****************
            //        objectXPath = locator;
            //    }

            //    //Add index to locator is it matches more than one element
            //    if (index.Length > 0)
            //    {
            //        objectXPath = string.Format("({0})[{1}]", objectXPath, index);
            //    }

            //    //Debug code do not use unless debugging your locators
            //    //GlobalReporter.ReportInfo("********Locator: " + locator + " , objectXPath: " + objectXPath);
            //    //var objectTagName = TestDriver.Retrievers_GetObjectTagName(By.XPath(objectXPath));
            //    //GlobalReporter.ReportInfo(objectTagName);


            //    if (isConditional)
            //    {
            //        if (!TestDriver.Surveys_DoesObjectExist(By.XPath(objectXPath)))
            //        {
            //            continue;
            //        }
            //    }


            //    //Switch special step execution commands
            //    switch (special)
            //    {
            //        //Select option from drop down by text value
            //        case "DropDown":
            //            {
            //                TestDriver.Actions_SelectOptionFromDropDownByText(By.XPath(objectXPath), value, "Select: " + value + ", from dropdown. " + stepDescription);
            //                break;
            //            }

            //        //Enter current date into text field
            //        case "CurrentDate":
            //            {
            //                //var currentDate = Utilities.Utility_GetDateStringFromDateTime(Utilities.Utility_GetCurrentDate());
            //                var currentDate = Utilities.Utility_GetCurrentDateAsStandardFormattedString(Constants.dateFormat);
            //                TestDriver.Actions_EnterText(By.XPath(objectXPath), currentDate, "Enter: " + currentDate + ". " + stepDescription);
            //                break;
            //            }

            //        // *****************************
            //        // START - LNel

            //        case "EnterTextAndTab":
            //            {
            //                TestDriver.Actions_ClickOnObject(By.XPath(objectXPath), "Enter: " + value + ". " + stepDescription);
            //                TestDriver.Actions_ClearText(By.XPath(objectXPath), "Enter: " + value + ". " + stepDescription);
            //                TestDriver.Actions_EnterTextInActiveWindowAndPressTab(value);
            //                break;
            //            }

            //        case "RightClick":
            //            {
            //                TestDriver.Actions_RightClickOnObject(By.XPath(objectXPath), "Right Click on object: " + objectXPath + ". " + stepDescription);
            //                break;
            //            }

            //        case "Click":
            //            {
            //                TestDriver.Actions_ClickOnObject(By.XPath(objectXPath), stepDescription);
            //                break;
            //            }

            //        case "SwitchToFrame":
            //            {
            //                TestDriver.SwitchToFrameByLocator(By.XPath(objectXPath), stepDescription);
            //                break;
            //            }

            //        case "Verify":
            //            {
            //                IWebElement element = TestDriver.Public_GetWebElement(By.XPath(objectXPath));

            //                if (element != null)
            //                {
            //                    var js = TestDriver.CreateWebDriverJavascriptExecutor();
            //                    js.ExecuteScript("arguments[0].setAttribute('style', 'border: 2px solid red;');", element);
            //                }

            //                //TestDriver.HighlightElement(element);

            //                var actualValue = TestDriver.Retrievers_GetObjectText(By.XPath(objectXPath));
            //                TestDriver.Assertions_CompareTwoTextValues(actualValue, verificationText, stepDescription);
            //                verificationText = "";
            //                break;
            //            }

            //        case "VerifyTable":
            //            {

            //                var table = TestDriver.Retrievers_ReadWebTableWithHeaders(By.XPath(objectXPath), stepDescription);

            //                if (parameter == null || parameter.Split(Constants.seperator).Length < 2)
            //                {
            //                    GlobalReporter.ReportWarning("Parameter must not be null.  Enter column name and row number seperated by " + Constants.seperator);
            //                }
            //                else
            //                {

            //                    string[] parameters = parameter.Split(Constants.seperator);

            //                    var colName = parameters[0];
            //                    if (parameters[1].Equals("*"))
            //                    {
            //                        // check if every row is 'Eligible'
            //                        foreach (var currentRow in table)
            //                        {
            //                            TestDriver.Assertions_CompareTwoTextValues(
            //                                Utilities.Utility_GetOptionalValueFromDictionaryByKey(currentRow, colName),
            //                                verificationText, stepDescription);
            //                        }
            //                    }
            //                    else
            //                    {
            //                        Int32.TryParse(parameters[1], out int rowNum);
            //                        TestDriver.Assertions_CompareTwoTextValues(
            //                         Utilities.Utility_GetOptionalValueFromDictionaryByKey(table[rowNum], colName),
            //                            verificationText, "2-" + stepDescription);
            //                    }
            //                }

            //                continue;
            //            }

            //        case "VerifyEligPeriod":
            //            {

            //                var table = TestDriver.Retrievers_ReadWebTableWithHeaders(By.XPath(objectXPath), stepDescription);

            //                // get the application date
            //                DateTime appDate;
            //                if (value.Length > 0 && DataDriver.IsRuntimeDataValuePresent(value))
            //                {
            //                    appDate = Utilities.Utility_ConvertStringToDateTime(DataDriver.GetRuntimeDataValueByName(value));
            //                }
            //                else
            //                {
            //                    appDate = Utilities.Utility_GetCurrentDate();
            //                }

            //                // get 1st occurance - this will have the start date 
            //                var lastRow = Utilities.Utility_GetOptionalValueFromDictionaryByKey(table[0], "Coverage Period");
            //                var startDate = MyUtilities.moveToFirstOfMonthToString(appDate);
            //                if (!lastRow.Contains(startDate))
            //                {
            //                    TestDriver.Assertions_CompareTwoTextValues(startDate, lastRow, stepDescription);
            //                }

            //                // get last occurance - this will have the end date 
            //                var firstRow = Utilities.Utility_GetOptionalValueFromDictionaryByKey(table[table.Count - 1], "Coverage Period");
            //                var endDate = MyUtilities.moveToEndOfMonthToString(appDate.AddMonths(11));
            //                if (!firstRow.Contains(endDate))
            //                {
            //                    TestDriver.Assertions_CompareTwoTextValues(endDate, firstRow, stepDescription);
            //                }

            //                continue;
            //            }



            //        // END - LNel
            //        // *****************************

            //        //Click on an object and wait for a condition multiple times until condition is met or number of attempts exceeded maximum
            //        case "ClickAndWait":
            //            {
            //                var waitIsOver = false;
            //                var attempts = 0;
            //                TestDriver.Actions_ClickOnObject(By.XPath(objectXPath), stepDescription);
            //                do
            //                {
            //                    if (verificationText.Length > 0)
            //                    {
            //                        if (TestDriver.Surveys_DoesTextExistsOnPageByFullTextValue(verificationText))
            //                        {
            //                            waitIsOver = true;
            //                        }
            //                    }

            //                    if (verificationAttribute.Length > 0 && verificationLocator.Length > 0)
            //                    {
            //                        var verificationObjectXPath = Utilities.Utilities_BuildXpathByPartialTextValueAndTagName(verificationLocator);
            //                        if (TestDriver.Surveys_IsObjectVisible(By.XPath(verificationObjectXPath)))
            //                        {
            //                            waitIsOver = true;
            //                            break;
            //                        }
            //                    }

            //                    TestDriver.Utilities_DelayTestExecution(5);
            //                    TestDriver.Actions_ClickOnObject(By.XPath(objectXPath), stepDescription);
            //                    ++attempts;

            //                } while (!waitIsOver && attempts < 9);

            //                if (!waitIsOver)
            //                {
            //                    GlobalReporter.ReportFailure("Click and Wait funcionality failed due to exceeded number of attempts. " + stepDescription);
            //                }
            //                break;
            //            }

            //        //Save data into run time storage
            //        case "SaveData":
            //            {
            //                var acquiredData = TestDriver.Retrievers_GetObjectText(By.XPath(objectXPath));
            //                DataDriver.AddRuntimeDataValueByName(value, acquiredData);
            //                GlobalReporter.ReportInfo("Save data: " + acquiredData + " to field: " + value);
            //                continue;
            //            }


            //        //Execute step if no special command found
            //        default:
            //            {
            //                if (value.Length > 0)
            //                {
            //                    TestDriver.Actions_EnterText(By.XPath(objectXPath), value, "Enter: " + value + ". " + stepDescription);
            //                }
            //                else
            //                {
            //                    TestDriver.Actions_ClickOnObject(By.XPath(objectXPath), stepDescription);
            //                }
            //                break;
            //            }
            //    }

            //    //DIsmiss alert if present
            //    TestDriver.Actions_HandleAlert(true, true);

            //    //Verification steps
            //    if (verificationText.Length > 0)
            //    {
            //        TestDriver.Utilities_DelayTestExecution(5);
            //        TestDriver.Assertions_VerifyTextExistsOnPageByFullTextValue(verificationText);
            //    }

            //    if (verificationAttribute.Length > 0 && verificationLocator.Length > 0)
            //    {
            //        var verificationObjectXPath = Utilities.Utilities_BuildXpathByAttributeNameAndValue(verificationAttribute, verificationLocator);
            //        TestDriver.Assertions_VerifyObjectVisibility(By.XPath(verificationObjectXPath));
            //    }
            }

        }

    }

    //public static class MyUtilities
    //{

    //    public static string getDateFromParameter(String parameter)
    //    {

    //        if (String.IsNullOrEmpty(parameter))
    //        {
    //            return Utilities.Utility_GetCurrentDateAsStandardFormattedString(Constants.dateFormat);
    //        }

    //        if (parameter.Equals("eom"))
    //        {
    //            return moveToEndOfMonthToString(DateTime.Now);
    //        }

    //        var quantity = parameter.Substring(0, 1);
    //        var direction = parameter.Substring(1, 1);
    //        Int32.TryParse(parameter.Substring(2), out int amount);

    //        var returnDate = "";
    //        if (direction.Equals("-"))
    //        {
    //            amount = amount * -1;
    //        }

    //        //GlobalReporter.ReportInfo(">>>>>>>> quantity: " + quantity + ", direction: "  + direction + ", amount: " + amount);
    //        switch (quantity)
    //        {
    //            case "d":
    //                {
    //                    returnDate = Utilities.Utility_GetCurrentDate().AddDays(amount).ToString(Constants.dateFormat);
    //                    break;
    //                }

    //            case "m":
    //                {
    //                    returnDate = Utilities.Utility_GetCurrentDate().AddMonths(amount).ToString(Constants.dateFormat);
    //                    break;
    //                }

    //            case "y":
    //                {
    //                    returnDate = Utilities.Utility_GetCurrentDate().AddYears(amount).ToString(Constants.dateFormat);
    //                    break;
    //                }

    //            default:
    //                {
    //                    returnDate = Utilities.Utility_GetCurrentDateAsStandardFormattedString(Constants.dateFormat);
    //                    break;
    //                }
    //        }

    //        return returnDate;
    //    }


    //    public static string generateDate(int age, string value)
    //    {

    //        int year = Utilities.Utility_GetCurrentDate().AddYears(age).Year;

    //        var newValue = "";
    //        if (DataDriver.IsRuntimeDataValuePresent(value))
    //        {
    //            newValue = DataDriver.GetRuntimeDataValueByName(value);
    //            value = newValue;
    //        }
    //        else
    //        {
    //            var _month = Utilities.Utility_GenerateRandomNumberInRange(1, 12);
    //            var _date = Utilities.Utility_GenerateRandomNumberInRange(1, 28);
    //            var _year = Utilities.Utility_GenerateRandomNumberInRange(year, year);

    //            newValue = string.Format("{0}/{1}/{2}", _date, _month, _year);
    //            DataDriver.AddRuntimeDataValueByName(value, newValue);
    //            value = newValue;
    //        }

    //        return value;
    //    }

    //    public static String moveToEndOfMonthToString(DateTime date)
    //    {
    //        DateTime endDate = new DateTime(date.Year, date.Month,
    //                DateTime.DaysInMonth(date.Year, date.Month));
    //        return endDate.ToString("d/M/yyyy").Trim();
    //    }

    //    public static String moveToFirstOfMonthToString(DateTime date)
    //    {
    //        DateTime startDate = new DateTime(date.Year, date.Month, 1);
    //        return startDate.ToString("d/M/yyyy").Trim();

    //    }

    //}

