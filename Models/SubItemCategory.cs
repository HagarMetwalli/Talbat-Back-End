using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Talbat.Models
{
    [Table("SubItemCategory")]
    public partial class SubItemCategory
    {
        public SubItemCategory()
        {
            //SubItems = new HashSet<SubItem>();
        }

        [Key]
        public int SubItemCategoryId { get; set; }

        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 1)]
        public string SubItemCategoryName { get; set; }

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 1)]
        public string SubItemCategoryDescription { get; set; }


        [InverseProperty(nameof(SubItem.SubItemCategory))]
        public virtual ICollection<SubItem> SubItems { get; set; }
    }
}
