using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
   public class InMemoryCarDal : ICarDal
    {

        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>() {

            new Car(){Id=1,BrandId=1,ColorId=2,DailyPrice=100,ModelYear=2010,Description="Station"},
            new Car(){Id=2,BrandId=1,ColorId=1,DailyPrice=1250,ModelYear=2001,Description="Sedan"},
            new Car(){Id=3,BrandId=3,ColorId=2,DailyPrice=550,ModelYear=2020,Description="Sedan"},
            new Car(){Id=4,BrandId=4,ColorId=3,DailyPrice=900,ModelYear=1990,Description="Hatchback"},
            new Car(){Id=5,BrandId=5,ColorId=4,DailyPrice=350,ModelYear=2002,Description="Station"},

        };

        }

       
        
    

        public void Add(Car car)
        {
            _cars.Add(car); 
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars; 
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.Id == id);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
