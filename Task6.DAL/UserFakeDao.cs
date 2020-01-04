using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Dao.Interfaces;
using Task6.Entities;

namespace Task6.DAL
{
    public class UserFakeDao : IUserDao
    {
        private static readonly Dictionary<int, User> _users = new Dictionary<int, User>();

        public User AddUser(User user)
        {
            var lastId = _users.Keys.Count > 0 
                ? _users.Keys.Max() : 0;

            user.Id = lastId + 1;

            _users.Add(user.Id, user);

            return user;
        }
        public User GetById(int id)
        {
            _users.TryGetValue(id, out var user);

            return user;
        }
        public IEnumerable<User> GetAll()
        {
            return _users.Values;
        }
        public void RemoveUser(int id)
        {
            _users.Remove(id);
        }

        public Award AddAward(int userId, Award award)
        {
            _users.TryGetValue(userId, out var user);

            user.CommonAmountOfAwards++;

            award.Id = user.CommonAmountOfAwards;

            user.awards.Add(award);

            return award;
        }

        //public void RemoveAward(int userId, int awardId)
        //{
        //    _users.TryGetValue(userId, out var user);

        //    Award award = null; //?

        //    foreach (var item in user.awards)
        //    {
        //        if (item.Id == awardId) award = item;
        //    }

        //    user.awards.Remove(award);
        //}
    }
}
