﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace This_Is_Soccer.Models
{
    public class GenericRepository<T> : Interface.IGenericRepository<T> where T : class
    {
        private ApplicationDbContext db = null;
        private DbSet<T> table = null;

        public GenericRepository()
        {
            this.db = new ApplicationDbContext();
            table = db.Set<T>();
        }

        public GenericRepository(ApplicationDbContext db)
        {
            this.db = db;
            table = db.Set<T>();
        }

        public IEnumerable<T> SelectAll()
        {
            return table.ToList();
        }

        public T SelectByID(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            db.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}