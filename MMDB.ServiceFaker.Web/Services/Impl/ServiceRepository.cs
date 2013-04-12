using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MMDB.ServiceFaker.Web.Dto;

namespace MMDB.ServiceFaker.Web.Services.Impl
{
	internal class ServiceRepository : IServiceRepository
	{
		public List<FakeService> LoadFakeServiceList()
		{
			using(var db = DBHelper.GetDb())
			{
				var sql = GetBaseFakeServiceQuery();
				return db.Query<FakeService>(sql).ToList();
			}
		}

		public FakeService GetFakeService(int id)
		{
			using (var db = DBHelper.GetDb())
			{
				return db.Single<FakeService>(id);
			}
		}

		public FakeService CreateFakeService(string serviceName, string realEndpointRootUrl, string relativeFakeRootUrl, EnumFakeServiceResponseType enumFakeServiceResponseTypeID)
		{
			using(var db = DBHelper.GetDb())
			{
				var item = new FakeService
				{
					ServiceName = serviceName,
					RealEndpointRootUrl = realEndpointRootUrl,
					RelativeFakeRootUrl = relativeFakeRootUrl,
					EnumFakeServiceResponseTypeID = enumFakeServiceResponseTypeID
				};
				db.Insert("FakeService", "ID", item);
				return item;
			}
		}

		public FakeService UpdateFakeService(int id, string serviceName, string realEndpointRootUrl, string relativeFakeRootUrl, EnumFakeServiceResponseType enumFakeServiceResponseTypeID)
		{
			using(var db = DBHelper.GetDb())
			{
				var item = GetFakeService(id);
				item.ServiceName = serviceName;
				item.RelativeFakeRootUrl = relativeFakeRootUrl;
				item.RealEndpointRootUrl = realEndpointRootUrl;
				item.EnumFakeServiceResponseTypeID = enumFakeServiceResponseTypeID;
				db.Update("FakeService", "ID", item);
				return item;
			}
		}

		public FakeService FindFakeServiceForRelativeFakeRootUrl(string relativeUrlRoot)
		{
			using(var db = DBHelper.GetDb())
			{
				var sql = GetBaseFakeServiceQuery();
				sql = sql.Where("RelativeFakeRootUrl = @0", relativeUrlRoot);
				return db.FirstOrDefault<FakeService>(sql);
			}
		}

		private PetaPoco.Sql GetBaseFakeServiceQuery()
		{
			var sql = PetaPoco.Sql.Builder.Select
						(
							"ID",
							"ServiceName",
							"RealEndpointRootUrl",
							"RelativeFakeRootUrl",
							"EnumFakeServiceResponseTypeID"	
						)
						.From("FakeService");
			return sql;
		}
	}
}