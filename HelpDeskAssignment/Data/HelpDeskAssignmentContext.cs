using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HelpDeskModelProject;

namespace HelpDeskAssignment.Data
{
    public class HelpDeskAssignmentContext : DbContext
    {
        public HelpDeskAssignmentContext(DbContextOptions<HelpDeskAssignmentContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("server=localhost;database=A05HelpDesk;user id=sa;password=P@ssword!;encrypt=false");            
        }

        public DbSet<User> User { get; set; } = default!;
        public DbSet<Tickets> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>()
            //    .HasOne(t => t.TicketList)
            //    .WithMany()
            //    .HasForeignKey(u => u.Username);

            modelBuilder.Entity<Tickets>()
                .HasOne(t => t.TicketSubmitter)
                .WithMany(v => v.TicketList)
                .HasForeignKey(u => u.TicketSubmitterID);

            modelBuilder.Entity<Tickets>()
                .HasOne(t => t.TicketResolver)
                .WithMany()
                .HasForeignKey(u => u.TicketResolverID);
        }
    }


}
