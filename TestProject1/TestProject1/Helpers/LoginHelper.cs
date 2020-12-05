using System.Threading;
using OpenQA.Selenium;
using TestProject1.Data;

namespace TestProject1.Helpers
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager applicationManager) : base(applicationManager)
        {
        }

        public void Login(AuthData authData)
        {
            ApplicationManager.Driver.Manage().Window.FullScreen();
            Thread.Sleep(100);
            ApplicationManager.Driver.FindElement(By.Id("passp-field-login")).SendKeys(authData.Login);
            ApplicationManager.Driver.FindElement(By.Id("passp-field-login")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            ApplicationManager.Driver.FindElement(By.Name("passwd")).SendKeys(authData.Password);
            ApplicationManager.Driver.FindElement(By.Name("passwd")).SendKeys(Keys.Enter);
            Thread.Sleep(1000);
        }
    }
}