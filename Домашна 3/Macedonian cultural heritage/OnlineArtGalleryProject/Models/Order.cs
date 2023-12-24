using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineArtGalleryProject.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public System.DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
    }
}