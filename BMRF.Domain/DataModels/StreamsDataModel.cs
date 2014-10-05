using System.Data.Entity;
using BMRF.Domain.Entities;

namespace BMRF.Domain.DataModels
{
    public partial class StreamsDataModel : DbContext
    {
        public StreamsDataModel()
            : base("name=StreamsDataModel")
        {
        }

        public virtual DbSet<Stream> Streams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stream>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<Stream>()
                .Property(e => e.platform)
                .IsUnicode(false);
        }
    }
}
