using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _413_team_project.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            TimeSlotContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<TimeSlotContext>();
            
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.TimeSlots.Any())
            {
                // Add 5 days worth of time slots
                for (int d = 0; d < 5; d++)
                {
                    // Add time slots from 8am to 8pm
                    for (int h = 8; h <= 20; h++)
                    {
                        context.TimeSlots.Add(
                            new TimeSlot
                            {
                                Slot = DateTime.Today.AddDays(d).AddHours(h)
                            }
                        );
                    }
                }
            }

            context.SaveChanges();
        }
    }
}
