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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal=customerDal;
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new Result(Messages.CustomerAdded, true);
        }

        public IResult Add(Rental rental)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new Result(Messages.CustomerDeleted, true);
        }

        public IDataResult<List<Customer>> Get(int id)
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(c => c.UserID==id), Messages.CustomerGetByID);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomerListed);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new Result(Messages.CustomerUpdated, true);
        }
    }
}
