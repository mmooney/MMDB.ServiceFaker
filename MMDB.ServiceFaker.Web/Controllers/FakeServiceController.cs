using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MMDB.ServiceFaker.Web.Services;
using MMDB.ServiceFaker.Web.Dto;

namespace MMDB.ServiceFaker.Web.Controllers
{
    public class FakeServiceController : Controller
    {
		private readonly IServiceRepository _serviceRepository;
		
		public FakeServiceController(IServiceRepository serviceRepository)
		{
			_serviceRepository = DIHelper.VerifyParameter(serviceRepository);
		}

        public ActionResult Index()
        {
			var list = _serviceRepository.LoadFakeServiceList();
            return View(list);
        }

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(string serviceName, string realEndpointRootUrl, string relativeFakeRootUrl, EnumFakeServiceResponseType enumFakeServiceResponseTypeID)
		{
			var item = _serviceRepository.CreateFakeService(serviceName, realEndpointRootUrl, relativeFakeRootUrl, enumFakeServiceResponseTypeID);
			return RedirectToAction("Details", new { id=item.ID });
		}

		public ActionResult Details(int id)
		{
			var item = _serviceRepository.GetFakeService(id);
			return View(item);
		}

		public ActionResult Edit(int id)
		{
			var item = _serviceRepository.GetFakeService(id);
			return View(item);
		}

		[HttpPost]
		public ActionResult Edit(int id, string serviceName, string realEndpointRootUrl, string relativeFakeRootUrl, EnumFakeServiceResponseType enumFakeServiceResponseTypeID)
		{
			var item = _serviceRepository.UpdateFakeService(id, serviceName, realEndpointRootUrl, relativeFakeRootUrl, enumFakeServiceResponseTypeID);
			return RedirectToAction("Details", new { id = item.ID });
		}
    }
}
