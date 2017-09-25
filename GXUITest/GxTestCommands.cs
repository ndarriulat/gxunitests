using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
//using System.IO;

namespace GXtest
{
    public class GxTestCommands
    {
        private IWebDriver driver;
        private static IWebDriver staticDriver;
        private string location = "./";
        public void SetLocation(string loc)
        {
            location = loc;
        }
        public void Start()
        {       
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddExcludedArgument("-ignore-certifcate-errors");
            chromeOptions.AddArgument("-test-type");
            chromeOptions.AddArgument("-disable-extensions");
            chromeOptions.LeaveBrowserRunning = true;

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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        public void StartRemote(string url)
        {
            ChromeOptions options = new ChromeOptions();
            driver = new RemoteWebDriver(new Uri(url), options.ToCapabilities());
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        public void Go(string url)
        {
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
                    IWebElement aux =  driver.FindElement(By.XPath("//*[contains(text(),'" + text + "')]"));
                    return true;
                   /* IWebElement bodyTag = driver.FindElement(By.TagName("body"));
                      return bodyTag.Text.ToLower().Contains(text.ToLower());*/
                }
            }
            catch (WebDriverException e)
            {
                return false;
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
        public void ClickByName(string text)
        {
            try
            {
                driver.FindElement(By.Name(text)).Click();
            }
            catch (WebDriverException e)
            {
                End();
                throw e;
            }
        }
        public void ClickByText(string text)
        {
            try
            {
                driver.FindElement(By.XPath("//*[contains(text(),'"+text+"')]")).Click();
            }
            catch (WebDriverException e)
            {
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
