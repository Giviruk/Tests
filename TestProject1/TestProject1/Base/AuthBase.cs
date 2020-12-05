using System.Threading;
using NUnit.Framework;
using TestProject1.Data;

namespace TestProject1.Base
{
    public class AuthBase : TestBase
    {
        [SetUp]
        public new void SetUpTest()
        {
            ApplicationManager = TestProject1.ApplicationManager.GetInstance();
            ApplicationManager.Auth(new AuthData("givi111222333", "1q2w3eqazwsxedc"));
            Thread.Sleep(1000);
        }
    }
}