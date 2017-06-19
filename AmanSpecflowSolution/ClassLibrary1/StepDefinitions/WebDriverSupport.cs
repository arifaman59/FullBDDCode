using BoDi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Configuration;

namespace ClassLibrary1.StepDefinitions
{
    [Binding]
    public sealed class WebDriverSupport
    {
        private readonly IObjectContainer objectContainer;
        private IWebDriver driver;

        public WebDriverSupport(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void InitializeWebDriver()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            objectContainer.RegisterInstanceAs<IWebDriver>(driver);
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }

        public IWebElement GetElement(string locator)
        {
            IWebElement ele = GetDriver().FindElement(By.XPath(ConfigurationManager.AppSettings[locator]));
            return ele;
        }

        public void Click(string locator)
        {
            GetElement(locator).Click();
        }

        public void Type(string locator, string data)
        {
            GetElement(locator).SendKeys(data);
        }

        public bool IsElementPresent(string locator)
        {
            IList<IWebElement> allEle = GetDriver().FindElements(By.XPath(ConfigurationManager.AppSettings[locator]));
            if (allEle.Count == 0)
            {
                return false;
            }
            return true;
        }

        [AfterScenario]
        public void QuitAll()
        { 
            driver.Quit();
        }
    }
}
