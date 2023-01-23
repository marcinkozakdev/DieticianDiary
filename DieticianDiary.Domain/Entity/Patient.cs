using DieticianDiary.Domain.Common;
using System.Xml.Serialization;

namespace DieticianDiary.Domain.Entity
{
    public class Patient : BaseEntity
    {
        [XmlElement("First Name")]
        public string FirstName { get; set; }
        [XmlElement("Last Name")]
        public string LastName { get; set; }
        [XmlElement("Phone number")]
        public int PhoneNumber { get; set; }
        [XmlElement("Email Address")]
        public string EmailAddress { get; set; }
        [XmlElement("Sex")]
        public string Sex { get; set; }
        [XmlElement("Age")]
        public int Age { get; set; }
        [XmlElement("Height")]
        public int Height { get; set; }
        [XmlElement("Weight")]
        public int Weight { get; set; }

        public Patient()
        {

        }
        
        public Patient(int id, string firstName, string lastName, int phoneNumber, string emailAddress, string sex, int age, int height, int weight)
        {
            id = Id;
            firstName = FirstName;
            lastName = LastName;
            phoneNumber = PhoneNumber;
            emailAddress = EmailAddress;
            sex = Sex;
            age = Age;
            height = Height;
            weight = Weight;
        }

        public override string ToString()
        {
            return 
                "First name: " + FirstName
                + "\r\nLast name: " + LastName
                + "\r\nPhone number: " + PhoneNumber
                + "\r\nEmail address: " + EmailAddress
                + "\r\nSex: " + Sex
                + "\r\nAge: " + Age
                + "\r\nHeight: " + Height
                + "\r\nWeight: " + Weight;
        }
    }
}
