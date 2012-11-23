using System;
using System.Collections.Generic;

namespace MvcApplication1.Core.Models
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<Email> Emails { get; set; }
        public ICollection<Phone> Phones { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}