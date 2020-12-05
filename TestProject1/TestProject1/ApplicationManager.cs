using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestProject1.Data;
using TestProject1.Helpers;

namespace TestProject1
{
    public class ApplicationManager
    {
        private string pathFid = @"C:\Study\Tests\Tests\TestProject1\TestProject1\Data\fid.txt";
        public string pathData = @"C:\Study\Tests\Tests\TestProject1\TestProject1\Data\";
        public static ThreadLocal<ApplicationManager> AppManager = new ThreadLocal<ApplicationManager>();
        public int fid
        {
            get
            {
                var sr = new StreamReader(pathFid);
                var v = sr.ReadToEnd();
                sr.Close();
                return int.Parse(v);
            }
            set
            {
                var sw = new StreamWriter(pathFid, false);
                sw.Write(value);
                sw.Close();
            }
        }

        public static ApplicationManager GetInstance()
        {
            if (AppManager.IsValueCreated) return AppManager.Value;
            var instance = new ApplicationManager();
            instance.GoToLogin();
            AppManager.Value = instance;

            return AppManager.Value;
        }
        public readonly IWebDriver Driver;
        private IDictionary<string, object> Vars { get; set; }
        public IJavaScriptExecutor Js { get; private set; }
        private LoginHelper LoginHelper { get; set; }
        private LogOutHelper LogOutHelper { get; set; }
        private NavigationHelper NavigationHelper { get; set; }
        private CreateDirectoryHelper CreateDirectoryHelper { get; set; }
        private AuthData AuthData { get; set; }

        private ApplicationManager()
        {
            Driver = new ChromeDriver(@"C:\Users\user\Desktop");
            Js = (IJavaScriptExecutor) Driver;
            Vars = new Dictionary<string, object>();
            LoginHelper = new LoginHelper(this);
            LogOutHelper = new LogOutHelper(this);
            NavigationHelper = new NavigationHelper(this);
            CreateDirectoryHelper = new CreateDirectoryHelper(this);
            AuthData = new AuthData("givi111222333", "1q2w3eqazwsxedc");
        }

        ~ApplicationManager()
        {
            try
            {
                Driver.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Auth(AuthData authData)
        {
            GoToLogin();
            LoginHelper.Login(authData);
        }

        public void CreateDirectory(string folderName)
        {
            //Auth(AuthData);
            GoToMailBox();
            CreateDirectoryHelper.CreateDirectory(folderName);
        }

        public void LogOut(AuthData authData)
        {
            LogOutHelper.LogOut();
        }

        public void GoToLogin()
        {
            NavigationHelper.GoTo(
                "https://passport.yandex.ru/auth?origin=home_desktop_ru&retpath=https%3A%2F%2Fmail.yandex.ru%2F&backpath=https%3A%2F%2Fyandex.ru");
        }

        public void FailLogIn()
        {
            GoToLogin();
            Auth(new AuthData("givi111222333", "1q2w3eqazwsxe"));
        }

        public void GoToMailBox()
        {
            NavigationHelper.GoTo("https://mail.yandex.ru/?uid=1215779683#inbox");
            Thread.Sleep(300);
        }
    }
}