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
        bool InsertRecord(string deveui, string payload)
        {
            try
            {


                string connectionstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\paul\\OneDrive\\Documents\\testdb.mdf;Integrated Security=True;Connect Timeout=30";


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

        bool InsertWaterRecord(string eui, float waterlevel) {
            try
            {


                string connectionstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\paul\\OneDrive\\Documents\\testdb.mdf;Integrated Security=True;Connect Timeout=30";


                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("insert into payloadforwater (deveui,waterlevel) values ('");
                    sb.Append(eui);
                    sb.Append("','");
                    sb.Append(waterlevel.ToString());
                    sb.Append("')");
                    String sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
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
        bool InsertSoilMoistureRecord(string eui, float temp,float moisture) {
            try
            {


                string connectionstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\paul\\OneDrive\\Documents\\testdb.mdf;Integrated Security=True;Connect Timeout=30";


                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("insert into payloadfortemp (deveui,temp,soil) values ('");
                    sb.Append(eui);
                    sb.Append("','");
                    sb.Append(temp.ToString());
                    sb.Append("','");
                    sb.Append(moisture.ToString());
                    sb.Append("')");
                    String sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
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


        bool InsertFosterRecord(string eui, float temp, float humid, float pressure)
        {
            try
            {


                string connectionstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\paul\\OneDrive\\Documents\\testdb.mdf;Integrated Security=True;Connect Timeout=30";


                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("insert into payloadforfoster (deveui,temp,mositure,humid) values ('");
                    sb.Append(eui);
                    sb.Append("','");
                    sb.Append(temp.ToString());
                    sb.Append("','");
                    sb.Append(humid.ToString());
                    sb.Append("','");
                    sb.Append(pressure.ToString());
                    sb.Append("')");
                    String sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
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