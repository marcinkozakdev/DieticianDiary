using DieticianDiary.Domain.Common;

namespace DieticianDiary.Domain.Entity
{
    public class Patient : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAdress { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }

        public Patient()
        {

        }
        
        public Patient(int id, string firstName, string lastName, string phoneNumber, string emailAdress, int age, int height, int weight)
        {
            id = Id;
            firstName = FirstName;
            lastName = LastName;
            phoneNumber = PhoneNumber;
            emailAdress = EmailAdress;
            age = Age;
            height = Height;
            weight = Weight;
        }
    }
}
