using Core.Entities;
using Core.Entities.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCarDal : EFEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using(ReCapProjectContext context = new ReCapProjectContext())
            {
                var carDetailList = from car in context.Cars
                                    join brand in context.Brands
                                    on car.BrandID equals brand.BrandID
                                    join model in context.Models
                                    on car.ModelID equals model.ModelID
                                    join color in context.Colors
                                    on car.ColorID equals color.ColorID
                                    select new CarDetailDto
                                    {
                                        CarID = car.CarID,
                                        BrandName = brand.BrandName,
                                        ModelName = model.ModelName,
                                        ColorName = color.ColorName,
                                        ModelYear = car.ModelYear,
                                        DailyPrice = car.DailyPrice,
                                        Description = car.Description
                                    };
                return carDetailList.ToList();
                    
            }
        }
    }
}
