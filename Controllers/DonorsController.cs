using BloodBankProject.Models;
using BloodBankProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankProject.Controllers
{
    [Authorize]
    public class DonorsController : Controller
    {
        private readonly ApplicationDbContext context;

        public DonorsController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var donors = context.Donors.ToList();
            //var donors = context.Donors.OrderByDescending(p => p.Id).ToList(); Reverse Order
            return View(donors);
        }

        public IActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Create(DonorDto donorDto)
        {
            if(!ModelState.IsValid)
            {
                return View(donorDto);
            }

            Donor donor = new Donor()
            {
                Name = donorDto.Name,
                Email = donorDto.Email,
                Contact = donorDto.Contact,
                Age = donorDto.Age,
                Bloodgroup = donorDto.Bloodgroup,
                Birthdate = donorDto.Birthdate,
                City = donorDto.City,
                Address = donorDto.Address
            };

            context.Donors.Add(donor);
            context.SaveChanges();
            return RedirectToAction("Index", "Donors");
        }

        public IActionResult Edit(int id) 
        {
            var donor = context.Donors.Find(id);
            if (donor == null) 
            {
                return RedirectToAction("Index", "Donors");
            }
            var donorDto = new DonorDto()
            {
                Name = donor.Name,
                Email = donor.Email,
                Contact = donor.Contact,
                Age = donor.Age,
                Bloodgroup = donor.Bloodgroup,
                Birthdate = donor.Birthdate,
                City = donor.City,
                Address = donor.Address
            };

            ViewData["DonorId"] = donor.Id;
            return View(donorDto);
        }
        [HttpPost]
        public IActionResult Edit(int id, DonorDto donorDto)
        {
            var donor = context.Donors.Find(id);
            if (donor == null)
            {
                return RedirectToAction("Index", "Donors");
            }

            if (!ModelState.IsValid) 
            {
                ViewData["DonorId"] = donor.Id;
                return View(donorDto);
            }
            
            //update the product in the database
            donor.Name = donorDto.Name;
            donor.Email = donorDto.Email;
            donor.Contact = donorDto.Contact;
            donor.Age = donorDto.Age;
            donor.Bloodgroup = donorDto.Bloodgroup;
            donor.Birthdate = donorDto.Birthdate;
            donor.City = donorDto.City;
            donor.Address = donorDto.Address;

            context.SaveChanges();
            return RedirectToAction("Index", "Donors");
        }

        public IActionResult Delete(int id) 
        {
            var donor = context.Donors.Find(id);
            if (donor == null) 
            {
                return RedirectToAction("Index", "Donors");
            }
            context.Donors.Remove(donor);
            context.SaveChanges(true);
            return RedirectToAction("Index", "Donors");
        }
    }
}
