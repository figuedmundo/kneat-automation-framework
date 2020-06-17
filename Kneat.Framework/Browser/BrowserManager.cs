using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Kneat.Framework.Browser
{
    public class BrowserManager
    {
        public int DefaultTimeToWait = 30;

        public IWebDriver Driver { get; private set; }
        public WebDriverWait Wait { get; private set; }
        public Actions Actions { get; private set; }

        private static BrowserManager _instance;
        public static BrowserManager Instance => _instance ??= new BrowserManager();

        public BrowserManager()
        {

        }

        public void Init()
        {

            Driver = GetDriver();
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
            Driver.Manage().Window.Maximize();
            Driver.Manage().Cookies.DeleteAllCookies();

            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(DefaultTimeToWait));

            Actions = new Actions(Driver);

            //log 

        }

        public void Visit(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void Quit()
        {
            if(Driver != null)
            {
                Driver.Close();
                Driver.Quit();
                Driver.Dispose();

                Driver = null;

                // log
            }
        }


        private IWebDriver GetDriver()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var driver = new ChromeDriver(Path.Combine(path, "Drivers"));
            // log driver used

            return driver;
        }
    }
}
