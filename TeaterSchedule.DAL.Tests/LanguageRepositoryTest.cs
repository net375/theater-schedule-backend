using Entities.Models;
using Microsoft.EntityFrameworkCore;
using TheaterSchedule.DAL.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeaterSchedule.DAL.Tests
{
    [TestClass]
    public class LanguageRepositoryTest
    {
        [TestMethod]
        public void GetLanguageByIdTest()
        {
            var options = new DbContextOptionsBuilder<TheaterDatabaseContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase").Options;

            var context = new TheaterDatabaseContext(options);

            context.Language.Add(new Language { LanguageId = 1, LanguageCode = "en" });
            context.SaveChanges();

            var repository = new LanguageRepository(context);
            
            var actual = repository.GetLanguageById(1) ?? new Language { LanguageCode = "null"};
            var expected = new Language { LanguageCode = "en" };

            Assert.IsTrue(actual.LanguageCode == expected.LanguageCode);
        }

        [TestMethod]
        public void GetLanguageByNameTest()
        {
            var options = new DbContextOptionsBuilder<TheaterDatabaseContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase").Options;

            var context = new TheaterDatabaseContext(options);

            context.Language.Add(new Language { LanguageId = 2, LanguageCode = "uk" });
            context.SaveChanges();

            var repository = new LanguageRepository(context);

            var actual = repository.GetLanguageByName("uk") ?? new Language { LanguageId = 0 };
            var expected = new Language { LanguageId = 2 };

            Assert.IsTrue(actual.LanguageId == expected.LanguageId);
        }
    }
}
