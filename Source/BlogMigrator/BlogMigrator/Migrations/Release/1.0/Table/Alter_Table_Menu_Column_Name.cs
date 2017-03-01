using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMigrator.Migrations.Release._1._0.Table
{
    [Migration(030120171024)]
    public class Alter_Table_Menu_Column_Name : Migration
    {
        public override void Down()
        {
            string sql = @"IF EXISTS (SELECT * FROM SYS.columns WHERE NAME=N'Identifier' AND object_id = OBJECT_ID('Menu'))
                            BEGIN
								EXEC sp_rename 'Menu.Identifier', 'MenuId', 'COLUMN';  
                            END
                            ";
            Execute.Sql(sql);
        }

        public override void Up()
        {
            string sql = @"IF EXISTS (SELECT * FROM SYS.columns WHERE NAME=N'MenuId' AND object_id = OBJECT_ID('Menu'))
                            BEGIN
								EXEC sp_rename 'MenuId', 'Identifier', 'COLUMN';  
                            END";
            Execute.Sql(sql);
        }
    }
}
