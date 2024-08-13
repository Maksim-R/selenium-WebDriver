﻿using OpenQA.Selenium.Chrome;
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
            driver.Url = "http://localhost/litecart/admin/";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
        
        [Test]
        public void MenuItems_HaveH1Header()
        {
            // Находим все пункты меню
            var menuItems = driver.FindElements(By.XPath("//ul[@id='box-apps-menu']/li"));

            // Обрабатываем каждый пункт меню
            foreach (var menuItem in menuItems)
            {
                // Находим ссылку в пункте меню
                var link = menuItem.FindElement(By.XPath(".//a"));

                // Кликаем по ссылке
                link.Click();

                // Ждем пока загрузится страница и появится заголовок h1
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1")));

                // Проверяем наличие заголовка h1
                Assert.IsTrue(IsH1HeaderPresent());
            }
        }

        [Test]
        public void SubMenuItems_HaveH1Header()
        {
            // Находим все пункты меню
            var menuItems = driver.FindElements(By.XPath("//ul[@id='box-apps-menu']/li"));

            // Обрабатываем каждый пункт меню
            foreach (var menuItem in menuItems)
            {
                // Если пункт меню имеет вложенные пункты, обрабатываем их
                try
                {
                    var subMenuItems = menuItem.FindElements(By.XPath(".//ul[@class='docs']/li"));
                    foreach (var subMenuItem in subMenuItems)
                    {
                        var subLink = subMenuItem.FindElement(By.XPath(".//a"));
                        subLink.Click();

                        // Ждем пока загрузится страница и появится заголовок h1
                        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1")));

                        // Проверяем наличие заголовка h1
                        Assert.IsTrue(IsH1HeaderPresent());
                    }
                }
                catch (NoSuchElementException)
                {
                    // Пункт меню не имеет вложенных пунктов
                }
            }
        }

        private bool IsH1HeaderPresent()
        {
            try
            {
                var h1 = driver.FindElement(By.XPath("//h1"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
