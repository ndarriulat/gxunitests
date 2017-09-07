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
        public void ConvertXml(string originalXmlPath, string formattedXmlPath)
        {
            //XmlDocument originalDocument = new XmlDocument();
            //originalDocument.LoadXml(@"C:\Models\SecondGxApp_KB\CSharpModel\web\GXUnitResults\R_20170905_160947.xml");

            //// Create XmlDocument for the new xml file
            //XmlDocument formattedDocument = new XmlDocument();
            //// In JUnit format, it always starts with <testsuites> node
            //XmlElement testsuitesElement=formattedDocument.CreateElement("testsuites");

            //// Get all suites from the original xml
            //// Nodes with text GXUnitSuites are not included because it is the root folder for test suites, 
            //// and it won't have test cases in it.
            //XmlNodeList gxUnitSuitesNodes = originalDocument.SelectNodes("//SuiteName[text()[not(contains(.,'GXUnitSuites'))]]");
            
        }
    }
}
