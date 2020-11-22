using System;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;

namespace Sogeti_Client_Data_Repository.Models
{
    public class getTableData
    {
        SqlConnection con;
        public getTableData()
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

        public List<dataTableEntry> getDataTableEntries(int clientIDparm) {
            List<dataTableEntry> data = new List<dataTableEntry>();

            SqlCommand com = new SqlCommand("Get_ApplicationsByClient", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ClientID", clientIDparm);

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
                                dataTableEntry newEntry = new dataTableEntry();

                                newEntry.App_ID = sqlReader.GetInt32(0).ToString();
                                newEntry.Criticality = sqlReader.GetInt32(1).ToString();
                                newEntry.FutureDevlopment = sqlReader.GetInt32(2).ToString();
                                newEntry.Stability = sqlReader.GetInt32(3).ToString();
                                newEntry.Sensitivity = sqlReader.GetInt32(4).ToString();
                                newEntry.Department = sqlReader.GetInt32(5).ToString();
                                newEntry.Repository = sqlReader.GetInt32(6).ToString();
                                newEntry.App_name = sqlReader.GetString(7);
                                newEntry.CodeSource = sqlReader.GetInt32(8).ToString();

                                
                                //Append Object too array
                                data.Add(newEntry);

                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {}
            finally
            {
                con.Close();
            }
            foreach (dataTableEntry entry in data)
            {
                Debug.WriteLine(entry.App_name + " || " + entry.App_ID);
            }
            return data;
        }

        public List<dataTableEntry> getDataTableEntriesTest()
        {
            List<dataTableEntry> data = new List<dataTableEntry>();
            dataTableEntry newEntry = new dataTableEntry("App Name 1", "Department 1", "Gage Gommels", "Microsoft", "BA 1", "Scott Van", "Web App", "Java Script","PS 1","URL 1", "QAS 1", "QA URL 1", "DevS 1", "DevURL 1", "Code Source 1", "Repo 1", "High", "Medium", "low","low","1");
            dataTableEntry newEntry2 = new dataTableEntry("App Name 2", "Department 2", "Eric Kim", "Google", "BA 2", "Ethan C", "Windows App", "C#", "PS 2", "URL 2", "QAS 2", "QA URL 2", "DevS 2", "DevURL 2", "Code Source 2", "Repo 3", "Low", "low", "Medium", "medium", "2");
            dataTableEntry newEntry3 = new dataTableEntry("App Name 3", "Department 3", "Brian Zan", "FaceBook", "BA 3", "James M", "Web App", "Java Script", "PS 3", "URL 3", "QAS 3", "QA URL 3", "DevS 3", "DevURL 3", "Code Source 3", "Repo 3", "High", "High", "Medium", "High", "3");

            data.Add(newEntry);
            data.Add(newEntry2);
            data.Add(newEntry3);

            foreach (dataTableEntry entry in data) { Debug.WriteLine(entry.App_ID); }

            return data;
        }


    }
}
