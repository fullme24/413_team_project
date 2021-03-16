using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _413_team_project.Models
{
    public class TimeSlot
    {
        [Required]
        public DateTime Slot { get; set; }
        [Required]
        public bool Scheduled { get; set; }

    }
}
