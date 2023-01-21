using DieticianDiary.Domain.Entity;
using Microsoft.VisualBasic;
using System.Net.WebSockets;
using System.Xml.Serialization;

namespace DieticianDiary.App.Concrete
{
    public class UserDataService
    {
        public UserData userData { get; private set; }
        private readonly MenuActionService _actionService;

        public UserDataService(MenuActionService actionService)
        {
            userData = ReadUserDataFromXml();
            _actionService = actionService;
        }

        public void InputUserData()
        {
            string firstName, lastName, emailAddress, sex, specialization;
            int id, phoneNumber;

            Console.WriteLine("No user data is available!");
            string title = "Please enter user information:";
            Console.WriteLine(title);
            _actionService.Underscore(title);
            Console.WriteLine();

            id = 1;

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

            SetUserData(firstName, lastName, phoneNumber, emailAddress, sex, specialization);
        }

        public void ShowUserData()
        {
            string title = "Your current data:";
            Console.WriteLine(title);
            _actionService.Underscore(title);
            Console.WriteLine();
            Console.WriteLine($"{userData}");
            _actionService.Underscore(title);
            Console.WriteLine("\n");
        }

        public void UpdateUserData()
        {
            Console.Clear();
            var operation = _actionService.ReadMenuAction("Update User", "Please let me know what you want to update:");
            Console.WriteLine();

            switch (operation.KeyChar)
            {
                case '1':
                    Console.Write("First name: ");
                    userData.FirstName = Console.ReadLine();
                    break;
                case '2':
                    Console.Write("Last name: ");
                    userData.LastName = Console.ReadLine();
                    break;
                case '3':
                    Console.Write("Phone number: ");
                    int phoneNumber = userData.PhoneNumber;
                    while (!Int32.TryParse(Console.ReadLine(), out phoneNumber))
                        Console.WriteLine("Wrong data type, enter a numeric value,");
                    break;
                case '4':
                    Console.Write("Email adress: ");
                    userData.EmailAddress = Console.ReadLine();
                    break;
                case '5':
                    Console.Write("Sex: ");
                    userData.Sex = Console.ReadLine();
                    
                    break;
                case '6':
                    Console.Write("Sepcialization: ");
                    userData.Specialization = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Action you entered doeas not exist");
                    break;
            }
        }

        public void SetUserData(string firstName, string lastName, int phoneNumber, string emailAddress, string sex, string specialization)
        {
            userData.FirstName = firstName;
            userData.LastName = lastName;
            userData.PhoneNumber = phoneNumber;
            userData.EmailAddress = emailAddress;
            userData.Sex = sex;
            
            userData.Specialization = specialization;
        }

        private UserData ReadUserDataFromXml()
        {
            XmlRootAttribute root = new XmlRootAttribute();
            root.ElementName = "UserData";
            root.IsNullable = true;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserData), root);
            if (!File.Exists(@"C:\Temp\userData.xml"))
            {
                return new UserData();
            }
            string xml = File.ReadAllText(@"C:\Temp\userData.xml");
            StringReader stringReader = new StringReader(xml);
            var item = (UserData)xmlSerializer.Deserialize(stringReader);
            return item;
        }

        public void SaveUserDataToXml()
        {
            XmlRootAttribute root = new XmlRootAttribute();
            root.ElementName = "UserData";
            root.IsNullable = true;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserData), root);

            using (StreamWriter streamWriter = new StreamWriter(@"C:\Temp\userData.xml"))
            {
                xmlSerializer.Serialize(streamWriter, userData);
            }
        }

    }
}
