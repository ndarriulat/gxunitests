using GXtest;
namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var clientPort = new GxTestCommands();
            //clientPort.StartRemote("http://192.168.0.242:4444/wd/hub/");
            clientPort.SetLocation(@"C:\Models\gxtest\CSharpModel\web\bin");
            clientPort.Start();
            clientPort.Go("http://192.168.0.156/UnitTests2.NetEnvironment/person.aspx");      
            bool ok =clientPort.AppearText("Persossn");
            //clientPort.Go("http://google.com");
            //clientPort.End();                                          
            }
        
    }
}
