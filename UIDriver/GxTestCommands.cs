using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
//using System.IO;

namespace GXtest
{
    public class GxTestCommands
    {
        private IWebDriver driver;
        private static IWebDriver staticDriver;
        public void Go(string url)
        {
            string location = @".\bin";
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddExcludedArgument("-ignore-certifcate-errors");
            chromeOptions.AddArgument("-test-type");
            chromeOptions.AddArgument("-disable-extensions");
            chromeOptions.LeaveBrowserRunning = true;

            System.Console.WriteLine("ARUNNER  "+System.IO.Directory.GetCurrentDirectory());
            ChromeDriverService driverService = ChromeDriverService.CreateDefaultService(location);
            driverService.HideCommandPromptWindow = true;
            try
            {
                staticDriver = new ChromeDriver(driverService, chromeOptions);
            }
            catch
            { //Reintento porque a veces demora
                staticDriver = new ChromeDriver();
            }
            driver = staticDriver;          
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            if (driver.Url != url)
            {
                End();
                throw new WebDriverException("Couldn't reach the url.");
            }

        }
        public bool AppearText(string text)
        {
            try
            {
                if (!string.IsNullOrEmpty(text))
                {
                    IWebElement bodyTag = driver.FindElement(By.TagName("body"));
                    return bodyTag.Text.ToLower().Contains(text.ToLower());
                }
            }
            catch (WebDriverException e)
            {
                End();
                throw e;
            }          
            return false;
        }
        public void Click(string id)
        {
            try
            {
                driver.FindElement(By.Id(id)).Click();
            }
            catch (WebDriverException e) {
                End();
                throw e;
            }
        }
        public void End()
        {
            Thread.Sleep(2000);
            driver.Close();
            driver.Quit();
        }

    }
}
