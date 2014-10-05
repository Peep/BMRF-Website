using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMRF.Domain.Entities
{
    [Table("vbulletin4.usergroup")]
    public partial class Usergroup
    {
        [Column(TypeName = "usmallint")]
        public int usergroupid { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(100)]
        public string title { get; set; }

        [Required]
        [StringLength(250)]
        public string description { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(100)]
        public string usertitle { get; set; }

        [Column(TypeName = "usmallint")]
        public int passwordexpires { get; set; }

        [Column(TypeName = "usmallint")]
        public int passwordhistory { get; set; }

        [Column(TypeName = "usmallint")]
        public int pmquota { get; set; }

        [Column(TypeName = "usmallint")]
        public int pmsendmax { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(100)]
        public string opentag { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(100)]
        public string closetag { get; set; }

        [Column(TypeName = "usmallint")]
        public int canoverride { get; set; }

        [Column(TypeName = "usmallint")]
        public int ispublicgroup { get; set; }

        [Column(TypeName = "uint")]
        public long forumpermissions { get; set; }

        [Column(TypeName = "uint")]
        public long pmpermissions { get; set; }

        [Column(TypeName = "uint")]
        public long calendarpermissions { get; set; }

        [Column(TypeName = "uint")]
        public long wolpermissions { get; set; }

        [Column(TypeName = "uint")]
        public long adminpermissions { get; set; }

        [Column(TypeName = "uint")]
        public long genericpermissions { get; set; }

        [Column(TypeName = "uint")]
        public long genericpermissions2 { get; set; }

        [Column(TypeName = "uint")]
        public long genericoptions { get; set; }

        [Column(TypeName = "uint")]
        public long signaturepermissions { get; set; }

        [Column(TypeName = "uint")]
        public long visitormessagepermissions { get; set; }

        [Column(TypeName = "uint")]
        public long attachlimit { get; set; }

        [Column(TypeName = "usmallint")]
        public int avatarmaxwidth { get; set; }

        [Column(TypeName = "usmallint")]
        public int avatarmaxheight { get; set; }

        [Column(TypeName = "uint")]
        public long avatarmaxsize { get; set; }

        [Column(TypeName = "usmallint")]
        public int profilepicmaxwidth { get; set; }

        [Column(TypeName = "usmallint")]
        public int profilepicmaxheight { get; set; }

        [Column(TypeName = "uint")]
        public long profilepicmaxsize { get; set; }

        [Column(TypeName = "usmallint")]
        public int sigpicmaxwidth { get; set; }

        [Column(TypeName = "usmallint")]
        public int sigpicmaxheight { get; set; }

        [Column(TypeName = "uint")]
        public long sigpicmaxsize { get; set; }

        [Column(TypeName = "usmallint")]
        public int sigmaximages { get; set; }

        [Column(TypeName = "usmallint")]
        public int sigmaxvideos { get; set; }

        [Column(TypeName = "usmallint")]
        public int sigmaxsizebbcode { get; set; }

        [Column(TypeName = "usmallint")]
        public int sigmaxchars { get; set; }

        [Column(TypeName = "usmallint")]
        public int sigmaxrawchars { get; set; }

        [Column(TypeName = "usmallint")]
        public int sigmaxlines { get; set; }

        [Column(TypeName = "uint")]
        public long usercsspermissions { get; set; }

        [Column(TypeName = "uint")]
        public long albumpermissions { get; set; }

        [Column(TypeName = "usmallint")]
        public int albumpicmaxwidth { get; set; }

        [Column(TypeName = "usmallint")]
        public int albumpicmaxheight { get; set; }

        [Column(TypeName = "uint")]
        public long albummaxpics { get; set; }

        [Column(TypeName = "uint")]
        public long albummaxsize { get; set; }

        [Column(TypeName = "uint")]
        public long socialgrouppermissions { get; set; }

        [Column(TypeName = "uint")]
        public long pmthrottlequantity { get; set; }

        [Column(TypeName = "uint")]
        public long groupiconmaxsize { get; set; }

        [Column(TypeName = "uint")]
        public long maximumsocialgroups { get; set; }

        [Column(TypeName = "uint")]
        public long vbblog_general_permissions { get; set; }

        [Column(TypeName = "uint")]
        public long vbblog_entry_permissions { get; set; }

        [Column(TypeName = "uint")]
        public long vbblog_comment_permissions { get; set; }

        [Column(TypeName = "uint")]
        public long vbblog_customblocks { get; set; }

        [Column(TypeName = "uint")]
        public long vbblog_custompages { get; set; }

        [Column(TypeName = "uint")]
        public long vbcmspermissions { get; set; }

        public bool panjo_can_sell { get; set; }

        public decimal? panjo_transaction_fee { get; set; }

        public decimal? panjo_listing_fee { get; set; }
    }
}
