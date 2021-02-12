using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {


        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal; 
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded); 
        }

        public IResult Delete(User user)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.UserAdded);
        }

        public IDataResult<User> GetById(int id)
        {

            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id),Messages.UserAdded);
        }

        public IResult Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
