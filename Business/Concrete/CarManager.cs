﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IDataResult<Car> GetById(int carId)
        {
            var getById = _carDal.Get(c => c.Id == carId);
            return new SuccessDataResult<Car>(getById);
        }

        public IDataResult<List<Car>> GetAll()
        {
            var getAll = _carDal.GetAll();
            return new SuccessDataResult<List<Car>>(getAll);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            var getCarsByBrandId = _carDal.GetAll(c => c.BrandId == brandId);
            return new SuccessDataResult<List<Car>>(getCarsByBrandId);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            var getCarsByColorId = _carDal.GetAll(c => c.ColorId == colorId);
            return new SuccessDataResult<List<Car>>(getCarsByColorId);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            var getCarDetails = _carDal.GetCarDetails();
            return new SuccessDataResult<List<CarDetailDto>>(getCarDetails);
        }
    }
}