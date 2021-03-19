using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        CarDetailDto GetCarDetail(Expression<Func<CarDetailDto, bool>> filter);
        List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null);
    }
}