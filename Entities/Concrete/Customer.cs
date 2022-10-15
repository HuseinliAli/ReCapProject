using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Customer : IEntity
    {
        public int CustomerID { get; set; }

        public int UserID { get; set; }

        public string CompanyName { get; set; }
    }
}
