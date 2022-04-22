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
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Option> Options { get; set; }

        public DbSet<UserInfo> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Quiz>().HasData(
                new Quiz { QuizId = 1, Title = "BeetleJuice", Topic = "English", Author = "Me", DateCreated = DateTime.UtcNow, PassingGrade = 5 }
                );
                
            builder.Entity<Question>().HasData(
                new Question { QuestionId = 1,  QuestionText = "How do you spell 'Red'?", Image = null, Topic = "English", QuizId = 1 },
                new Question { QuestionId = 2, QuestionText = "What colour is a carrot?", Image = null, Topic = "English", QuizId = 1 }
                );

            builder.Entity<Option>().HasData(
                new Option { OptionId = 1, OptionText = "L-S-T-E-R", Order = "A", IsCorrect = false, QuestionId = 1 },
                new Option { OptionId = 2, OptionText = "16", Order = "B", IsCorrect = false, QuestionId = 1 },
                new Option { OptionId = 3, OptionText = "R-E-D", Order = "C", IsCorrect = true, QuestionId = 1 },

                new Option { OptionId = 4, OptionText = "Purple", Order = "A", IsCorrect = false, QuestionId = 2 },
                new Option { OptionId = 5, OptionText = "Orange", Order = "B", IsCorrect = true, QuestionId = 2 },
                new Option { OptionId = 6, OptionText = "Pineapple", Order = "C", IsCorrect = false, QuestionId = 2 },
                new Option { OptionId = 7, OptionText = "I don't know", Order = "D", IsCorrect = false, QuestionId = 2 }
                );

            builder.Entity<UserInfo>().HasData(
                new UserInfo { UserInfoID = 1, Username = "Shaun", Password = "abc_1234" }
                );

        }
    }
}
