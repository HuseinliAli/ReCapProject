using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{BrandID=1,CarID=1,ColorID=23,DailyPrice=344.5m,Description="Fresh Comfort For Business Class Car",ModelYear=2021},
                new Car{BrandID=1,CarID=2,ColorID=8,DailyPrice=49.3m,Description="Similar For Economic Class Car",ModelYear=2012},
                new Car{BrandID=2,CarID=3,ColorID=3,DailyPrice=129.8m,Description="Comfort For Middle Class Car",ModelYear=2016},
                new Car{BrandID=2,CarID=4,ColorID=13,DailyPrice=339.1m,Description="Fresh Comfort For Lux Class Car",ModelYear=2023},
                new Car{BrandID=3,CarID=5,ColorID=7,DailyPrice=29.98m,Description="Old UnComfortable For Poor Class Car",ModelYear=1986}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.CarID==car.CarID);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetByID(int brandid)
        {
            return _cars.Where(c => c.CarID==brandid).ToList();
        }

        public Car GetByID(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarID==car.CarID);

            carToUpdate.CarID = car.CarID;
            carToUpdate.BrandID = car.BrandID;
            carToUpdate.ColorID = car.ColorID;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
