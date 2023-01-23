using DieticianDiary.App.Concrete;

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
            while (true)
            {
                _actionService.MenuTitle("Patient Database Menu");
                var operation = _actionService.ReadMenuAction("Patient Database Menu", "\nPlease let me know what you want to do:");

                switch (operation.KeyChar)
                {
                    case '0':
                        return;
                        break;
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
        }
    }
}

