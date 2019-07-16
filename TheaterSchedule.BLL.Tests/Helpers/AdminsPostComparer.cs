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
            AdminsPost y = b as AdminsPost;

            if (x.ToUserId.HasValue && !y.ToUserId.HasValue)
            {
                return 1;
            }
            else if (!x.ToUserId.HasValue && y.ToUserId.HasValue)
            {
                return 1;
            }

            if (x.AdminsPostId.CompareTo(y.AdminsPostId) != 0)
            {
                return x.AdminsPostId.CompareTo(y.AdminsPostId);
            }
            else if (x.Subject.CompareTo(y.Subject) != 0)
            {
                return x.Subject.CompareTo(y.Subject);
            }
            else if (x.PostText.CompareTo(y.PostText) != 0)
            {
                return x.PostText.CompareTo(y.PostText);
            }
            else if (x.PostDate.CompareTo(y.PostDate) != 0)
            {
                return x.PostDate.CompareTo(y.PostDate);
            }
            else if (x.IsPersonal.CompareTo(y.IsPersonal) != 0)
            {
                return x.IsPersonal.CompareTo(y.IsPersonal);
            }
            else if (x.ToUserId.HasValue && y.ToUserId.HasValue)
            {
                return x.ToUserId.Value.CompareTo(y.ToUserId.Value);
            }
            else
            {
                return 0;
            }
        }
    }
}
