using System.Collections.Generic;
using FlowerStoreAPI.Models;
using FlowerStoreAPI.Data;

namespace FlowerStoreAPI.Repositorys
{
    public interface IStoreRepo
    {
        bool SaveChanges();
        IEnumerable<Store> GetAllStores();
        Store GetStoreById(int id);
        void CreateStore(Store store);
        void UpdateStore(Store store);
        void DeleteStore(Store store);
    }
}