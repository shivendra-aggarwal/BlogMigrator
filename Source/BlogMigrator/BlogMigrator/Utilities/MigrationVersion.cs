using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMigrator.Utilities
{
    public class MigrationVersion : MigrationAttribute
    {
        public MigrationVersion(long version) : base(version)
        {

        }

        
    }
}
