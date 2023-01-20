using DieticianDiary.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DieticianDiary.App.Concrete
{
    public class UserDataService
    {
        public UserData userData { get; private set; }

        public UserDataService()
        {
            userData = ReadUserDataFromXml();
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

        public void SetUserData(string firstName, string lastName, int phoneNumber, string emailAddress, string sex, string specialization)
        {
            userData.FirstName = firstName;
            userData.LastName = lastName;
            userData.PhoneNumber = phoneNumber;
            userData.EmailAddress = emailAddress;
            userData.Sex = sex;
            userData.Specialization = specialization;
        }
    }
}
