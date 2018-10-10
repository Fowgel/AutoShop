using AutoWebShopEntity.Entitys;
using System.Collections.Generic;

namespace AutoWebShopEntity.Repositorys
{
    public interface IAdvertiseCategoryRepository
    {
        AdvertisementCategoryEntity GetById(int id);
        IEnumerable<ChildCategoryEntity> GetChildCategorysById(int id);
        IEnumerable<AdvertisementCategoryEntity> GetParentCategory();
        AdvertisementCategoryEntity GetSingleParentCategoy(int id);
    }
}