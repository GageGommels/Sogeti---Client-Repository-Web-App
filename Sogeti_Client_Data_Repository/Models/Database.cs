using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Sogeti_Client_Data_Repository.Models
{
    public class Database
    {

        SqlConnection con;
        public Database()
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

        public bool LoginUser(User user)
        {
            SqlCommand com = new SqlCommand("Get_Password", con);       //Get_Password is the name of the Stored Procedure
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Username", user.Username);    //@Username is an Input Parameter to the Proc
            
            SqlParameter password = new SqlParameter();
            password.ParameterName = "@Password";                       //@Password is an Output Parameter to the Proc
            password.SqlDbType = SqlDbType.VarBinary;
            password.Direction = ParameterDirection.Output;
            password.Size = 128;
            com.Parameters.Add(password);
            
            SqlParameter salt = new SqlParameter();
            salt.ParameterName = "@Salt";                               //@Password is an Output Parameter to the Proc
            salt.SqlDbType = SqlDbType.VarBinary;
            salt.Direction = ParameterDirection.Output;
            salt.Size = 128;
            com.Parameters.Add(salt);
            
            con.Open();
            int ret = com.ExecuteNonQuery();                            //Execute Proc and capture return value
            con.Close();
            
            if (ret == -1)                                              //Proc fails to find username return false
                return false;

            byte[] salted = (byte[])salt.Value;                 
            byte[] hashed = KeyDerivation.Pbkdf2(                       //Hash entered password with SALT from DB
                password: user.Password,
                salt: salted,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 128 / 8);
            return hashed == (byte[])password.Value;                    //If Password matches returned Password from DB return true
        }
    }
}
