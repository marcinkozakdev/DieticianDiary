using DieticianDiary.App.Concrete;
using DieticianDiary.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DieticianDiary.App.Managers
{
    public class UserDataManager
    {
        private readonly UserDataService _userDataService;
        private readonly MenuActionService _actionService;


        public UserDataManager(UserDataService userDataService, MenuActionService actionService)
        {
            _userDataService = userDataService;
            _actionService = actionService;
        }

        public void SetUserData(MenuActionService actionService)
        {
            Console.Clear();
            var userDataMenu = actionService.GetMenuActionByMenuName("UserDataMenu");

            Console.WriteLine($"Your current data: \n\r\n{_userDataService.userData}");
            Console.WriteLine();
            for (int i = 0; i < userDataMenu.Count; i++)
                Console.WriteLine($"{userDataMenu[i].Id}. {userDataMenu[i].Name}");

            var chosenOption = Console.ReadKey();
            Console.Clear();

            if (chosenOption.KeyChar != '1')
                return;

            string firstName, lastName, emailAddress, sex, specialization;
            int id, phoneNumber;

            Console.WriteLine("Please enter user information: ");

            Console.Write("First name: ");
            firstName = Console.ReadLine();

            Console.Write("Last name: ");
            lastName = Console.ReadLine();

            Console.Write("Email adress: ");
            emailAddress = Console.ReadLine();

            Console.Write("Phone number: ");
            while (!Int32.TryParse(Console.ReadLine(), out phoneNumber))
                Console.WriteLine("Wrong data type, enter a numeric value,");

            Console.Write("Sex: ");
            sex = Console.ReadLine();

            Console.Write("Specialization: ");
            specialization = Console.ReadLine();

            _userDataService.SetUserData(firstName, lastName, phoneNumber, emailAddress, sex, specialization);
        }
    }
}
