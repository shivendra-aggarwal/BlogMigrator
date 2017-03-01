using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMigrator.Migrations.Release._1._0.Data
{
    [Migration(030120171114)]
    public class Add_Menus : Migration
    {
        public override void Down()
        {
            string sql = @"DELETE FROM Menus";
            Execute.Sql(sql);
        }

        public override void Up()
        {
            string sql = @" DECLARE @ParentId int
                            INSERT Menu(MenuName,MenuTitle,ParentId,MenuOrder) VALUES('Dashboard','Dashboard',null,1)
                            INSERT Menu(MenuName,MenuTitle,ParentId,MenuOrder) VALUES('FeatureManagement','Feature Management',null,2)
                            SELECT @ParentId = Identifier FROM Menu WHERE MenuName='FeatureManagement'
                            INSERT Menu(MenuName,MenuTitle,ParentId,MenuOrder) VALUES('ViewAllFeatures','View All Features',@ParentId,1)
                            ";
            Execute.Sql(sql);
        }
    }
}
