using System;
using System.Collections.Generic;
using System.Text;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.DALwp.Repositories
{
    class ScheduleRepositoryWp //: IScheduleRepository
    {
        public IEnumerable<ScheduleDataModel> GetListPerformancesByDateRange(string phoneId, string languageCode, DateTime? startDate, DateTime? endDate)
        {
            throw new NotImplementedException();
            //TODO
            //No such fields in API: Beginning. But they exist in site
        }
    }
}
