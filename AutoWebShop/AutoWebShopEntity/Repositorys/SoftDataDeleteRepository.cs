using AutoWebShopEntity.Entitys;
using Dapper;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoWebShopEntity.Repositorys
{
    public class SoftDataDeleteRepository : BaseRepository<SoftDeletedDataEntity>,ISoftDataDeleteRepository
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(SoftDataDeleteRepository));

        public SoftDataDeleteRepository(string connectionString) : base(connectionString)
        {
        }
        public void InsertObj(SoftDeletedDataEntity dataObj)
        {
            using (var connection = base.Connection())
            {
                connection.Execute(SqlQuerys.Insert, new
                {
                    AdvertisementId = dataObj.AdvertisementId,
                    AdvertisementCategory = dataObj.AdvertisementCategory,
                    TimeDeleted = dataObj.TimeDeleted,
                    Description = dataObj.Description
                });
            }
        }
        public static class SqlQuerys
        {
            public static string Insert =>
            @"INSERT INTO [dbo].[tSoftDeletedData] (AdvertisementId, AdvertisementCategory, TimeDeleted, Description)
                            VALUES(@AdvertisementId, @AdvertisementCategory, @TimeDeleted, @Description)";
        }
    }
}
