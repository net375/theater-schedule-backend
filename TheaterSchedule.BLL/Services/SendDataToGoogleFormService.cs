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
    public class SendDataToGoogleFormService : ISendDataToGoogleFormService
    {
       
        public Dictionary<string, string> SetFieldValues(Dictionary<string, string> data)
        {
            Dictionary<string, string> resDataToStoreInField = new Dictionary<string, string>();
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            if (data.Keys.Any(value => string.IsNullOrWhiteSpace(value)))
                throw new ArgumentNullException(nameof(data), "empty keys");

            var fieldsWithData = data.Where(param => !string.IsNullOrWhiteSpace(param.Value));

            foreach (var param in fieldsWithData)
            {
                resDataToStoreInField[param.Key] = param.Value;
            }
            return resDataToStoreInField;
        }

        public Dictionary<string, string[]> SetCheckboxValues(string key, params string[] values)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));
            Dictionary<string, string[]> resDataToStoreInCheckBox = new Dictionary<string, string[]>();
            var valuesWithData = values.Where(value => !string.IsNullOrWhiteSpace(value)).ToArray();
            resDataToStoreInCheckBox[key] = valuesWithData;
            return resDataToStoreInCheckBox;
        }

        public string Submit(string rootUrl, Dictionary<string, string> valuesForField, Dictionary<string, string[]> valuesForCheckbox)
        {
            rootUrl = rootUrl.Replace("viewform", "formResponse?");
            var resDataToStoreInCheckBox = new Dictionary<string, string[]>();

            foreach(var temp in valuesForCheckbox)
            {
                var res = SetCheckboxValues(temp.Key, temp.Value).First();
                resDataToStoreInCheckBox.Add(res.Key, res.Value);
            }

            var resDataToStoreInField = SetFieldValues(valuesForField);

            if (!resDataToStoreInField.Any() && !resDataToStoreInCheckBox.Any())
            {
                throw new InvalidOperationException("No data has been set to submit");
            }

            NameValueCollection nameValue = new NameValueCollection();


            foreach (var temp in resDataToStoreInField)
            {
                nameValue.Add(temp.Key, temp.Value);
            }

            foreach (var temp in resDataToStoreInCheckBox)
            {
                for (int i = 0; i < temp.Value.Length; i++)
                {
                    rootUrl += $"{temp.Key}={temp.Value[i]}&";
                }
                rootUrl = rootUrl.TrimEnd();
            }

            Uri _uri = new Uri(rootUrl);
            WebClient _client = new WebClient();
            byte[] response = _client.UploadValues(_uri, "POST", nameValue);
            string result = Encoding.UTF8.GetString(response);
            return result;
        }
    }
}
