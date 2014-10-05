using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMRF.Domain.Entities
{
    [Table("vbulletin4.customavatar")]
    public partial class CustomAvatar
    {
        [Key]
        [Column(TypeName = "uint")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long userid { get; set; }

        [Column(TypeName = "mediumblob")]
        public byte[] filedata { get; set; }

        [Column(TypeName = "uint")]
        public long dateline { get; set; }

        [Required]
        [StringLength(100)]
        public string filename { get; set; }

        public short visible { get; set; }

        [Column(TypeName = "uint")]
        public long filesize { get; set; }

        [Column(TypeName = "usmallint")]
        public int width { get; set; }

        [Column(TypeName = "usmallint")]
        public int height { get; set; }

        [Column(TypeName = "mediumblob")]
        public byte[] filedata_thumb { get; set; }

        [Column(TypeName = "uint")]
        public long width_thumb { get; set; }

        [Column(TypeName = "uint")]
        public long height_thumb { get; set; }
    }
}
