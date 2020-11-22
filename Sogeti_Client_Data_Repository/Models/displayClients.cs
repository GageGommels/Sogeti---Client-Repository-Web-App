using System;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Sogeti_Client_Data_Repository.Models
{
    public class displayClients
    {
        SqlConnection con;
        public displayClients()
        {
            var config = GetConfiguration();
            con = new SqlConnection(config.GetSection("Data").GetSection("ConnectionString").Value);
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .AddUserSecrets<Startup>()
                .AddEnvironmentVariables();
            return builder.Build();
        }

        public string getClientInfo()
        {
            string data = "";

            SqlCommand com = new SqlCommand("get_ClientInfo", con);
            com.CommandType = CommandType.StoredProcedure;
            try
            {
                using (con)
                {
                    con.Open();
                    using (SqlDataReader sqlReader = com.ExecuteReader())
                    {
                        if (sqlReader.HasRows)
                        {
                            while (sqlReader.Read())
                            {
                                int clientID = sqlReader.GetInt32(0);
                                string name = sqlReader.GetString(1);
                                string description = sqlReader.GetString(2);

                                data += "<tr><td scope='col' class='col-3'><a href='ClientApplications/'>" + name + "</a></td><td scope='col' class='col-9'>" + description + "</td></tr>";
                                
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                con.Close();
            }
            return data;
        }

        public string getClientSearchInfo(Client client)
        {
            string data = "";

            SqlCommand com = new SqlCommand("get_ClientSearchInfo", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", client.ClientName);
            com.Parameters.AddWithValue("@Description", client.Description);

            try
            {
                using (con)
                {
                    con.Open();
                    using (SqlDataReader sqlReader = com.ExecuteReader())
                    {
                        if (sqlReader.HasRows)
                        {
                            while (sqlReader.Read())
                            {
                                int clientID = sqlReader.GetInt32(0);
                                string name = sqlReader.GetString(1);
                                string description = sqlReader.GetString(2);

                                data += "<tr><td scope='col' class='col-3'><a href='ClientApplications/'>" + name + "</a></td><td scope='col' class='col-9'>" + description + "</td></tr>";
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                con.Close();
            }
            return data;
        }
    }
}
