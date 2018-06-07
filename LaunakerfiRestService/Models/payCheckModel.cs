using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LaunakerfiRestService.Models
{
    public class payCheckModel
    {
        public int Id { get; set; }
        public int IdLaunthegi { get; set; }
        public byte[] launasedillprent { get; set; }
        public DateTime timiFra { get; set; }
        public DateTime timiTil { get; set; }
        public int IdLaunagreidsla { get; set; }
        public int IdRskSkilagrein { get; set; }
        public int IdLifeyrirSkilagrein { get; set; }
        public int astand { get; set; }
    }

    public class SalarySystemDBContext : DbContext
    {
        public DbSet<payCheckModel> PayCheck { get; set; }
    }
}