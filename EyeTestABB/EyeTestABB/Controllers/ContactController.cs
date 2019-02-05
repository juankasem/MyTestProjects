using EyeTestABB.Data;
using EyeTestABB.Data.Interfaces;
using EyeTestABB.Data.Models;
using EyeTestABB.Data.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EyeTestABB.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IStateRepository _stateRepository;
        private readonly IHostingEnvironment _hostingEnvironment;

        public ContactController(IContactRepository contactRepository, ICountryRepository countryRepository, 
                                 IStateRepository stateRepository, IHostingEnvironment hostingEnvironment)
        {
            _contactRepository = contactRepository;
            _countryRepository = countryRepository;
            _stateRepository = stateRepository;
            _hostingEnvironment = hostingEnvironment;
        }

        #region contactList
        [HttpGet("/")]
        [Route("Contact/List")]
        public IActionResult List()
        {
            List<ContactListViewModel> contactListVM = new List<ContactListViewModel>();

            //Retreieve all contacts
            var contacts = _contactRepository.GetAllContacts().OrderBy(c=> c.FirstName);

            if (contacts.Count() == 0)
            {
                return View("Empty");
            }

            foreach (var contact in contacts)
            {
                contactListVM.Add(new ContactListViewModel()
                {
                    ContactId = contact.ContactId,
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    ContactNumber1 = contact.ContactNumber1,
                    ContactNumber2 = contact.ContactNumber2,
                    ContactNumber3 = contact.ContactNumber3,
                    CompanyName = contact.CompanyName,
                    EmailId = contact.EmailId,
                    Country = contact.Country.Name,
                    State = contact.State.Name,
                    HomeAddress = contact.HomeAddress,
                    WorkAddress = contact.WorkAddress,
                    ImagePath = contact.ImagePath
                });
            }

            return View(contactListVM);
        }
        #endregion

        #region contactDetails
        public IActionResult ViewDetails(int? id)
        {
            //Fetch contact from db
            if (id == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            var contact = _contactRepository.GetContactById(id);

            if (contact == null)
            {
                return NotFound();
            }

            ContactListViewModel model = new ContactListViewModel()
            {
                ContactId= contact.ContactId,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                ContactNumber1 = contact.ContactNumber1,
                ContactNumber2 = contact.ContactNumber2,
                ContactNumber3 = contact.ContactNumber3,
                CompanyName = contact.CompanyName,
                EmailId = contact.EmailId,
                Country = contact.Country.Name,
                State = contact.State.Name,
                HomeAddress = contact.HomeAddress,
                WorkAddress = contact.WorkAddress,
                ImagePath = contact.ImagePath
            };

            return View(model);
        }

        #endregion

        #region AddContact
        public IActionResult AddContact()
        {
            //Fetch List of countries
            ContactViewModel model = new ContactViewModel();
            BindCountriesWithStates(model);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddContact(ContactViewModel model, IFormFile ImagePath)
        {
            //Validate the model
            if (!ModelState.IsValid)
            {
                BindCountriesWithStates(model);
                return View(model);
            }

            try
            {
                Contact contact = new Contact()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,  
                    ContactNumber1 = model.ContactNumber1,
                    ContactNumber2 = model.ContactNumber2,
                    ContactNumber3 = model.ContactNumber3,
                    CompanyName = model.CompanyName,
                    EmailId = model.EmailID,
                    CountryId = model.CountryID,
                    StateId = model.StateID,
                    HomeAddress = model.HomeAddress,
                    WorkAddress = model.WorkAddress,
                };

                if (ImagePath != null)
                {
                    var imagePath = SaveImage(ImagePath);
                    contact.ImagePath = imagePath;
                }
                
                //Add a new contact
                _contactRepository.Create(contact);

                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                ViewBag.message=ex.ToString();
                return View("Error");
            }
        }
        #endregion

        #region EditContact
        public IActionResult EditContact(int? id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            //Fetch contact from db by passed id
            var contact = _contactRepository.GetById(id);

            if (contact == null)
            {
                return NotFound();
            }

            ContactViewModel model = new ContactViewModel()
            {
                ContactId = contact.ContactId,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                ContactNumber1 = contact.ContactNumber1,
                ContactNumber2 = contact.ContactNumber2,
                ContactNumber3 = contact.ContactNumber3,
                CompanyName = contact.CompanyName,
                EmailID = contact.EmailId,
                CountryID= contact.CountryId,
                StateID= contact.StateId,
                HomeAddress = contact.HomeAddress,
                WorkAddress = contact.WorkAddress,
                ImagePath = contact.ImagePath
            };

            BindCountriesWithStates(model);

            return View(model);
        }

        [HttpPost, ActionName("EditContact")]
        public ActionResult UpdateContact(ContactViewModel model, IFormFile ImagePath)
        {
            if (!ModelState.IsValid)
            {
                BindCountriesWithStates(model);
                return View(model);
            }

            //Fetch contact from db
            Contact contact = _contactRepository.GetById(model.ContactId);

            if (contact == null)
            {
                return NotFound();
            }

            try
            {
                //Set properties to edited values
                contact.FirstName = model.FirstName;
                contact.LastName = model.LastName;
                contact.ContactNumber1 = model.ContactNumber1;
                contact.ContactNumber2 = model.ContactNumber2;
                contact.ContactNumber3 = model.ContactNumber3;
                contact.CompanyName = model.CompanyName;
                contact.EmailId = model.EmailID;
                contact.CountryId = model.CountryID;
                contact.StateId = model.StateID;
                contact.HomeAddress = model.HomeAddress;
                contact.WorkAddress = model.WorkAddress;

                //Set image ath if there's any
                if (ImagePath != null)
                {
                    var imagePath = SaveImage(ImagePath);
                    contact.ImagePath = imagePath;
                }

                //Update the contact
                _contactRepository.Update(contact);

                return RedirectToAction("List");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
        #endregion

        #region DeleteContact
        [HttpPost]
        public JsonResult Delete(int? id)
        {
            bool result = false;
            try
            {
                //Fetch contact from db
                var contact = _contactRepository.GetById(id);

                if (contact == null)
                {
                    return Json(result);
                }

                _contactRepository.Delete(contact);
                result = true;

                return Json(result);
                //return RedirectToAction("List");
            }
            catch (Exception)
            {
                return Json(false);
            } 
        }
        #endregion

        private void BindCountriesWithStates(ContactViewModel model)
        {
            //Fetch List of countries
            model.CountryList = _countryRepository.GetAll().OrderBy(c => c.Name).Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString(),
                Selected = c.Id == model.CountryID ? true : false
            }).ToList();

            if (model.StateID.ToString() != null)
            {
                model.StateList = _stateRepository.Find(s=> s.CountryId == model.CountryID).OrderBy(s => s.Name).Select(s => new SelectListItem()
                {
                    Text = s.Name,
                    Value = s.Id.ToString(),
                    Selected = s.Id == model.StateID ? true : false
                }).ToList();
            }
            else
            {
                model.StateList = new List<SelectListItem>();
            }
        }

        public JsonResult BindStates(int countryId)
        {
            var states = _stateRepository.Find(s => s.CountryId == countryId).OrderBy(s => s.Name);

            return Json(states);
        }

        private string SaveImage(IFormFile image)
        {
            if (image != null & image.Length > 0)
            {
                var folderPath = Path.Combine(_hostingEnvironment.WebRootPath, "images");

                var filePath = Path.Combine(folderPath, Path.GetFileName(image.FileName));

                image.CopyTo(new FileStream(filePath, FileMode.Create));

                return "/images/" + Path.GetFileName(image.FileName);
            }

            return "No image found.";
        }
    }
}