using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MvcApplication1.Core.Models;

namespace MvcApplication1.Core.Interfaces
{
    public interface IPersonRepository
    {
        bool IsDirty(BaseEntity entity);

        List<Address> GetAddresses(IEnumerable<Expression<Func<Address, object>>> includeList = null);
        Address GetAddress(int id, IEnumerable<Expression<Func<Address, object>>> includeList = null);
        int SaveAddress(Address a);
        int DeleteAddress(Address a);

        List<Email> GetEmails(IEnumerable<Expression<Func<Email, object>>> includeList = null);
        Email GetEmail(int id, IEnumerable<Expression<Func<Email, object>>> includeList = null);
        int SaveEmail(Email e);
        int DeleteEmail(Email e);

        List<Person> GetPeople(IEnumerable<Expression<Func<Person, object>>> includeList = null);
        Person GetPerson(int id, IEnumerable<Expression<Func<Person, object>>> includeList = null);
        int SavePerson(Person p);
        int DeletePerson(Person p);

        List<Phone> GetPhones(IEnumerable<Expression<Func<Phone, object>>> includeList = null);
        Phone GetPhone(int id, IEnumerable<Expression<Func<Phone, object>>> includeList = null);
        int SavePhone(Phone p);
        int DeletePhone(Phone p);

        List<State> GetStates(IEnumerable<Expression<Func<State, object>>> includeList = null);
        State GetState(int id, IEnumerable<Expression<Func<State, object>>> includeList = null);
        int SaveState(State s);
        int DeleteState(State s);
    }
}
