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


        [Test]
        public void VisitTest()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://localhost:5001/");
            driver.Manage().Window.Maximize();
            string verwachteUrl = "https://localhost:5001/";
            var url = driver.Url;
            Assert.AreEqual(verwachteUrl, url);
            driver.Close();
        }

        [Test]
        public void NavTest()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://localhost:5001/");
            driver.Manage().Window.Maximize();

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
