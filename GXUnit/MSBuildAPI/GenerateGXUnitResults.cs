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

        [Required]
        public string KBPath
        {
            get { return kbPath; }
            set { kbPath = value; }
        }

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

            //ManejadorContexto.Model = KB.DesignModel;
            FuncionesAuxiliares.EscribirOutput("LastXMLName: " + ManejadorContexto.LastXMLName);
            ManejadorResultado mr = ManejadorResultado.GetInstance();
            string outputPath = mr.CreateResult(ManejadorContexto.LastXMLName, KBPath);
            //GxModel modelo = KBManager.getTargetModel();
            //string xmlPath = Path.Combine(modelo.WebTargetFullPath, xmlName);

            ManejadorProcedimiento mp = new ManejadorProcedimiento();
            mp.EliminarProcedimiento("RunnerProcedure");

            CommonServices.Output.EndSection("Generate GXUnit Results Task", true);
            OutputUnsubscribe();
            return true;
        }
    }
}
