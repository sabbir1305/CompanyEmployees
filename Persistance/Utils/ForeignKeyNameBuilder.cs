using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Utils
{
    internal static class ForeignKeyNameBuilder
    {
        /// <summary>
        /// Builds a foreign key name for the specified primary and foreign key tables and columns..
        /// </summary>
        /// <param name="primaryKeyTable">The primary key table.</param>
        /// <param name="foreignKeyTable">The foreign key table.</param>
        /// <param name="columns">The key columns.</param>
        /// <returns>
        /// A foreign key name.
        /// </returns>
        public static string Build(string primaryKeyTable, string foreignKeyTable, params string[] columns)
        {
            return $"FK_{primaryKeyTable}_{foreignKeyTable}_{string.Join("_", columns)}";
        }
    }

}
