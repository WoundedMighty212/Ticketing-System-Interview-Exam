//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ticketing_System_Interview_Exam.Models;

namespace Ticketing_System_Interview_Exam.Data
{
    public class Ticketing_System_Interview_ExamContext : DbContext
    {
        public Ticketing_System_Interview_ExamContext (DbContextOptions<Ticketing_System_Interview_ExamContext> options)
            : base(options)
        {
        }

        public DbSet<Ticketing_System_Interview_Exam.Models.Bug> Bug { get; set; } = default!;
        public DbSet<Ticketing_System_Interview_Exam.Models.User> User { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Bug>().ToTable("Bug");
            modelBuilder.Entity<User>().ToTable("User Table");

            // Seed data
            modelBuilder.Entity<Bug>().HasData(
                new Bug { BugId = 1, Summary = "Sample Bug 1", Description = "This is a sample bug", Status = "Open", CreatedByUserId = 1 },
                new Bug { BugId = 2, Summary = "Sample Bug 2", Description = "This is another sample bug", Status = "Closed", CreatedByUserId = 1 },
                new Bug { BugId = 3, Summary = "Sample Bug 3", Description = "This is a sample bug", Status = "inprogress", CreatedByUserId = 1 },
                new Bug { BugId = 4, Summary = "Sample Bug 4", Description = "This is another sample bug", Status = "resolved", CreatedByUserId = 1 }
            );
        }
    }
}
