using Dapper;
using MCGalvaoWebAPI.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MCGalvaoWebAPI.Utils
{
    public class DataRepository : IDataRepository
    {
        private IConfiguration Configuration;

        public DataRepository(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        public IEnumerable<Itinerary> GetItineraries()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Configuration.GetConnectionString("Work")))
            {
                var results = connection.QueryMultiple(@"
                            select * from Itineraries");

                var itineraries = results.Read<Itinerary>();

                return itineraries;
            }
        }
    }
}
