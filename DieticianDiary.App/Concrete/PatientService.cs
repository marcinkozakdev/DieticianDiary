using DieticianDiary.App.Common;
using DieticianDiary.App.Concrete;
using DieticianDiary.App.Helpers;
using DieticianDiary.Domain.Entity;

namespace DieticianDiary.App
{
    public class PatientService : BaseService<Patient>
    {
        private readonly MenuActionService _actionService;
        public Patient patient { get; private set; }

        public PatientService(string path, MenuActionService actionService)
        {
            _actionService = actionService;
            Items = ReadItemsFromXml("Patients", path).ToList();
        }

        public Patient CreatePatient()
        {
            string firstName, lastName, emailAddress, sex;
            int id, age, phoneNumber, weight, height;

            Console.Clear();
            _actionService.MenuTitle("Add Patient to Database");
            Messages.Notice("\nPlease enter patient information: ");

            id = GetLastId();

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
            SetPatientData(id + 1, firstName, lastName, phoneNumber, emailAddress, sex, age, weight, height);
            Items.Add(patient);

            Messages.Positive($"Patient {patient.FirstName} {patient.LastName} by ID: {patient.Id} added to database!");
            Messages.Notice("\nPress any key to return to patient menu...");
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

            Console.WriteLine(patients.ToStringTable(new[] { "ID", "First Name", "Last Name" }, a => a.Id, a => a.FirstName, a => a.LastName));
            Messages.Notice("\nPress any key to return to patient menu...");
            Console.ReadKey();

            return patients;

        }

        public void DeletePatient()
        {
            Console.Clear();
            _actionService.MenuTitle("Delete Patient");
            Patient patient = GetPatientById();
            Items.Remove(patient);
            Messages.Positive($"Patient {patient.FirstName} {patient.LastName} by ID: {patient.Id} has been removed!");
            Messages.Notice("\nPress any key to return to patient menu...");
            Console.ReadKey();
        }


        public Patient UpdatePatientData()
        {
            while (true)
            {
                Console.Clear();
                _actionService.MenuTitle("Update patient data");
                Patient patient = GetPatientById();
                Console.Write($"{patient}");
                Console.WriteLine();
                Messages.Notice("\nPlease let me know which property you want to update:");
                var updateMenu = _actionService.GetMenuActionByMenuName("Update Patient");

                for (int i = 0; i < updateMenu.Count; i++)
                {
                    Console.WriteLine($"{updateMenu[i].Id}. {updateMenu[i].Name}");
                }
                var updateProperty = Messages.Choice();

                switch (updateProperty.KeyChar)
                {
                    case '0':
                        return patient;
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
                            Messages.Negative("Wrong data type, enter a numeric value");
                        break;
                    case '4':
                        Console.Write("Email adress: ");
                        patient.EmailAddress = Console.ReadLine();
                        break;
                    case '5':
                        Console.Write("Age: ");
                        int age = patient.Age;
                        while (!Int32.TryParse(Console.ReadLine(), out age))
                            Messages.Negative("Wrong data type, enter a numeric value");
                        break;
                    case '6':
                        Console.Write("Height: ");
                        int height = patient.Height;
                        while (!Int32.TryParse(Console.ReadLine(), out height))
                            Messages.Negative("Wrong data type, enter a numeric value");
                        break;
                    case '7':
                        Console.Write("Weight: ");
                        int weight = patient.Weight;
                        while (!Int32.TryParse(Console.ReadLine(), out weight))
                            Messages.Negative("Wrong data type, enter a numeric value");
                        break;
                    default:
                        Messages.Negative("Action you entered doeas not exist");
                        Messages.Notice("\nPress any key to return to update patient menu...");
                        Console.ReadKey();
                        _actionService.MenuTitle("Update patient data");
                        break;
                }

                Messages.Positive($"Patient by ID: {patient.Id} Updated!");
                Messages.Notice("\nPress any key to return to patient menu...");
                Console.ReadKey();
                return patient;
            }
        }

        private Patient GetPatientById()
        {
            int id;
            Messages.Notice("\nEnter the ID of the patient.");
            Console.Write("Patient ID: ");
            while (!Int32.TryParse(Console.ReadLine(), out id))
                Console.WriteLine("Wrong data type, enter a numeric value,");
            var patient = Items.FirstOrDefault(p => p.Id == id);

            return patient;
        }

        private List<Patient> GetAllPatients()
        {
            List<Patient> patients = Items.ToList();
            return patients;
        }

        private void SetPatientData(int id, string firstName, string lastName, int phoneNumber, string emailAddress, string sex, int age, int height, int weight)
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
