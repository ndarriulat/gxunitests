using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using System.Configuration;
//using System.IO;

namespace GXtest
{
    public class GxTestCommands
    {
        private IWebDriver driver;
        private static IWebDriver staticDriver;
        private string location = ConfigurationManager.AppSettings["path"] ?? "./";
        public void SetLocation(string loc)
        {
            location = loc;
        }

        /// <summary>
        /// Opens a local connection using Chrome Driver.
        /// </summary>
        public void StartLocal()
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

        /// <summary>
        /// Opens a remote connection using Remote Driver.
        /// </summary>
        /// <param name="url"></param>
        public void StartRemote(string url)
        {
            ChromeOptions options = new ChromeOptions();
            driver = new RemoteWebDriver(new Uri(url), options.ToCapabilities());
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        /// <summary>
        /// Opens a connection with Sauce Labs, with the given parameters.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="browserName"></param>
        /// <param name="username"></param>
        /// <param name="accessKey"></param>
        public void StartCloudExecution(string url, string browserName, string username, string accessKey)
        {            
            DesiredCapabilities caps = new DesiredCapabilities();
            caps.SetCapability(CapabilityType.BrowserName, browserName);
            caps.SetCapability("username", username);
            caps.SetCapability("accessKey", accessKey);
            driver = new RemoteWebDriver(new Uri(url), caps, TimeSpan.FromSeconds(600));

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
        }

        public void Go(string url)
        {
            driver.Navigate().GoToUrl(url);
            if (driver.Url != url)
            {
                End();
                throw new WebDriverException("Couldn't reach the url.");
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            Thread.Sleep(5000);
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
                IWebElement elem = driver.FindElement(By.Id(id));
                elem.Click();
                Thread.Sleep(2000);
            }
            catch (WebDriverException e) {
                End();
                throw e;
            }
        }

        public void ClickByName(string name)
        {
            try
            {
                IWebElement elem = driver.FindElement(By.Name(name));
                elem.Click();
                Thread.Sleep(2000);
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
                IWebElement elem = driver.FindElement(By.XPath("//*[contains(text(),'" + text + "')]"));
                elem.Click();
                Thread.Sleep(2000);
            }
            catch (WebDriverException e)
            {
                End();
                throw e;
            }
        }

        public void SendKeysById(string id, string text)
        {
            try
            {
                IWebElement elem = driver.FindElement(By.Id(id));
                elem.Clear();
                elem.SendKeys(text);
            }
            catch (WebDriverException e)
            {
                End();
                throw e;
            }
        }

        public void SendKeysByName(string name, string text)
        {
            try
            {
                IWebElement elem = driver.FindElement(By.Name(name));
                elem.Clear();
                elem.SendKeys(text);
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
