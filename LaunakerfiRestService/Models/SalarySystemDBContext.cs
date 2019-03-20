using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LaunakerfiRestService.Models
{

    public class SalarySystemDBContext : DbContext
    {
        public SalarySystemDBContext() : base("name=MyDbConnection")
        {

        }

        public DbSet<payCheckModel> PayCheck { get; set; }
        public DbSet<companyModel> Company { get; set; }
        public DbSet<employeeModel> Employee { get; set; }
        public System.Data.Entity.DbSet<LaunakerfiRestService.Models.launalidurModel> launalidurModels { get; set; }
        public System.Data.Entity.DbSet<LaunakerfiRestService.Models.employeeSettingsModel> employeeSettingsModels { get; set; }

        public System.Data.Entity.DbSet<LaunakerfiRestService.Models.groupModel> groupModels { get; set; }

        public System.Data.Entity.DbSet<LaunakerfiRestService.Models.jobCatagoryModel> jobCatagoryModels { get; set; }

        public System.Data.Entity.DbSet<LaunakerfiRestService.Models.personalDiscountModel> personalDiscountModels { get; set; }

        public System.Data.Entity.DbSet<LaunakerfiRestService.Models.employeeFeesModel> employeeFees { get; set; }

        public System.Data.Entity.DbSet<LaunakerfiRestService.Models.unionModel> unionsModels { get; set; }

        public System.Data.Entity.DbSet<LaunakerfiRestService.Models.pensionFundModel> pensionFundModels { get; set; }

        public System.Data.Entity.DbSet<LaunakerfiRestService.Models.taxOfficeModel> taxOfficeModels { get; set; }

        public System.Data.Entity.DbSet<LaunakerfiRestService.Models.taxItems> taxItems { get; set; }

        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<employeeFeesModel>()
                        .HasRequired(m => m.pensionFundModel)
                        .WithMany(t => t.HomeMatches)
                        .HasForeignKey(m => m.pensionFundModelId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<employeeFeesModel>()
                        .HasRequired(m => m.GuestTeam)
                        .WithMany(t => t.AwayMatches)
                        .HasForeignKey(m => m.GuestTeamId)
                        .WillCascadeOnDelete(false);
        }*/
    }
}
