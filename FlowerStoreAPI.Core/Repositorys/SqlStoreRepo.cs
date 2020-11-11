using System;
using System.Collections.Generic;
using System.Linq;
using FlowerStoreAPI.Data;
using FlowerStoreAPI.Models;

namespace FlowerStoreAPI.Repositorys
{
    public class SqlStoreRepo : IStoreRepo
    {
        private readonly FlowerContext _context;

          public SqlStoreRepo(FlowerContext context)
        {
            _context = context; 
        }

        public void CreateStore(Store store)
        {
            if(store == null)
            {
                throw new ArgumentNullException(nameof(store));
            }

            _context.Stores.Add(store);
        }

        public void DeleteStore(Store store)
        {
            if(store == null)
            {
                throw new ArgumentNullException(nameof(store));
            }

            _context.Stores.Remove(store);
        }

        public IEnumerable<Store> GetAllStores()
        {
            return _context.Stores.ToList();
        }

        public Store GetStoreById(int id)
        {
            return _context.Stores.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
             return (_context.SaveChanges() >= 0);
        }

        public void UpdateStore(Store store)
        {
            //nothing
        }
    }
}