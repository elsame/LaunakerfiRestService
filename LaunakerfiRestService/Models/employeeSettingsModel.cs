using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LaunakerfiRestService.Models
{
    public class employeeSettingsModel
    {
        public int Id { get; set; }
        public DateTime worktimeFrom { get; set; }
        public DateTime worktimeTo { get; set; }
        public int jobPercentage { get; set; }
        public int fixedSalary { get; set; }
        public int hourly { get; set; }
        public int carBenefits { get; set; }
        public int dailyallowance { get; set; }
        public int overtime { get; set; }
        public int shiftWork { get; set; }
        public bool remuneration { get; set; }
        public bool calculateVehicleTax { get; set; }
        public bool calculatePaymentOfDailyAllowance { get; set; }
        public bool salaryOnAccount { get; set; }
        public bool vacationOnAccount { get; set; }
        public bool idStatus { get; set; }
        public DateTime personalDiscountFrom { get; set; }
        public int otherWages { get; set; }
        public int amountPercent { get; set; }
        public int amountSpousePercent { get; set; }

        [ForeignKey("employeeModel")]
        public int employeeModelId { get; set; }

        public virtual employeeModel employeeModel { get; set; }
    }
} 