using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldPopulation.BusinessEntity
{
    public class Population
    {
        public SexData Female;

        public SexData Male;

        public int Year { get; set; }

        public Population()
        {
            Female = new SexData(Sex.Female);
            Male = new SexData(Sex.Male);
        }
    }
}
