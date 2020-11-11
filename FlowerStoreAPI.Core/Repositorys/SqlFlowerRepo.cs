using System;
using System.Collections.Generic;
using System.Linq;
using FlowerStoreAPI.Data;
using FlowerStoreAPI.Models;

namespace FlowerStoreAPI.Repositorys
{
    public class SqlFlowerRepo : IFlowerRepo
    {
        
        private readonly FlowerContext _context;

           public SqlFlowerRepo(FlowerContext context)
        {
            _context = context;
        }

        public void CreateFlower(Flower flower)
        {
            if(flower == null){
                throw new System.NotImplementedException(nameof(flower));
            }
            
            _context.Flowers.Add(flower);
        }

        public void DeleteFlower(Flower flower)
        {
            if(flower == null)
            {
                throw new ArgumentNullException(nameof(flower));
            }

            _context.Flowers.Remove(flower);
        }

        public IEnumerable<Flower> GetAllFlowers()
        {
            return _context.Flowers.ToList();
        }

        public Flower GetFlowerById(int id)
        {
            return _context.Flowers.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateFlower(Flower flower)
        {
            //nothing
        }
    }
}