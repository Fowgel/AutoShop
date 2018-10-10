using System.Collections.Generic;
using AutoWebShopEntity.Entitys;

namespace AutoWebShopEntity.Repositorys
{
    public interface IAdvertiseCategorySystem
    {
        AdvertisementCategoryEntity GetById(int id);
        IEnumerable<ChildCategoryEntity> GetChildCategorysById(int id);
        IEnumerable<AdvertisementCategoryEntity> GetParentCategory();
        AdvertisementCategoryEntity GetSingleParentCategoy(int id);
    }
}