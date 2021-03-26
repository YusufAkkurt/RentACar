using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {
        CustomerDetailDto GetByEmail(Expression<Func<CustomerDetailDto, bool>> filter);
        List<CustomerDetailDto> GetCustomerDetails();
    }
}