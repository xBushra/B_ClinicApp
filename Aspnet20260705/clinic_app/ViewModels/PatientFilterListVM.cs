namespace ClinicApp.ViewModels
{
    public class PatientFilteredListVM
    {

        public List<PatientReadVM> Patients { get; set; } = new();

        public PatientFilterVM Filter { get; set; } = new();
    }
}