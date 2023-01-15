using DieticianDiary.Domain.Common;

namespace DieticianDiary.Domain.Entity
{
    public class Patient : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string EmailAdress { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }

        public Patient()
        {

        }
        
        public Patient(int id, string firstName, string lastName, int phoneNumber, string emailAdress, string sex, int age, int height, int weight)
        {
            id = Id;
            firstName = FirstName;
            lastName = LastName;
            phoneNumber = PhoneNumber;
            emailAdress = EmailAdress;
            sex = Sex;
            age = Age;
            height = Height;
            weight = Weight;
        }
    }
}
