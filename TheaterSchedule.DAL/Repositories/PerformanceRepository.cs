using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;
using Entities.Models;
using System.Linq;

namespace TheaterSchedule.DAL.Repositories
{
    public class PerformanceRepository : IPerformanceRepository
    {
        private TheaterDatabaseContext db;

        public PerformanceRepository( TheaterDatabaseContext context )
        {
            this.db = context;
        }

        public PerformanceDataModel GetInformationAboutPerformanceScreen( string languageCode, int id )
        {
            PerformanceDataModel perfomanceData = null;

            perfomanceData =
                (from performance in db.Performance
                 join performanceTr in db.PerformanceTr on performance.PerformanceId equals performanceTr.PerformanceId
                 join language in db.Language on performanceTr.LanguageId equals language.LanguageId
                 where ((performance.PerformanceId == id) && (language.LanguageCode == languageCode))
                 select new PerformanceDataModel
                 {
                     MainImage = performance.MainImage,
                     MinPrice = performance.MinPrice,
                     MaxPrice = performance.MaxPrice,
                     MinimumAge = performance.MinimumAge,
                     Duration = performance.Duration,
                     Description = performanceTr.Description,

                     FirstName = (from creativeTeamMemberTr in db.CreativeTeamMemberTr
                                  join creativeTeamMember in db.CreativeTeamMember on creativeTeamMemberTr.CreativeTeamMemberId
                                      equals creativeTeamMember.CreativeTeamMemberId
                                  join performanceCreativeTeamMember in db.PerformanceCreativeTeamMember on creativeTeamMember
                                      .CreativeTeamMemberId equals performanceCreativeTeamMember.CreativeTeamMemberId
                                  where ((performanceCreativeTeamMember.PerformanceId == id) && (language.LanguageId == creativeTeamMemberTr.LanguageId))
                                  select creativeTeamMemberTr.FistName),

                     LastName = (from creativeTeamMemberTr in db.CreativeTeamMemberTr
                                 join creativeTeamMember in db.CreativeTeamMember on creativeTeamMemberTr.CreativeTeamMemberId
                                     equals creativeTeamMember.CreativeTeamMemberId
                                 join performanceCreativeTeamMember in db.PerformanceCreativeTeamMember on creativeTeamMember
                                     .CreativeTeamMemberId equals performanceCreativeTeamMember.CreativeTeamMemberId
                                 where ((performanceCreativeTeamMember.PerformanceId == id) && (language.LanguageId == creativeTeamMemberTr.LanguageId))
                                 select creativeTeamMemberTr.LastName),

                 }).SingleOrDefault();



            return perfomanceData;
        }
    }
}
