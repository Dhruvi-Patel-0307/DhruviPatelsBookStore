﻿using DhruviPatelsBooks.DataAccess.Repository.IRepository;
using DhruviPatelsBookStore.DataAccess.Data;

using System;
using System.Collections.Generic;
using System.Text;

namespace DhruviPatelsBooks.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
           
            SP_Call = new SP_Call(_db);
            
        }
        public ICategoryRepository Category { get; private set; }
        public ISP_Call SP_Call { get; private set; }


        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
