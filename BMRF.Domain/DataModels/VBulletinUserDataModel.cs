using System.Data.Entity;
using BMRF.Domain.Entities;

namespace BMRF.Domain.DataModels
{
    public partial class VBulletinUserDataModel : DbContext
    {
        public VBulletinUserDataModel()
            : base("name=VBulletinUserDataModel")
        {
        }

        public virtual DbSet<VBulletinUser> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VBulletinUser>()
                .Property(e => e.membergroupids)
                .IsUnicode(false);

            modelBuilder.Entity<VBulletinUser>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<VBulletinUser>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<VBulletinUser>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<VBulletinUser>()
                .Property(e => e.parentemail)
                .IsUnicode(false);

            modelBuilder.Entity<VBulletinUser>()
                .Property(e => e.homepage)
                .IsUnicode(false);

            modelBuilder.Entity<VBulletinUser>()
                .Property(e => e.icq)
                .IsUnicode(false);

            modelBuilder.Entity<VBulletinUser>()
                .Property(e => e.aim)
                .IsUnicode(false);

            modelBuilder.Entity<VBulletinUser>()
                .Property(e => e.yahoo)
                .IsUnicode(false);

            modelBuilder.Entity<VBulletinUser>()
                .Property(e => e.msn)
                .IsUnicode(false);

            modelBuilder.Entity<VBulletinUser>()
                .Property(e => e.skype)
                .IsUnicode(false);

            modelBuilder.Entity<VBulletinUser>()
                .Property(e => e.usertitle)
                .IsUnicode(false);

            modelBuilder.Entity<VBulletinUser>()
                .Property(e => e.timezoneoffset)
                .IsUnicode(false);

            modelBuilder.Entity<VBulletinUser>()
                .Property(e => e.birthday)
                .IsUnicode(false);

            modelBuilder.Entity<VBulletinUser>()
                .Property(e => e.ipaddress)
                .IsUnicode(false);

            modelBuilder.Entity<VBulletinUser>()
                .Property(e => e.salt)
                .IsUnicode(false);

            modelBuilder.Entity<VBulletinUser>()
                .Property(e => e.infractiongroupids)
                .IsUnicode(false);

            modelBuilder.Entity<VBulletinUser>()
                .Property(e => e.assetposthash)
                .IsUnicode(false);

            modelBuilder.Entity<VBulletinUser>()
                .Property(e => e.fbuserid)
                .IsUnicode(false);

            modelBuilder.Entity<VBulletinUser>()
                .Property(e => e.fbname)
                .IsUnicode(false);

            modelBuilder.Entity<VBulletinUser>()
                .Property(e => e.logintype)
                .IsUnicode(false);

            modelBuilder.Entity<VBulletinUser>()
                .Property(e => e.fbaccesstoken)
                .IsUnicode(false);

            modelBuilder.Entity<VBulletinUser>()
                .Property(e => e.comments)
                .IsUnicode(false);
        }
    }
}
