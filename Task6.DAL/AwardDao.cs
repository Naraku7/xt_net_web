using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Dao.Interfaces;
using Task6.Entities;

namespace Task6.DAL
{
    public class AwardDao : IAwardDao
    {
        //private static readonly Dictionary<int, Award> _awards = new Dictionary<int, Award>();

        public string AwardsFile { get; private set; } = @"E:\Studying\EPAM_Task6_Awards\Awards.txt";

        int amountOfAwards = 0;

        //writes award to the file
        public Award CreateAward(Award award)
        {
            using (StreamReader reader = new StreamReader(AwardsFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    amountOfAwards++;
                }
            }

            using (StreamWriter writer = new StreamWriter(AwardsFile, true))
            {
                award.Id = amountOfAwards++;
                writer.WriteLine(JsonConvert.SerializeObject(award));
            }

            return award;
        }
    }
}
