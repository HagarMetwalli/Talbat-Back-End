using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Talbat.Models
{
    //enum WeekDays
    //{
    //    Monday,
    //    Tuesday,
    //    Wednesday,
    //    Thursday,
    //    Friday,
    //    Saturday,
    //    Sunday
    //}

    [Table("StoreWorkingHour")]
    [Index(nameof(StoreId), Name = "IX_StoreWorkingHour_Store_Id")]
    public partial class StoreWorkingHour
    {
        [Key]
        public int StoreWorkingHourId { get; set; }

        [Required]
        [StringLength(maximumLength: 15, MinimumLength = 1)]
        public string StoreWorkingHourDay { get; set; }
        //TODO:enum

        [Required]
        [Range(0, 24)]
        public int StoreWorkingHourStart { get; set; }

        [Required]
        [Range(0, 24)]
        public int StoreWorkingHourEnd { get; set; }

        public int StoreId { get; set; }


        [ForeignKey(nameof(StoreId))]
        [InverseProperty("StoreWorkingHours")]
        public virtual Store Store { get; set; }
    }
}
