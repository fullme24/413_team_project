using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _413_team_project.Models
{
    public class TimeSlotContext : DbContext
    {
        public TimeSlotContext (DbContextOptions<TimeSlotContext> options) : base(options)
        {

        }

        public DbSet<TimeSlot> TimeSlots { get; set; }
    }
}
