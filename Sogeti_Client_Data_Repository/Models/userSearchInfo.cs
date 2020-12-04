using System;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Diagnostics;
namespace Sogeti_Client_Data_Repository.Models
{
    public class userSearchInfo
    {
        SqlConnection con;
        public userSearchInfo()
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

        public List<userSearch> getUserInfo()
        {
            List<userSearch> data = new List<userSearch>();

            SqlCommand com = new SqlCommand("Get_UserInfo", con);
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
                                userSearch newUser = new userSearch();

                                
                                newUser.UserID = sqlReader.GetInt32(0).ToString();

                                
                                newUser.UserName = sqlReader.GetString(1);

                                
                                newUser.UserFirstName = sqlReader.GetString(2);

                                
                                newUser.UserLastName = sqlReader.GetString(3);


                                data.Add(newUser);
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
