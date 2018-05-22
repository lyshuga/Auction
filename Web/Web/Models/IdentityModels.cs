using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auction.Web.Models
{
    public class LoginViewModel
    {
        [Required]
        //[DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}