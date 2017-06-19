using NUnit.Framework;
using POM.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.TestCases
{
    [TestFixture]
    public class TestClass1
    {
        [Test]
        public void TestMethod()
        {
            LaunchPage lp = new LaunchPage();
            LoginPage loginP = lp.GoToLoginPage();
            Homepage hp = loginP.DoLogin("username", "password");
            ShoppingCartPage scPage = hp.BuyProduct("product");
            OrderStatusPage osPage = scPage.ReviewPlaceOrder();
            osPage.VerifyOrder();
        }
    }
}
