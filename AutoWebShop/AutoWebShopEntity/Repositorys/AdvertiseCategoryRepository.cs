using AutoWebShopEntity.Entitys;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoWebShopEntity.Repositorys
{
    public class AdvertiseCategoryRepository : BaseRepository<AdvertisementCategoryEntity>, IAdvertiseCategoryRepository
    {
        public AdvertiseCategoryRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<AdvertisementCategoryEntity> GetParentCategory()
        {
            using (var connection = base.Connection())
            {
                return connection.Query<AdvertisementCategoryEntity>(SqlQuerys.GetParentCategory);
            }
        }
        public IEnumerable<ChildCategoryEntity> GetChildCategorysById(int id)
        {
            using (var connection = base.Connection())
            {
                return connection.Query<ChildCategoryEntity>(SqlQuerys.GetChildCategorys
                    , new { ID = id});
            }
        }
        public AdvertisementCategoryEntity GetById(int id)
        {
            using (var connection = base.Connection())
            {
                return connection.Query<AdvertisementCategoryEntity>(SqlQuerys.GetSingleById
                    , new { Id = id }).FirstOrDefault();
            }
        }

        public AdvertisementCategoryEntity GetSingleParentCategoy(int id)
        {
            using (var connection = base.Connection())
            {
                return connection.Query<AdvertisementCategoryEntity>(SqlQuerys.GetSingleParentCategory,
                    new
                    {
                        ParentId = id
                    }).SingleOrDefault();
            }
        }

        public static class SqlQuerys
        {
            public static string GetParentCategory =>
                @"SELECT c.[ParentCategoryId], c.ParentCategoryName
                FROM [dbo].[tAdvertisingCategory] AS c";
            public static string GetChildCategorys =>
               @"SELECT c.ChildCategoryId, c.ChildCategoryName
                FROM [dbo].[tChildCategory] AS c
				JOIN tAdvertisingCategory as ac on c.CategoryId = ac.ParentCategoryId
                where ParentCategoryId = @ID";
            public static string GetSingleById =>
               @"SELECT c.[ParentCategoryId], c.ChildCategoryName
                FROM [dbo].[tAdvertisingCategory] AS c";
            public static string GetSingleParentCategory =>
                @"Select c.[ParentCategoryName] from tAdvertisingCategory as c
                    where ParentCategoryId = @ParentId";
        }
    }
}
