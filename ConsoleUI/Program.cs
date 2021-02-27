using Business.Concrete;
using DataAccess.Concrete.EntitiyFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.IO;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // UserTest();
            // CustomerTest();
            RentalTest();
        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var rental = rentalManager.Add(new Rental
            {
                CarId = 1,
                CustomerId = 2,
                RentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
            });

            Console.WriteLine(rental.Message);
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            var listCustomers = customerManager.GetAll();

            foreach (var customer in listCustomers.Data)
            {
                Console.WriteLine(customer.CompanyName);
            }
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            var listUsers = userManager.GetAll();

            foreach (var user in listUsers.Data)
            {
                Console.WriteLine(user.FirstName);
            }
        }
    }
}