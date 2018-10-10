using AutoWebShopEntity.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoWebShopEntity.Repositorys
{
    public class SoftDataDeleteSystem : ISoftDataDeleteSystem
    {
        private ISoftDataDeleteRepository _dataRepository;
        public SoftDataDeleteSystem(ISoftDataDeleteRepository deleteRepository)
        {
            _dataRepository = deleteRepository;
        }
        public void InsertObj(SoftDeletedDataEntity objects)
        {
            _dataRepository.InsertObj(objects);
        }
    }
}
