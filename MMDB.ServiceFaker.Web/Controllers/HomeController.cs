﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MMDB.ServiceFaker.Web.ViewModels;
using MMDB.ServiceFaker.Web.Services;

namespace MMDB.ServiceFaker.Web.Controllers
{
    public class HomeController : Controller
    {
		private readonly IServiceRepository _serviceRepository;

		public HomeController(IServiceRepository serviceRepository)
		{
			_serviceRepository = DIHelper.VerifyParameter(serviceRepository);
		}
        public ActionResult Index()
        {
			var viewModel = new HomePageViewModel()
			{
				FakeServiceList = _serviceRepository.LoadFakeServiceList()
			};
            return View(viewModel);
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Home/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
