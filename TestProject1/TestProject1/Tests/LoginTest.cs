using NUnit.Framework;
using TestProject1.Base;
using TestProject1.Data;

namespace TestProject1.Tests
{
    [TestFixture]
    public class LoginTest : TestBase
    {
        [Test]
        public void AuthTest()
        {
            ApplicationManager.Auth(new AuthData("givi111222333", "1q2w3eqazwsxedc"));
        }
    }
}