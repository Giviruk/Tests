using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using TestProject1.Base;
using TestProject1.Data;

namespace TestProject1.Tests
{
    public class CLogOutTest : AuthBase
    {
        [Test]
        public void LogOutTest()
        {
            ApplicationManager.LogOut(new AuthData("givi111222333", "1q2w3eqazwsxedc"));
            Thread.Sleep(1000);
            try
            {
                var expectedElement = ApplicationManager.Driver.FindElement(By.ClassName("user-account__name")).Text;
                
                Assert.True(false);
            }
            catch (Exception e)
            {
                Assert.True(true);
            }
        }
    }
}