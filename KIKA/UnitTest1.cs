using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Tests
{
    public class Tests
    {
        private ChromeDriver _driver;

        [SetUp]
        public void Setup()
        {
            var option = new ChromeOptions();
            option.AddArguments("incognito");
            _driver = new ChromeDriver(option);
            _driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(_driver, System.TimeSpan.FromSeconds(15));
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            _driver.Url = "https://www.kika.lt/";
        }

        [Test]
        public void LogIn()
        {
            
            _driver.FindElement(By.CssSelector("#editable_popup[style*='display: block;'] .close")).Click();
            IWebElement logIn = _driver.FindElement(By.CssSelector("#profile_menu a"));
            logIn.Click();
            IWebElement userName = _driver.FindElement(By.CssSelector("#login_form [name='email']"));
            userName.SendKeys("test@test.test");
            IWebElement password = _driver.FindElement(By.CssSelector("#login_form [name='password']"));
            password.SendKeys("test123");
            IWebElement prisijungti = _driver.FindElement(By.CssSelector("#login_form .btn-primary"));
            prisijungti.Click();
        }

       [TearDown]
        public void TearDownTest()
        {
            _driver.Close();
        }
    }
}