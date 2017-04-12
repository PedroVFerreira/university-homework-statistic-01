using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldPopulation.Framework
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message, HeaderTypes type)
        {
            string newMessage = Format(message, type);

            Console.WriteLine(newMessage);
        }

        public string Format(string message, HeaderTypes type)
        {
            string result;

            switch (type)
            {
                case HeaderTypes.Header1:
                    result = String.Format("###### {0}", message);
                    break;
                case HeaderTypes.Header2:
                    result = String.Format("   ###### {0}", message);
                    break;
                case HeaderTypes.Header3:
                    result = String.Format("      ###### {0}", message);
                    break;
                case HeaderTypes.Error:
                    result = String.Format("######### ERROR - {0}", message);
                    break;
                default:
                    result = String.Format("{0}", message);
                    break;
            }

            return result;
        }

    }
}
