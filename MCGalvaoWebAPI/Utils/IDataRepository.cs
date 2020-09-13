using MCGalvaoWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCGalvaoWebAPI.Utils
{
    public interface IDataRepository
    {
        IEnumerable<Itinerary> GetItineraries();
    }
}
