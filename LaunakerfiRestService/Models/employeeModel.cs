using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaunakerfiRestService.Models
{
    public partial class employeeModel
    {
        public int Id { get; set; }
        public string personalId { get; set; }
        public string name { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string postalCode { get; set; }
        public string city { get; set; }
        public bool status { get; set; }
        public string jobName { get; set; }
        public int IdJobCatagory { get; set; }
        public string email { get; set; }
        public bool electronic { get; set; }
        public string phonenumber { get; set; }
        public int idGroup { get; set; }
        public string salaryAccount { get; set; }
        public string vacationAccount { get; set; }

    }
}