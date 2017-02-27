using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMigrator.Migrations.Release._1._0.Data
{
    [Migration(022720171029)]
    public class Add_FeatureTypes : Migration
    {
        public override void Down()
        {
            string query = "";
            Execute.Sql(query);
        }

        public override void Up()
        {
            throw new NotImplementedException();
        }
    }
}
