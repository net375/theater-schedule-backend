using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TheaterSchedule.BLL.Interfaces;
namespace TheaterSchedule.BLL.Services
{
    public class SendDataToGoogleFormService:ISendDataToGoogleFormService
    {
        private string _baseUrl;
        private Dictionary<string, string> _field;
        public Dictionary<string, string[]> _checkbox;
        private WebClient _client;
        private Uri _uri;

        public SendDataToGoogleFormService()
        {
            _field = new Dictionary<string, string>();
            _checkbox = new Dictionary<string, string[]>();
            _client = new WebClient();
        }

        public void SetFieldValues(Dictionary<string,string> data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            if (data.Keys.Any(value => string.IsNullOrWhiteSpace(value)))
                throw new ArgumentNullException(nameof(data), "empty keys");

            var fieldsWithData = data.Where(param => !string.IsNullOrWhiteSpace(param.Value));

            foreach (var param in fieldsWithData)
            {
                _field[param.Key] = param.Value;
            }
        }

        public void SetCheckboxValues(string key, params string[] values)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            var valuesWithData = values.Where(value => !string.IsNullOrWhiteSpace(value)).ToArray();
            _checkbox[key] = valuesWithData;
        }

        public string SubmitAsync(string rootUrl)
        {
            _baseUrl = rootUrl.Replace("viewform", "formResponse?");


            if (!_field.Any() && !_checkbox.Any())
            {
                throw new InvalidOperationException("No data has been set to submit");
            }

            NameValueCollection nameValue = new NameValueCollection();


            foreach (var temp in _field)
            {
                nameValue.Add(temp.Key, temp.Value);
            }

            foreach (var temp in _checkbox)
            {
                for (int i = 0; i < temp.Value.Length; i++)
                {
                    _baseUrl += temp.Key + "=" + temp.Value[i] + "&";
                }
                _baseUrl =_baseUrl.TrimEnd();
            }

            _uri = new Uri(_baseUrl);
            byte[] response = _client.UploadValues(_uri, "POST", nameValue);
            string result = Encoding.UTF8.GetString(response);
            return result;
        }
    }
}
