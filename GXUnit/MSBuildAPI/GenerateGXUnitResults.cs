using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Artech.Architecture.Common.Services;
using Artech.Genexus.Common;
using Artech.MsBuild.Common;
using Microsoft.Build.Framework;
using PGGXUnit.Packages.GXUnit.GeneXusAPI;

namespace PGGXUnit.Packages.GXUnit.MSBuildAPI
{
    public class GenerateGXUnitResults : ArtechTask
    {
        private string kbPath;
        //private string xmlName;

        //[Required]
        //public string Path
        //{
        //    get { return kbPath; }
        //    set { kbPath = value; }
        //}

        //[Required]
        //public string XMLName
        //{
        //    get { return xmlName; }
        //    set { xmlName = value; }
        //}

        public override bool Execute()
       {
            OutputSubscribe();
            CommonServices.Output.StartSection("Generate GXUnit Results Task");

            string kbPath=this.KB.Location;
            string temporalResultsPath = Path.Combine(kbPath, "CSharpModel\\web");

            ManejadorResultado mr = ManejadorResultado.GetInstance();
            // TODO: return this output path
            string outputPath = mr.CreateResult(ManejadorContexto.LastXMLName, temporalResultsPath);

            ManejadorProcedimiento mp = new ManejadorProcedimiento();
            mp.EliminarProcedimiento("RunnerProcedure");

            CommonServices.Output.EndSection("Generate GXUnit Results Task", true);
            OutputUnsubscribe();
            return true;
        }
    }
}
