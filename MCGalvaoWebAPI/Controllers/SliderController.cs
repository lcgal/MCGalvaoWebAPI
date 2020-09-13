using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MCGalvaoWebAPI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MCGalvaoWebAPI.Controllers
{
    public class SliderController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private IConfiguration Configuration;

        public SliderController(IWebHostEnvironment hostEnvironment, IConfiguration _configuration)
        {
            webHostEnvironment = hostEnvironment;
            Configuration = _configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddSliderImages()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSliderImages(SliderImage image)
        {
            Guid id = Guid.NewGuid();
            image.Id = id;
            string uniqueFileName = UploadedFile(image);
            image.File = uniqueFileName;


            if (ModelState.IsValid)
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Configuration.GetConnectionString("Work")))
                {
                    //TODO tryparse gameId to long before querying
                    try
                    {
                        connection.Query<SliderImage>($"dbo.[addSliderImages] @id, @name, @file, @url, @description"
                            , new { image.Id, image.Name, image.File, image.Url, image.Description});


                        //var results = connection.QueryMultiple(@"
                        //    select id,name,photo,days,nights,slug from Itineraries");

                        //var itineraries = results.Read<Itinerary>();

                        //string json = JsonConvert.SerializeObject(itineraries);

                        //System.IO.File.WriteAllText(@"D:\Repositorios Pessoais\MCGalvaoWebSite\src\testObjects\Destinos.json", json);
                    }
                    catch (Exception e)
                    {
                        var teste2 = e.Message;
                    }
                }
            }
            return View();
        }

        private string UploadedFile(SliderImage model)
        {
            string uniqueFileName = null;

            if (model.PhotoFile != null)
            {
                string root = Configuration["ApiImagesFolder"];
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
