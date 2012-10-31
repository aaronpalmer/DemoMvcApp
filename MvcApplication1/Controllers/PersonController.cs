using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using MvcApplication1.Core;
using MvcApplication1.Core.Interfaces;
using MvcApplication1.ViewModels;
using System.Linq;
using MvcApplication1.Extensions;

namespace MvcApplication1.Controllers
{
    public class PersonController : Controller
    {
        [Dependency] // must be public in order to be registered via DI
        public IPersonRepository PersonRepository { get; set; }        

        // GET: /Person/
        public ActionResult Index()
        {
            var people = PersonRepository.GetPeople();
            var successMessage = TempData["SuccessMessage"] as string;
            var errorMessage = TempData["ErrorMessage"] as string;
            var infoMessage = TempData["InfoMessage"] as string;

            var personViewModels = people.Select(p => 
                new PersonViewModel
                {
                    Id = p.Id,
                    FirstName = p.FirstName, 
                    LastName = p.LastName, 
                    DateOfBirth = p.DateOfBirth, 
                    PrimaryEmail = "pEmail",
                    PrimaryPhone = "pPhone",
                    PrimaryAddress = "pAddress",
                }
            ).ToList();

            var personIndexViewModel = new PersonIndexViewModel { 
                PersonViewModels = personViewModels, 
                SuccessMessage = successMessage, 
                ErrorMessage = errorMessage, 
                InfoMessage = infoMessage
            };

            return View(personIndexViewModel);
        }

        // Get: /Person/Create
        [HttpGet]
        public ActionResult Create(Person person)
        {
            var isDirty = PersonRepository.IsDirty(person);
            if (isDirty)
                return CreateView(person);

            return CreateView(null);
        }

        // POST: /Person/Create
        [HttpPost]
        public ActionResult Create(Person person, int? id)
        {
            return Save(person, "Index", "Create");
        }

        // GET: /Person/Edit/id
        public ActionResult Edit(Person person, int? id)
        {
            var isDirty = PersonRepository.IsDirty(person);
            if (isDirty && !id.HasValue) return View("Create");

            if (!isDirty && id.HasValue)
                person = PersonRepository.GetPerson(id.Value);

            return EditView(person);
        }

        // Post: /Person/Edit/id
        [HttpPost]
        public ActionResult Edit(Person person)
        {
            var dbPerson = PersonRepository.GetPerson(person.Id);

            // map person to dbPerson
            dbPerson.DateOfBirth = person.DateOfBirth;
            dbPerson.FirstName = person.FirstName;
            dbPerson.LastName = person.LastName;

            return Save(dbPerson, "Index", "Edit");
        }

        private ActionResult Save(Person person, string successAction, string failAction)
        {
            try
            {
                PersonRepository.SavePerson(person);
                TempData["SuccessMessage"] = string.Format("Success! \"{0} {1}\" has been saved! ", person.FirstName, person.LastName);
                return RedirectToAction(successAction);
            }
            catch (DbEntityValidationException ex)
            {
                TempData["ErrorMessage"] = string.Format("Error saving \"{0} {1}\" Please ensure everything is formatted properly and try again.", person.FirstName, person.LastName);
                TempData["InfoMessage"] = ex.GetFormattedExceptionMessage();
            }
            catch (DbUpdateException ex)
            {
                TempData["ErrorMessage"] = string.Format("Error saving \"{0} {1}\" Please ensure everything is formatted properly and try again.", person.FirstName, person.LastName);
                TempData["InfoMessage"] = ex.GetFormattedExceptionMessage();
            }
            catch (DBConcurrencyException ex)
            {
                TempData["ErrorMessage"] = string.Format("Error saving \"{0} {1}\" Please try again.", person.FirstName, person.LastName);
                TempData["InfoMessage"] = ex.GetFormattedExceptionMessage();
            }

            if (failAction == "Create")
                return CreateView(person);

            return EditView(person);

        }

        private ActionResult CreateView(Person person)
        {
            var successMessage = TempData["SuccessMessage"] as string;
            var errorMessage = TempData["ErrorMessage"] as string;
            var infoMessage = TempData["InfoMessage"] as string;
            var personViewModel = new PersonViewModel
            {
                Id = (person == null) ? (int?)null : person.Id,
                FirstName = (person == null) ? "" : person.FirstName,
                LastName = (person == null) ? "" : person.LastName,
                DateOfBirth = (person == null) ? (DateTime?)null : person.DateOfBirth,
                SuccessMessage = successMessage,
                ErrorMessage = errorMessage,
                InfoMessage = infoMessage
            };

            return View(personViewModel);
        }

        private ActionResult EditView(Person person)
        {
            var successMessage = TempData["SuccessMessage"] as string;
            var errorMessage = TempData["ErrorMessage"] as string;
            var infoMessage = TempData["InfoMessage"] as string;

            var personViewModel = new PersonViewModel
            {
                Id = (person == null) ? (int?)null : person.Id,
                FirstName = (person == null) ? "" : person.FirstName,
                LastName = (person == null) ? "" : person.LastName,
                DateOfBirth = (person == null) ? (DateTime?)null : person.DateOfBirth,
                SuccessMessage = successMessage,
                ErrorMessage = errorMessage,
                InfoMessage = infoMessage
            };

            return View(personViewModel);
        }

    }
}
