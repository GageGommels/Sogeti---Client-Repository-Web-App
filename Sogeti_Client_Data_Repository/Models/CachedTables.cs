using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Sogeti_Client_Data_Repository.Models
{
    public class CachedTables
    {
        public static Dictionary<int, string> DevelopmentRating = new Dictionary<int, string>();
        public static Dictionary<int, string> Repository = new Dictionary<int, string>();
        public static Dictionary<int, string> Stability = new Dictionary<int, string>();
        public static Dictionary<int, string> Criticality = new Dictionary<int, string>();
        public static Dictionary<int, string> ContactType = new Dictionary<int, string>();
        public static Dictionary<int, string> Environment = new Dictionary<int, string>();
        public static Dictionary<int, string> Permission = new Dictionary<int, string>();
        public static Dictionary<int, string> CodeSource = new Dictionary<int, string>();
        SqlConnection con;

        private CachedTables()
        {
            var config = GetConfiguration();
            con = new SqlConnection(config.GetSection("Data").GetSection("ConnectionString").Value);
            GetCachedTables();
        }

        public static CachedTables Instance { get; } = new CachedTables();

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .AddUserSecrets<Startup>()
                .AddEnvironmentVariables();
            return builder.Build();
        }

        public void GetCachedTables()
        {
            SqlCommand com = new SqlCommand("Get_CachedTables", con);       //Check_Password is the name of the Stored Procedure
            com.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter();
            DataSet dataSet = new DataSet();
            da = new SqlDataAdapter(com);
            try
            {
                using (con)
                {
                    con.Open();
                    da.Fill(dataSet);
                }
            }
            catch (Exception e)
            {
                return;
            }
            finally
            {
                con.Close();
            }

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                DevelopmentRating.Add(Convert.ToInt32(row[0]), row[1].ToString());
            }
            foreach (DataRow row in dataSet.Tables[1].Rows)
            {
                Repository.Add(Convert.ToInt32(row[0]), row[1].ToString());
            }
            foreach (DataRow row in dataSet.Tables[2].Rows)
            {
                Stability.Add(Convert.ToInt32(row[0]), row[1].ToString());
            }
            foreach (DataRow row in dataSet.Tables[3].Rows)
            {
                Criticality.Add(Convert.ToInt32(row[0]), row[1].ToString());
            }
            foreach (DataRow row in dataSet.Tables[4].Rows)
            {
                ContactType.Add(Convert.ToInt32(row[0]), row[1].ToString());
            }
            foreach (DataRow row in dataSet.Tables[5].Rows)
            {
                Environment.Add(Convert.ToInt32(row[0]), row[1].ToString());
            }
            foreach (DataRow row in dataSet.Tables[6].Rows)
            {
                Permission.Add(Convert.ToInt32(row[0]), row[1].ToString());
            }
            foreach (DataRow row in dataSet.Tables[7].Rows)
            {
                CodeSource.Add(Convert.ToInt32(row[0]), row[1].ToString());
            }

            return;
        }
    }
}
