using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DieticianDiary.Domain.Entity
{
    public class UserData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Sex { get; set; }
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
