using DieticianDiary;

MenuActionService actionService = new MenuActionService();
PatientService patientService = new PatientService();
actionService = Initialize(actionService);

Console.WriteLine("Welcome to Dietician Diary app!");
while (true)
{
    Console.WriteLine("\nPlease let me know what you want to do:");
    var mainMenu = actionService.GetMenuActionByMenuName("Main");

    for (int i = 0; i < mainMenu.Count; i++)
    {
        Console.WriteLine($"{mainMenu[i].Id}. {mainMenu[i].Name}");
    }

    Console.Write("\nYour choose: ");
    var operation = Console.ReadKey();
    Console.WriteLine("\n");

    switch (operation.KeyChar)
    {
        case '1':
            patientService.AddPatient();
            break;
        case '2':
            patientService.RemovePatient();
            break;
        case '3':
            patientService.GetPatientById();
            break;
        case '4':
            patientService.GetAllPatients();
            break;
        default:
            Console.WriteLine("Action you entered doeas not exist");
            break;
    }
}

static MenuActionService Initialize(MenuActionService actionService)
{
    actionService.AddNewAction(1, "Add patient", "Main");
    actionService.AddNewAction(2, "Remove patient", "Main");
    actionService.AddNewAction(3, "Show patient", "Main");
    actionService.AddNewAction(4, "List of patients", "Main");
    return actionService;
}
