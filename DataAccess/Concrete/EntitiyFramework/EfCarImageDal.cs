using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, ReCapProjectDbContext>, ICarImageDal
    {
    }
}