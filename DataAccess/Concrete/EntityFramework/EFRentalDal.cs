using Core.Entities.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFRentalDal : EFEntityRepositoryBase<Rental, ReCapProjectContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using(ReCapProjectContext context = new ReCapProjectContext())
            {
                var rentalDetailList = from rental in context.Rentals

                                       join customer in context.Customers
                                            on rental.CustomerID equals customer.CustomerID

                                       join car in context.Cars
                                            on rental.CarID equals car.CarID
                                        
                                       join model in context.Models
                                            on car.ModelID equals model.ModelID

                                       join brand in context.Brands
                                            on car.BrandID equals brand.BrandID

                                       join color in context.Colors
                                            on car.ColorID equals color.ColorID
                                       join user in context.Users
                                            on customer.UserID equals user.UserID

                                       select new RentalDetailDto
                                       {
                                           CarID = car.CarID,
                                           BrandName = brand.BrandName,
                                           ModelName = model.ModelName,
                                           ModelYear = car.ModelYear,
                                           DailyPrice = car.DailyPrice,
                                           FirstName = user.FirstName,
                                           LastName = user.LastName,
                                           RentDate = rental.RentDate,
                                           ReturnDate = rental.ReturnDate
                                       };
                return rentalDetailList.ToList();
            }
        }
    }
}
