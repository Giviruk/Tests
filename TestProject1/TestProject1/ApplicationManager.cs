using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestProject1.Data;
using TestProject1.Helpers;

namespace TestProject1
{
    public class ApplicationManager
    {
        public readonly IWebDriver Driver;
        private IDictionary<string, object> Vars { get; set; }
        private IJavaScriptExecutor Js { get; set; }
        private LoginHelper LoginHelper { get; set; }
        private NavigationHelper NavigationHelper { get; set; }
        private CreateDirectoryHelper CreateDirectoryHelper { get; set; }
        private AuthData AuthData { get; set; }

        public ApplicationManager()
        {
            Driver = new ChromeDriver("C:\\Users\\malyshkin\\Desktop");
            Js = (IJavaScriptExecutor) Driver;
            Vars = new Dictionary<string, object>();
            LoginHelper = new LoginHelper(this);
            NavigationHelper = new NavigationHelper(this);
            CreateDirectoryHelper = new CreateDirectoryHelper(this);
            AuthData = new AuthData("givi111222333", "1q2w3eqazwsxedc");
        }

        public void Auth(AuthData authData)
        {
            GoToLogin();
            LoginHelper.Login(authData);
        }

        public void CreateDirectory(string folderName)
        {
            Auth(AuthData);
            GoToMailBox();
            CreateDirectoryHelper.CreateDirectory(folderName);
        }

        public void GoToLogin()
        {
            NavigationHelper.GoTo(
                "https://passport.yandex.ru/auth?origin=home_desktop_ru&retpath=https%3A%2F%2Fmail.yandex.ru%2F&backpath=https%3A%2F%2Fyandex.ru");
        }

        public void GoToMailBox()
        {
            NavigationHelper.GoTo("https://mail.yandex.ru/?uid=1215779683#inbox");
        }
    }
}