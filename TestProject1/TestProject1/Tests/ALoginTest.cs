using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using TestProject1.Base;
using TestProject1.Data;

namespace TestProject1.Tests
{
    [TestFixture]
    public class ALoginTest : TestBase
    {
        [Test]
        public void AuthTest()
        {
            if (IsLogged()) return;
            ApplicationManager.Auth(new AuthData("givi111222333", "1q2w3eqazwsxedc"));
            Thread.Sleep(1000);
            var expectedElement = ApplicationManager.Driver.FindElement(By.ClassName("user-account__name")).Text;
            Assert.IsNotEmpty(expectedElement);
            Assert.AreEqual(expectedElement, "givi111222333");
        }

        private bool IsLogged()
        {
            try
            {
                var expectedElement = ApplicationManager.Driver.FindElement(By.ClassName("user-account__name")).Text;
                return false;
            }
            catch
            {
                return true;
            }
        }
    }
}