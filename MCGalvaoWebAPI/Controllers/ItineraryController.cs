using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MCGalvaoWebAPI.Models;
using MCGalvaoWebAPI.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MCGalvaoWebAPI.Controllers
{
    [Route("api/itineraries")]
    [ApiController]
    public class ItineraryController : ControllerBase
    {
        private IConfiguration Configuration;
        public ItineraryController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        [HttpGet]
        [Route("all/{tag}")]
        public ApiResponse<List<Itinerary>> GetGameDescription(string tag)
        {
            var response = new ApiResponse<List<Itinerary>>();

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Configuration.GetConnectionString("Work")))
            {
                //TODO tryparse gameId to long before querying
                try
                {
                    List<Itinerary> itineraries = connection.Query<Itinerary>($"select * from Itineraries").ToList();
                    response.Result = true;
                    response.ReturnData = itineraries;
                } catch (Exception e)
                {
                    var teste2 = e.Message;
                }
            }
            return response;
        }

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}


        [HttpPost]
        public IActionResult Create(Itinerary model)
        {
            string message = "";

            if (ModelState.IsValid)
            {
                message = "Destino adicionado";
            }
            else
            {
                message = "Failed to create the product. Please try again";
            }
            return Content(message);
        }

    }
}
