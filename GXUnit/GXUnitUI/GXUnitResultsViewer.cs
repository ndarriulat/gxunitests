﻿/*
 2017-04-19 LAZ Added Linq to sort files in folder by date-desc @PopulateListBox
 */

using Artech.Architecture.UI.Framework.Packages;
using Artech.Architecture.UI.Framework.Services;
using Artech.Common.Framework.Selection;
using Artech.FrameworkDE;
using PGGXUnit.Packages.GXUnit.GeneXusAPI;
using PGGXUnit.Packages.GXUnit.GXUnitCore;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;
using System.Linq;

namespace PGGXUnit.Packages.GXUnit.GXUnitUI
{
    [Guid("3be58cf9-b38c-4dab-a42f-80389fb3040d")]
    public partial class GXUnitResultsViewer : AbstractToolWindow, ISelectionListener // UserControl
    {

        public static Guid guid = typeof(GXUnitResultsViewer).GUID;
        private static GXUnitResultsViewer instance = new GXUnitResultsViewer();

        public GXUnitResultsViewer()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            PopulateListBox();
        }

        private void GXUnitResults_OnLoad(object sender, EventArgs e)
        {
            PopulateListBox();
        }

        public static GXUnitResultsViewer getInstance()
        {
            return instance;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    int i = listView1.SelectedIndices[0];

                    String fileName = listView1.Items[i].Text;

                    //using System.IO;  
                    string path = GxuHelper.GetResultsPath();

                    // TODO: change this as it is a temporal fix for Results Viewer
                    path=path.Replace("GXUnitResults\\", "");

                    string myFile = Path.Combine(path, fileName);

                    tbLabel.Text = "Results: " + fileName;
                    string xmlFile = myFile;

                    String gxPath = Environment.GetEnvironmentVariable("GX_PROGRAM_DIR");
                    gxPath = gxPath.Trim() + "\\Packages\\GxUnit\\";
                    string xslFile = Path.Combine(gxPath, "GXUnitSummary.xsl");

                    if ( File.Exists(xslFile))
                        {

                        XslCompiledTransform xslDocument = new XslCompiledTransform();
                        xslDocument.Load(xslFile);
                        StringWriter stringWriter = new StringWriter();
                        XmlWriter xmlWriter = new XmlTextWriter(stringWriter);
                        xslDocument.Transform(xmlFile, xmlWriter);
                        webBrowser1.DocumentText = stringWriter.ToString();
                    }
                    else {
                        webBrowser1.DocumentText = "Transformation file not found at " + xslFile;
                    }
                }
            }
            catch (Exception ex)
            {
                GxHelper.WriteOutput("ListView_Select:" + ex.Message);
                CleanBrowser();
            }
        }

        private void CleanBrowser()
        {
            tbLabel.Text = "Results";
            webBrowser1.DocumentText = "";
        }

        public void PopulateListBox()
        {

            try
            {
                if (UIServices.KB.CurrentKB != null)
                {
                    string path = GxuHelper.GetResultsPath();
                    string fileType = "*.xml";
                    DirectoryInfo dinfo = new DirectoryInfo(path);
                    FileInfo[] files = dinfo.GetFiles(fileType).OrderByDescending(p => p.CreationTime).ToArray(); ;

                    listView1.Items.Clear();
                    listView1.Columns.Clear();

                    listView1.View = View.Details;
                    listView1.Columns.Add("Result File");

                    foreach (FileInfo file in files)
                    {

                        listView1.Items.Add(file.Name);
                    }
                    listView1.Columns[0].Width = listView1.Width -4;

                }
            }
            catch (Exception e)
            {
                GxHelper.WriteOutput(e.Message);
            }
        }

        public bool OnSelectChange(ISelectionContainer pSC)
        {

            if (!string.IsNullOrEmpty(ManejadorContexto.KBName) && ManejadorContexto.Model != null)
            {
                try
                {
                    this.PopulateListBox();
                }
                catch (Exception e)
                {
                    GxHelper.WriteOutput(e.StackTrace);
                }
            }
            return true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           PopulateListBox();
        }

      

        //public bool OnSelectChange(ISelectionContainer pSC)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
