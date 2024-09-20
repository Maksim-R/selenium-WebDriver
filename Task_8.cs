using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

public class Task_8
{
    private IWebDriver driver;

    [SetUp]
    public void SetUp()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("http://localhost/litecart/admin/?app=countries&doc=countries");
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }

    [Test]
    public void CheckCountriesAreInAlphabeticalOrder()
    {
        // Получаем все строки таблицы
        ReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//table[@class='dataTable']//tbody//tr[@class='row']"));

        // Извлекаем названия стран
        List<string> countryNames = rows.Select(row => row.FindElement(By.XPath(".//td/a")).Text).ToList();

        // Проверяем, что страны расположены в алфавитном порядке
        List<string> sortedCountryNames = countryNames.OrderBy(name => name).ToList();
        Assert.That(countryNames, Is.EqualTo(sortedCountryNames));
    }

    [Test]
    public void CheckGeoZonesAreInAlphabeticalOrder()
    {
        // Получаем все строки таблицы
        ReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//table[@class='dataTable']//tbody//tr[@class='row']"));

        // Итерируемся по странам и проверяем геозоны
        foreach (IWebElement row in rows)
        {
            int zonesCount = int.Parse(row.FindElement(By.XPath(".//td")).Text);
            if (zonesCount > 0)
            {
                // Переходим на страницу редактирования страны
                IWebElement countryLink = row.FindElement(By.XPath(".//td/a"));
                countryLink.Click();

                // Получаем все геозоны
                ReadOnlyCollection<IWebElement> geoZones = driver.FindElements(By.XPath("//table[@id='table-zones']//tbody//tr//td//select//option"));

                // Извлекаем названия геозон
                List<string> geoZoneNames = geoZones.Select(zone => zone.Text).ToList();

                // Проверяем, что геозоны расположены в алфавитном порядке
                List<string> sortedGeoZoneNames = geoZoneNames.OrderBy(name => name).ToList();
                Assert.That(geoZoneNames, Is.EqualTo(sortedGeoZoneNames));

                // Возвращаемся на страницу со списком стран
                driver.Navigate().Back();
            }
        }
    }
}