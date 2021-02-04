using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        readonly List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> 
            {
                new Car{Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 15, ModelYear = 2013, Description = "Hyundai"},
                new Car{Id = 2, BrandId = 1, ColorId = 1, DailyPrice = 55, ModelYear = 2010, Description = "Hyundai"},
                new Car{Id = 3, BrandId = 2, ColorId = 2, DailyPrice = 190, ModelYear = 2019, Description = "Audi"},
                new Car{Id = 4, BrandId = 3, ColorId = 2, DailyPrice = 210, ModelYear = 2015, Description = "Mercedes"},
                new Car{Id = 5, BrandId = 3, ColorId = 2, DailyPrice = 65, ModelYear = 2021, Description = "Mercedes"},
            };
        }

        public Car GetById(int carId)
        {
            return _cars.SingleOrDefault(c => c.Id == carId);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);

            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}