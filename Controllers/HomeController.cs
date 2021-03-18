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

        //Bringing in database contexts to work with data
        private TimeSlotContext _TimeSlotContext { get; set; }
        private AppointmentContext _AppointmentContext { get; set; }

        public HomeController(ILogger<HomeController> logger, TimeSlotContext timeslotcontext, AppointmentContext appointmentcontext)
        {
            _logger = logger;

            //assigning the values to contexts
            _TimeSlotContext = timeslotcontext;
            _AppointmentContext = appointmentcontext;
        }

        //Calling home view at start of project
        public IActionResult Index()
        {
            return View();
        }

        //Calling sign up page and returning with it the timeslots that are still available
        [HttpGet]
        public IActionResult SignUp()
        {
            return View(_TimeSlotContext.TimeSlots.Where(t => t.Scheduled == false));
        }

        //sending information from form on sign up view to appointment form view
        [HttpPost]
        public IActionResult SignUp(int TimeSlotId)
        {
            //Grabs timeslot based on the id seclected by user and sets that timeslot to a variable called timeSlot
            TimeSlot timeSlot = _TimeSlotContext.TimeSlots
                .Where(t => t.TimeSlotId == TimeSlotId)
                .FirstOrDefault();

            //Set the new DateTime varibale to the value of the slot property of the TimeSlot object that we made above
            DateTime ts = timeSlot.Slot;

            //Stores ts into a TempData for later use
            TempData["Slot"] = ts;

            return View("AppointmentForm");
        }

        [HttpGet]
        public IActionResult AppointmentForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AppointmentForm(Appointment appointment)
        {
            //Following code (2 lines) adds the appointment information enterd by user into database
            _AppointmentContext.Appointments.Add(appointment);
            _AppointmentContext.SaveChanges();
            
            //Changes the scheduled property of the TimeSlot database
            _TimeSlotContext.TimeSlots
                .Where(t => t.Slot == appointment.Slot)
                .FirstOrDefault().Scheduled = true;

            //Saves the changes
            _TimeSlotContext.SaveChanges();

            return View("Index");
            
        }

        //Shows User all the current appointments
        [HttpGet]
        public IActionResult AppointmentList()
        {
            return View(_AppointmentContext.Appointments);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
