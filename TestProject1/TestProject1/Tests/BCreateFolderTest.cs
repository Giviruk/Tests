using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Xml.Serialization;
using NUnit.Framework;
using OpenQA.Selenium;
using TestProject1.Base;

namespace TestProject1.Tests
{
    [TestFixture]
    public class BCreateFolderTest : AuthBase
    {
        public static IEnumerable<string> DataFromXml()
        {
            const string fileName = "1.xml";
            return (List<string>) new XmlSerializer(typeof(List<string>))
                .Deserialize(new StreamReader(appManager.pathData + fileName));
        }
        [Test,TestCaseSource(nameof(DataFromXml))]
        public void CreateDirectoryTest(string folderName)
        {
            ApplicationManager.CreateDirectory(folderName);
            Thread.Sleep(300);
            var expectedElement = ApplicationManager.Driver.FindElement(By.ClassName(folderName)).Text;
            Assert.AreEqual(expectedElement,folderName);
            ApplicationManager.fid++;
        }
    }
}