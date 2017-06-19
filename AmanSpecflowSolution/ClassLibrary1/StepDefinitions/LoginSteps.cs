using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace ClassLibrary1.StepDefinitions
{
    [Binding]
    public sealed class LoginSteps
    {
        WebDriverSupport ws;

        public LoginSteps(WebDriverSupport ws)
        {
            this.ws = ws;
        }

        [Given(@"I goto ""(.*)"" on ""(.*)""")]
        public void GivenIGotoOn(string url, string browser)
        {
            ws.GetDriver().Url = url;
        }

        [Given(@"I enter ""(.*)"" as ""(.*)""")]
        public void GivenIEnterAs(string locator, string data)
        {
            ws.Type(locator, data);
        }

        [When(@"I click ""(.*)""")]
        public void WhenIClick(string locator)
        {
            ws.Click(locator);
        }

        [Then(@"login is ""(.*)""")]
        public void ThenLoginIs(string expectedResult)
        {
            string actualResult = null;
            bool result = ws.IsElementPresent("profileName");
            if (result)
            {
                actualResult = "successful";
            }
            else
            {
                actualResult = "unsuccessful";
            }

            Assert.AreEqual(expectedResult, actualResult, "Result mismatched");
        }

    }
}
