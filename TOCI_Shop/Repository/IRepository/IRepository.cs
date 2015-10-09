using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Ajax.Utilities;
using System;

namespace Repository.IRepository
{
    public interface IRepository<T> where T:class 
    {
     IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
     IQueryable<T> GetAll();
     T GetById(int id);
     void Insert(T obj);
     void Delete(T obj);
    }
}