using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMRF.Domain.Entities
{
    [Table("bmrf.streams")]
    public partial class Stream
    {
        [Key]
        [Column(Order = 0)]
        public string url { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(64)]
        public string platform { get; set; }
    }
}
