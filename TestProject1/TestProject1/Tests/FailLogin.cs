using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using TestProject1.Base;

namespace TestProject1.Tests
{
    public class FailLogin : TestBase
    {
        [Test]
        public void AuthTest()
        {
            ApplicationManager.FailLogIn();
            Thread.Sleep(1000);
            var expectedElement = ApplicationManager.Driver.FindElement(By.LinkText("Войти"));
        }
    }
}