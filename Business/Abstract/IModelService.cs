using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IModelService
    {
        void Add(Model model);

        void Update(Model model);

        void Delete(Model model);

        List<Model> GetAll();

        List<Model> Get(int id);
    }
}
