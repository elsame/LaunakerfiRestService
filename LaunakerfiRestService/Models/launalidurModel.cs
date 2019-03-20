using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaunakerfiRestService.Models
{
    public class launalidurModel
    {
        public int Id { get; set; }
        public string heiti { get; set; }
        public int gildi { get; set; }
        public string skyring { get; set; }
        public bool prosenta { get; set; }
        public bool fradrattur { get; set; }
        public bool asedli { get; set; }
        public int idAstand { get; set; }
    }
}