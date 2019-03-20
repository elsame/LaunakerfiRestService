using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaunakerfiRestService.Models
{
    public class employeeFeesModel
    {
        public int Id { get; set; }
        public double membershipFee { get; set; }
        public double premium { get; set; }
        public double privateProperty { get; set; }
        public double vacationFund { get; set; }
        public double training { get; set; }
        public double nationalHealth { get; set; }
        public double matchingFounds { get; set; }
        public double privateMatchingFounds { get; set; }

        [ForeignKey("employeeModel")]
        public int employeeModelId { get; set; }

        [ForeignKey("unionModel")]
        public int unionModelId { get; set; }

        [ForeignKey("pensionFundModel")]
        public int pensionFundModelId { get; set; }

        [ForeignKey("pensionFundModel")]
        public int privatePensionFundModelId { get; set; }

        public virtual employeeModel employeeModel { get; set; }
        public virtual unionModel unionModel { get; set; }
        public virtual ICollection<pensionFundModel> pensionFundModel { get; set; }
    }
}