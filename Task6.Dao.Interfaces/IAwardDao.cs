using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Entities;

namespace Task6.Dao.Interfaces
{
    public interface IAwardDao
    {
        Award CreateAward(Award award);
        //Award AddAward(int userId, int AwardId);
        //void RemoveAward(int userId, int AwardId);
    }
}
