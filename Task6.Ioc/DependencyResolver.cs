using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.BLL;
using Task6.BLL.Interfaces;
using Task6.DAL;
using Task6.Dao.Interfaces;

namespace Task6.Ioc
{
    /// <summary>
    /// With this class we can use specific classes. 
    /// Thus, we have the only entry point, in compliance with Single Responsibility principle.
    /// </summary>

    public static class DependencyResolver
    {
        private static IUserDao _userDao;
        private static IAwardDao _awardDao;

        static DependencyResolver()
        {
            var DAL = ReadSetting("DAL");

            if (DAL == "JSONFile")
            {
                _userDao = new UserJSONFileDao();
                _awardDao = new AwardDao();
            }
            else
            {
                _userDao = new UserFakeDao();
                _awardDao = new AwardDao();
            }
        }


        public static IUserDao UserDao => _userDao ?? (_userDao = new UserJSONFileDao());

        private static IUserLogic _userLogic;

        public static IUserLogic UserLogic => _userLogic ?? (_userLogic = new UserLogic(UserDao));


        public static IAwardDao AwardDao => _awardDao ?? (_awardDao = new AwardDao());

        private static IAwardLogic _awardLogic;

        public static IAwardLogic AwardLogic => _awardLogic ?? (_awardLogic = new AwardLogic(AwardDao));


        //Reading app.config line with the key
        static string ReadSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key] ?? "Not Found";

                return result;
            }
            catch (ConfigurationErrorsException)
            {
                return "Error reading app settings";
            }
        }

    }
}
