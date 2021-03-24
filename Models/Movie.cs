using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JoelHiltonFilms.Models
{
    public class Movie
    {//some fields required
        [Key]
        [Required]
        public int movieId { get; set; }
        [Required(ErrorMessage = "Choose a category")]
        public string category { get; set; }

        [Required(ErrorMessage = "Enter a title")]
        public string title { get; set; }

        
        [Required(ErrorMessage = "Enter a year")]
        public int year { get; set; }

        [Required(ErrorMessage = "Enter a director")]
        public string director { get; set; }

        [Required(ErrorMessage = "Choose a rating")]
        public string rating { get; set; }

       
        public string lentTo { get; set; }

        [StringLength(25)]
        public string notes { get; set; }

        public bool edited { get; set; }

    }
}
