using ClinicApp.Helpers;
using ClinicApp.Models;
using ClinicApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace ClinicApp.Controllers
{
    [Authorize]
    public class PatientController : Controller
    {


        private readonly ClinicContext _db;
        private readonly SomeService _someService;


        public PatientController(ClinicContext db, SomeService someService, OtherService otherService)
        {
            _db = db;
            _someService = someService;
        }

        public IActionResult Index(PatientFilterVM vm)
        {
            var initQuery = _db.Patients
                .Include(d => d.Specialities)
                .Where(d => vm.Id == null || d.Id == vm.Id)
                .Where(d => vm.Name == null || d.Name.Contains(vm.Name))
                .Where(d => vm.HireDateStart == null || d.HireDate >= vm.HireDateStart)
                .Where(d => vm.HireDateEnd == null || d.HireDate <= vm.HireDateEnd);

            vm.TotalRows = initQuery.Count();

            var patients = initQuery
                .Select(d => d.ToPatientReadVM())
                .Skip((vm.Page - 1) * vm.PageSize)
                .Take(vm.PageSize)
                .ToList();

            return View(new PatientFilteredListVM { Patients = patients, Filter = vm });
        }
        public IActionResult Details(int id)
        {
            var patient = _db.Patients
                .Include(d => d.Specialities)
                .Single(d => d.Id == id)
                .ToPatientReadVM();
            return View(patient); 
        }

        public IActionResult Add()
        {
            var vm = new PatientCreateVM();
            vm.AllSpecialities = _db.Specialities
                .Select(s => s.ToSpecialityReadVM())
                .ToList();

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(PatientCreateVM vm)
        {

            if (!ModelState.IsValid)
            {
                vm.AllSpecialities = _db.Specialities
               .Select(s => s.ToSpecialityReadVM())
               .ToList();
                return View(vm);
            }

            var patient = vm.ToPatient();
            patient.Specialities = _db.Specialities
                  .Where(s => vm.SelectedSpecialityIds.Contains(s.Id))
                  .ToList();
            _db.Patients.Add(patient);
            _db.SaveChanges();

            return RedirectToAction(nameof(Details), new { patient.Id });
        }
       

        public IActionResult Delete(int id)
        {
            var patient = _db.Patients
                .Single(d => d.Id == id);
            _db.Patients.Remove(patient);
            _db.SaveChanges();

            return NoContent();
        }

        public IActionResult Update(int id)
        {
            var patient = _db.Patients
                .Include(d => d.Specialities)
                .Single(d => d.Id == id).ToPatientUpdateVM();
                .patient.AllSpecialities = _db.Specialities
                .Select(s => s.ToSpecialityReadVM())
                .ToList();

            return View(patient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, PatientUpdateVM vm)
        {

            if (!ModelState.IsValid)
            {
                vm.AllSpecialities = _db.Specialities
                .Select(s => s.ToSpecialityReadVM()).ToList();
                return View(vm);
            }

            var patient = _db.Patients.Include(d => d.Specialities).Single(d => d.Id == id);
            vm.ToPatient(patient);
            patient.Specialities = _db.Specialities
                .Where(s => vm.SelectedSpecialityIds.Contains(s.Id))
                .ToList();
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
