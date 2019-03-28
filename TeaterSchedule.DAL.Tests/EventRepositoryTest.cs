using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheaterSchedule.DAL.Models;
using TheaterSchedule.DAL.Repositories;

namespace TeaterSchedule.DAL.Tests
{
    [TestClass]
    public class EventRepositoryTest
    {
        [TestMethod]
        public void GetAllEventsDateFilterTest()
        {
            var options = new DbContextOptionsBuilder<TheaterDatabaseContext>()
                 .UseInMemoryDatabase(databaseName: "DateFilterTestDb").Options;

            var context = new TheaterDatabaseContext(options);

            context.Event.Add(new Event { EventId = 1, Date = new DateTime(2020, 10, 10) });
            context.Event.Add(new Event { EventId = 2, Date = new DateTime(2018, 10, 10) });

            context.EventTr.Add(new EventTr { EventId = 1, LanguageId = 1 });
            context.EventTr.Add(new EventTr { EventId = 2, LanguageId = 2 });

            context.Language.Add(new Language { LanguageCode = "en", LanguageId = 1 });
            context.Language.Add(new Language { LanguageCode = "en", LanguageId = 2 });
            context.SaveChanges();

            var repository = new EventRepository(context);

            var actual = repository.GetAllEvents("en").First();
            var expected = new EventDataModel { EventId = 1, Date = new DateTime(2020, 10, 10) };

            Assert.IsTrue(actual.EventId == expected.EventId && actual.Date == expected.Date);
        }

        [TestMethod]
        public void GetAllEventsLanguageFilterTest()
        {
            var options = new DbContextOptionsBuilder<TheaterDatabaseContext>()
                  .UseInMemoryDatabase(databaseName: "LanguageFilterTestDb").Options;

            var context = new TheaterDatabaseContext(options);

            context.Event.Add(new Event { EventId = 1, Date = new DateTime(2020, 10, 10) });
            context.Event.Add(new Event { EventId = 2, Date = new DateTime(2021, 10, 10) });

            context.EventTr.Add(new EventTr { EventId = 1, LanguageId = 1 });
            context.EventTr.Add(new EventTr { EventId = 2, LanguageId = 2 });

            context.Language.Add(new Language { LanguageCode = "en", LanguageId = 1 });
            context.Language.Add(new Language { LanguageCode = "ua", LanguageId = 2 });
            context.SaveChanges();

            var repository = new EventRepository(context);

            var actual = repository.GetAllEvents("en").First();
            var expected = new EventDataModel { EventId = 1, Date = new DateTime(2020, 10, 10) };

            Assert.IsTrue(actual.EventId == expected.EventId && actual.Date == expected.Date);
        }
    }
}
