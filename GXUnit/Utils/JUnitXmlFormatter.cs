using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PGGXUnit.Packages.GXUnit.Utils
{
    class JUnitXmlFormatter : IXmlFormatter
    {
        /// <summary>
        /// Converts a Genexus SDT xml into a xml file with JUnit format.
        /// </summary>
        /// <param name="originalXmlPath">Path of the xml to be formatted.</param>
        /// <param name="formattedXmlPath">Output path of the xml with JUnit format.</param>
        public void ConvertXml(string originalXmlPath, string formattedXmlPath)
        {
            // Load the original xml document
            XmlDocument originalDocument = new XmlDocument();
            originalDocument.Load(originalXmlPath);

            // Get all suites from the original xml            
            XmlNodeList gxUnitSuitesNodes = originalDocument.SelectNodes("//Suites//Suite//Suite");


            // Create XmlDocument for the new xml file
            XmlDocument formattedDocument = new XmlDocument();
            // In JUnit format, it always starts with <testsuites> node
            XmlElement testsuitesRoot = formattedDocument.CreateElement("testsuites");

            // Create a <testsuite> for each suite existing in GXUnit, counting the amount of failure and successful tests
            foreach (XmlNode gxUnitSuite in gxUnitSuitesNodes)
            {
                // Get suite name from the original xml
                string suiteName = gxUnitSuite.FirstChild.InnerText;
                XmlElement testSuiteElement = formattedDocument.CreateElement("testsuite");
                testSuiteElement.SetAttribute("name", suiteName);

                // Iterate through the test cases inside the GXUnit Suite
                IterateSuiteTestCases(gxUnitSuite, formattedDocument, suiteName, ref testSuiteElement);

                testsuitesRoot.AppendChild(testSuiteElement);
            }

            // Append <testsuites> node to the new document
            formattedDocument.AppendChild(testsuitesRoot);

            // Saves the new document in the specified directory
            formattedDocument.Save(formattedXmlPath);
        }

        /// <summary>
        /// Iterates through all tests case inside the suite, and adds a <testcase> node for every test.
        /// </summary>
        /// <param name="gxUnitSuite">The suite created with GXUnit.</param>
        /// <param name="suiteName">Name of the given suite</param>
        /// <param name="suiteElement">Suite element generated with JUnit format.</param>
        private static void IterateSuiteTestCases(XmlNode gxUnitSuite, XmlDocument formattedDocument, string suiteName, ref XmlElement suiteElement)
        {
            double suiteExecutionTime = 0;
            int totalTestsCount = 0;
            int failureTestsCount = 0;
            //int errorTestsCount = 0;
            //int skippedTestsCount = 0;

            // Get all the test cases nodes for the given suite
            XmlNodeList gxUnitTestCasesList = gxUnitSuite.
                SelectNodes("//SuiteName[text()[contains(.,'" + suiteName + "')]]//..//TestCases//TestCase//TestCase");

            // Set the total amount of test cases inside the suite
            totalTestsCount = gxUnitTestCasesList.Count;
            suiteElement.SetAttribute("tests", totalTestsCount + "");

            //foreach (XmlNode gxUnitTestCase in gxUnitTestCasesList)
            for (int i = 0; i < gxUnitTestCasesList.Count; i++)
            {
                int failedTestCaseAssertions = 0;
                double testCaseExecutionTime = 0;

                // Create test case node 
                XmlElement testCaseElement = formattedDocument.CreateElement("testcase");

                // Get <TestCase> node
                XmlNode testCaseNode = gxUnitTestCasesList[i];
                // Get text in <TestName> node
                string testCaseName = testCaseNode.ChildNodes[0].InnerText;
                // Set test case name
                testCaseElement.SetAttribute("name", testCaseName);

                // Get value in <TestTimeExecution> node
                testCaseExecutionTime = double.Parse(testCaseNode.ChildNodes[1].InnerText);
                // Convert time from miliseconds to seconds
                double testCaseExecutionTime_Seconds = testCaseExecutionTime / 1000;
                // Set test time execution
                testCaseElement.SetAttribute("time", testCaseExecutionTime_Seconds.ToString().Replace(',', '.'));

                // Set className in order to display a package name in Jenkins
                testCaseElement.SetAttribute("classname", suiteName + "." + testCaseName);

                // Get a list of assertions, which could match this relative XPath: "//Asserts//Assert//Assert"
                XmlNodeList testCaseAssertionsList = testCaseNode.ChildNodes[2].ChildNodes;
                IterateTestCaseAssertions(testCaseAssertionsList, formattedDocument, ref testCaseElement, out failedTestCaseAssertions);

                suiteExecutionTime += testCaseExecutionTime;
                // No matter how many assertions fail, the test failure is counted as only one in the total suite failures
                if (failedTestCaseAssertions > 0)
                {
                    failureTestsCount++;
                }
                suiteElement.AppendChild(testCaseElement);
            }
            suiteElement.SetAttribute("failures", failureTestsCount + "");
            suiteElement.SetAttribute("errors", "0");

            // Convert time from miliseconds to seconds
            double suiteExecutionTime_Seconds = suiteExecutionTime / 1000;
            suiteElement.SetAttribute("time", suiteExecutionTime_Seconds.ToString().Replace(',', '.'));
        }

        /// <summary>
        /// Iterates through all the test case assertions, adding a <failure> node for every failed assertion. 
        /// Also, sets the total amount of failed assertions in the given test case.
        /// </summary>
        /// <param name="testCaseAssertionsList">The assertions results for a given test case.</param>
        /// <param name="formattedDocument">The new document with JUnit format.</param>
        /// <param name="testCaseElement">A given test case element generated with JUnit format.</param>
        /// <param name="failedTestCaseAssertions">Amount of failed assertions in the test case.</param>
        /// <param name="testCaseExecutionTime">Total test case execution time</param>
        private static void IterateTestCaseAssertions(XmlNodeList testCaseAssertionsList, XmlDocument formattedDocument,
            ref XmlElement testCaseElement, out int totalFailedAssertions)
        {
            totalFailedAssertions = 0;

            foreach (XmlNode assertionNodeParent in testCaseAssertionsList)
            {
                // Go to the first child as the xml generates two consecutive <Assert> nodes
                XmlNode assertionNode = assertionNodeParent.ChildNodes[0];

                // Get inner text from <ObtainedValue>
                string assertionResult = assertionNode.ChildNodes[0].InnerText;
                if (assertionResult == "FAIL")
                {
                    // Increment the total amount of failed assertion in the given test case
                    totalFailedAssertions++;

                    XmlElement failureElement = formattedDocument.CreateElement("failure");
                    failureElement.SetAttribute("message", "Assertion FAILED");

                    // Obtain assertion expected and obtained values
                    // Get <GXUnitAssertInfo> node
                    XmlNode gxUnitAssertInfoNode = assertionNode.ChildNodes[1].ChildNodes[0];
                    // Get <Expected> node
                    string assertionExpectedValue = gxUnitAssertInfoNode.ChildNodes[0].InnerText;
                    // Get <Obtained> node
                    string assertionObtainedValue = gxUnitAssertInfoNode.ChildNodes[1].InnerText;

                    // Set assertion expected and obtained values
                    failureElement.InnerText = "Expected: " + assertionExpectedValue;
                    failureElement.InnerText += ", Obtained: " + assertionObtainedValue;

                    testCaseElement.AppendChild(failureElement);

                    // If there was a failed assertion, there should not exist any other more, 
                    // as it stops the test cases execution
                    break;

                    // TODO: change GXUnit code so that it stops when the first assertion fails
                }
                // TODO: Use SKIPPED and ERROR JUnit results
            }
        }
    }
}
