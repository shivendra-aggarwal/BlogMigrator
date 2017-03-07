using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMigrator.Migrations.Release._1._0.Data
{
    [Migration(030720171111)]
    public class Add_Menu_Controller_Action : Migration
    {
        public override void Up()
        {
            string sql = @" DELETE FROM Menu;
                            DECLARE @ParentId int
                    
                            INSERT Menu(MenuName,MenuTitle, ParentID,MenuOrder, ControllerName,ActionName)
                            VALUES('Dashboard', 'DashBoard',NULL,1,'Dashboard','Index');
                        
                            INSERT Menu(MenuName,MenuTitle, ParentID,MenuOrder, ControllerName,ActionName)
                            VALUES('FeatureManagement', 'Feature Management',NULL,2,NULL,NULL);

                            Select @ParentId = Identifier FROM Menu WHERE MenuName='FeatureManagement';
                            INSERT Menu(MenuName,MenuTitle, ParentID,MenuOrder, ControllerName,ActionName)
                            VALUES('Features', 'Features',@ParentId,1,'Features','Index');

                            INSERT Menu(MenuName,MenuTitle, ParentID,MenuOrder, ControllerName,ActionName)
                            VALUES('Tasks', 'Tasks',@ParentId,2,'Tasks','Index');
                           ";

            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql = "DELETE FROM Menu;";

            Execute.Sql(sql);
        }

    }
}
