using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineArtGalleryProject.Models
{
    public class Painting
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required]
        public string ImageURL { get; set; }
        public virtual List<Artist> Artists { get; set; }
        public int ArtGalleryId { get; set; }
        public virtual ArtGallery ArtGallery { get; set; }
    }
}