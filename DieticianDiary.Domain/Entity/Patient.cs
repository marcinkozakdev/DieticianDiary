using DieticianDiary.Domain.Common;

namespace DieticianDiary.Domain.Entity
{
    public class Patient : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
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
