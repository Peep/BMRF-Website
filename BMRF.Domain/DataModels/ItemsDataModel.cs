using System.Data.Entity;

namespace BMRF.Domain.DataModels
{
    public class ItemsDataModel : DbContext
    {
        public ItemsDataModel()
            : base("name=ItemsDataModel")
        {
        }

        public virtual DbSet<Entities.Item> Items { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Item>()
                .Property(e => e.ID);

            modelBuilder.Entity<Entities.Item>()
                .Property(e => e.Class)
                .IsUnicode(false);

            modelBuilder.Entity<Entities.Item>()
                .Property(e => e.Category)
                .IsUnicode(false);

            modelBuilder.Entity<Entities.Item>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Entities.Item>()
                .Property(e => e.Subtitle)
                .IsUnicode(false);

            modelBuilder.Entity<Entities.Item>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Entities.Item>()
                .Property(e => e.Image)
                .IsUnicode(false);
        }
    }
}
