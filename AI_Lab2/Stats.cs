using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Lab2
{
    public class Stats
    {
        private double _art { get; set; }
        private double _people { get; set; }

        private double _technology { get; set; }

        public Stats() 
        { 
            _art = 0;
            _people = 0;
            _technology = 0;
        }
        
        public Stats Modify(double art, double people, double technology)
        {
            _art += art;
            _people += people;
            _technology += technology;

            _art = Math.Max(0, _art);
            _people = Math.Max(0, _people);
            _technology = Math.Max(0, _technology);

            return this;
        }

        public Dictionary<string, double> GetFinalModifiers() 
        {
            return new Dictionary<string, double>
            {
                { "Art" , _art},
                { "People" , _people},
                { "Technology" , _technology},
            };
        }
    }
}
