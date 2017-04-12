using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldPopulation.BusinessEntity;
namespace WorldPopulation.BusinessObject
{
    public interface IExporter
    {
        bool Export(List<Country> country);
    }
}
