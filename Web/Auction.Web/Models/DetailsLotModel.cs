using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auction.Web.Models
{
    public class DetailsLotModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string GoodType { get; set; }
        public string Photo { get; set; }
        public decimal Price { get; set; }
        public string BidderId { get; set; }
        public string SellerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime LastBid { get; set; }
    }
}