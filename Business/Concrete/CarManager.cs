using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public Car GetById(int carId)
        {
            return _carDal.GetById(carId);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }
    }
}