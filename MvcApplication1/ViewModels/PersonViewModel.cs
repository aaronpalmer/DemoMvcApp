using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MvcApplication1.Core;
using MvcApplication1.Core.Models;

namespace MvcApplication1.ViewModels
{
    public class PersonViewModel : BaseViewModel
    {
        public int? Id { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Date of Birth")]
        public DateTime? DateOfBirth { get; set; }

        public ICollection<Email> Emails { get; set; }

        public ICollection<Phone> Phones { get; set; }
        
        public ICollection<Address> Addresses { get; set; }


    }
}