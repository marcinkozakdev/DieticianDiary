﻿using DieticianDiary.App;
using DieticianDiary.App.Concrete;
using DieticianDiary.App.Managers;

MenuActionService actionService = new MenuActionService();
PatientService patientService = new PatientService();
PatientManager patientManager = new PatientManager(actionService, patientService);

Console.WriteLine("Welcome to Dietician Diary app!");

while (true)
{
    Console.Clear();
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
            patientManager.AddPatient();
            break;
        case '2':
            patientManager.GetPatient();
            break;
        case '3':
            patientManager.UpdatePatient();
            break;
        case '4':
            patientManager.RemovePatient();
            break;
        default:
            Console.WriteLine("Action you entered doeas not exist");
            break;
    }
}
