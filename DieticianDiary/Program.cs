

//// c.Wyświetlenie danych pacjenta
//// d.Wyświetlenie wszystkich pacjentów
////// a1 Zostanę poproszony o wprowadzenie wszystkich szczegółów
////// b1 Zostane poproszony o wprowadzenie id pacjenta
////// b2 Usunę ten produkt z listy produktów
////// c1 Zostane poproszony o wprowadzenie id pacjenta
////// c2 Wyświetlę wszystkie informacje związane z pacjentem
////// d1 Wyświetlę liste pacjentów

using DieticianDiary;

MenuActionService actionService = new MenuActionService();
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

    PatientService patientService = new PatientService();
    switch (operation.KeyChar)
    {
        case '1':
            var id = patientService.AddPatient();
            break;
        case '2':
            var removeId = patientService.RemovePatientView();
            patientService.RemovePatient(removeId);
            break;
        case '3':

            break;
        case '4':

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
