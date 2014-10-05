using System.Data.Entity;
using BMRF.Domain.Entities;

namespace BMRF.Domain.DataModels
{
    public partial class VBulletinUsergroupDataModel : DbContext
    {
        public VBulletinUsergroupDataModel()
            : base("name=VBulletinUsergroupDataModel")
        {
        }

        public virtual DbSet<Usergroup> Usergroups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usergroup>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<Usergroup>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Usergroup>()
                .Property(e => e.usertitle)
                .IsUnicode(false);

            modelBuilder.Entity<Usergroup>()
                .Property(e => e.opentag)
                .IsUnicode(false);

            modelBuilder.Entity<Usergroup>()
                .Property(e => e.closetag)
                .IsUnicode(false);
        }
    }
}
