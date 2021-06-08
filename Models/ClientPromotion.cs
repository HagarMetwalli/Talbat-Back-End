using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Talbat.Models
{
    [Table("ClientPromotion")]
    public partial class ClientPromotion
    {
        [Key]
        public int ClientId { get; set; }

        [Key]
        public int PromotionId { get; set; }


        [ForeignKey(nameof(ClientId))]
        [InverseProperty("ClientPromotions")]
        public virtual Client Client { get; set; }

        [ForeignKey(nameof(PromotionId))]
        [InverseProperty("ClientPromotions")]
        public virtual Promotion Promotion { get; set; }
    }
}
