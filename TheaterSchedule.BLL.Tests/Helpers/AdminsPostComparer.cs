using Entities.Models;
using System.Collections;
using System.Collections.Generic;

namespace TheaterSchedule.BLL.Tests.Helpers
{
    public class AdminsPostComparer : IComparer
    {
        public int Compare(object a, object b)
        {
            AdminsPost x = a as AdminsPost;
            AdminsPost y = a as AdminsPost;

            bool areEqual = x.AdminsPostId == y.AdminsPostId
                && x.Subject == y.Subject
                && x.PostText == y.PostText
                && x.PostDate == y.PostDate
                && x.IsPersonal == y.IsPersonal
                && x.ToUserId == y.ToUserId;

            if (areEqual)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
