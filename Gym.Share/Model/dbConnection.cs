using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Share.Model
{
    public class dbConnection
    {
        public string sqlConnection { get; set; }

        public dbConnection()
        {
            sqlConnection = "Data Source=68.168.208.58; "+
                "Initial Catalog=Progra5; Persist Security Info=True;"+
                "TrustServerCertificate=True; User ID=PrograV;"
                +" Password=Vm#6p99r0";
        }
    }
}
