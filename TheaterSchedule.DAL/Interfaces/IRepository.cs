using System;
using System.Collections.Generic;
using System.Text;
using WordPressPCL;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IRepository
    {
        WordPressClient InitializeClient();
    }
}
