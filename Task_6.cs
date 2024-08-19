using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace csharp_example
{
    [TestFixture]
    internal class Task_6
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Url = "http://localhost/litecart/admin/";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver = null;
        }

        [Test]
        public void MenuItems_HaveH1Header()
        {
            // Находим все пункты бокового меню "верхнего" уровня чтобы выяснить их количество
            var menuItems = driver.FindElements(By.XPath("//ul[@id='box-apps-menu']/li"));
            int count = menuItems.Count();

            // Обрабатываем каждый пункт меню
            for (int i = 0; i < count; i++)
            {
                // тут заново получаем элементы бокового меню "верхнего" уровня, так как страница была изменена
                var freshMenuItems = driver.FindElements(By.XPath("//ul[@id='box-apps-menu']/li"));
                                
                    IWebElement link = freshMenuItems[i].FindElement(By.XPath(".//a"));
                    Debug.WriteLine(link.TagName);
                    link.Click();
                    var h_1 = driver.FindElement(By.XPath("//h1"));
                    List <IWebElement> otherFreshMenuItems = driver.FindElements(By.XPath("//ul[@class='docs']//a")).ToList();
                    Debug.WriteLine($"===> Количество элементов: {otherFreshMenuItems.Count}");
                    for (int j = 0; j < otherFreshMenuItems.Count; j++)
                    {
                        List<IWebElement> subFreshMenuItems = driver.FindElements(By.XPath("//ul[@class='docs']//a")).ToList();
                        subFreshMenuItems[j].Click();
                        var h1 = driver.FindElement(By.XPath("//h1"));
                    }                    
            }
        }
    }
}