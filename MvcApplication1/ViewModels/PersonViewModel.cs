using System;

namespace MvcApplication1.ViewModels
{
    public class PersonViewModel : BaseViewModel
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PrimaryEmail { get; set; }
        public string PrimaryPhone { get; set; }
        public string PrimaryAddress { get; set; }
    }
}