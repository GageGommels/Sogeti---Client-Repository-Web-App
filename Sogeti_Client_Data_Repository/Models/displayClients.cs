using System;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Diagnostics;

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

            /*
            try
            {
                using (con)
                {
                    con.Open();
                    using (SqlDataReader sqlReader = com.ExecuteReader())
                    {
                        while (sqlReader.Read())
                        {
                            var id = sqlReader.GetString(0);
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
            */
        }
    }
}
