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
    public interface ICustomerService
    {
        IResult Add(Customer customer);

        IResult Add(Rental rental);

        IResult Update(Customer customer);

        IResult Delete(Customer customer);

        IDataResult<List<Customer>> GetAll();

        IDataResult<List<Customer>> Get(int id);
    }
}
