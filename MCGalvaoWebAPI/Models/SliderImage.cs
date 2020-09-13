using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MCGalvaoWebAPI.Models
{
    public class SliderImage
    {
        public Guid Id { get; set; }

        [Display(Name = "Titulo")]
        [Required(ErrorMessage = "Campo obrigatório"), StringLength(30)]
        public string Name { get; set; }

        [Display(Name = "Foto")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public IFormFile PhotoFile { get; set; }

        [Display(Name = "URL")]
        public string Url { get; set; }

        [Display(Name = "Descrição")]
        public string Description { get; set; }

        public string File { get; set; }
    }
}
