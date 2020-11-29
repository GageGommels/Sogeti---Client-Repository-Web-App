using System;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

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

        public List<Client> getClientInfo()
        {
            List<Client> data = new List<Client>();

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
                                Client newClient = new Client();
                                newClient.ClientId = sqlReader.GetInt32(0).ToString();
                                newClient.ClientName = sqlReader.GetString(1);
                                newClient.Description = sqlReader.GetString(2);
                                //Client newClient = new Client(sqlReader.GetInt32(0), sqlReader.GetString(1), sqlReader.GetString(2));


                                data.Add(newClient);
                                //data += "<tr><td scope='col' class='col-3'><a href='ClientApplications/'>" + name + "</a></td><td scope='col' class='col-9'>" + description + "</td></tr>";
                                
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            { }
            finally
            {
                con.Close();
            }
            return data;
        }
    }
}
