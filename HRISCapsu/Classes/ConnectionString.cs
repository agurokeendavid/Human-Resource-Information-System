using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISCapsu.Classes
{
    public static class ConnectionString
    {
        public static string GetConnectionString(string connectionName = "HRISConnection")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }
    }
}
