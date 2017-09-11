using PGGXUnit.Packages.GXUnit.GeneXusAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGGXUnit.Packages.GXUnit.GXUnitCore
{
    static class GxuHelper
    {

        public static String GetResultsPath()
        {
            String kbPath = KBManager.getTargetPath();
            String resultPath = kbPath.Trim() + Constantes.RESULT_PATH;
            return resultPath;
        }
    }
}
