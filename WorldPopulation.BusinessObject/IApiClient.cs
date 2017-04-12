using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldPopulation.BusinessEntity;

namespace WorldPopulation.BusinessObject
{
    public interface IApiClient
    {

        void GetInstance();
        List<Country> GetListOfCountries();

        Population GetPopulationByYear(string countryName, int year);

        Dictionary<Sex, float> GetMortalityDistributionUntil5Years(string countryName);
    }
}
