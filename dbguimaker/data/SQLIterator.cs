using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbguimaker.data
{
    internal static class SQLIterator
    {
        /// <summary>
        /// A simple loop through all elements of a table
        /// </summary>
        /// <param name="create_reader">The method that returns a table (will be called via using)</param>
        /// <param name="iteration">The code that is executed each row</param>
        public static void IterateReader(Func<DbDataReader> create_reader, Action<DbDataReader> iteration)
        {
            using (DbDataReader r = create_reader())
                while (r.Read())
                    iteration(r);
        }
    }
}
