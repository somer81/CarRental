using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Entityframework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();

            if(result.Success == true)
                foreach(var car in result.Data)
                {
                    Console.WriteLine("{0} - {1} - {2} ", car.CarName, car.BrandName, car.ColorName);
                }


            //if(result.Success == true)
            //foreach (var car in result.Data)
            //{
            //    Console.WriteLine("{0} - {1} - {2} ", car.Id, car.Description, car.ModelYear);
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);  
            //}

            //Console.WriteLine("------------------------------");
            //result = carManager.GetCarsByBrandId(1);
            
            //if(result.Success == true)
            //foreach (var car in result.Data)
            //{
            //    Console.WriteLine("{0} - {1} - {2} ", car.Id, car.Description, car.ModelYear);
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}

            //Console.WriteLine("------------------------------");
            //result = carManager.GetCarsByColorId(1);
      
            //foreach (var car in result.Data)
            //{
            //    Console.WriteLine("{0} - {1} - {2} ", car.Id, car.Description, car.ModelYear);
            //}
        }
    }
}
