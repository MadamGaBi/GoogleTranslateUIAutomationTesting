using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace GoogleTranslateTAFramework
{
    public class Browser
    {
        private static string baseUrl = "https://translate.google.com.ua/";
        private static IWebDriver webDriver = new ChromeDriver();

        public static void Initialize() => Goto("");        
        
        public static ISearchContext Driver => webDriver;

        public static WebDriverWait DriverWait => 
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));

        public static void Goto(string url)
        {    
                webDriver.Manage().Window.Maximize();
                webDriver.Navigate().GoToUrl(baseUrl + url);
        }

        public static void Quit()
        {
            if (webDriver == null)
                return;
            webDriver.Quit();
            webDriver = null;
        }
    }
}
