using System;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace Sogeti_Client_Data_Repository.Models
{
    public class Client
    {
        public string ClientName { get; set; }
        public string Description { get; set; }

        SqlConnection con;
        public Client()
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

        public string GetClientInfo(Client client)
        {
            SqlCommand com = new SqlCommand("get_ClientInfo", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", client.ClientName);
            com.Parameters.AddWithValue("@Description", client.Description);

            int response;
            try
            {
                using (con)
                {
                    con.Open();
                    response = com.;
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

            return ;
        }
    }
}
