using Business.Abstract;
using Business.Constants;
using Core.Entities;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
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

        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new Result(Messages.CarAdded,true); ;
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new Result(Messages.CarDeleted, true);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);    
        }

        public IDataResult<List<Car>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.CarID==id));
        }

        public IDataResult<List<Car>> GetByProductPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice>=min && c.DailyPrice<=max));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),Messages.CarDetailsListed);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new Result(Messages.CarUpdated, true);
        }
    }
}
