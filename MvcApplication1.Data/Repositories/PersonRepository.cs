using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MvcApplication1.Core.Interfaces;
using MvcApplication1.Core.Models;

namespace MvcApplication1.Data.Repositories
{
    public class PersonRepository : BaseRepository, IPersonRepository
    {
        public bool IsDirty(BaseEntity entity) { return base.IsDirty(entity); }

        public List<Address> GetAddresses(IEnumerable<Expression<Func<Address, object>>> includeList = null) { return GetAll(includeList); }
        public Address GetAddress(int id, IEnumerable<Expression<Func<Address, object>>> includeList = null) { return Get(id, includeList); }
        public int SaveAddress(Address a) { return Save(a); }
        public int DeleteAddress(Address a) { return Delete(a); }

        public List<Email> GetEmails(IEnumerable<Expression<Func<Email, object>>> includeList = null) { return GetAll(includeList); }
        public Email GetEmail(int id, IEnumerable<Expression<Func<Email, object>>> includeList = null) { return Get(id, includeList); }
        public int SaveEmail(Email e) { return Save(e); }
        public int DeleteEmail(Email e) { return Delete(e); }

        public List<Person> GetPeople(IEnumerable<Expression<Func<Person, object>>> includeList = null) { return GetAll(includeList); }
        public Person GetPerson(int id, IEnumerable<Expression<Func<Person, object>>> includeList = null) { return Get(id, includeList); }
        public int SavePerson(Person p) { return Save(p); }
        public int DeletePerson(Person p) { return Delete(p); }

        public List<Phone> GetPhones(IEnumerable<Expression<Func<Phone, object>>> includeList = null) { return GetAll(includeList); }
        public Phone GetPhone(int id, IEnumerable<Expression<Func<Phone, object>>> includeList = null) { return Get(id, includeList); }
        public int SavePhone(Phone p) { return Save(p); }
        public int DeletePhone(Phone p) { return Delete(p); }

        public List<State> GetStates(IEnumerable<Expression<Func<State, object>>> includeList = null) { return GetAll(includeList); }
        public State GetState(int id, IEnumerable<Expression<Func<State, object>>> includeList = null) { return Get(id, includeList); }
        public int SaveState(State s) { return Save(s); }
        public int DeleteState(State s) { return Delete(s); }

    }
}