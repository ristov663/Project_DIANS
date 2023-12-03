using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineArtGalleryProject.Models
{
    public class OrderDetails
    {

        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public string ItemId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
    }
}