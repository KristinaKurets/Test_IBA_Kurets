using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.IO;

namespace Data.Migrations
{
    public partial class RunSqlScript : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var overspeed = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"OverSpeed.sql");
            File.ReadAllText(overspeed);

            var minmaxspeed = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"MinMaxSpeed.sql");
            File.ReadAllText(minmaxspeed);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
