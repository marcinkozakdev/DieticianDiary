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
    }
}
