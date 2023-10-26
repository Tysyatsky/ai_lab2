using AI_Lab2.Enums;

namespace AI_Lab2
{
    public class Input
    {
        public static double Salary { get; set; }
        public static bool IsSalaryMatter { get; set; }
        public static List<Subjects>? FavouriteSubjects { get; set; }
        public static bool LikePeople { get; set; }
        public static int TimeSpentOnline { get; set; }
        public static int SocialMediaCount { get; set; }
        public static bool LovesCartoons { get; set; }

        public static Input Create(double salary, bool salaryMatter, bool people, int timeSpentOnline, int socialMediaCount, bool lovesCartoons, List<Subjects> subjects)
        {   
            if (salary < 0)
            {
                throw new ArgumentException("Salary cannot be less than 0");
            }

            if (timeSpentOnline < 0 || timeSpentOnline > 24)
            {
                throw new ArgumentException("Time spent cannot be less than 0 and more than 24");
            }

            if (socialMediaCount < 0)
            {
                throw new ArgumentException("Social media count cannot be less than 0");
            }

            if (subjects is null || subjects.Count == 0)
            {
                throw new ArgumentException("Favourite subject must be valid and be more than 0");
            }

            return new Input(salary, salaryMatter, people, timeSpentOnline, socialMediaCount, lovesCartoons, subjects);
        }

        private Input(double salary, bool salaryMatter, bool people, int timeSpentOnline, int socialMediaCount, bool lovesCartoons, List<Subjects> subjects)
        {
            Salary = salary;
            IsSalaryMatter = salaryMatter;
            LikePeople = people;
            TimeSpentOnline = timeSpentOnline;
            SocialMediaCount = socialMediaCount;
            LovesCartoons = lovesCartoons;
            FavouriteSubjects = subjects;
        }
    }
}
