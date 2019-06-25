using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface ISendDataToGoogleFormService
    {
        void SetFieldValues(Dictionary<string, string> data);
        void SetCheckboxValues(string key, params string[] values);
        Task<string> SubmitAsync(string rootUrl);
    }
}
