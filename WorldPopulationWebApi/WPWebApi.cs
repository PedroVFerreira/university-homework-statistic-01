using System;
using System.Collections.Generic;
using System.Linq;
using WorldPopulation.BusinessObject;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WorldPopulation.BusinessEntity;
using WorldPopulation.BusinessEntity.Responses;
using Newtonsoft.Json;

namespace WorldPopulationWebApi
{
    public class WPWebApi : IApiClient
    {
        public HttpClient client;

        public WPWebApi()
        {
            client = new HttpClient();
            
        }

        public void GetInstance()
        {
            client.BaseAddress = new Uri("http://api.population.io");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> Get(string path)
        {

            HttpResponseMessage response = await client.GetAsync(path);
            string result = "";
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();

            }
            return result;  

        }

        public List<Country> GetListOfCountries()
        {

            List<Country> result = new List<Country>();
            try
            {
                CountriesResponse response = JsonConvert.DeserializeObject<CountriesResponse>(Get(Routes.CountriesList().Value).Result);
                foreach (var item in response.countries)
                {
                    result.Add(new Country(item));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public Population GetPopulationByYear(string countryName, int year)
        {
            Population result = new Population();
            try
            {
                GetPopulation(result, countryName, year);
                GetLifeExpectancyByPopulationByYear(result, countryName, year);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        private void GetPopulation(Population result, string countryName, int year)
        {
            List<PopulationResponse> response = JsonConvert.DeserializeObject<List<PopulationResponse>>(Get(Routes.PopulationByYear(countryName, year).Value).Result);
            result.Female.Count = response.Sum(c => c.females);
            result.Male.Count = response.Sum(c => c.males);
        }

        private void GetLifeExpectancyByPopulationByYear(Population result, string countryName, int year)
        {
            LifeExpectancyResponse responseFemale = JsonConvert.DeserializeObject<LifeExpectancyResponse>(Get(Routes.LifeExpectancy("female", countryName, year).Value).Result);
            result.Female.LifeExpectancy = responseFemale.total_life_expectancy;

            LifeExpectancyResponse responseMale = JsonConvert.DeserializeObject<LifeExpectancyResponse>(Get(Routes.LifeExpectancy("male", countryName, year).Value).Result);
            result.Male.LifeExpectancy = responseMale.total_life_expectancy;

        }

        public Dictionary<Sex, float> GetMortalityDistributionUntil5Years(string countryName)
        {
            Dictionary<Sex, float> result = new Dictionary<Sex, float>();
            MortalityDistributionResponse responseFemale = JsonConvert.DeserializeObject<MortalityDistributionResponse>(Get(Routes.MortalityDistribution("female", countryName).Value).Result);
            result.Add(Sex.Female, responseFemale.mortality_distribution.Where(c => c.age <= 5).Sum(c => c.mortality_percent));

            MortalityDistributionResponse responseMale = JsonConvert.DeserializeObject<MortalityDistributionResponse>(Get(Routes.MortalityDistribution("male", countryName).Value).Result);
            result.Add(Sex.Male, responseMale.mortality_distribution.Where(c => c.age <= 5).Sum(c => c.mortality_percent));

            return result;
        }

    }
}
