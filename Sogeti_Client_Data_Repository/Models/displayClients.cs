using System;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Diagnostics;

namespace Sogeti_Client_Data_Repository.Models
{
    /// <summary>
    /// This class provides the back-end functionality for the ClientInfo view.
    /// </summary>
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

        /// <summary>
        /// This method is called by the loadData function in the ClientInfo view.
        /// It calls the get_ClientInfo stored procedure from the database, which
        /// returns the clientID, clientName, and description of all clients. This
        /// method converts what is returned from the stored procedure into a list 
        /// of Client objects, which is subsequently returned by the method. 
        /// </summary>
        /// <returns> List<Client> </returns>
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

                                data.Add(newClient); 
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

        /// <summary>
        /// This method is called by the getIdForClientApp method in the home controller class
        /// to get information about a specified client based on the client id. The method calls
        /// the get_ClientInfoFromID stored procedure, which returns the client name and description
        /// of a client based on the client id. The method then creates and returns the client object.
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Client object </returns>
        public Client getAppClient(string id)
        {
            Client newClient = new Client();
            SqlCommand com = new SqlCommand("Get_ClientInfoFromID", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ClientID", Int32.Parse(id));
            try
            {
                using (con)
                {
                    con.Open();
                    using (SqlDataReader sqlReader = com.ExecuteReader())
                    {
                        while (sqlReader.Read())
                        {
                            newClient.ClientId = id;
                            newClient.ClientName = sqlReader.GetString(0);
                            newClient.Description = sqlReader.GetString(1);
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
            return newClient;
        }

        /// <summary>
        /// This method inserts a new client into the database. It takes a client
        /// name and description as parameters, and calls the Insert_Client stored
        /// procedure.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public void saveClient(string name, string description)
        {
            SqlCommand com = new SqlCommand("Insert_Client", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", name);
            com.Parameters.AddWithValue("@Description", description);
            com.Parameters.AddWithValue("@Client_ID", 1);

            int response = -1;
            try
            {
                using(con)
                {
                    con.Open();
                    response = com.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
            if (response == 1)
            {
                Debug.WriteLine("client added");
            }
            else
            {
                Debug.WriteLine("client add failed");
            }
        }
    }
}
