
using System.Xml.Serialization;

namespace DieticianDiary.Domain.Entity
{
    public class UserData
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
        [XmlElement("Specialization")]
        public string Specialization { get; set; }

        public UserData()
        {

        }

        public override string ToString()
        {
            return "First name: " + FirstName
                + "\r\nLast name: " + LastName
                + "\r\nPhone number: " + PhoneNumber
                + "\r\nEmail address: " + EmailAddress
                + "\r\nSex: " + Sex
                + "\r\nSpecialization: " + Specialization;
        }
    }
}
