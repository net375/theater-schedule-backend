using System.Collections.Generic;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;
using Entities.Models;
using System.Linq;

namespace TheaterSchedule.DAL.Repositories
{
    public class PerformanceDetailsRepository : IPerformanceDetailsRepository
    {
        private TheaterDatabaseContext db;

        public PerformanceDetailsRepository( TheaterDatabaseContext context )
        {
            this.db = context;
        }

        public PerformanceDetailsDataModel GetInformationAboutPerformanceScreen( string languageCode, int id )
        {
            PerformanceDetailsDataModel perfomanceData = null;
            perfomanceData =
                (from performance in db.Performance
                 join performanceTr in db.PerformanceTr on performance.PerformanceId equals performanceTr.PerformanceId
                 join language in db.Language on performanceTr.LanguageId equals language.LanguageId

                 where ((performance.PerformanceId) == id && (language.LanguageCode == languageCode))//
                 select new PerformanceDetailsDataModel
                 {
                     MainImage = performance.MainImage,
                     MinPrice = performance.MinPrice,
                     MaxPrice = performance.MaxPrice,
                     MinimumAge = performance.MinimumAge,
                     Duration = performance.Duration,
                     Description = performanceTr.Description,
                     Title = performanceTr.Title,
                     TeamMember = (from ctm_tm in db.CreativeTeamMemberTr
                                   join ctm in db.CreativeTeamMember on ctm_tm.CreativeTeamMemberId equals ctm.CreativeTeamMemberId
                                   join pctm in db.PerformanceCreativeTeamMember on ctm.CreativeTeamMemberId equals pctm.CreativeTeamMemberId
                                   join pctm_tr in db.PerformanceCreativeTeamMemberTr on pctm.PerformanceCreativeTeamMemberId equals pctm_tr.PerformanceCreativeTeamMemberId
                                       into pctm_tr_join
                                   from role in pctm_tr_join.DefaultIfEmpty()
                                   where ((pctm.PerformanceId == id)
                                          && (ctm_tm.LanguageId == language.LanguageId)
                                          && (role.LanguageId == language.LanguageId))
                                   select new TeamMember
                                   {
                                       Role = role.Role,
                                       FirstName = ctm_tm.FistName,
                                       LastName = ctm_tm.LastName,

                                   }).ToList(),

                     HashTag = (from ht_tr in db.HashTagTr
                                join ht in db.HashTag on ht_tr.HashTagId equals ht.HashTagId
                                join ht_performance in db.HashTagPerformance on ht.HashTagId equals ht_performance.HashTagId
                                where ((ht_performance.PerformanceId == id) && (ht_tr.LanguageId == language.LanguageId))
                                select ht_tr.Tag).ToList(),

                     GalleryImage = from galleryImage in db.GalleryImage
                                    where (galleryImage.PerformanceId == id)
                                    select galleryImage.Image

                 }).SingleOrDefault();

            return perfomanceData;
        }
    }
}
