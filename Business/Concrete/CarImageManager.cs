using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Concrete.Entityframework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using Business.Constants;
using DataAccess.Uploads;
using System.IO;
using Core.Entities;
using Core.Business;
using Core.Aspects.Autofac;
using Business.ValidationRules.FluentValidation;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService, IImageService<CarImage>
    {

        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }


        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage)
        {


            IResult result = BusinessRule.Run(CheckIfCarImageNumberExceeds(carImage.Id));

            if (result != null)
            {
                return result;
            }

            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

       

        public IResult DeleteImage(int carImageId)
        {
            var image = _carImageDal.Get(c => c.Id == carImageId);
            var path = image.ImagePath;

            File.Delete(Directory.GetParent(Directory.GetCurrentDirectory()) + path);

            return new SuccessResult(Messages.ImageFileDeleted);
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            var carImage = _carImageDal.Get(c => c.Id == carImageId);
            return new SuccessDataResult<CarImage>(carImage);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            var carImages = _carImageDal.GetAll();
            return new SuccessDataResult<List<CarImage>>(carImages);

        }

        public IResult Update(CarImage carImage)
        {
            DeleteImage(carImage.Id);
            SaveImage(carImage);

            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        public IResult SaveImage(CarImage carImage)
        {
            carImage.ImagePath = UploadPathFounder.CarImageSave(carImage.Image).Result.ToString();
            return new SuccessResult(Messages.ImageSaved);
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);

            return new SuccessResult(Messages.CarImageDeleted);
        }

        private IResult CheckIfCarImageNumberExceeds(int carId)
        {
           var result = _carImageDal.GetAll(ci => ci.CarId == carId).Count;

            if(result > 5)
            {
                return new ErrorResult(Messages.CarImageNumberExceeds);
            }

            return new SuccessResult();
        } 
    }
}
