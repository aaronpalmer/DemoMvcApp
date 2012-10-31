namespace MvcApplication1.Core
{
    public class Email : BaseEntity
    {
        public EmailType EmailType { get; set; }
        public string Address { get; set; }
    }
}