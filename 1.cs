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
    public class 1
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
        public void WaitLoad(){
			wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
		}
		
        [Test]
        
		public void The1Test()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
			WaitLoad();
            driver.FindElement(By.LinkText("Маркет")).Click();
			WaitLoad();
            driver.FindElement(By.LinkText("Компьютеры")).Click();
			WaitLoad();
            driver.FindElement(By.LinkText("Ноутбуки")).Click();
			WaitLoad();
            driver.FindElement(By.XPath("//div[3]/div[3]/div/div/div/h3/a/span")).Clear();
            driver.FindElement(By.XPath("//div[3]/div[3]/div/div/div/h3/a/span")).SendKeys("30000");
            driver.FindElement(By.XPath("//div[6]/a/span/label")).Click();
            driver.FindElement(By.XPath("//div[7]/a/span/label")).Click();
			driver.FindElement(By.XPath("(//button[@type='button'])[8]")).Click();
			WaitLoad();
			List<WebElement> iconelements = driver.findElements(By.className("snippet-card__header-text"));
			Assert(iconelements.Count == 12);
			List<WebElement> title1elements = driver.findElements(By.className("snippet-card__header-text")).findElement(By.xpath(".//*[text()='Lenovo']/.."));
			List<WebElement> title2elements = driver.findElements(By.className("snippet-card__header-text")).findElement(By.xpath(".//*[text()='HP']/.."));
			Assert((title1elements.Count+title2elements.Count) == 12);
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
