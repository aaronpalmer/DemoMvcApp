using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using MvcApplication1.Core;
using MvcApplication1.Core.Models;

namespace MvcApplication1.Data
{
    public class PersonContext : DbContext
    {
        public ObjectContext ObjectContext
        {
            get
            {
                return ((IObjectContextAdapter)this).ObjectContext;
            }
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<State> States { get; set; }
    }
}
