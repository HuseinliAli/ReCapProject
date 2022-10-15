using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Model : IEntity
    {
        public int ModelID { get; set; }

        public int BrandID { get; set; }

        public string ModelName { get; set; }

    }
}
