using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDB.ServiceFaker.Web.Dto
{
	public class FakeService
	{
		public int ID { get; set; }
		public string ServiceName { get; set; }
		public string RealEndpointRootUrl { get; set; }
		public string RelativeFakeRootUrl { get; set; }
		public EnumFakeServiceResponseType EnumFakeServiceResponseTypeID { get; set; }
	}
}