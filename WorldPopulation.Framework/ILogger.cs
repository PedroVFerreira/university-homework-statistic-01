using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldPopulation.Framework
{
    public interface ILogger
    {

        void Log(string message, HeaderTypes type);

        string Format(string message, HeaderTypes type);

    }
}
    