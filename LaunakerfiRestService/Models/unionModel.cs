using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LaunakerfiRestService.Models
{
    public class unionModel
    {
        public int Id { get; set; }
        public string number { get; set; }
        [Required]
        public string personalId { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string postalCode { get; set; }
        public string city { get; set; }
        public string phoneNumber { get; set; }
        public double membershipFee { get; set; }
        public double vacationFund { get; set; }
        public double training { get; set; }
        public double nationalHealth { get; set; }
        public double rehabilitation { get; set; }
        public bool active { get; set; }
    }
}