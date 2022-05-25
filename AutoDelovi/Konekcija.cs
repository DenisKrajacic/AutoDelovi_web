using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace AutoDelovi
{
    public class Konekcija
    {
        static public SqlConnection Connect()
        {
            string cs = ConfigurationManager.ConnectionStrings["home"].ConnectionString;
            SqlConnection veza = new SqlConnection(cs);
            return veza;
        }
    }
}