using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Entities;

namespace Task6.BLL.Interfaces
{
    public interface IUserLogic
    {
        User AddUser(User user);
        User GetById(int id);
        IEnumerable<User> GetAll();
        void RemoveUser(int id);
        Award AddAward(int userId, int awardId);
        //void RemoveAward(int userId, int awardId);
    }
}
