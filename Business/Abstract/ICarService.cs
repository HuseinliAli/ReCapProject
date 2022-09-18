using Core.Entities;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();

        IDataResult<List<Car>> GetAllByCategoryId(int id);

        IDataResult<List<Car>> GetByProductPrice(decimal min, decimal max);

        IDataResult<List<CarDetailDto>> GetCarDetails();

        IResult Add(Car car);

        IResult Update(Car car);

        IResult Delete(Car car);
    }
}
