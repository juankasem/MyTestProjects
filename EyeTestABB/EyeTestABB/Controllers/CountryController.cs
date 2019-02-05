using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EyeTestABB.Data.Interfaces;
using EyeTestABB.Data.Models;
using EyeTestABB.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EyeTestABB.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;

        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        // GET: Country
        public IActionResult Index()
        {
            List<CountryViewModel> countryList = new List<CountryViewModel>();

            //Retreive all countries
            var countries = _countryRepository.GetAll().OrderBy(c=> c.Name);

            if (countries.Count() == 0)
            {
                return View("Empty");
            }

            foreach (var country in countries)
            {
                countryList.Add(new CountryViewModel()
                {
                    Id = country.Id,
                    Name = country.Name
                });
            }
                
            return View(countryList);
        }

        // GET: Country/Details/5
        public IActionResult Details(int? id)
        {
            //Fetch contact from db
            if (id == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            var country = _countryRepository.GetById(id);

            if (country == null)
            {
                return NotFound();
            }

            CountryViewModel model = new CountryViewModel()
            {
                Id = country.Id,
                Name = country.Name
            };

            return View(model);
        }

        #region Create
        // GET: Country/Create
        public IActionResult Create()
        {
            //Fetch List of countries
            CountryViewModel model = new CountryViewModel();

            return View(model);
        }

        // POST: Country/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CountryViewModel model)
        { 
            //Validate the model
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                Country country = new Country()
                {
                    Name = model.Name     
                };

                _countryRepository.Create(country);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }
        #endregion

        #region Edit
        // GET: Country/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            //Fetch contact from db by passed id
            var country = _countryRepository.GetById(id);

            if (country == null)
            {
                return NotFound();
            }

            CountryViewModel model = new CountryViewModel()
            {
                Id = country.Id,
                Name = country.Name
            };

            return View(model);
        }

        // POST: Country/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, CountryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //Fetch country from db
            Country country = _countryRepository.GetById(id);

            if (country == null)
            {
                return NotFound();
            }
            try
            {
                //Set properties to edited values
                country.Name = model.Name;

                _countryRepository.Update(country);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region DeleteCountry
        // POST: Country/Delete/5
        [HttpPost]
        public JsonResult Delete(int id)
        {
            bool result = false;
            try
            {
                //Fetch contact from db
                var country = _countryRepository.GetById(id);

                if (country == null)
                {
                    return Json(result);
                }

                _countryRepository.Delete(country);
                result = true;

                return Json(result);
            }
            catch (Exception)
            {
                return Json(false);
            }
        }
        #endregion
    }
}