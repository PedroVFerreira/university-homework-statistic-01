using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldPopulation.BusinessEntity
{
    public class PopulationResponse
    {
        public int females { get; set; }
        public string country { get; set; }
        public int age { get; set; }
        public int males { get; set; }
        public int year { get; set; }
        public int total { get; set; }
    }
}
