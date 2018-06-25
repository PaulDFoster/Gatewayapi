using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Data.SqlClient;
using System.Text;

namespace GatewayAPI.Controllers
{
    public partial class ValuesController : ApiController
    {
        bool InsertRecord(string payload, string deveui)
        {
            try
            {


                string connectionstring = "<your SQL connection string here>";


                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("insert into payload (deveui,payload) values ('");
                    sb.Append(deveui);
                    sb.Append("','");
                    sb.Append(payload);
                    sb.Append("')");
                    String sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            return true;
        }
    }
}