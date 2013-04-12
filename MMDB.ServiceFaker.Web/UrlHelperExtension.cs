namespace System.Web.Mvc
{
	public static class UrlHelperExtension
	{
		public static string ContentFullPath(this UrlHelper url, string virtualPath)
		{
			var result = string.Empty;
			Uri requestUrl = url.RequestContext.HttpContext.Request.Url;

			result = string.Format("{0}://{1}{2}",
								   requestUrl.Scheme,
								   requestUrl.Authority,
								   VirtualPathUtility.ToAbsolute(virtualPath));
			return result;
		}
	}
}