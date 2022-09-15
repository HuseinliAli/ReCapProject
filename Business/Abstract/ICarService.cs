using Core.Entities;
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
        List<Car> GetAll();

        List<Car> GetAllByCategoryId(int id);

        List<Car> GetByProductPrice(decimal min, decimal max);

        List<CarDetailDto> GetCarDetails();

        void Add(Car car);

        void Update(Car car);

        void Delete(Car car);
    }
}
