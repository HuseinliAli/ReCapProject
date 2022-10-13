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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal=userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new Result(Messages.UserAdded, true);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new Result(Messages.UserDeleted, true);
        }

        public IDataResult<List<User>> GetByMail(string email)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.Email==email), Messages.UserGetByID);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserListed);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new Result(Messages.UserUpdated, true);
        }
    }
}
