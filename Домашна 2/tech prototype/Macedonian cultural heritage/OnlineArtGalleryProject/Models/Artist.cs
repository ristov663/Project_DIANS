using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineArtGalleryProject.Models
{
    public class Artist
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Biography { get; set; }

        [Required]
        public string ImageURL { get; set; }
        
        public virtual List<Painting> Paintings { get; set; }
    }
}