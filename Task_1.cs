using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Threading;  
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;


namespace csharp_example
{
    [TestFixture]
    public class MyFirstTest
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void FirstTest()
        {
            driver.Url = "http://www.google.com/";
            Thread.Sleep(5000);
            driver.FindElement(By.Name("q")).SendKeys("webdriver");
            Thread.Sleep(5000);
            driver.FindElement(By.Name("btnK")).Click();
            Thread.Sleep(5000);
            wait.Until(ExpectedConditions.TitleContains("webdriver"));
        }

        [TearDown]
        public void stop()
        {            
                driver.Quit();                
                driver = null;            
        }
    }
}
