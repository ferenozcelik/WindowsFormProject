using System;
using System.Collections.Generic;
using System.Text;

namespace LoginApp.Constants
{
    public class ConnectionStrings
    {
        public static string conStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = TestDB; Integrated Security = True";

        public static string conStrMars = @"Data Source=.\SQLEXPRESS;Initial Catalog=TestDB;Integrated Security=True; MultipleActiveResultSets=true";
    }
}
