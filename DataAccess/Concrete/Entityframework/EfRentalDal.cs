using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.Entityframework
{
    public class EfRentalDal:EfEntityRepositoryBase<Rental, CarsDbContext>,IRentalDal
    { 

         public void Add(Rental entity)
    {
        using (CarsDbContext context = new CarsDbContext())
        {
            var addEntity = context.Entry(entity);
            addEntity.State = EntityState.Added;
            context.SaveChanges();
        }
    }

    public void Delete(Rental entity)
    {
        using (CarsDbContext context = new CarsDbContext())
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }
    }

    public Rental Get(Expression<Func<Rental, bool>> filter)
    {
        using (CarsDbContext context = new CarsDbContext())
        {
            return context.Set<Rental>().SingleOrDefault(filter);
        }
    }

    public List<Rental> GetAll(Expression<Func<Rental, bool>> filter = null)
    {
        using (CarsDbContext context = new CarsDbContext())
        {
            return filter == null ? context.Set<Rental>().ToList() :
                context.Set<Rental>().Where(filter).ToList();
        }
    }

    public void Update(Rental entity)
    {
        using (CarsDbContext context = new CarsDbContext())
        {
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
}
