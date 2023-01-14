using DieticianDiary.App.Abstract;
using DieticianDiary.App.Concrete;
using DieticianDiary.Domain.Entity;

namespace DieticianDiary.App.Managers
{
    public class PatientManager
    {
        private readonly MenuActionService _actionService;
        private IService<Patient> _patientService;

        public PatientManager(MenuActionService actionService, IService<Patient> patientService)
        {
            _actionService = actionService;
            _patientService = patientService;
        }

        public Patient AddPatient(Patient patient)
        {
            _patientService.AddItem(patient);
            return patient;
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
