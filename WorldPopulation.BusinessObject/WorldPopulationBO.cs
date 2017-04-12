using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldPopulation.Framework;
using WorldPopulation.BusinessEntity;

namespace WorldPopulation.BusinessObject
{
    public class WorldPopulationBO
    {

        private readonly ILogger Logger;

        private readonly IApiClient Api;
        public WorldPopulationBO(ILogger logger, IApiClient api)
        {
            Logger = logger;
            Api = api;
            Api.GetInstance();
        }

        public int Process()
        {
            Logger.Log("GETING COUNTRIES", HeaderTypes.Header2);
            List<Country> countries =  Api.GetListOfCountries();

            foreach (Country country in countries)
            {
                try
                {
                    country.PopulationIn1910 = Api.GetPopulationByYear(country.Name, 1990);
                    country.PopulationToday = Api.GetPopulationByYear(country.Name, DateTime.Today.Year);
                    country.MortalityDistributionUntil5Years = Api.GetMortalityDistributionUntil5Years(country.Name);
                }
                catch (Exception ex)
                {
                    Logger.Log(ex.Message, HeaderTypes.Error);
                }
            }

            return 1;   
        }

    }
}
