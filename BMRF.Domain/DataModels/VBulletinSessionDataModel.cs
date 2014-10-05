using System.Data.Entity;
using BMRF.Domain.Entities;

namespace BMRF.Domain.DataModels
{
    public partial class VBulletinSessionDataModel : DbContext
    {
        public VBulletinSessionDataModel()
            : base("name=VBulletinSessionDataModel")
        {
        }

        public virtual DbSet<VBulletinSession> Sessions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VBulletinSession>()
                .Property(e => e.sessionhash)
                .IsUnicode(false);

            modelBuilder.Entity<VBulletinSession>()
                .Property(e => e.host)
                .IsUnicode(false);

            modelBuilder.Entity<VBulletinSession>()
                .Property(e => e.idhash)
                .IsUnicode(false);

            modelBuilder.Entity<VBulletinSession>()
                .Property(e => e.location)
                .IsUnicode(false);

            modelBuilder.Entity<VBulletinSession>()
                .Property(e => e.useragent)
                .IsUnicode(false);

            modelBuilder.Entity<VBulletinSession>()
                .Property(e => e.apiaccesstoken)
                .IsUnicode(false);
        }
    }
}
