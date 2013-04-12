using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MMDB.ServiceFaker.Web.Dto;
using System.Web;

namespace MMDB.ServiceFaker.Web.Services
{
	public interface IPassthroughService
	{
		string PassthroughCall(FakeService matchingService, HttpRequestBase httpRequest, string relativeUrl);
	}
}
