using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlogMigrator.Migrations.Release._1._0.Table
{
    [Migration(030120170395)]
    public class Add_Menu_Table : Migration
    {
        public override void Down()
        {
            string sql = @"IF EXISTS (SELECT * FROM SYS.objects WHERE NAME=N'Menu' AND type='U')
                            BEGIN
                                IF EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'dbo.FK_Menu_MenuId') AND parent_object_id = OBJECT_ID(N'dbo.Menu'))
                                BEGIN
                                    ALTER TABLE [dbo.Menu] DROP CONSTRAINT [FK_Menu_MenuId]
                                END
                                
                                GO 

                                ALTER TABLE [Menu] DROP CONSTRAINT AK_MenuName

                                GO

                                DROP TABLE [Menu]
                            END";
            Execute.Sql(sql);
        }

        public override void Up()
        {
            string sql = @"IF NOT EXISTS (SELECT * FROM SYS.objects WHERE NAME=N'Menu' AND type='U')
                            BEGIN
                                CREATE TABLE [Menu](
                                	[MenuId] [int] IDENTITY(1,1) NOT NULL,
                                	[MenuName] [nvarchar](100) NOT NULL,
                                	[MenuTitle] [nvarchar](200) NOT NULL,
                                	[ParentId] [int] NULL,
                                	[MenuOrder] [int] NOT NULL,
                                 CONSTRAINT [PK_Menu_MenuId] PRIMARY KEY CLUSTERED 
                                (
                                	[MenuId] ASC
                                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                                ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
                                
                                GO
                                
                                ALTER TABLE [Menu]  WITH CHECK ADD  CONSTRAINT [FK_Menu_MenuId] FOREIGN KEY([ParentId])
                                REFERENCES [Menu] ([MenuId])
                                GO
                                
                                ALTER TABLE [Menu] CHECK CONSTRAINT [FK_Menu_MenuId]
                                GO

                                ALTER TABLE [Menu]   
                                ADD CONSTRAINT AK_MenuName UNIQUE MenuName
                                
                                GO
                            END";

            Execute.Sql(sql);
        }
    }
}
