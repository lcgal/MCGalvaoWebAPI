using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MCGalvaoWebAPI.Models;
using MCGalvaoWebAPI.Models.Responses;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MCGalvaoWebAPI.Controllers
{
    public class AddItineraryController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private IConfiguration Configuration;

        public AddItineraryController (IWebHostEnvironment hostEnvironment, IConfiguration _configuration)
        {
            webHostEnvironment = hostEnvironment;
            Configuration = _configuration;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult AddItineraries()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddItineraries(Itinerary itinerary)
        {
            Guid id = Guid.NewGuid();
            itinerary.Id = id;
            string uniqueFileName = UploadedFile(itinerary);
            itinerary.Photo = uniqueFileName;
            if (ModelState.IsValid)
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Configuration.GetConnectionString("Work")))
                {
                    //TODO tryparse gameId to long before querying
                    try
                    {
                        connection.Query<Itinerary>($"dbo.[AddItineraries] @id , @name , @photo , @days , @nights"
                            , new { itinerary.Id, itinerary.Name, itinerary.Photo, itinerary.Days, itinerary.Nights });
                    }
                    catch (Exception e)
                    {
                        var teste2 = e.Message;
                    }
                }


            }

            return View();
        }



        private string UploadedFile(Itinerary model)
        {
            string uniqueFileName = null;

            if (model.PhotoFile != null)
            {
                string root = Configuration["WebImagesFolder"];
                string uploadsFolder = root;
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.PhotoFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.PhotoFile.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }




    }
}
