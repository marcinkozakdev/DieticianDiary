using Warehouse;

namespace DieticianDiary
{
    public class PatientService
    {
        public List<Patient> Patients { get; set; }

        public PatientService()
        {
            Patients = new List<Patient>();
        }

        public void AddPatient()
        {
            Patient patient = new Patient();

            Console.WriteLine("Please enter patient information: ");
            Console.Write("Id: ");
            var id = Console.ReadLine();
            int patientId;
            Int32.TryParse(id, out patientId);

            Console.Write("First name: ");
            var firstName = Console.ReadLine();

            Console.Write("Last name: ");
            var lastName = Console.ReadLine();

            Console.Write("Age: ");
            var age = Console.ReadLine();
            int patientAge;
            Int32.TryParse(id, out patientAge);

            Console.Write("Email adress: ");
            var emailAdress = Console.ReadLine();

            Console.Write("Phone number: ");
            var phoneNumber = Console.ReadLine();

            Console.Write("Weight: ");
            var weight = Console.ReadLine();
            int patientWeight;
            Int32.TryParse(id, out patientWeight);

            Console.Write("Height: ");
            var height = Console.ReadLine();
            int patientHeight;
            Int32.TryParse(id, out patientHeight);

            patient.Id = patientId;
            patient.FirstName = firstName;
            patient.LastName = lastName;
            patient.Age = patientAge;
            patient.EmailAdress = emailAdress;
            patient.PhoneNumber = phoneNumber;
            patient.Weight = patientWeight;
            patient.Height = patientHeight;

            Patients.Add(patient);
        }

        public void RemovePatient()
        {
            Console.Write("Please enter id for patient you want to remove: ");

            var patientId = Console.ReadLine();
            int id;
            Int32.TryParse(patientId.ToString(), out id);

            Patient patientToRemove = new Patient();

            foreach (var patient in Patients)
            {
                if (patient.Id == id);
                {
                    patientToRemove = patient;
                    break;
                }
            }

            Patients.Remove(patientToRemove);
        }
     
        public void GetPatientById()
        {
            Console.Write("Please enter id for patient you want to show: ");

            var patientId = Console.ReadLine();
            int id;
            Int32.TryParse(patientId.ToString(), out id);

            Patient patientToShow = new Patient();

            foreach (var patient in Patients)
            {
                if (patient.Id == id)
                {
                    patientToShow = patient;
                    break;
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Patient id: {patientToShow.Id}");
            Console.WriteLine($"Patient first name: {patientToShow.FirstName}");
            Console.WriteLine($"Patient last name: {patientToShow.LastName}");
            Console.WriteLine($"Patient last name: {patientToShow.PhoneNumber}");
            Console.WriteLine($"Patient phone number: {patientToShow.EmailAdress}");
            Console.WriteLine($"Patient age: {patientToShow.Age}");
            Console.WriteLine($"Patient weight: {patientToShow.Weight}");
            Console.WriteLine($"Patient height: {patientToShow.Height}");
        }

        public void GetAllPatients()
        {
            List<Patient> patientsToShow = new List<Patient>();
            foreach (var patient in Patients)
            {
                patientsToShow.Add(patient);
            }

            Console.WriteLine(patientsToShow.ToStringTable(new[] {"Id", "First Name", "Last Name"}, a=>a.Id, a=>a.FirstName, a=>a.LastName));
        }
    }
}
