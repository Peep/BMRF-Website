using System.Data.Entity;
using BMRF.Domain.Entities;

namespace BMRF.Domain.DataModels
{
    public partial class VBulletinCustomAvatarDataModel : DbContext
    {
        public VBulletinCustomAvatarDataModel()
            : base("name=VBulletinCustomAvatarDataModel")
        {
        }

        public virtual DbSet<CustomAvatar> customavatars { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomAvatar>()
                .Property(e => e.filename)
                .IsUnicode(false);
        }
    }
}
