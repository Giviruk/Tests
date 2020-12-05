using OpenQA.Selenium;

namespace TestProject1.Helpers
{
    public class LogOutHelper : HelperBase
    {
        public LogOutHelper(ApplicationManager applicationManager) : base(applicationManager)
        {
        }

        public void LogOut()
        {
            ApplicationManager.Driver.FindElement(By.CssSelector(".user-pic:nth-child(2) > .user-pic__image")).Click();
            ApplicationManager.Driver.FindElement(By.CssSelector(".legouser__menu-item_action_exit > .menu__text")).Click();
        }
    }
}