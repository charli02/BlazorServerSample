using Microsoft.EntityFrameworkCore;
using SampleModel;
using System;

namespace SampleData
{
    public class SampleDbContext : DbContext
    {
        public SampleDbContext(DbContextOptions<SampleDbContext> options)
           : base(options)
        {
        }
        public SampleDbContext()
           : base()
        {
        }

        #region DbSet
        public virtual DbSet<Employee> Employee { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<GroupGroupsMapping>()
            //            .HasOne(x => x.Group)
            //            .WithMany(x => x.GroupGroupsMapping)
            //            .HasForeignKey(x => x.GroupId);

            //modelBuilder.Entity<Auth_FeatureCodeMapping>().HasKey(c => new { c.FeatureId, c.CodeId });
        }
    }
}
