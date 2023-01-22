using DieticianDiary.App.Concrete;
using DieticianDiary.Domain.Entity;

namespace DieticianDiary.App.Managers
{
    public class PatientManager
    {
        private readonly PatientService _patientService;
        private readonly MenuActionService _actionService;

        public PatientManager(PatientService patientService, MenuActionService actionService)
        {
            _patientService = patientService;
            _actionService = actionService;
        }

        public void GoToPatientDatabase()
        {
            _actionService.MenuTitle("Patient Database Menu");
            var operation = _actionService.ReadMenuAction("Patient Database Menu", "\nPlease let me know what you want to do:");

            switch (operation.KeyChar)
            {
                case '0':
                    return;
                case '1':
                    _patientService.CreatePatient();
                    break;
                case '2':
                    _patientService.ReadPatientData();
                    break;
                case '3':
                    _patientService.ReadAllPatientsData();
                    break;
                case '4':
                   _patientService.UpdatePatientData();
                    break;
                case '5':
                    _patientService.DeletePatient();
                    break;
                default:
                    Console.WriteLine("Action you entered doeas not exist");
                    break;
            }
        }

        //public Patient AddPatient()
        //{
        //    Patient patient = new Patient();
        //    _patientService.CreatePatient(patient);
        //    return patient;
        //}

        //public Patient GetPatient()
        //{
        //    Patient patient = _patientService.GetPatientById();
        //    _patientService.ReadPatientData(patient);
        //    return patient;
        //}

        //public List<Patient> GetAllPatients()
        //{
        //    List<Patient> patients = _patientService.GetAllPatients();
        //    _patientService.ReadAllPatientsData();
        //    return patients;
        //}

        //public Patient UpdatePatient()
        //{
        //    Patient patient = _patientService.GetPatientById();
        //    _patientService.UpdatePatientData(patient);
        //    return patient;
        //}

        //public void RemovePatient()
        //{
        //    Patient patient = _patientService.GetPatientById();
        //    _patientService.DeletePatient(patient);
        //}
    }
}

