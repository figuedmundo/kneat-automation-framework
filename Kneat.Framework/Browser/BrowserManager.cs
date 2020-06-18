﻿using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using Kneat.Reports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Kneat.Framework.Browser
{
    public class BrowserManager
    {
        public struct Browser
        {
            public const string Firefox = "Firefox";
            public const string Chrome = "Chrome";
        }

        public int DefaultTimeToWait = 30;

        public IWebDriver Driver { get; private set; }
        public WebDriverWait Wait { get; private set; }
        public Actions Actions { get; private set; }

        private string _browser = ConfigurationManager.AppSettings["Browser"];

        private static BrowserManager _instance;
        public static BrowserManager Instance => _instance ??= new BrowserManager();


        public BrowserManager()
        {

        }

        public void Init()
        {

            Driver = GetDriver(_browser);
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
            Driver.Manage().Window.Maximize();
            Driver.Manage().Cookies.DeleteAllCookies();

            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(DefaultTimeToWait));

            Actions = new Actions(Driver);

            //log
            ExtentReportsHelper.Instance.SetStepStatusPass("Browser started.");
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
                ExtentReportsHelper.Instance.SetStepStatusPass("Browser Closed.");
            }
        }


        private IWebDriver GetDriver(string browser)
        {
            IWebDriver driver;  
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            
            switch (browser)
            {
                case Browser.Chrome:
                    driver = new ChromeDriver(Path.Combine(path, "Drivers"));
                    break;
                case Browser.Firefox:
                    driver = new FirefoxDriver();
                    break;
                default:
                    driver = new ChromeDriver(Path.Combine(path, "Drivers"));
                    break;
            }

            ExtentReportsHelper.Instance.SetStepStatusPass($" {browser} Browser Instantiaded.");
            return driver;  
        }

        public string ScreenCaptureAsBase64String()
        {
            ITakesScreenshot ts = (ITakesScreenshot)Driver;
            Screenshot screenshot = ts.GetScreenshot();
            return screenshot.AsBase64EncodedString;
        }
    }
}
