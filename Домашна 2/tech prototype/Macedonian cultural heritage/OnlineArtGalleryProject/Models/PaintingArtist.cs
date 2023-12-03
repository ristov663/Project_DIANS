using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineArtGalleryProject.Models
{
    public class PaintingArtist
    {

        public int PaintingId { get; set; }
        public int ArtistId { get; set; }
        public List<Artist> Artists { get; set; }
    }
}