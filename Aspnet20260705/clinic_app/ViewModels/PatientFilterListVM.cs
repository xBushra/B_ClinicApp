namespace ClinicApp.ViewModels
{
    public class PatientFilteredListVM
    {

        public List<PatientReadVM> Doctors { get; set; } = new();

        public PatientFilterVM Filter { get; set; } = new();
    }
}