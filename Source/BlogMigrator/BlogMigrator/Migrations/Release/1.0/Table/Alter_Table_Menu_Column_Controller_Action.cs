using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMigrator.Migrations.Release._1._0.Table
{
    [Migration(030720171059)]
    public class Alter_Table_Menu_Column_Controller_Action : Migration
    {
        public override void Down()
        {
            string sql = @"IF EXISTS (SELECT * FROM SYS.columns WHERE NAME=N'ControllerName' AND object_id = OBJECT_ID('Menu'))
                            BEGIN
								ALTER TABLE Menu DROP COLUMN ControllerName
                            END

                            IF EXISTS (SELECT * FROM SYS.columns WHERE NAME=N'ActionName' AND object_id = OBJECT_ID('Menu'))
                            BEGIN
								ALTER TABLE Menu DROP COLUMN ActionName
                            END
                            ";
            Execute.Sql(sql);
        }

        public override void Up()
        {
            string sql = @"IF NOT EXISTS (SELECT * FROM SYS.columns WHERE NAME=N'ControllerName' AND object_id = OBJECT_ID('Menu'))
                            BEGIN
								ALTER TABLE Menu ADD COLUMN ControllerName NVARCHAR(100)
                            END

                            IF NOT EXISTS (SELECT * FROM SYS.columns WHERE NAME=N'ActionName' AND object_id = OBJECT_ID('Menu'))
                            BEGIN
								ALTER TABLE Menu ADD COLUMN ActionName NVARCHAR(100)
                            END";
            Execute.Sql(sql);
        }
    }
}
