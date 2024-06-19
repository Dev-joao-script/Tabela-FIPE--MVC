using Microsoft.AspNetCore.Mvc;

namespace WebApplication10.Singletons
{
    public class versaoGlobalValue
    {
        private string _value;

        public string GetValue()
        {
            return _value;
        }

        public void SetValue(string value)
        {
            _value = value;
        }
    }


    public class versaoGlobalNome
    {
        private string _value;

        public string GetValue()
        {
            return _value;
        }

        public void SetValue(string value)
        {
            _value = value;
        }
    }
}
