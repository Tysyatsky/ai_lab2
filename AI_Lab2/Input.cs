using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AI_Lab2
{
    public class Input
    {
        private static List<Subjects> _definedSubjects = new()
        {
            Subjects.Math,
            Subjects.Art,
            Subjects.Chemistry,
            Subjects.Geometry,
            Subjects.Algebra,
            Subjects.PE,
            Subjects.Biology,
            Subjects.English,
            Subjects.Language
        };

        public double Salary { get; set; }
        public bool IsSalaryMatter { get; set; }
        public List<Subjects>? FavouriteSubjects { get; set; }
        public bool LikePeople { get; set; }
        public int TimeSpentOnline { get; set; }
        public int SocialMediaCount { get; set; }
        public bool LovesCartoons { get; set; }

        public Input(double salary, bool salaryMatter, string subjects, bool people, int timeSpentOnline, int socialMediaCount, bool lovesCartoons)
        {
            Salary = salary;
            IsSalaryMatter = salaryMatter;
            LikePeople = people;
            TimeSpentOnline = timeSpentOnline;
            SocialMediaCount = socialMediaCount;
            LovesCartoons = lovesCartoons;

            MapToEnum(subjects);
        }

        private void MapToEnum(string subjects)
        {
            FavouriteSubjects = new List<Subjects>();

            var stringest = subjects.Split(new char[] { ',' }).ToList();

            foreach (string subject in stringest)
            {
                if (Enum.TryParse(subject, out Subjects result))
                {
                    FavouriteSubjects.Add(result);
                }
            }
        }
    }
}
