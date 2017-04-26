using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMigrator.Migrations.Release._1._0.Data
{
    [Migration(042620171125)]
    public class Add_Menu_ContentManagement : Migration
    {
        public override void Up()
        {
            string sql = @" DECLARE @ParentId int
                    
                            INSERT Menu(MenuName,MenuTitle, ParentID,MenuOrder, ControllerName,ActionName)
                            VALUES('ContentManagement', 'Content Management',NULL,99,'NULL','NULL');
                        
                            Select @ParentId = Identifier FROM Menu WHERE MenuName='ContentManagement';
                            INSERT Menu(MenuName,MenuTitle, ParentID,MenuOrder, ControllerName,ActionName)
                            VALUES('SetupTestData', 'Setup Test Data',@ParentId,1,'TestData','GetModules');

                           ";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql = @"DELETE FROM Menu WHERE MenuName='SetupTestData';
                           DELETE FROM Menu WHERE MenuName='ContentManagement';";

            Execute.Sql(sql);
        }

    }
}
