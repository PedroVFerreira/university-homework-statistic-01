using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldPopulation.BusinessEntity
{
    public class SexData
    {
        public SexData(Sex sex)
        {
            Sex = sex;
        }
        public Sex Sex { get; }

        public int Count { get; set; }

        public float LifeExpectancy { get; set; }

    }
}
