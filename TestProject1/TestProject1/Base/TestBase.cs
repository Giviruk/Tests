using NUnit.Framework;

namespace TestProject1.Base
{
    public class TestBase
    {
        protected ApplicationManager ApplicationManager;

        [SetUp]
        public void SetUpTest()
        {
            ApplicationManager = new ApplicationManager();
            ApplicationManager.GoToLogin();
        }
    }
}