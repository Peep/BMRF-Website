using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMRF.Domain.Entities
{
    [Table("bmrf.items")]
    public partial class Item
    {
        [Key]
        [Column(Order = 0)]
        public string ID { get; set; }

        [Column(Order = 1)]
        public string Class { get; set; }

        [Column(Order = 2)]
        public string Category { get; set; }

        [Column(Order = 3)]
        public string Name { get; set; }

        [Column(Order = 4)]
        public string Subtitle { get; set; }

        [Column(Order = 5)]
        public string Description { get; set; }

        [Column(Order = 6)]
        public string Image { get; set; }
    }
}
