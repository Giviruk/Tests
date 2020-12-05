using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace TestProject1
{
    public static class Settings
    {
        private static string _login;
        private static string _passwordd;
        private static string _baseUrl;
        private static XmlDocument _document;
        public static string file = "Settings.xml";

        public static string BaseUrl
        {
            get
            {
                if (_baseUrl != null) return _baseUrl;
                var node = _document.DocumentElement.SelectSingleNode("BaseUrl");
                _baseUrl = node.InnerText;

                return _baseUrl;
            }
        }

        public static string Login
        {
            get
            {
                if (_baseUrl != null) return _baseUrl;
                var node = _document.DocumentElement.SelectSingleNode("BaseUrl");
                _baseUrl = node.InnerText;

                return _baseUrl;
            }
        }

        static Settings()
        {
            _document = new XmlDocument();
            _document.Load(file);
        }
    }
}