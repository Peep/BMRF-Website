using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMRF.Domain.Entities
{
    [Table("bmrf.player")]
    public partial class Player
    {
        [Column(TypeName = "uint")]
        public long ID { get; set; }

        [Required]
        [StringLength(32)]
        public string OriginDB { get; set; }

        [Column(TypeName = "uint")]
        public long CharacterID { get; set; }

        [Required]
        [StringLength(20)]
        public string PlayerUID { get; set; }

        public int InstanceID { get; set; }

        public DateTime Datestamp { get; set; }

        public DateTime? LastLogin { get; set; }

        [Required]
        [StringLength(1073741823)]
        public string Inventory { get; set; }

        [Required]
        [StringLength(1073741823)]
        public string Backpack { get; set; }

        [Required]
        [StringLength(128)]
        public string Worldspace { get; set; }

        [Required]
        [StringLength(300)]
        public string Medical { get; set; }

        public sbyte Alive { get; set; }

        public int Generation { get; set; }

        public DateTime? LastAte { get; set; }

        public DateTime? LastDrank { get; set; }

        public int KillsZ { get; set; }

        public int HeadshotsZ { get; set; }

        public int DistanceFoot { get; set; }

        public int Duration { get; set; }

        [Required]
        [StringLength(200)]
        public string CurrentState { get; set; }

        public int KillsH { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        public int KillsB { get; set; }

        public int Humanity { get; set; }

        public sbyte Infected { get; set; }
    }
}
