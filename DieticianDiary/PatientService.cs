using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieticianDiary
{
    public class PatientService
    {
        public List<Patient> Patients { get; set; }

        public PatientService()
        {
            Patients = new List<Patient>();
        }

        public int AddPatient()
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

            patient.Id = patientId;
            patient.FirstName = firstName;
            patient.LastName = lastName;
            patient.Age = patientAge;
            patient.EmailAdress = emailAdress;
            patient.PhoneNumber = phoneNumber;

            Patients.Add(patient);
            return patientId;
        }

        public int RemovePatientView()
        {
            Console.Write("Please enter id for patient you want to remove: ");
            var patientId = Console.ReadKey();
            int id;
            Int32.TryParse(patientId.KeyChar.ToString(), out id);

            return id;
        }

        public void RemovePatient(int removeId)
        {
            Patient patientToRemove = new Patient();
            foreach (var patient in Patients)
            {
                if (patient.Id == removeId)
                {
                    patientToRemove = patient;
                    break;
                }
            }
            Patients.Remove(patientToRemove);
        }
    }
}
