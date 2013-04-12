using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MMDB.ServiceFaker.Web.Dto;

namespace MMDB.ServiceFaker.Web.Services
{
	public interface IServiceRepository
	{
		List<FakeService> LoadFakeServiceList();
		FakeService GetFakeService(int id);
		FakeService CreateFakeService(string serviceName, string realEndpointRootUrl, string relativeFakeRootUrl, EnumFakeServiceResponseType enumFakeServiceResponseTypeID);
		FakeService UpdateFakeService(int id, string serviceName, string realEndpointRootUrl, string relativeFakeRootUrl, EnumFakeServiceResponseType enumFakeServiceResponseTypeID);
		FakeService FindFakeServiceForRelativeFakeRootUrl(string relativeUrlRoot);
	}
}
