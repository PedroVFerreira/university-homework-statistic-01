using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldPopulation.Framework;
using WorldPopulation.Facade;
using WorldPopulation.BusinessObject;
using System.Configuration;
namespace WorldPopulation.Call
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ILogger Log = WorldPopulationFacade.InitializeLogger();
            try
            {
                
                Log.Log("STARTING PROCESS", HeaderTypes.Header1);

                WorldPopulationBO WorldPopulation = WorldPopulationFacade.InitializeWorldPopulationBO();
                

                WorldPopulation.Process();

                Log.Log("END OF PROCESS", HeaderTypes.Header1);

            }
            catch (Exception ex)
            {
                Log.Log(ex.Message, HeaderTypes.Error);               
            }
            
        }
        
    }
}
