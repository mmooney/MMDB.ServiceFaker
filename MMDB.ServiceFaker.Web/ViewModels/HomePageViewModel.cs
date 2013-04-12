using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MMDB.ServiceFaker.Web.Dto;

namespace MMDB.ServiceFaker.Web.ViewModels
{
	public class HomePageViewModel
	{
		public List<FakeService> FakeServiceList { get; set; }
	}
}