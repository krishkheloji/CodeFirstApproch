using JunBatchCodeFirstApproachImpl.Models;
using Microsoft.EntityFrameworkCore;

namespace JunBatchCodeFirstApproachImpl.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Emp> employee { get; set; }

        public DbSet<Employee> emps {get;set;}
        public DbSet<Managers> managers { get; set; }
        
        
        
        public DbSet<Manager> Manager { get; set; }
        public DbSet<Dept> depts { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Student> students { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Emp>(ent =>
            {
                ent.HasOne(x => x.manager)
                .WithMany(x => x.emps)
                .HasForeignKey(x => x.Mid)
                .OnDelete(DeleteBehavior.Restrict);

                ent.HasOne(x => x.dept)
                .WithMany(x => x.emps)
                .HasForeignKey(x => x.Did)
                .OnDelete(DeleteBehavior.Restrict);

                ent.HasOne(x => x.role)
                .WithMany(x => x.emps)
                .HasForeignKey(x => x.Rid)
                .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<Employee>(ent =>
            {
                ent.HasOne(x => x.mans)
                .WithMany(x => x.employees)
                .HasForeignKey(x => x.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            });
        }
    }
}
