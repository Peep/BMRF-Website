using System.Data.Entity;
using BMRF.Domain.Entities;

namespace BMRF.Domain.DataModels
{
    public partial class PlayerDataModel : DbContext
    {
        public PlayerDataModel()
            : base("name=PlayerDataModel")
        {
        }

        public virtual DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .Property(e => e.OriginDB)
                .IsUnicode(false);

            modelBuilder.Entity<Player>()
                .Property(e => e.PlayerUID)
                .IsUnicode(false);

            modelBuilder.Entity<Player>()
                .Property(e => e.Inventory)
                .IsUnicode(false);

            modelBuilder.Entity<Player>()
                .Property(e => e.Backpack)
                .IsUnicode(false);

            modelBuilder.Entity<Player>()
                .Property(e => e.Worldspace)
                .IsUnicode(false);

            modelBuilder.Entity<Player>()
                .Property(e => e.Medical)
                .IsUnicode(false);

            modelBuilder.Entity<Player>()
                .Property(e => e.CurrentState)
                .IsUnicode(false);

            modelBuilder.Entity<Player>()
                .Property(e => e.Model)
                .IsUnicode(false);
        }
    }
}
