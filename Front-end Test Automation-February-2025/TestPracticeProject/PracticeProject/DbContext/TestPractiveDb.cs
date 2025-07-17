using Microsoft.EntityFrameworkCore;
using PracticeProject.DbContext.DataModels;

namespace PracticeProject.DbContext
{
    public class TestPractiveDb : Microsoft.EntityFrameworkCore.DbContext
    {
        public TestPractiveDb(DbContextOptions<TestPractiveDb> options)
            : base(options)
        {
        }

        public DbSet<TestEntityModel> TestEntityModels { get; set; }
    }
}
