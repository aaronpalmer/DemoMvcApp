using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MvcApplication1.Core;
using MvcApplication1.Core.Interfaces;

namespace MvcApplication1.Data
{
    public class PersonRepository : BaseRepository, IPersonRepository
    {
        public bool IsDirty(BaseEntity entity) { return base.IsDirty(entity); }

        public List<Address> GetAddresses(IEnumerable<Expression<Func<Address, object>>> includeList = null) { return GetAll(includeList); }
        public Address GetAddress(int id, IEnumerable<Expression<Func<Address, object>>> includeList = null) { return Get(id, includeList); }
        public int SaveAddress(Address a) { return Save(a); }

        public List<Email> GetEmails(IEnumerable<Expression<Func<Email, object>>> includeList = null) { return GetAll(includeList); }
        public Email GetEmail(int id, IEnumerable<Expression<Func<Email, object>>> includeList = null) { return Get(id, includeList); }
        public int SaveEmail(Email e) { return Save(e); }

        public List<Person> GetPeople(IEnumerable<Expression<Func<Person, object>>> includeList = null) { return GetAll(includeList); }
        public Person GetPerson(int id, IEnumerable<Expression<Func<Person, object>>> includeList = null) { return Get(id, includeList); }
        public int SavePerson(Person p) { return Save(p); }

        public List<Phone> GetPhones(IEnumerable<Expression<Func<Phone, object>>> includeList = null) { return GetAll(includeList); }
        public Phone GetPhone(int id, IEnumerable<Expression<Func<Phone, object>>> includeList = null) { return Get(id, includeList); }
        public int SavePhone(Phone p) { return Save(p); }

        public List<State> GetStates(IEnumerable<Expression<Func<State, object>>> includeList = null) { return GetAll(includeList); }
        public State GetState(int id, IEnumerable<Expression<Func<State, object>>> includeList = null) { return Get(id, includeList); }
        public int SaveState(State s) { return Save(s); }

    }
}