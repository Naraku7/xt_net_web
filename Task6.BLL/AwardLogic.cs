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
    public class AwardLogic : IAwardLogic
    {
        private readonly IAwardDao _awardDao;

        public AwardLogic(IAwardDao awardDao)
        {
            _awardDao = awardDao;
        }

        public Award CreateAward(Award award)
        {
            return _awardDao.CreateAward(award);
        }
    }
}
