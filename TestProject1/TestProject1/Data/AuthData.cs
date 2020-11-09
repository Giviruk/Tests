namespace TestProject1.Data
{
    public class AuthData
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public AuthData(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}