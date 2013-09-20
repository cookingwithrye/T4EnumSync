using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace T4EnumSync
{
    class Program
    {
        static void Main(string[] args)
        {
            //our business logic will be a validator to ensure that white motorcycles aren't present in the database. They're kind of lame so we don't want them.
            
            //but wait, what if a new color is added and we want special logic for it? Do we update both the enum?

            //we can also have logic to verify at runtime that the enums have corresponding table values in the server as a sanity check
        }
    }
}
