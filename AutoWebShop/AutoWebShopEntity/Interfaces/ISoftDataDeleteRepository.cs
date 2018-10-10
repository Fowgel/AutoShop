using AutoWebShopEntity.Entitys;

namespace AutoWebShopEntity.Repositorys
{
    public interface ISoftDataDeleteRepository
    {
        void InsertObj(SoftDeletedDataEntity dataObj);
    }
}