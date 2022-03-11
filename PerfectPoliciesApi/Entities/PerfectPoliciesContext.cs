using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectPoliciesApi.Entities
{
    public class PerfectPoliciesContext : DbContext
    {
        public PerfectPoliciesContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Question>().HasData(
                new Question { questionId = 0, topic = "math", answer = "5", ansA = "1", ansB = "2", ansC = "3", ansD = "4", ansE = "5" }
                );
        }
    }
}
