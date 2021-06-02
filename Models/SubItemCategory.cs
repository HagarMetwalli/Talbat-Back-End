using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Talbat.Models
{
    public partial class SubItemCategory
    {
        public SubItemCategory()
        {
            //SubItems = new HashSet<SubItem>();
        }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int SubItemCategoryId { get; set; }

        [MaxLength(100), MinLength(3)]
        [Required]
        public string SubItemCategoryName { get; set; }

        [MaxLength(200), MinLength(3)]
        [Required]
        public string SubItemCategoryDescription { get; set; }

        public virtual ICollection<SubItem> SubItems { get; set; }
    }
}
