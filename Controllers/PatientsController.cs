using BloodBankProject.Services;
using BloodBankProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankProject.Controllers
{
    [Authorize]
    public class PatientsController : Controller
    {
        private readonly ApplicationDbContext context;

        public PatientsController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var products = context.Patients.ToList();
            return View(products);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PatientDto patientDto)
        {
            if (!ModelState.IsValid)
            {
                return View(patientDto);
            }

            Patient patient = new Patient()
            {
                Name = patientDto.Name,
                Email = patientDto.Email,
                Contact = patientDto.Contact,
                Age = patientDto.Age,
                Bloodgroup = patientDto.Bloodgroup,
                DoctorName = patientDto.DoctorName,
                City = patientDto.City,
                Address = patientDto.Address
            };

            context.Patients.Add(patient);
            context.SaveChanges();
            return RedirectToAction("Index", "Patients");
        }

        public IActionResult Edit(int id)
        {
            var patient = context.Patients.Find(id);
            if (patient == null)
            {
                return RedirectToAction("Index", "Patients");
            }
            var patientDto = new PatientDto()
            {
                Name = patient.Name,
                Email = patient.Email,
                Contact = patient.Contact,
                Age = patient.Age,
                Bloodgroup = patient.Bloodgroup,
                DoctorName = patient.DoctorName,
                City = patient.City,
                Address = patient.Address
            };

            ViewData["PatientId"] = patient.Id;
            return View(patientDto);
        }

        [HttpPost]
        public IActionResult Edit(int id, PatientDto patientDto)
        {
            var patient = context.Patients.Find(id);
            if (patient == null)
            {
                return RedirectToAction("Index", "Patients");
            }

            if (!ModelState.IsValid)
            {
                ViewData["PatientId"] = patient.Id;
                return View(patientDto);
            }

            //update the product in the database
            patient.Name = patientDto.Name;
            patient.Email = patientDto.Email;
            patient.Contact = patientDto.Contact;
            patient.DoctorName = patientDto.DoctorName;
            patient.Age = patientDto.Age;
            patient.Bloodgroup = patientDto.Bloodgroup;
            
            patient.City = patientDto.City;
            patient.Address = patientDto.Address;

            context.SaveChanges();
            return RedirectToAction("Index", "Patients");
        }
        public IActionResult Delete(int id)
        {
            var patient = context.Patients.Find(id);
            if (patient == null)
            {
                return RedirectToAction("Index", "Patients");
            }
            context.Patients.Remove(patient);
            context.SaveChanges(true);
            return RedirectToAction("Index", "Patients");
        }
    }
}
