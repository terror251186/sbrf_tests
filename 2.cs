using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class 2
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://yandex.ru/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void The2Test()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
			WaitLoad();
            driver.FindElement(By.LinkText("Маркет")).Click();
			WaitLoad();
            driver.FindElement(By.LinkText("Компьютеры")).Click();
			WaitLoad();
            driver.FindElement(By.LinkText("Планшеты")).Click();
			WaitLoad();
            driver.FindElement(By.Id("glf-pricefrom-var")).Clear();
            driver.FindElement(By.Id("glf-pricefrom-var")).SendKeys("20000");
            driver.FindElement(By.Id("glf-priceto-var")).Clear();
            driver.FindElement(By.Id("glf-priceto-var")).SendKeys("25000");
            driver.FindElement(By.XPath("(//button[@type='button'])[5]")).Click();
            driver.FindElement(By.Id("glf-7893318-153080")).Click();
			driver.FindElement(By.Id("glf-7893318-267101")).Click();
			driver.FindElement(By.XPath("(//button[@type='button'])[8]")).Click();
			WaitLoad();
            List<WebElement> iconelements = driver.findElements(By.className("snippet-card__header-text"));
			Assert(iconelements.Count == 12);
			List<WebElement> priceelement = driver.findElements(By.className("price"))
			var text; 
			int a; 
			for (int i = 0; i <= 11; i++)
			{
				text = priceelement[i].Text;
				text = text.Replace("от ","");
				text = text.Replace(" ","");
				text = text.Replace(" руб.","");
				a = int.Parse(text.Text);
				Assert(a >= 20000);
				Assert(a <=25000);
			}
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
