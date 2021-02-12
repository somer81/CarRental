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
   public class EfUserDal:EfEntityRepositoryBase<User,CarsDbContext>,IUserDal
    {
        public void Add(User entity)
        {
            using (CarsDbContext context = new CarsDbContext())
            {
                var addEntity = context.Entry(entity);
                addEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(User entity)
        {
            using (CarsDbContext context = new CarsDbContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public User Get(Expression<Func<User, bool>> filter)
        {
            using (CarsDbContext context = new CarsDbContext())
            {
                return context.Set<User>().SingleOrDefault(filter);
            }
        }

        public List<User> GetAll(Expression<Func<User, bool>> filter = null)
        {
            using (CarsDbContext context = new CarsDbContext())
            {
                return filter == null ? context.Set<User>().ToList() :
                    context.Set<User>().Where(filter).ToList();
            }
        }

        public void Update(User entity)
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
