using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MMDB.Shared;

namespace MMDB.ServiceFaker.Web.Dto
{
	public enum EnumFakeServiceResponseType
	{
		[EnumDisplayValue("Passthrough")]
		Passthrough = 0,
		[EnumDisplayValue("Passthrough and Cache recognized methods")]
		PassthroughAndCache,
		[EnumDisplayValue("Simulate server unavailable")]
		Unavailable,
		[EnumDisplayValue("Simulate Internal Server Error (500)")]
		InternalServerError500,
		[EnumDisplayValue("Simulate Not Found (404)")]
		NotFound404
	}
}