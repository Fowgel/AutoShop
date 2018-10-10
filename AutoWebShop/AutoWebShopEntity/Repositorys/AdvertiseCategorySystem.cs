using AutoWebShopEntity.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoWebShopEntity.Repositorys
{
    public class AdvertiseCategorySystem : IAdvertiseCategorySystem
    {
        public IAdvertiseCategoryRepository _categoryRepository;
        public AdvertiseCategorySystem(IAdvertiseCategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IEnumerable<AdvertisementCategoryEntity> GetParentCategory()
        {
            return _categoryRepository.GetParentCategory();
        }
        public IEnumerable<ChildCategoryEntity> GetChildCategorysById(int id)
        {
            return _categoryRepository.GetChildCategorysById(id);
        }
        public AdvertisementCategoryEntity GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public AdvertisementCategoryEntity GetSingleParentCategoy(int id)
        {
            return _categoryRepository.GetSingleParentCategoy(id);
        }
    }
}
