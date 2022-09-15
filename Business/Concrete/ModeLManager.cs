using Business.Abstract;
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

        public void Add(Model model)
        {
            _modelDal.Add(model);
        }

        public void Delete(Model model)
        {
            _modelDal.Delete(model);    
        }

        public List<Model> Get(int id)
        {
            return _modelDal.GetAll(m => m.ModelID==id);
        }

        public List<Model> GetAll()
        {
            return _modelDal.GetAll();
        }

        public void Update(Model model)
        {
            _modelDal.Update(model);
        }
    }
}
