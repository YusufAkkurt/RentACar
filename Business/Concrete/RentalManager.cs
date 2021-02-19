using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            ValidationTool.Validate(new RentalValidator(), rental);

            var rentalsReturnDate = _rentalDal.GetAll(r => r.CarId == rental.CarId);

            if (rentalsReturnDate.Count > 0)
            {
                foreach (var rentalReturnDate in rentalsReturnDate)
                {
                    if (rentalReturnDate.ReturnDate == null)
                    {
                        return new ErrorResult(Messages.RentalReturnDateIsNull);
                    }
                }
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            ValidationTool.Validate(new RentalValidator(), rental);

            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            var getAll = _rentalDal.GetAll();
            return new SuccessDataResult<List<Rental>>(getAll);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            var getById = _rentalDal.Get(u => u.Id == rentalId);
            return new SuccessDataResult<Rental>(getById);
        }

        public IResult Update(Rental rental)
        {
            ValidationTool.Validate(new RentalValidator(), rental);

            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}