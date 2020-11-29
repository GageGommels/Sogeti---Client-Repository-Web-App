using System;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace Sogeti_Client_Data_Repository.Models
{
    public class displayClientApplications
    {
        SqlConnection con;
        public displayClientApplications()
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

        public List<ClientApplication> getClientApplications(string clientID)
        {
            List<ClientApplication> data = new List<ClientApplication>();
            SqlCommand com = new SqlCommand("get_ApplicationAndProdURL", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ClientID", Int32.Parse(clientID));
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
                                ClientApplication newClientApp = new ClientApplication();
                                newClientApp.ApplicationName = sqlReader.GetString(0);
                                newClientApp.ProductionURL = sqlReader.GetString(1);

                                data.Add(newClientApp);

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

        public Client getClientForApplications(string clientID)
        {
            Client clientForApps = new Client();
            SqlCommand com = new SqlCommand("get_ClientInfoFromID", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ClientID", Int32.Parse(clientID));

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
                                clientForApps.ClientName = sqlReader.GetString(0);
                                clientForApps.Description = sqlReader.GetString(1);
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
            return clientForApps;
        }
    }
}
