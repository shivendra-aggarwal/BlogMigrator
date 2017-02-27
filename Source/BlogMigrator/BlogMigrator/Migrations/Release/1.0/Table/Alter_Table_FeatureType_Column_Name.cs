using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMigrator.Migrations.Release._1._0.Table
{
    [Migration(022720171033)]
    public class Alter_Table_FeatureType_Column_Name : Migration
    {
        public override void Down()
        {
            string sql = @"IF EXISTS (SELECT * FROM SYS.columns WHERE NAME=N'FeatureTypeName' AND object_id = OBJECT_ID('Feature.FeatureType'))
                            BEGIN
                                ALTER TABLE Feature.FeatureType RENAME COLUMN FeatureTypeName TO FeatureName
                            END
                            ";
            Execute.Sql(sql);
        }

        public override void Up()
        {
            string sql = @"IF EXISTS (SELECT * FROM SYS.columns WHERE NAME=N'FeatureName' AND object_id = OBJECT_ID('Feature.FeatureType'))
                            BEGIN
                                ALTER TABLE Feature.FeatureType RENAME COLUMN FeatureName TO FeatureTypeName
                            END";
            Execute.Sql(sql);
        }
    }
}
