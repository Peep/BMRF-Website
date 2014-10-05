using System.Data.Entity;
using BMRF.Domain.Entities;

namespace BMRF.Domain.DataModels
{
    public partial class StatsDataModel : DbContext
    {
        public StatsDataModel()
            : base("name=StatsDataModel")
        {
        }

        public virtual DbSet<PlayerStat> Stats { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerStat>()
                .Property(e => e.GUID)
                .IsUnicode(false);

            modelBuilder.Entity<PlayerStat>()
                .Property(e => e.PUID)
                .IsUnicode(false);

            modelBuilder.Entity<PlayerStat>()
                .Property(e => e.ForumUsername)
                .IsUnicode(false);

            modelBuilder.Entity<PlayerStat>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
