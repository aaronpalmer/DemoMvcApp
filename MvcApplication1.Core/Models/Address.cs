namespace MvcApplication1.Core.Models
{
    public class Address : BaseEntity
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public string PostalCode { get; set; }
    }
}