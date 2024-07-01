using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            modelBuilder.Entity<Bug>().ToTable("Bug");
            modelBuilder.Entity<User>().ToTable("User Table");
        }
    }
}
