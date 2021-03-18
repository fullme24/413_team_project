using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _413_team_project.Models
{
    public class Appointment
    {

        //Properties for managing the information needed to schedule and store an appointment into the database
        [Key]
        public int AppointmentId { get; set; }
        [Required]
        public string GroupName { get; set; }
        [Required]
        public int GroupSize { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime Slot { get; set; }
    }
}
