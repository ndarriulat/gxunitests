﻿using GXtest;
namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var clientPort = new GxTestCommands();

            //clientPort.StartRemote("http://192.168.0.242:4444/wd/hub/");
            // Sauce Labs (http://YOUR_USERNAME:YOUR_ACCESS_KEY@ondemand.saucelabs.com/wd/hub)
            //clientPort.StartCloudExecution("http://ondemand.saucelabs.com/wd/hub", "Chrome", "ndarriulat", "1c1dd7f3-494f-4aa8-9352-e1a54933e958");
            //clientPort.SetLocation(@"C:\Models\gxtest\CSharpModel\web\bin");
            clientPort.StartLocal();
            //clientPort.Go("http://192.168.0.156/UnitTests2.NetEnvironment/person.aspx");      
            //bool ok =clientPort.AppearText("Persossn");
            clientPort.Go("http://apps5.genexus.com/Id4a621093eec500c52b22f8b688e172ef/factura.aspx");
            
            clientPort.SendKeysByName("FACTURARAZONSOCIAL", "1891");

            clientPort.End();
        }
        
    }
}
