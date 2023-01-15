using DieticianDiary.Domain.Entity;

namespace DieticianDiary.App.Managers
{
    public class PatientManager
    {
        private readonly PatientService _patientService;

        public PatientManager(PatientService patientService)
        {
            _patientService = patientService;
        }

        public Patient AddPatient()
        {
            Patient patient = new Patient();
            _patientService.CreatePatient(patient);
            return patient;
        }

        public Patient GetPatient()
        {
            Patient patient = _patientService.GetPatientById();
            _patientService.ReadPatientData(patient);
            return patient;
        }

        public List<Patient> GetAllPatients()
        {
            List<Patient> patients = _patientService.GetAllPatients();
            _patientService.ReadAllPatientsData();
            return patients;
        }

        public Patient UpdatePatient()
        {
            Patient patient = _patientService.GetPatientById();
            _patientService.UpdatePatientData(patient);
            return patient;
        }

        public void RemovePatient()
        {
            Patient patient = _patientService.GetPatientById();
            _patientService.DeletePatient(patient);
        }
    }
}

