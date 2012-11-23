namespace MvcApplication1.Core.Models
{
    public class Phone : BaseEntity
    {
        public int AreaCode { get; set; }
        public int Prefix { get; set; }
        public int Line { get; set; }
        public int Extension { get; set; }
    }
}