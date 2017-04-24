using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMigrator.Migrations.Release._1._0.Table
{
    [Migration(240420171145)]
    public class Add_Feature_Table : Migration
    {
        public override void Down()
        {
            string sql = @"IF EXISTS (SELECT * FROM SYS.objects WHERE NAME=N'Feature' AND type='U')
                            BEGIN
                                IF EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'dbo.FK_Feature_FeatureType') AND parent_object_id = OBJECT_ID(N'dbo.Feature'))
                                BEGIN
                                    ALTER TABLE [dbo.Feature] DROP CONSTRAINT [FK_Feature_FeatureType]
                                END
                                
                                GO

                                DROP TABLE [Feature]
                            END";
            Execute.Sql(sql);
        }

        public override void Up()
        {
            string sql = @"IF NOT EXISTS (SELECT * FROM SYS.objects WHERE NAME=N'Feature' AND type='U')
                            BEGIN
                                CREATE TABLE [Feature](
                                	[Identifier] [int] IDENTITY(1,1) NOT NULL,
                                	[FeatureName] [nvarchar](max) NULL,
                                	[FeatureDescription] [nvarchar](max) NULL,
                                	[IsCompleted] [bit] NOT NULL,
                                	[CompletedOn] [datetime] NULL,
                                	[StartedOn] [datetime] NULL,
                                	[IsActive] [bit] NOT NULL,
                                	[DocUrl] [nvarchar](max) NULL,
                                	[ImageUrl] [nvarchar](max) NULL,
                                	[FeatureTypeId] [int] NOT NULL,
                                	[ProjectId] [int] NOT NULL,
                                	[CreatedDate] [datetime] NOT NULL,
                                	[CreatedBy] [nvarchar](max) NULL,
                                	[UpdatedDate] [datetime] NOT NULL,
                                	[UpdatedBy] [nvarchar](max) NULL,
                                 CONSTRAINT [PK_Feature] PRIMARY KEY CLUSTERED 
                                (
                                	[Identifier] ASC
                                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                                ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
                                
                                GO
                                
                                ALTER TABLE [Feature]  WITH CHECK ADD  CONSTRAINT [FK_Feature_FeatureType] FOREIGN KEY([FeatureTypeId])
                                REFERENCES [FeatureType] ([Identifier])
                                GO
                                
                                ALTER TABLE [Feature] CHECK CONSTRAINT [FK_Feature_FeatureType]
                                GO";

            Execute.Sql(sql);
        }
    }
}
