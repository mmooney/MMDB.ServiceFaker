using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MMDB.ServiceFaker.Web.Services;

namespace MMDB.ServiceFaker.Web.Areas.fake.Controllers
{
    public class CatchAllController : Controller
    {
		private readonly IPassthroughService _passthroughService;
		private readonly IServiceRepository _serviceRepository;

		public CatchAllController(IServiceRepository serviceRepository, IPassthroughService passthroughService)
		{
			_serviceRepository = DIHelper.VerifyParameter(serviceRepository);
			_passthroughService = DIHelper.VerifyParameter(passthroughService);
		}
        //
        // GET: /fake/CatchAll/

        public ActionResult Index()
        {
			string fakePrefix = this.Url.ContentFullPath("~/fake/");
			string relativeUrlRoot = this.Request.Url.ToString().Substring(fakePrefix.Length);
			string relativeUrlSuffix;
			if(relativeUrlRoot.Contains("/"))
			{
				relativeUrlSuffix = relativeUrlRoot.Substring(relativeUrlRoot.IndexOf("/"));
				relativeUrlRoot = relativeUrlRoot.Substring(0, relativeUrlRoot.IndexOf("/"));
			}
			else 
			{
				relativeUrlSuffix = string.Empty;
			}
			var matchingService = _serviceRepository.FindFakeServiceForRelativeFakeRootUrl(relativeUrlRoot);
			var result = _passthroughService.PassthroughCall(matchingService, this.Request, relativeUrlSuffix);
            return Content(result);
        }

        //
        // GET: /fake/CatchAll/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /fake/CatchAll/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /fake/CatchAll/Create

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
        // GET: /fake/CatchAll/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /fake/CatchAll/Edit/5

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
        // GET: /fake/CatchAll/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /fake/CatchAll/Delete/5

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
