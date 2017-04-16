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

        private readonly IExporter Exporter;

        private List<Country> countries;

        public WorldPopulationBO(ILogger logger, IApiClient api, IExporter exporter)
        {
            Logger = logger;
            Api = api;
            Exporter = exporter;
            Api.GetInstance();
        }

        public int Process()
        {
            GetDatas();

            Export();

            return 1;   
        }

        public void GetDatas()
        {
            Logger.Log("GETTING COUNTRIES", HeaderTypes.Header2);
            countries = Api.GetListOfCountries();

            GetNumbersByCountry(countries);

            Export();

        }

        public bool Export()
        {
            Exporter.Export(countries);
            return true;
        }
        public void GetNumbersByCountry(List<Country> countries)
        {
            foreach (Country country in countries)
            {
                try
                {
                    if (country.Name.ToUpper() == country.Name)
                        continue;
                    Logger.Log(String.Format("GETING INFO : {0}", country.Name), HeaderTypes.Header3);
                    country.PopulationIn1910 = Api.GetPopulationByYear(country.Name, 1990);
                    country.PopulationToday = Api.GetPopulationByYear(country.Name, DateTime.Today.Year);
                    country.MortalityDistributionUntil5Years = Api.GetMortalityDistributionUntil5Years(country.Name);
                }
                catch (Exception ex)
                {
                    Logger.Log(ex.Message, HeaderTypes.Error);
                }
            }
        }

    }
}
