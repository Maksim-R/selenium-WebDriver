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
            //driver.FindElement(By.Name("username")).SendKeys("admin");
            //driver.FindElement(By.Name("password")).SendKeys("admin");
            //driver.FindElement(By.Name("login")).Click();
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
            // Найти все стикеры у товаров
            List <IWebElement> boxList = new List<IWebElement> ();
            IWebElement popular = driver.FindElement(By.XPath("//div[@id='box-most-popular']"));
            IWebElement campaigns = driver.FindElement(By.XPath("//div[@id='box-campaigns']"));
            IWebElement latestProducts = driver.FindElement(By.XPath("//div[@id='box-latest-products']"));
            boxList.Add(popular);
            boxList.Add(campaigns);
            boxList.Add(latestProducts);

            // Проверить каждый товар
            for (int i = 0; i < boxList.Count; i++)
            {
                List <IWebElement> cardList = boxList[i].FindElements(By.XPath("//li[@class='product column shadow hover-light']")).ToList();
                
                for (int j = 0; j < cardList.Count; j++)
                {
                    // Найти стикеры для текущего товара
                    List <IWebElement> stickers = cardList[j].FindElements(By.XPath("//div[contains(@class, 'sticker')]")).ToList();

                    // Проверить, что у каждого товара ровно один стикер
                    Assert.That(stickers.Count, Is.EqualTo(1), $"У товара {cardList[j].FindElement(By.XPath(".//div[@class='name']")).Text} количество стикеров не равно одному");
                }               
            }
        }
    }
}