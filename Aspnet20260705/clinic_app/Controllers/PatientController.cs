
using ClinicApp.Models;
using ClinicApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace ClinicApp.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult Index()
        {
            //var patient = Data.Patient;
            var patient = Data.Patient.Select(d => d.ToPatientReadVM()).ToList();
            return View(patient);
        }
        public IActionResult Details(int id)
        {
            //var patient = Data.Patient.Single( d => d.Id == id);
            var patient = Data.Patient.Single(d => d.Id == id).ToPatientReadVM();
            return View(patient);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(PatientCreateVM vm)
        {

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var patient = vm.ToPatient();
            patient.Id = Data.Patient.Max(d => d.Id) + 1;
            Data.Patient.Add(patient);

            return RedirectToAction(nameof(Details), new { patient.Id });
        }

        public IActionResult Delete(int id)
        {
            var patient = Data.Patient.Single(d => d.Id == id);
            Data.Patient.Remove(patient);

            return NoContent();
        }

        public IActionResult Update(int id)
        {
            var patient = Data.Patient.Single(d => d.Id == id).ToPatientUpdateVM();
            return View(patient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, PatientUpdateVM vm)
        {

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var patient = Data.Patient.Single(d => d.Id == id);
            vm.ToPatient(patient);

            return RedirectToAction(nameof(Index));
        }
    }
}
