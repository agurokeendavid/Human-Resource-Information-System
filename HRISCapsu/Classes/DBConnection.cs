using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISCapsu.Classes
{
    class DBConnection
    {
        public const string conString = "datasource=localhost;database=hriscapsu;port=3306;username=root";

#pragma warning disable CS0649 // Field 'DBConnection.id' is never assigned to, and will always have its default value null
        public static string id;
#pragma warning restore CS0649 // Field 'DBConnection.id' is never assigned to, and will always have its default value null
    }
}
