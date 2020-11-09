using System;
using NUnit.Framework;
using TestProject1.Base;

namespace TestProject1.Tests
{
    [TestFixture]
    public class CreateFolderTest : TestBase
    {
        [Test]
        public void CreateDirectoryTest()
        {
            ApplicationManager.CreateDirectory(DateTime.Now.TimeOfDay.ToString());
        }
    }
}