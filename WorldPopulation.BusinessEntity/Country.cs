using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldPopulation.BusinessEntity
{
    public class Country
    {

        public Country(string name)
        {
            Name = name;
        }
        public string Name { get; set; }

        public Population PopulationToday;

        public Population PopulationIn1910;
        public Dictionary<Sex, float> MortalityDistributionUntil5Years { get; set; }
    }
}
