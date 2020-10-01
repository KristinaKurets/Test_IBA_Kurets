using Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Linq;

namespace Data.Context
{
    public class RecordContext :DbContext
    {
        public DbSet<Record> Records { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-S2L9C420;Database=IBA_Test;Integrated Security=True;");
        }
    }
}
