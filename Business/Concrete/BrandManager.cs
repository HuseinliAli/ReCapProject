using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal=brandDal;
        }

        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new Result(Messages.BrandAdded, true);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new Result(Messages.BrandDeleted, true);
        }

        public IDataResult<List<Brand>> Get(int id)
        {
            return new SuccessDataResult<List<Brand>>
                (_brandDal.GetAll(b => b.BrandID == id),Messages.BrandGetByID);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>
                (_brandDal.GetAll(),Messages.BrandListed);
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new Result(Messages.BrandUpdated, true);
        }
    }
}
