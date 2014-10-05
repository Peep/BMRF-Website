using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMRF.Domain.Entities
{
    [Table("vbulletin4.user")]
    public partial class VBulletinUser
    {
        [Key]
        public int userid { get; set; }

        [Column(TypeName = "usmallint")]
        public int usergroupid { get; set; }

        [Column(TypeName = "char")]
        [StringLength(250)]
        public string membergroupids { get; set; }

        [Column(TypeName = "usmallint")]
        public int displaygroupid { get; set; }

        [StringLength(100)]
        public string username { get; set; }

        [Column(TypeName = "char")]
        [StringLength(64)]
        public string password { get; set; }

        [Column(TypeName = "date")]
        public DateTime passworddate { get; set; }

        [Column(TypeName = "char")]
        [StringLength(100)]
        public string email { get; set; }

        [Column(TypeName = "usmallint")]
        public int styleid { get; set; }

        [Column(TypeName = "char")]
        [StringLength(50)]
        public string parentemail { get; set; }

        [Column(TypeName = "char")]
        [StringLength(100)]
        public string homepage { get; set; }

        [Column(TypeName = "char")]
        [StringLength(20)]
        public string icq { get; set; }

        [Column(TypeName = "char")]
        [StringLength(20)]
        public string aim { get; set; }

        [Column(TypeName = "char")]
        [StringLength(32)]
        public string yahoo { get; set; }

        [Column(TypeName = "char")]
        [StringLength(100)]
        public string msn { get; set; }

        [Column(TypeName = "char")]
        [StringLength(32)]
        public string skype { get; set; }

        [Column(TypeName = "usmallint")]
        public int showvbcode { get; set; }

        [Column(TypeName = "usmallint")]
        public int showbirthday { get; set; }

        [Column(TypeName = "char")]
        [StringLength(250)]
        public string usertitle { get; set; }

        public short customtitle { get; set; }

        [Column(TypeName = "uint")]
        public long joindate { get; set; }

        public short daysprune { get; set; }

        [Column(TypeName = "uint")]
        public long lastvisit { get; set; }

        [Column(TypeName = "uint")]
        public long lastactivity { get; set; }

        [Column(TypeName = "uint")]
        public long lastpost { get; set; }

        [Column(TypeName = "uint")]
        public long lastpostid { get; set; }

        [Column(TypeName = "uint")]
        public long posts { get; set; }

        public int reputation { get; set; }

        [Column(TypeName = "uint")]
        public long reputationlevelid { get; set; }

        [Column(TypeName = "char")]
        [StringLength(4)]
        public string timezoneoffset { get; set; }

        public short pmpopup { get; set; }

        public short avatarid { get; set; }

        [Column(TypeName = "uint")]
        public long avatarrevision { get; set; }

        [Column(TypeName = "uint")]
        public long profilepicrevision { get; set; }

        [Column(TypeName = "uint")]
        public long sigpicrevision { get; set; }

        [Column(TypeName = "uint")]
        public long options { get; set; }

        [Column(TypeName = "char")]
        [StringLength(10)]
        public string birthday { get; set; }

        [Column(TypeName = "date")]
        public DateTime birthday_search { get; set; }

        public short maxposts { get; set; }

        public short startofweek { get; set; }

        [Column(TypeName = "char")]
        [StringLength(15)]
        public string ipaddress { get; set; }

        [Column(TypeName = "uint")]
        public long referrerid { get; set; }

        [Column(TypeName = "usmallint")]
        public int languageid { get; set; }

        [Column(TypeName = "uint")]
        public long emailstamp { get; set; }

        [Column(TypeName = "usmallint")]
        public int threadedmode { get; set; }

        public short autosubscribe { get; set; }

        [Column(TypeName = "usmallint")]
        public int pmtotal { get; set; }

        [Column(TypeName = "usmallint")]
        public int pmunread { get; set; }

        [Column(TypeName = "char")]
        [StringLength(30)]
        public string salt { get; set; }

        [Column(TypeName = "uint")]
        public long ipoints { get; set; }

        [Column(TypeName = "uint")]
        public long infractions { get; set; }

        [Column(TypeName = "uint")]
        public long warnings { get; set; }

        [StringLength(255)]
        public string infractiongroupids { get; set; }

        [Column(TypeName = "usmallint")]
        public int infractiongroupid { get; set; }

        [Column(TypeName = "uint")]
        public long adminoptions { get; set; }

        [Column(TypeName = "uint")]
        public long profilevisits { get; set; }

        [Column(TypeName = "uint")]
        public long friendcount { get; set; }

        [Column(TypeName = "uint")]
        public long friendreqcount { get; set; }

        [Column(TypeName = "uint")]
        public long vmunreadcount { get; set; }

        [Column(TypeName = "uint")]
        public long vmmoderatedcount { get; set; }

        [Column(TypeName = "uint")]
        public long socgroupinvitecount { get; set; }

        [Column(TypeName = "uint")]
        public long socgroupreqcount { get; set; }

        [Column(TypeName = "uint")]
        public long pcunreadcount { get; set; }

        [Column(TypeName = "uint")]
        public long pcmoderatedcount { get; set; }

        [Column(TypeName = "uint")]
        public long gmmoderatedcount { get; set; }

        [StringLength(32)]
        public string assetposthash { get; set; }

        [StringLength(255)]
        public string fbuserid { get; set; }

        [Column(TypeName = "uint")]
        public long fbjoindate { get; set; }

        [StringLength(255)]
        public string fbname { get; set; }

        [Column(TypeName = "enum")]
        [StringLength(65532)]
        public string logintype { get; set; }

        [StringLength(255)]
        public string fbaccesstoken { get; set; }

        [Column(TypeName = "usmallint")]
        public int newrepcount { get; set; }

        [Column(TypeName = "uint")]
        public long bloggroupreqcount { get; set; }

        public int showblogcss { get; set; }

        public int ban { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string comments { get; set; }

        public bool? panjo_selling { get; set; }
    }
}
