using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LaunakerfiRestService.Models
{
    public class companyModel
    {
        public int Id { get; set; }
        public string personalId { get; set; }
        public string name { get; set; }
        public string home { get; set; }
        public string postalCode { get; set; }
        public string city { get; set; }
        public string phoneNumber { get; set; }
        public string job { get; set; }
        public string sectorCodes { get; set; }
        public string bankNumber { get; set; }
        public int status { get; set; }
    }
}