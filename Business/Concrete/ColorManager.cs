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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal=colorDal;
        }

        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new Result(Messages.ColorAdded, true);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new Result(Messages.ColorAdded, true);
        }

        public IDataResult<List<Color>> Get(int id)
        {
            return new SuccessDataResult<List<Color>>
                (_colorDal.GetAll(c=>c.ColorID==id),Messages.ColorGetByID);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Messages.ColorListed);
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new Result(Messages.ColorUpdated, true);
        }
    }
}
