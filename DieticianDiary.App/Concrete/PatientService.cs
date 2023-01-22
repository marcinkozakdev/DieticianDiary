using DieticianDiary.App.Common;
using DieticianDiary.App.Concrete;
using DieticianDiary.App.Helpers;
using DieticianDiary.Domain.Entity;
using System.Diagnostics.Metrics;
using System.Net.WebSockets;
using System.Numerics;
using System.Runtime.Intrinsics.X86;

namespace DieticianDiary.App
{
    public class PatientService : BaseService<Patient>
    {
        private readonly MenuActionService _actionService;
        public List<Patient> Patients { get; set; }
        public Patient patient { get; private set; }

        public PatientService(MenuActionService actionService)
        {
            _actionService = actionService;
            Patients = new List<Patient>();
        }

        public Patient CreatePatient()
        {
            string firstName, lastName, emailAddress, sex;
            int id, age, phoneNumber, weight, height;

            Console.Clear();
            _actionService.MenuTitle("Add Patient to Database");
            Messages.Notice("\nPlease enter patient information: ");

            Console.Write("Id: ");
            while (!Int32.TryParse(Console.ReadLine(), out id))
                Messages.Negative("Wrong data type, enter a numeric value!");

            Console.Write("First name: ");
            firstName = Console.ReadLine();

            Console.Write("Last name: ");
            lastName = Console.ReadLine();

            Console.Write("Age: ");
            while (!Int32.TryParse(Console.ReadLine(), out age))
                Messages.Negative("Wrong data type, enter a numeric value!");

            Console.Write("Email adress: ");
            emailAddress = Console.ReadLine();

            Console.Write("Phone number: ");
            while (!Int32.TryParse(Console.ReadLine(), out phoneNumber))
                Messages.Negative("Wrong data type, enter a numeric value!");

            Console.Write("Sex: ");
            sex = Console.ReadLine();

            Console.Write("Weight: ");
            while (!Int32.TryParse(Console.ReadLine(), out weight))
                Messages.Negative("Wrong data type, enter a numeric value!");

            Console.Write("Height: ");
            while (!Int32.TryParse(Console.ReadLine(), out height))
                Messages.Negative("Wrong data type, enter a numeric value!");

            patient = new Patient();
            SetPatientData(id, firstName, lastName, phoneNumber, emailAddress, sex, age, weight, height);
            Patients.Add(patient);

            Messages.Positive($"\nPatient {patient.FirstName} + {patient.LastName} added to database!");
            Console.ReadKey();

            return patient;
        }

        public Patient ReadPatientData()
        {
            Console.Clear();
            _actionService.MenuTitle("Show patient from database");
            Patient patient = GetPatientById();
            Messages.Notice($"\nCurrent patient data: ");
            Console.Write($"{patient}");
            Console.WriteLine();
            Messages.Notice("\nPress any key to return to patient menu...");
            Console.ReadKey();

            return patient;
        }

        public List<Patient> ReadAllPatientsData()
        {
            Console.Clear();
            _actionService.MenuTitle("List of all patients: ");
            List<Patient> getPatients = GetAllPatients();
            var patients = getPatients.ToList();

            Console.WriteLine(patients.ToStringTable(new[] { "Id", "First Name", "Last Name" }, a => a.Id, a => a.FirstName, a => a.LastName));
            Console.ReadKey();

            return patients;

        }

        public void DeletePatient()
        {
            Console.Clear();
            _actionService.MenuTitle("Delete Patient");
            Patient patient = GetPatientById();
            Patients.Remove(patient);
            Messages.Positive($"\nPatient {patient.FirstName} {patient.LastName} has been removed!");
            Messages.Notice("\nPress any key to return to patient menu...");
            Console.ReadKey();
        }

        public Patient GetPatientById()
        {
            int id;
            Messages.Notice("\nEnter the id of the patient you want to see.");
            Console.Write("Patient Id: ");
            while (!Int32.TryParse(Console.ReadLine(), out id))
                Console.WriteLine("Wrong data type, enter a numeric value,");
            var patient = Patients.FirstOrDefault(p => p.Id == id);

            return patient;
        }

        public List<Patient> GetAllPatients()
        {
            List<Patient> patients = Patients.ToList();
            return patients;
        }

        public Patient UpdatePatientData()
        {
            Console.Clear();
            _actionService.MenuTitle("Update patient data");
            Patient patient = GetPatientById();
            Messages.Notice("\nPlease let me know which property you want to update:");
            var updateMenu = _actionService.GetMenuActionByMenuName("Update Patient");

            for (int i = 0; i < updateMenu.Count; i++)
            {
                Console.WriteLine($"{updateMenu[i].Id}. {updateMenu[i].Name}");
            }
            var choice = "\nYour choice: ";
            Messages.Underscore(choice);
            Console.Write(choice);
            var updateProperty = Console.ReadKey();
            Console.WriteLine();
            Messages.Underscore(choice);
            Console.WriteLine();


            switch (updateProperty.KeyChar)
            {
                case '1':
                    Console.Write("First name: ");
                    patient.FirstName = Console.ReadLine();
                    break;
                case '2':
                    Console.Write("Last name: ");
                    patient.LastName = Console.ReadLine();
                    break;
                case '3':
                    Console.Write("Phone number: ");
                    int phoneNumber = patient.PhoneNumber;
                    while (!Int32.TryParse(Console.ReadLine(), out phoneNumber))
                        Console.WriteLine("Wrong data type, enter a numeric value,");
                    break;
                case '4':
                    Console.Write("Email adress: ");
                    patient.EmailAddress = Console.ReadLine();
                    break;
                case '5':
                    Console.Write("Age: ");
                    int age = patient.Age;
                    while (!Int32.TryParse(Console.ReadLine(), out age))
                        Console.WriteLine("Wrong data type, enter a numeric value,");
                    break;
                case '6':
                    Console.Write("Height: ");
                    int height = patient.Height;
                    while (!Int32.TryParse(Console.ReadLine(), out height))
                        Console.WriteLine("Wrong data type, enter a numeric value,");
                    break;
                case '7':
                    Console.Write("Weight: ");
                    int weight = patient.Weight;
                    while (!Int32.TryParse(Console.ReadLine(), out weight))
                        Console.WriteLine("Wrong data type, enter a numeric value,");
                    break;
                default:
                    Console.WriteLine("Action you entered doeas not exist");
                    break;
            }

            Messages.Positive($"\nPatient by id {patient.Id} Updated!");
            Messages.Notice("\nPress any key to return to patient menu...");
            Console.ReadKey();
            return patient;
        }

        public void SetPatientData(int id, string firstName, string lastName, int phoneNumber, string emailAddress, string sex, int age, int height, int weight)
        {
            patient.Id = id;
            patient.FirstName = firstName;
            patient.LastName = lastName;
            patient.PhoneNumber = phoneNumber;
            patient.EmailAddress = emailAddress;
            patient.Sex = sex;
            patient.Age = age;
            patient.Height = height;
            patient.Weight = weight;
        }
    }
}
