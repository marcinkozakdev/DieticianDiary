using DieticianDiary.App;
using DieticianDiary.App.Concrete;
using DieticianDiary.App.Managers;

MenuActionService actionService = new MenuActionService();
UserDataService userDataService = new UserDataService(actionService);
PatientService patientService = new PatientService(actionService);
PatientManager patientManager = new PatientManager(patientService, actionService);
UserDataManager userDataManager = new UserDataManager(userDataService, actionService);

while (true)
{
    actionService.MenuTitle("Dietician Diary App");
    var operation = actionService.ReadMenuAction("Main", "\nPlease let me know what you want to do:");

    Console.WriteLine("\n");

    switch (operation.KeyChar)
    {
        case '0':
            Environment.Exit(0);
            break;
        case '1':
            userDataManager.GoToUserData(actionService);
            break;
        case '2':
            patientManager.GoToPatientDatabase();
            break;
        case '3':
            
            break;
        default:
            Console.WriteLine("Action you entered doeas not exist");
            break;
    }
}
