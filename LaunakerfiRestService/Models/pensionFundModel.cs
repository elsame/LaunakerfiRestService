using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaunakerfiRestService.Models
{
    public class pensionFundModel
    {
        public int Id { get; set; }
        public string number { get; set; }
        public string personalId { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string postalCode { get; set; }
        public string city { get; set; }
        public string phoneNumber { get; set; }
        public double premium { get; set; }
        public double privateProperty { get; set; }
        public double vacationFund { get; set; }
        public double training { get; set; }
        public double nationalHealth { get; set; }
        public double matchingFounds { get; set; }
        public double privateMatchingFounds { get; set; }
        public bool active { get; set; }
    }
}