using DieticianDiary.App.Concrete;
using DieticianDiary.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieticianDiary.App.Managers
{
    public class ItemManager
    {
        private readonly MenuActionService _actionService;
        private PatientService _patientService;

        public ItemManager(MenuActionService actionService)
        {
            _actionService = actionService;
            _patientService = new PatientService();
        }

        public void AddNewPatient()
        {
            var addNewPatientMenu = _actionService.GetMenuActionByMenuName("AddNewItemMenu");
        }

        public int AddPatient()
        {

            Console.WriteLine("Please enter patient information: ");
            var lastId = _patientService.GetLastId();

            Console.Write("Id: ");
            var id = Console.ReadLine();
            int patientId;
            Int32.TryParse(id, out patientId);

            Console.Write("First name: ");
            var firstName = Console.ReadLine();

            Console.Write("Last name: ");
            var lastName = Console.ReadLine();

            Console.Write("Age: ");
            var patientAge = Console.ReadLine();
            int age;
            Int32.TryParse(id, out age);

            Console.Write("Email adress: ");
            var emailAdress = Console.ReadLine();

            Console.Write("Phone number: ");
            var phoneNumber = Console.ReadLine();

            Console.Write("Weight: ");
            var patientWeight = Console.ReadLine();
            int weight;
            Int32.TryParse(id, out weight);

            Console.Write("Height: ");
            var patientHeight = Console.ReadLine();
            int height;
            Int32.TryParse(id, out height);

            Patient patient = new Patient(lastId+1, firstName, lastName, phoneNumber, emailAdress, age, height, weight);

            _patientService.AddPatient(patient);

            return patient.Id;
        }
    }
}
