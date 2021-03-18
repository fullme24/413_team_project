using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _413_team_project.Models
{
    public class TimeSlot
    {
        //This is a model that helps to keep track of all the time slots that users can select
        [Key]
        public int TimeSlotId { get; set; }
        [Required]
        public DateTime Slot { get; set; }
        [Required]
        public bool Scheduled { get; set; } = false;


    }
}
