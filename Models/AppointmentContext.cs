﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _413_team_project.Models
{
    public class AppointmentContext : DbContext
    {
        public AppointmentContext (DbContextOptions<AppointmentContext> options) : base(options)
        {

        }

        public DbSet<Appointment> Appointments { get; set; }
    }
}
