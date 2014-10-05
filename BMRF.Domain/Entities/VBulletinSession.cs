using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMRF.Domain.Entities
{
    [Table("vbulletin4.session")]
    public partial class VBulletinSession
    {
        [Key]
        [Column(TypeName = "char")]
        [StringLength(32)]
        public string sessionhash { get; set; }

        [Column(TypeName = "uint")]
        public long userid { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(15)]
        public string host { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(32)]
        public string idhash { get; set; }

        [Column(TypeName = "uint")]
        public long lastactivity { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(255)]
        public string location { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(100)]
        public string useragent { get; set; }

        [Column(TypeName = "usmallint")]
        public int styleid { get; set; }

        [Column(TypeName = "usmallint")]
        public int languageid { get; set; }

        [Column(TypeName = "usmallint")]
        public int loggedin { get; set; }

        [Column(TypeName = "usmallint")]
        public int inforum { get; set; }

        [Column(TypeName = "uint")]
        public long inthread { get; set; }

        [Column(TypeName = "usmallint")]
        public int incalendar { get; set; }

        [Column(TypeName = "usmallint")]
        public int badlocation { get; set; }

        public sbyte bypass { get; set; }

        [Column(TypeName = "usmallint")]
        public int profileupdate { get; set; }

        [Column(TypeName = "uint")]
        public long apiclientid { get; set; }

        [Required]
        [StringLength(32)]
        public string apiaccesstoken { get; set; }

        public sbyte isbot { get; set; }
    }
}
