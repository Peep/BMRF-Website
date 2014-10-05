using System.Data.Entity;
using BMRF.Domain.Entities;

namespace BMRF.Domain.DataModels
{
    public partial class WhitelistDataModel : DbContext
    {
        public WhitelistDataModel()
            : base("name=WhitelistDataModel")
        {
        }

        public virtual DbSet<WhitelistData> WhitelistData { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WhitelistData>()
                .Property(e => e.GUID)
                .IsUnicode(false);

            modelBuilder.Entity<WhitelistData>()
                .Property(e => e.PUID)
                .IsUnicode(false);

            modelBuilder.Entity<WhitelistData>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<WhitelistData>()
                .Property(e => e.BanReason)
                .IsUnicode(false);

            modelBuilder.Entity<WhitelistData>()
                .Property(e => e.Notes)
                .IsUnicode(false);
        }
    }
}
