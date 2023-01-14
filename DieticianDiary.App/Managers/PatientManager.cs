using DieticianDiary.App.Abstract;
using DieticianDiary.Domain.Entity;

namespace DieticianDiary.App.Managers
{
    public class PatientManager
    {
        private IService<Patient> _patientService;

        public PatientManager(IService<Patient> patientService)
        {
            _patientService = patientService;
        }

        public Patient AddPatient()
        {
            Patient patient = new Patient();
            _patientService.AddItem(patient);
        }

        public Patient UpdatePatient(Patient patient)
        {
            _patientService.UpdateItem(patient);
            return patient;
        }

        public void RemovePatient(int id)
        {
            var patient = _patientService.GetItemById(id);
            _patientService.RemoveItem(patient);
        }

        public Patient GetPatient(int id)
        {
            var patient = _patientService.GetItemById(id);
            return patient;
        }
    }
}
