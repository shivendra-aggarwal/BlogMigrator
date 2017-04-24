using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMigrator.Migrations.Release._1._0.Table
{
    [Migration(240420171142)]
    public class Add_Table_FeatureType : Migration
    {
        public override void Down()
        {
            string sql = @"IF EXISTS (SELECT * FROM SYS.objects WHERE NAME=N'FeatureType' AND type='U')
                            BEGIN
                                DROP TABLE [FeatureType]
                            END";
            Execute.Sql(sql);
        }

        public override void Up()
        {
            string sql = @"IF NOT EXISTS (SELECT * FROM SYS.objects WHERE NAME=N'FeatureType' AND type='U')
                            BEGIN
                                CREATE TABLE [FeatureType](
                                	[Identifier] [int] IDENTITY(1,1) NOT NULL,
                                	[FeatureTypeName] [nvarchar](200) NOT NULL,
                                 CONSTRAINT [PK_FeatureType] PRIMARY KEY CLUSTERED 
                                (
                                	[Identifier] ASC
                                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                                ) ON [PRIMARY]
                                
                                GO
                                ";

            Execute.Sql(sql);
        }
    }
}
