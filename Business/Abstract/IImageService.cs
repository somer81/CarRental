using Core.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IImageService<T> where T : class, IEntity, new()
    {
        IResult SaveImage(T entity);


        IResult  DeleteImage(int entityId);
       
    }
}
