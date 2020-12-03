using System;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace Sogeti_Client_Data_Repository.Models
{
    /// <summary>
    /// This class provides the back-end functionality for the ClientApplications view.
    /// </summary>
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

        /// <summary>
        /// This method is called by the loadData function in the ClientApplications view.
        /// It calls the get_ApplicationAndProdURL stored procedure from the database, which
        /// returns the application name and production url of all applications associated
        /// with a specific client. This method converts what is returned from the stored
        /// procedure into a list of ClientApplication objects, which is subsequently
        /// returned by the method.
        /// </summary>
        /// <param name="clientID"></param>
        /// <returns> List<ClientApplication> </returns>
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
    }
}
