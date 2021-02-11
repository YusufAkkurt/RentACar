using Business.Concrete;
using DataAccess.Concrete.EntitiyFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();
            // NewMethod();
            // ColorTest();
            // CarDetailsTest();
        }

        private static void CarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("{0} / {1} / {2} / {3}",
                        car.Description,
                        car.BrandName,
                        car.ColorName,
                        car.DailyPrice
                    );
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            colorManager.Delete(new Color { Id = 1003, Name = "Watermelon Green" });

            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Name);
            }
        }

        private static void NewMethod()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            brandManager.Delete(new Brand { Id = 1003, Name = "Renault" });

            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Name);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var addedCar = carManager.Add(new Car
            {
                BrandId = 6,
                ColorId = 4,
                ModelYear = 2018,
                DailyPrice = 13,
                Description = "Toledo"
            });

            Console.WriteLine(addedCar.Message);
        }
    }
}