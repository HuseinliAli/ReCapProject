using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ModeLManager : IModelService
    {
        IModelDal _modelDal;

        public ModeLManager(IModelDal modelDal)
        {
            _modelDal=modelDal;
        }

        public IResult Add(Model model)
        {
            _modelDal.Add(model);
            return new Result(Messages.ModelAdded, true);
        }

        public IResult Delete(Model model)
        {
            _modelDal.Delete(model);
            return new Result(Messages.ModelDeleted, true);
        }

        public IDataResult<List<Model>> Get(int id)
        {
            return new SuccessDataResult<List<Model>>(_modelDal.GetAll(m => m.ModelID==id),Messages.ModelGetByID);
        }

        public IDataResult<List<Model>> GetAll()
        {
            return new SuccessDataResult<List<Model>>(_modelDal.GetAll(),Messages.ModelListed);
        }

        public IResult Update(Model model)
        {
            _modelDal.Update(model);
            return new Result(Messages.ModelUpdated, true);
        }
    }
}
