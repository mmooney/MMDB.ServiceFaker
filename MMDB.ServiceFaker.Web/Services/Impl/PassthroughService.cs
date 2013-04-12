using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MMDB.ServiceFaker.Web.Dto;
using System.Net;
using MMDB.Shared;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace MMDB.ServiceFaker.Web.Services.Impl
{
	internal class PassthroughService : IPassthroughService
	{
		public string PassthroughCall(FakeService matchingService, HttpRequestBase httpRequest, string relativeUrl)
		{
			try 
			{
				if(matchingService.EnumFakeServiceResponseTypeID == EnumFakeServiceResponseType.InternalServerError500)
				{
					throw new HttpException(500, "Go away please");
				}
				else if (matchingService.EnumFakeServiceResponseTypeID == EnumFakeServiceResponseType.NotFound404)
				{
					throw new HttpException(404, "This is not the service you're looking for");
				}
				else if (matchingService.EnumFakeServiceResponseTypeID == EnumFakeServiceResponseType.Unavailable)
				{
					Thread.Sleep(1000*5*60);
					return null;
				}
				string newUrl = CombineUrls(matchingService.RealEndpointRootUrl, relativeUrl);
				var request = (HttpWebRequest)HttpWebRequest.Create(newUrl);
				foreach(string headerKey in httpRequest.Headers.Keys)
				{
					string headerValue = httpRequest.Headers[headerKey];
					if(!string.IsNullOrEmpty(headerValue)) 
					{
						switch(headerKey.ToLower())
						{
							case "connection":
								if(headerValue.ToLower() == "keep-alive")
								{
									request.KeepAlive = true;
								}
								break;
							case "accept":
								request.Accept = headerValue;
								break;
							case "user-agent":
								request.UserAgent = headerValue;
								break;
							case "host":
								//do nothing
								break;
							default:
								request.Headers[headerKey] = headerValue;
								break;
						}
					}
				}
				foreach(string cookieName in httpRequest.Cookies)
				{
					HttpCookie httpCookie = httpRequest.Cookies[cookieName];
					var cookie = HttpCookieToCookie(httpCookie);
					if(string.IsNullOrEmpty(cookie.Domain))
					{
						cookie.Domain = request.RequestUri.Host;
					}
					if(request.CookieContainer == null)
					{
						request.CookieContainer = new CookieContainer();
					}
					request.CookieContainer.Add(cookie);
				}
				using(var response = request.GetResponse())
				{
					using(var responseStream = response.GetResponseStream())
					{
						using(var reader = new StreamReader(responseStream))
						{
							return reader.ReadToEnd();
						}
					}
				}
			}
			catch(Exception err)
			{
				Debug.WriteLine(err.ToString());
				throw;
			}
		}

		private static string CombineUrls(string roolurl, string relativeUrl)
		{
			if (relativeUrl.StartsWith("/"))
			{
				relativeUrl = relativeUrl.Substring(1);
			}
			string newUrl = roolurl;
			if (!newUrl.EndsWith("/"))
			{
				newUrl += "/";
			}
			newUrl += relativeUrl;
			return newUrl;
		}
	
		private static Cookie HttpCookieToCookie(HttpCookie httpCookie)
		{
			Cookie cookie = new Cookie(httpCookie.Name, null);

			cookie.Value = HttpUtility.UrlEncode(httpCookie.Value);
			///*Copy keys and values*/
			//foreach (string value in cookie.Value.Split('&'))
			//{
			//    string[] val = value.Split('=');
			//    httpCookie.Values.Add(val[0], val[1]); /* or httpCookie[val[0]] = val[1];  */
			//}


			/*Copy Porperties*/
			cookie.Domain = cookie.Domain;
			cookie.Expires = httpCookie.Expires;
			cookie.HttpOnly = httpCookie.HttpOnly;
			//cookie.Path = httpCookie.Path;
			cookie.Secure = httpCookie.Secure;

			return cookie;
		}
	}
}