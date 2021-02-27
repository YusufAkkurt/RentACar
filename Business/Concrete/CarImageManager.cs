using Business.Abstract;
using Business.Constants;
using Core.Utilities.BusinessRules;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Uploads;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        readonly ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage)
        {
            var result = BusinessRule.Run(CheckCarImageLimit(carImage.CarId));

            if (result != null)
                return result;

            SaveImage(carImage);

            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            DeleteImage(carImage.Id);

            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            var getById = _carImageDal.Get(c => c.Id == carImageId);
            return new SuccessDataResult<CarImage>(getById);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            var getAll = _carImageDal.GetAll();
            return new SuccessDataResult<List<CarImage>>(getAll);
        }

        public IDataResult<List<CarImage>> GetListByCarId(int carId)
        {
            var getListByCarId = _carImageDal.GetAll(c => c.CarId == carId);

            if (getListByCarId.Count > 0)
                return new SuccessDataResult<List<CarImage>>(getListByCarId);

            var path = PathName.CarDefaultImages;
            var defaultImage = new List<CarImage> { new CarImage { ImagePath = path } };

            return new SuccessDataResult<List<CarImage>>(defaultImage);
        }

        public IResult Update(CarImage carImage)
        {
            DeleteImage(carImage.Id);
            SaveImage(carImage);

            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        private static void SaveImage(CarImage carImage)
        {
            carImage.ImagePath = UploadPathFounder.CarImageSave(carImage.Image).Result.ToString();
        }

        private void DeleteImage(int carImageId)
        {
            var image = _carImageDal.Get(c => c.Id == carImageId);
            var path = image.ImagePath;

            File.Delete(Directory.GetParent(Directory.GetCurrentDirectory()) + path);
        }

        private IResult CheckCarImageLimit(int carId)
        {
            var imageCount = _carImageDal.GetAll(c => c.CarId == carId).Count;

            if (imageCount >= 5)
            {
                return new ErrorResult(Messages.CarLimitExceded);
            }

            return new SuccessResult();
        }
    }
}