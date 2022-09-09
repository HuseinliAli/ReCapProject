using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal=carDal;
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();    
        }

        public List<Car> GetAllByCategoryId(int id)
        {
            return _carDal.GetAll(c => c.CarID==id);
        }

        public List<Car> GetByProductPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(c => c.DailyPrice>=min && c.DailyPrice<=max);
        }
    }
}
