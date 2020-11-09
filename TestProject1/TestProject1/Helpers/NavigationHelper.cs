using OpenQA.Selenium;

namespace TestProject1.Helpers
{
    public class NavigationHelper : HelperBase
    {
        public NavigationHelper(ApplicationManager applicationManager) : base(applicationManager)
        {
        }

        public void GoTo(string url)
        {
            ApplicationManager.Driver.Navigate()
                .GoToUrl(url);
        }
    }
}