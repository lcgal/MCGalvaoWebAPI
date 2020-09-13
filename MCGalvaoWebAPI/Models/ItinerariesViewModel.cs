using MCGalvaoWebAPI.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCGalvaoWebAPI.Models
{
    public class ItinerariesViewModel : PageModel
    {
        private readonly IDataRepository dataRepository;

        [BindProperty]
        public IEnumerable<Itinerary> Itineraries { get; set; }

        public ItinerariesViewModel(IDataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
            Itineraries = dataRepository.GetItineraries();
        }

        public void OnGet()
        {
            Itineraries = dataRepository.GetItineraries();
        }

    }
}
