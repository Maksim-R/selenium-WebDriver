using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_example
{
    [TestFixture]
    internal class Task_6
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
        public void MenuItems_HaveHeaders()
        {
            driver.Url = "http://localhost/litecart/admin/";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            Thread.Sleep(2000);

            // Ищем список меню
            IWebElement menu = driver.FindElement(By.XPath("//ul[@id='box-apps-menu']"));

            // Ищем все пункты меню
            IList<IWebElement> menuItems = menu.FindElements(By.XPath(".//li"));

            // Обрабатываем каждый пункт меню
            foreach (IWebElement menuItem in menuItems)
            {
                // Ищем ссылку в пункте меню
                IWebElement link = menuItem.FindElement(By.XPath(".//a"));

                // Кликаем по ссылке
                link.Click();

                // Проверяем наличие заголовка на странице
                Assert.IsTrue(IsHeaderPresent());

                // Если пункт меню имеет вложенные пункты, обрабатываем их
                try
                {
                    IWebElement subMenu = menuItem.FindElement(By.XPath(".//ul[@class='docs']"));
                    IList<IWebElement> subMenuItems = subMenu.FindElements(By.XPath(".//li"));

                    foreach (IWebElement subMenuItem in subMenuItems)
                    {
                        IWebElement subLink = subMenuItem.FindElement(By.XPath(".//a"));
                        subLink.Click();

                        // Проверяем наличие заголовка на странице
                        Assert.IsTrue(IsHeaderPresent());
                    }
                }
                catch (NoSuchElementException)
                {
                    // Пункт меню не имеет вложенных пунктов
                }

                // Возвращаемся на страницу с меню
                driver.Navigate().Back();
            }
        }

        private bool IsHeaderPresent()
        {
            try
            {
                IWebElement header = driver.FindElement(By.XPath("//h1"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
