using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldPopulation.Framework;
using WorldPopulation.BusinessObject;
using WorldPopulationWebApi;
using ExportToExcel;

namespace WorldPopulation.Facade
{
    public class WorldPopulationFacade
    {
        public static WorldPopulationBO InitializeWorldPopulationBO()
        {
            return new WorldPopulationBO(InitializeLogger() , InitializeWebApi() , InitializeExporter());
        }

        public static IApiClient InitializeWebApi()
        {
            return new WorldPopulationWebApi.WPWebApi();
        }

        public static ILogger InitializeLogger()
        {
            return new ConsoleLogger();
        }
        public static IExporter InitializeExporter()
        {
            return new ExportToExcel.Exporter();
        }
    }
}
