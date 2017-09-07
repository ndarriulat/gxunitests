using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PGGXUnit.Packages.GXUnit.Utils
{
    public interface IXmlFormatter
    {
        /// <summary>
        /// Converts the given xml to a specific format. 
        /// </summary>
        /// <param name="originalXml">Path of the given xml.</param>
        /// <param name="formattedXmlPath">Path of the new xml, with the applied format.</param>
        /// <returns></returns>
        void ConvertXml(string originalXmlPath,string formattedXmlPath);
    }
}
