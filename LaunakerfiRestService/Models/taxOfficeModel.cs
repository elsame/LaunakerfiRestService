using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaunakerfiRestService.Models
{
    public class taxOfficeModel
    {
        public int Id { get; set; }
        public string personalId { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string postalCode { get; set; }
        public string city { get; set; }
        public string phoneNumber { get; set; }
        public bool active { get; set; }
    }
}