using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Rental rental)
        {
            var rentalledCars = _rentalDal.GetAll(
                r => r.CarId == rental.CarId && (
                r.ReturnDate == null || 
                r.ReturnDate > DateTime.Now)).Any();

            if (rentalledCars)
                return new ErrorResult(Messages.CarIsStillRentalled);

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            var getAll = _rentalDal.GetAll();
            return new SuccessDataResult<List<Rental>>(getAll);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            System.Threading.Thread.Sleep(2000);
            var getById = _rentalDal.Get(u => u.Id == rentalId);
            return new SuccessDataResult<Rental>(getById);
        }

        [CacheAspect]
        [PerformanceAspect(3)]
        public IDataResult<List<RentDetailDto>> GetRentDetails()
        {
            System.Threading.Thread.Sleep(3000);
            var getRentalDetails = _rentalDal.GetRentDetils();
            return new SuccessDataResult<List<RentDetailDto>>(getRentalDetails);
        }

        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}