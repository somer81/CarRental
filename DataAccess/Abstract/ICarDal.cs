using Entities.Concrete;
using Entities.DTOs;
using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {


        List<CarDetailsDto> GetCarDetails();
    
    }
}
