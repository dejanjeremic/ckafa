
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace B2BAdmin.Functions.Data
{
    public class BaseDataContext : DbContext
    {
        protected readonly string _connectionString;

        public BaseDataContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      => optionsBuilder.UseSqlServer(_connectionString);

    }
}
