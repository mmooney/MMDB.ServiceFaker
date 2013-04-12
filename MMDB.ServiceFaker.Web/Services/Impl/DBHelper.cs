using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDB.ServiceFaker.Web.Services.Impl
{
	internal static class DBHelper
	{
		public static PetaPoco.Database GetDb()
		{
			return new PetaPoco.Database("ServiceFakerDB");
		}
	}
}