using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_NET.UITests
{
    class IndexTests
    {
        IWebDriver driver;      

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://localhost:5001/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // Werkt niet?

        }

        [TearDown]
        public void Teardown()
        {
            driver.Close();
        }

        [Test]
        public void VisitTest()
        {
            /*
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://localhost:5001/");
            driver.Manage().Window.Maximize();
            */
            string verwachteUrl = "https://localhost:5001/";
            var url = driver.Url;
            Assert.AreEqual(verwachteUrl, url);
        }

        [Test]
        public void ElementsAvailableTests()
        {
            /*
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://localhost:5001/");
            driver.Manage().Window.Maximize();
            */

            //We vragen eerste alle elementen op in de navigatie 
            IWebElement NavResearch = driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[1]/a"));
            IWebElement NavAddResearch = driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[2]/a"));
            IWebElement NavDropdown = driver.FindElement(By.XPath("//*[@id=\"navbarDropdown\"]"));
            //We vragen enkele Content elementen op.
            IWebElement HelloWorld = driver.FindElement(By.XPath("//*[@id=\"content\"]/div[2]/h1"));
            IWebElement Lead = driver.FindElement(By.XPath("//*[@id=\"content\"]/div[2]/p[1]"));
           

            //We valideren of deze niet null zijn en dus aanwezig zijn.
            Assert.NotNull(NavResearch);
            Assert.NotNull(NavAddResearch);
            Assert.NotNull(NavDropdown);
            Assert.NotNull(HelloWorld);
            Assert.NotNull(Lead);
        }

        [Test]
        public void NavTest()
        {   /*
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://localhost:5001/");
            driver.Manage().Window.Maximize();
            */
            //Get element
            IWebElement NavResearch = driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[1]/a"));

            //Validate text elements
            Assert.AreEqual("Research", NavResearch.Text);
            NavResearch.Click();

            //Assert URL
            string verwachteUrl = "https://localhost:5001/Research";
            var url = driver.Url;
            Assert.AreEqual(verwachteUrl, url);

            //https://www.softwaretestinghelp.com/selenium-webdriver-commands-selenium-tutorial-17/
        }

        [Test]
        public void CssValueTest()
        {
            //Hello world element opvragen
            IWebElement HelloWorld = driver.FindElement(By.XPath("//*[@id=\"content\"]/div[2]/h1"));
            //We verwachten dat dit element een fontweight van 300 heeft.
            string verwachteValue = "300";
            //Assert.
            Assert.AreEqual(verwachteValue, HelloWorld.GetCssValue("font-weight"));
        }

        [Test]
        public void DropdownTest()
        {
            //We vragen eerst het element op die de lijst gaat tonen.
            IWebElement DropdownShow = driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[3]"));

            //De verwachte klasse
            string verwachteKlasse = "nav-item dropdown show";
            //We kijken of we momenteel nog niet de verwachte klasse hebben.
            Assert.AreNotEqual(verwachteKlasse, DropdownShow.GetAttribute("class"));

            //We vragen het dropdown element op.
            IWebElement NavDropdown = driver.FindElement(By.XPath("//*[@id=\"navbarDropdown\"]"));
            //Click
            NavDropdown.Click();
            //We vergelijken de klasse nu terug
            Assert.AreEqual(verwachteKlasse, DropdownShow.GetAttribute("class"));
        }






        /**
         * Alle index testen
         * Url check
         * Check nav-elements
         * Check content-elements
         * Check css Attributes
         * Check class attributes
         * Check navigation
         * Check dropdown
         */

    }
}
