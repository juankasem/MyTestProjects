using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EyeTestABB.Data.Interfaces;
using EyeTestABB.Data.Models;
using EyeTestABB.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EyeTestABB.Controllers
{
    public class StateController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IStateRepository _stateRepository;

        public StateController(IStateRepository stateRepository, ICountryRepository countryRepository)
        {
            _stateRepository = stateRepository;
            _countryRepository = countryRepository;
        }

        public IActionResult Index()
        {
            List<StateListViewModel> stateList = new List<StateListViewModel>();

            //Retreive all countries
            var states = _stateRepository.GetAllStates().OrderBy(c=> c.Country.Name);

            if (states.Count() == 0)
            {
                return View("Empty");
            }

            foreach (var state in states)
            {
                stateList.Add(new StateListViewModel()
                {
                    Id = state.Id,
                    Country= state.Country.Name,
                    Name = state.Name
                });
            }

            return View(stateList);
        }


        #region Create
        // GET: Country/Create
        public IActionResult Create()
        {
            //Fetch List of countries
            StateViewModel model = new StateViewModel();
            BindCountries(model);

            return View(model);
        }

        // POST: Country/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StateViewModel model)
        {
            //Validate the model
            if (!ModelState.IsValid)
            {
                BindCountries(model);
                return View(model);
            }

            try
            {
                State state = new State()
                {
                    CountryId= model.CountryId,
                    Name = model.Name
                };

                _stateRepository.Create(state);


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
            var state = _stateRepository.GetById(id);

            if (state == null)
            {
                return NotFound();
            }

            StateViewModel model = new StateViewModel()
            {
                Id = state.Id,
                CountryId= state.CountryId,
                Name = state.Name
            };

            BindCountries(model);

            return View(model);
        }

        // POST: Country/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, StateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //Fetch country from db
            State state = _stateRepository.GetById(id);

            if (state == null)
            {
                return NotFound();
            }
            try
            {
                //Set properties to edited values
                state.CountryId = model.CountryId;
                state.Name = model.Name;

                _stateRepository.Update(state);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error");
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
                var state = _stateRepository.GetById(id);

                if (state == null)
                {
                    return Json(result);
                }

                _stateRepository.Delete(state);
                result = true;

                return Json(result);
            }
            catch (Exception)
            {
                return Json(false);
            }
        }
        #endregion

        private void BindCountries(StateViewModel model)
        {
            //Fetch List of countries
            model.CountryList = _countryRepository.GetAll().OrderBy(c => c.Name).Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString(),
                Selected = c.Id == model.CountryId ? true : false
            }).ToList(); 
        }
    }
}