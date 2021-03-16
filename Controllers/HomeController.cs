using _413_team_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _413_team_project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private TimeSlotContext _TimeSlotContext { get; set; }
        private AppointmentContext _AppointmentContext { get; set; }

        public HomeController(ILogger<HomeController> logger, TimeSlotContext timeslotcontext, AppointmentContext appointmentcontext)
        {
            _logger = logger;
            _TimeSlotContext = timeslotcontext;
            _AppointmentContext = appointmentcontext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View(_TimeSlotContext.TimeSlots.Where(t => t.Scheduled == false));
        }

        [HttpPost]
        public IActionResult SignUp(int TimeSlotId)
        {
            ViewData["TimeSlot"] = _TimeSlotContext.TimeSlots
                .Where(t => t.TimeSlotId == TimeSlotId)
                .FirstOrDefault();

            return View("AppointmentForm");
        }

        [HttpGet]
        public IActionResult AppointmentForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AppointmentForm(Appointment appointment, int timeslotid)
        {
            appointment.Slot = _TimeSlotContext.TimeSlots
                 .Where(t => t.TimeSlotId == timeslotid)
                 .FirstOrDefault();
            
            _AppointmentContext.Appointments.Add(appointment);
            _AppointmentContext.SaveChanges();

            _TimeSlotContext.TimeSlots
                .Where(t => t.TimeSlotId == appointment.Slot.TimeSlotId)
                .FirstOrDefault().Scheduled = true;

            _TimeSlotContext.SaveChanges();

            return View("Index");
            
        }

        [HttpGet]
        public IActionResult AppointmentList()
        {
            return View(_AppointmentContext.Appointments);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
