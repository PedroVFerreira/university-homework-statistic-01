using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldPopulation.BusinessEntity.Responses
{
    public class LifeExpectancyResponse
    {
        public string dob { get; set; }

        public string country { get; set; }

        public float total_life_expectancy { get; set; }

        public string sex { get; set; }
    }
}
