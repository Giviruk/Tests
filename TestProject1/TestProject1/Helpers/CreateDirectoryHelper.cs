using System.Threading;
using OpenQA.Selenium;

namespace TestProject1.Helpers
{
    public class CreateDirectoryHelper : HelperBase
    {
        public CreateDirectoryHelper(ApplicationManager applicationManager) : base(applicationManager)
        {
            
        }

        public void CreateDirectory(string directoryName)
        {
            Thread.Sleep(3000);
            ApplicationManager.Driver.FindElement(By.CssSelector(".js-folders-setup-add")).Click();
            Thread.Sleep(3000);
            ApplicationManager.Driver.FindElement(By.Id("nb-3")).SendKeys(directoryName);
            ApplicationManager.Driver.FindElement(By.CssSelector(".\\_nb-small-button:nth-child(1) .\\_nb-button-text")).Click();
        }
    }
}