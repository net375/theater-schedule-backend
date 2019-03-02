using System;
using System.Collections.Generic;
using System.Text;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.DALwp.Repositories
{
    class PerformanceDetailsRepositoryWp //: IPerformanceDetailsRepository
    {
        public PerformanceDetailsDataModel GetInformationAboutPerformanceScreen(string languageCode, int id)
        {
            throw new NotImplementedException();
            //TODO
            //No such fields in API : MinPrice, MaxPrice, MinimumAge, Duration. But they exist in site        
        }
    }
}
