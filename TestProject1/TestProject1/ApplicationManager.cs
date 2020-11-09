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
        public IDictionary<string, object> Vars { get; set; }
        public IJavaScriptExecutor _js;
        private LoginHelper _loginHelper;
        private NavigationHelper _navigationHelper;
        private CreateDirectoryHelper _createDirectoryHelper;
        public AuthData AuthData;

        public ApplicationManager()
        {
            Driver = new ChromeDriver("C:\\Users\\malyshkin\\Desktop");
            _js = (IJavaScriptExecutor) Driver;
            Vars = new Dictionary<string, object>();
            _loginHelper = new LoginHelper(this);
            _navigationHelper = new NavigationHelper(this);
            _createDirectoryHelper = new CreateDirectoryHelper(this);
            AuthData = new AuthData("givi111222333", "1q2w3eqazwsxedc");
        }

        public void Auth(AuthData authData)
        {
            GoToLogin();
            _loginHelper.Login(authData);
        }

        public void CreateDirectory(string folderName)
        {
            Auth(AuthData);
            GoToMailBox();
            _createDirectoryHelper.CreateDirectory(folderName);
        }

        public void GoToLogin()
        {
            _navigationHelper.GoTo(
                "https://passport.yandex.ru/auth?origin=home_desktop_ru&retpath=https%3A%2F%2Fmail.yandex.ru%2F&backpath=https%3A%2F%2Fyandex.ru");
        }

        public void GoToMailBox()
        {
            _navigationHelper.GoTo("https://mail.yandex.ru/?uid=1215779683#inbox");
        }
    }
}