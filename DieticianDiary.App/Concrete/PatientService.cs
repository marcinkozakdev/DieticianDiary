using DieticianDiary.App.Abstract;
using DieticianDiary.App.Common;
using DieticianDiary.App.Helpers;
using DieticianDiary.Domain.Entity;

namespace DieticianDiary.App
{
    public class PatientService : BaseService<Patient>
    {
        public List<Patient> Patients { get; set; }

        public PatientService()
        {
            Patients = new List<Patient>();
        }

        public Patient CreatePatient(Patient patient)
        {
            string firstName, lastName, emailAdress, sex;
            int id, age, phoneNumber, weight, height;

            Console.WriteLine("Please enter patient information: ");

            Console.Write("Id: ");
            while (!Int32.TryParse(Console.ReadLine(), out id))
                Console.WriteLine("Wrong data type, enter a numeric value,");

            Console.Write("First name: ");
            firstName = Console.ReadLine();

            Console.Write("Last name: ");
            lastName = Console.ReadLine();

            Console.Write("Age: ");
            while (!Int32.TryParse(Console.ReadLine(), out age))
                Console.WriteLine("Wrong data type, enter a numeric value,");

            Console.Write("Email adress: ");
            emailAdress = Console.ReadLine();

            Console.Write("Phone number: ");
            while (!Int32.TryParse(Console.ReadLine(), out phoneNumber))
                Console.WriteLine("Wrong data type, enter a numeric value,");

            Console.Write("Sex: ");
            sex = Console.ReadLine();

            Console.Write("Weight: ");
            while (!Int32.TryParse(Console.ReadLine(), out weight))
                Console.WriteLine("Wrong data type, enter a numeric value,");

            Console.Write("Height: ");
            while (!Int32.TryParse(Console.ReadLine(), out height))
                Console.WriteLine("Wrong data type, enter a numeric value,");

            patient = new Patient();

            patient.Id = id;
            patient.FirstName = firstName;
            patient.LastName = lastName;
            patient.Age = age;
            patient.Sex = sex;
            patient.EmailAdress = emailAdress;
            patient.PhoneNumber = phoneNumber;
            patient.Weight = weight;
            patient.Height = height;

            Patients.Add(patient);

            return patient;
        }

        public Patient ReadPatientData(Patient patient)
        {
            Console.WriteLine();
            Console.WriteLine($"Patient id: {patient.Id}");
            Console.WriteLine($"Patient first name: {patient.FirstName}");
            Console.WriteLine($"Patient last name: {patient.LastName}");
            Console.WriteLine($"Patient last name: {patient.PhoneNumber}");
            Console.WriteLine($"Patient phone number: {patient.EmailAdress}");
            Console.WriteLine($"Patient age: {patient.Age}");
            Console.WriteLine($"Patient weight: {patient.Weight}");
            Console.WriteLine($"Patient height: {patient.Height}");
            
            return patient;
        }

        public List<Patient> ReadAllPatientsData()
        {
           var patients =  Patients.ToList();

            Console.WriteLine(patients.ToStringTable(new[] { "Id", "First Name", "Last Name" }, a => a.Id, a => a.FirstName, a => a.LastName));

            return patients;

        }

        public void DeletePatient(Patient patient)
        {
            Patients.Remove(patient);
        }
        
        public Patient GetPatientById()
        {
            int id;
             Console.Write("Please enter patient Id: ");

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

        public Patient UpdatePatientData(Patient patient)
        {
            return patient;
        }
    }
}
