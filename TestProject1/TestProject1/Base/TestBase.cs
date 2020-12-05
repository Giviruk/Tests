using NUnit.Framework;

namespace TestProject1.Base
{
    public class TestBase
    {
        protected static ApplicationManager appManager = ApplicationManager.GetInstance();
        protected ApplicationManager ApplicationManager;

        [SetUp]
        public void SetUpTest()
        {
            ApplicationManager = appManager;
        }
    }
}