using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMRF.Domain.Entities
{
    [Table("bmrf.whitelist")]
    public partial class WhitelistData
    {
        [Key]
        [Column(Order = 0, TypeName = "char")]
        [StringLength(32)]
        public string GUID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(24)]
        public string PUID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VUID { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(32)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool Banned { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(64)]
        public string BanReason { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(512)]
        public string Notes { get; set; }
    }
}
