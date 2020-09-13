using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Owin.Security;

namespace MCGalvaoWebAPI.Models
{
    public class Itinerary
    {
        public Guid Id { get; set; }

        [Display(Name = "Titulo")]
        [Required(ErrorMessage ="Campo obrigatório"), StringLength(30)]
        public string Name { get; set; }

        [Display(Name = "Foto")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public IFormFile PhotoFile { get; set; }

        [Display(Name = "Dias")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int Days { get; set; }

        [Display(Name = "Noites")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int Nights { get; set; }

        [Display(Name = "Texto")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Texto { get; set; }

        public string Photo { get; set; }

        public string Slug { get; set; }
    }
}
