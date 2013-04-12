using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDB.ServiceFaker.Web
{
	public static class DIHelper
	{
		public static T VerifyParameter<T>(T input)
		{
			if(input == null)
			{
				throw new ArgumentNullException("Invalid NULL parameter for " + typeof(T).FullName);
			}
			return input;
		}
	}
}