using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Lab2
{
    public static class Stats
    {
        private string List<Subjects> _definedSubjects = new List<Subjects>({
            Subjects.Math,
            Subjects.Art,
            Subjects.Chemistry,
            Subjects.Geometry,
            Subjects.Algebra,
            Subjects.PE,
            Subjects.Biology,
            Subjects.English,
            Subjects.Language
        });
;

        public static double Salary { get; set; }

        public static bool IsSalaryMatter { get; set; }

        public static List<string> FavouriteSubject { get; set; }


    }
}
