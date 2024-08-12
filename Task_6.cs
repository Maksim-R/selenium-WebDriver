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
        public void FirstTest()
        {
            driver.Url = "http://localhost/litecart/admin/";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[1][@id='app-']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-template']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-logotype']/a")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[2][@id='app-']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-catalog']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-product_groups']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-option_groups']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-manufacturers']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-suppliers']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-delivery_statuses']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-sold_out_statuses']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-quantity_units']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-csv']/a")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[3][@id='app-']/a")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[4][@id='app-']/a")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[5][@id='app-']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-customers']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-csv']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-newsletter']/a")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[6][@id='app-']/a")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[7][@id='app-']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-languages']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-storage_encoding']/a")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[8][@id='app-']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-jobs']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-customer']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-shipping']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-payment']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-order_total']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-order_action']/a")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[9][@id='app-']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-orders']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-order_statuses']/a")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[10][@id='app-']/a")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[11][@id='app-']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-monthly_sales']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-most_sold_products']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-most_shopping_customers']/a")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[12][@id='app-']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-store_info']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-defaults']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-general']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-listings']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-images']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-checkout']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-advanced']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-security']/a")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[13][@id='app-']/a")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[14][@id='app-']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-tax_classes']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-tax_rates']/a")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[15][@id='app-']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-search']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-scan']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-csv']/a")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[16][@id='app-']/a")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[17][@id='app-']/a")).Click();
            driver.FindElement(By.XPath("//*[@id='doc-vqmods']/a")).Click();
            Thread.Sleep(2000);
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
