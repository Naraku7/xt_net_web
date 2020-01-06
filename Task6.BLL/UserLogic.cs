using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.BLL.Interfaces;
using Task6.Dao.Interfaces;
using Task6.Entities;

namespace Task6.BLL
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserDao _userDao;

        public UserLogic(IUserDao userDao)
        {
            _userDao = userDao;
        }
        public UserLogic() { }
        public User AddUser(User user)
        {
            return _userDao.AddUser(user);
        }
        public User GetById(int id)
        {
            return _userDao.GetById(id);
        }
        public IEnumerable<User> GetAll()
        {
            return _userDao.GetAll();
        }
        public void RemoveUser(int id)
        {
            _userDao.RemoveUser(id);
        }

        public Award AddAward(int userId, int awardId)
        {
           return _userDao.AddAward(userId, awardId);
        }

        //public void RemoveAward(int userId, int awardId)
        //{
        //    _userDao.RemoveAward(userId, awardId);
        //}
    }
}
