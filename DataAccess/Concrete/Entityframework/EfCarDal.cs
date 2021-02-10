using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.Entityframework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarsDbContext>, ICarDal
    {
        public void Add(Car entity)
        {
            using (CarsDbContext context = new CarsDbContext())
            {
                var addEntity = context.Entry(entity);
                addEntity.State = EntityState.Added;
                context.SaveChanges(); 
            }
        }

        public void Delete(Car entity)
        {
            using (CarsDbContext context = new CarsDbContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (CarsDbContext context = new CarsDbContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (CarsDbContext context = new CarsDbContext())
            {
                return filter == null ? context.Set<Car>().ToList() :
                    context.Set<Car>().Where(filter).ToList(); 
            }
        }

        public List<CarDetailsDto> GetCarDetails()
        {

            using (CarsDbContext context = new CarsDbContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join cl in context.Colors
                             on c.ColorId equals cl.Id
                             select new CarDetailsDto
                             {
                                 BrandName = b.Name,
                                 CarName = c.Description,
                                 ColorName = cl.Name,
                                 DailyPrice = c.DailyPrice
                             };

                return result.ToList();
            }


        }

        public void Update(Car entity)
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
