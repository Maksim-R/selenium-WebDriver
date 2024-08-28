using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace csharp_example
{
    [TestFixture]
    internal class Task_7
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Url = "http://localhost/litecart/en/";
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver = null;
        }

        [Test]
        public void CheckStickersOnProducts()
        {
            // Найти все блоки с товарами
            List<IWebElement> boxList = new List<IWebElement>()
            {
                driver.FindElement(By.XPath("//div[@id='box-most-popular']")),
                driver.FindElement(By.XPath("//div[@id='box-campaigns']")),
                driver.FindElement(By.XPath("//div[@id='box-latest-products']"))
            };

            // Проверить каждый товар
            foreach (var box in boxList)
            {
                List<IWebElement> cardList = box.FindElements(By.XPath(".//li[contains(@class, 'product')]")).ToList();

                foreach (var card in cardList)
                {
                    // Найти стикеры для текущего товара
                    List<IWebElement> stickers = card.FindElements(By.XPath(".//div[contains(@class, 'sticker')]")).ToList();

                    // Проверить, что у каждого товара ровно один стикер
                    Assert.That(stickers.Count, Is.EqualTo(1), $"У товара {card.FindElement(By.XPath(".//div[@class='name']")).Text} количество стикеров не равно одному");
                }
            }
        }
    }
}