using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<CarDetailDto> GetById(int carId);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId);

        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);

        IResult UpdateTransactionalOperation(Car car);
    }
}