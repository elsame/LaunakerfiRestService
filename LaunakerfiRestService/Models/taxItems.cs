using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaunakerfiRestService.Models
{
    public class taxItems
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string key { get; set; }
        public double value { get; set; }
        public bool percentage { get; set; }
        public bool onNote { get; set; }
        public DateTime activeFrom { get; set; }
        public bool active { get; set; }
    }
}