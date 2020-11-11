using System.Collections.Generic;
using FlowerStoreAPI.Models;
using FlowerStoreAPI.Data;

namespace FlowerStoreAPI.Repositorys
{
    public interface IFlowerRepo
    {
        bool SaveChanges();
        IEnumerable<Flower> GetAllFlowers();
        Flower GetFlowerById(int id);
        void CreateFlower(Flower flower);
        void UpdateFlower(Flower flower);
        void DeleteFlower(Flower flower);
    }
}