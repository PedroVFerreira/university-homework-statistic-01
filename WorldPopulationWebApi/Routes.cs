using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldPopulationWebApi
{
    public class Routes
    {
        public Routes(string value)
        {
            Value = value;
        }

        public string Value { get; set; }

        public static Routes CountriesList()
        {
            return new Routes("/1.0/countries");
        }
        
        public static Routes PopulationByYear(string country, int year)
        {
            return new Routes(String.Format("/1.0/population/{0}/{1}/", year, country));
        }

        public static Routes LifeExpectancy(string sex, string country, int year)
        {
            return new Routes(String.Format("/1.0/life-expectancy/total/{0}/{1}/{2}-01-01/", sex, country, year));
        }

        public static Routes MortalityDistribution(string sex,string country)
        {   
          return new Routes(String.Format("/1.0/mortality-distribution/{0}/{1}/0/today/", country, sex));
        }
    }
}
