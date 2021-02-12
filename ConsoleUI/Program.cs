using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Entityframework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            UserTest();






            TestCarDetailDto();


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

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            //var result = userManager.Add(new User()
            //{
            // Id = 1,
            // FirstName = "Omer",
            // LastName  = "Sevinc",
            // Email = "omer@gmail.com",
            // Password = "abc"
            //});

            var result = userManager.GetById(1);

            if (result.Success == true)
              Console.WriteLine("{0} - {1} ", result.Data.FirstName, result.Data.LastName);
                
        }

        private static void TestCarDetailDto()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();

            if (result.Success == true)
                foreach (var car in result.Data)
                {
                    Console.WriteLine("{0} - {1} - {2} ", car.CarName, car.BrandName, car.ColorName);
                }
        }
    }
}
