using System;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace Sogeti_Client_Data_Repository.Models
{
    public class UserLogin
    {

        SqlConnection con;
        string user; 
        public UserLogin()
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

        public string LoginUser(Login login)
        {
            user = login.Username;
            byte[] pass = Encoding.ASCII.GetBytes(login.Password);
            var sha1 = new SHA1CryptoServiceProvider();
            var hashedPass = sha1.ComputeHash(pass);
            SqlCommand com = new SqlCommand("Check_Password", con);       //Check_Password is the name of the Stored Procedure
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Username", login.Username);    //@Username is an Input Parameter to the Proc
            com.Parameters.AddWithValue("@Password", hashedPass);

            SqlParameter LoginResponse = new SqlParameter();
            LoginResponse.ParameterName = "@ResponseMessage";                       //@Password is an Output Parameter to the Proc
            LoginResponse.SqlDbType = SqlDbType.VarChar;
            LoginResponse.Direction = ParameterDirection.Output;
            LoginResponse.Size = 250;
            com.Parameters.Add(LoginResponse);
            
            try
            {
                using (con)
                {
                    con.Open();
                    com.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                return "Login Failed";
            }
            finally
            {
                con.Close();
            }

            return Convert.ToString(LoginResponse.Value);
        }

        public string AddUser(Login login)
        {
            byte[] pass = Encoding.ASCII.GetBytes(login.Password);
            var sha1 = new SHA1CryptoServiceProvider();
            var hashedPass = sha1.ComputeHash(pass);
            SqlCommand com = new SqlCommand("Insert_User", con);       //Check_Password is the name of the Stored Procedure
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@User_Name", login.Username);    //@Username is an Input Parameter to the Proc
            com.Parameters.AddWithValue("@Password", hashedPass);
            com.Parameters.AddWithValue("@First_Name", "Wayne");    
            com.Parameters.AddWithValue("@Last_Name", "Gacey");
            com.Parameters.AddWithValue("@Email", "wgacey@gmail.com");   

            int response;
            try
            {
                using (con)
                {
                    con.Open();
                    response = com.ExecuteNonQuery();
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
            if (response == 1)
            {
                return "USER ADDED";
            }
            else
            {
                return "USER FAILED TO ADD";
            }
        }

        public string ChangePassword(ChangePassword change, string user)
        {
            if (change.NewPassword != change.NewPasswordRepeated)
                return "Passwords do not match";

            byte[] pass = Encoding.ASCII.GetBytes(change.Password);
            byte[] newpass = Encoding.ASCII.GetBytes(change.NewPassword);
            var sha1 = new SHA1CryptoServiceProvider();
            var hashedPass = sha1.ComputeHash(pass);
            var hashedNewPass = sha1.ComputeHash(newpass);
            SqlCommand com = new SqlCommand("Change_Password", con);       //Check_Password is the name of the Stored Procedure
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Username", user);    //@Username is an Input Parameter to the Proc
            com.Parameters.AddWithValue("@Password", hashedPass);
            com.Parameters.AddWithValue("@NewPassword", hashedNewPass);

            SqlParameter LoginResponse = new SqlParameter();
            LoginResponse.ParameterName = "@ResponseMessage";                       //@Password is an Output Parameter to the Proc
            LoginResponse.SqlDbType = SqlDbType.VarChar;
            LoginResponse.Direction = ParameterDirection.Output;
            LoginResponse.Size = 250;
            com.Parameters.Add(LoginResponse);

            try
            {
                using (con)
                {
                    con.Open();
                    com.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
            finally
            {
                con.Close();
            }
            
            return Convert.ToString(LoginResponse.Value);
        }
    }
}
