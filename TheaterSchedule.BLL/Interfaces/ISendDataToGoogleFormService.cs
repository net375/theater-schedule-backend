using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface ISendDataToGoogleFormService
    {
        Dictionary<string, string> SetFieldValues(Dictionary<string, string> data);
        Dictionary<string, string[]> SetCheckboxValues(string key, params string[] values);
        string Submit(string rootUrl, Dictionary<string, string> valuesForField, Dictionary<string, string[]> valuesForCheckbox);
    }
}
