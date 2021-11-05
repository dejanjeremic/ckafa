using B2BAdmin.Functions.Data;
using cKafa.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cKafa.Data
{
    class ClicksDataContext : BaseDataContext
    {
        public ClicksDataContext(string connectionString) : base(connectionString)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlServer(_connectionString);

        public DbSet<Clicks> Clicks { get; set; }
        public static ClicksDataContext GetCurrent()
        {
            string connString = "Data Source=sql-development-001.database.windows.net;Initial Catalog=c-kafa;User Id=gurudexx;Password=L4z4r.2014.;MultipleActiveResultSets=True";

            ClicksDataContext db = new ClicksDataContext(connString);

            return db;
        }
    }
}
