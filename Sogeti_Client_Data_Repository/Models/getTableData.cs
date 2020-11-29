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

            SqlCommand com = new SqlCommand("Get_AllApplicationsByUserID", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@UserID", 1);

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

                                newEntry.App_ID = sqlReader.GetInt32(0);
                                newEntry.App_name = sqlReader.GetString(1);
                                newEntry.Department = sqlReader.GetString(2);
                                string DeptManager = sqlReader.GetString(3) + " " + sqlReader.GetString(4);
                                newEntry.DepartmentManager = DeptManager;
                                newEntry.Client = sqlReader.GetString(5);
                                newEntry.Criticality = sqlReader.GetString(6);
                                newEntry.FutureDevlopment = sqlReader.GetString(7);
                                newEntry.Stability = sqlReader.GetString(8);
                                newEntry.Sensitivity = sqlReader.GetString(9);
                                newEntry.Repository = sqlReader.GetString(10);
                                newEntry.CodeSource = sqlReader.GetString(11);
                                newEntry.ApplicationType = sqlReader.GetString(12);
                                newEntry.Tech = sqlReader.GetString(13);

                                
                                //Append Object too array
                                data.Add(newEntry);

                            }
                        }
                        com = new SqlCommand("Get_ApplicationServers", con);
                        foreach (dataTableEntry entry in data)
                        {
                            com.Parameters.AddWithValue("@ApplicationID", entry.App_ID);
                            using (SqlDataReader sqlReader2 = com.ExecuteReader())
                            {
                                if (sqlReader2.HasRows)
                                {
                                    while (sqlReader2.Read())
                                    {
                                        if (sqlReader2.GetString(0) == "DEV")
                                        {
                                            entry.DevlopmentServer = sqlReader2.GetString(1);
                                        }
                                        else if (sqlReader2.GetString(0) == "PROD")
                                        {
                                            entry.ProductionServer = sqlReader2.GetString(1);
                                        }
                                        else if (sqlReader2.GetString(0) == "QA")
                                        {
                                            entry.QaServer = sqlReader2.GetString(1);
                                        }
                                    }
                                }
                            }  
                        }
                        com = new SqlCommand("Get_ApplicationContacts", con);
                        foreach (dataTableEntry entry in data)
                        {
                            com.Parameters.AddWithValue("@ApplicationID", entry.App_ID);
                            using (SqlDataReader sqlReader3 = com.ExecuteReader())
                            {
                                if (sqlReader3.HasRows)
                                {
                                    while (sqlReader3.Read())
                                    {
                                        if (sqlReader3.GetString(2) == "PrimaryBA")
                                        {
                                            string PrimaryBA = sqlReader3.GetString(0) + " " + sqlReader3.GetString(1);
                                            entry.PrimaryBA = PrimaryBA;
                                        }
                                        else if (sqlReader3.GetString(0) == "Technical")
                                        {
                                            string Technical = sqlReader3.GetString(0) + " " + sqlReader3.GetString(1);
                                            entry.TechContact = Technical;
                                        }
                                    }
                                }
                            }
                        }
                        com = new SqlCommand("Get_ApplicationUrl", con);
                        foreach (dataTableEntry entry in data)
                        {
                            com.Parameters.AddWithValue("@ApplicationID", entry.App_ID);
                            using (SqlDataReader sqlReader4 = com.ExecuteReader())
                            {
                                if (sqlReader4.HasRows)
                                {
                                    while (sqlReader4.Read())
                                    {
                                        if (sqlReader4.GetString(0) == "DEV")
                                        {
                                            entry.DevlopmentURL = sqlReader4.GetString(1);
                                        }
                                        else if (sqlReader4.GetString(0) == "PROD")
                                        {
                                            entry.ProductionURL = sqlReader4.GetString(1);
                                        }
                                        else if (sqlReader4.GetString(0) == "QA")
                                        {
                                            entry.QaURL = sqlReader4.GetString(1);
                                        }
                                    }
                                }
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
            //dataTableEntry newEntry = new dataTableEntry("App Name 1", "Department 1", "Gage Gommels", "Microsoft", "BA 1", "Scott Van", "Web App", "Java Script", "PS 1", "URL 1", "QAS 1", "QA URL 1", "DevS 1", "DevURL 1", "Code Source 1", "Repo 1", "High", "Medium", "low", "low", "1");
            //dataTableEntry newEntry2 = new dataTableEntry("App Name 2", "Department 2", "Eric Kim", "Google", "BA 2", "Ethan C", "Windows App", "C#", "PS 2", "URL 2", "QAS 2", "QA URL 2", "DevS 2", "DevURL 2", "Code Source 2", "Repo 3", "Low", "low", "Medium", "medium", "2");
            //dataTableEntry newEntry3 = new dataTableEntry("App Name 3", "Department 3", "Brian Zan", "FaceBook", "BA 3", "James M", "Web App", "Java Script", "PS 3", "URL 3", "QAS 3", "QA URL 3", "DevS 3", "DevURL 3", "Code Source 3", "Repo 3", "High", "High", "Medium", "High", "3");

            //data.Add(newEntry);
            //data.Add(newEntry2);
            //data.Add(newEntry3);

            //foreach (dataTableEntry entry in data) { Debug.WriteLine(entry.App_ID); }

            return data;
        }

        public dataTableEntry testData(int ID)
        {
            if (ID == 1)
            {
                dataTableEntry newEntry = new dataTableEntry("App Name 1", "Department 1", "Gage Gommels", "Microsoft", "BA 1", "Scott Van", "Web App", "Java Script", "PS 1", "URL 1", "QAS 1", "QA URL 1", "DevS 1", "DevURL 1", "Code Source 1", "Repo 1", "High", "Medium", "low", "low", 1);
                return newEntry;
            }
            else if (ID == 2)
            {
                dataTableEntry newEntry2 = new dataTableEntry("App Name 2", "Department 2", "Eric Kim", "Google", "BA 2", "Ethan C", "Windows App", "C#", "PS 2", "URL 2", "QAS 2", "QA URL 2", "DevS 2", "DevURL 2", "Code Source 2", "Repo 3", "Low", "low", "Medium", "medium", 2);
                return newEntry2;
            }
            else if (ID == 3) {
                dataTableEntry newEntry3 = new dataTableEntry("App Name 3", "Department 3", "Brian Zan", "FaceBook", "BA 3", "James M", "Web App", "Java Script", "PS 3", "URL 3", "QAS 3", "QA URL 3", "DevS 3", "DevURL 3", "Code Source 3", "Repo 3", "High", "High", "Medium", "High", 3);
                return newEntry3;
            }
            dataTableEntry newEntry4 = new dataTableEntry("App Name 1", "Department 1", "Gage Gommels", "Microsoft", "BA 1", "Scott Van", "Web App", "Java Script", "PS 1", "URL 1", "QAS 1", "QA URL 1", "DevS 1", "DevURL 1", "Code Source 1", "Repo 1", "High", "Medium", "low", "low", 1);
            return newEntry4;

        }

        public void editCodeSource(int ID, string codeSource)
        {
            SqlCommand com = new SqlCommand("Update_CodeSource", con);       //Check_Password is the name of the Stored Procedure
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ApplicationID", ID);
            com.Parameters.AddWithValue("@CodeSource_ID", 1);
            com.Parameters.AddWithValue("@CodeSource", codeSource);    //@Username is an Input Parameter to the Proc

            int response = -1;
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
                Debug.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
            if (response == 1)
            {
                Debug.WriteLine("CodeSource Edited");
            }
            else
            {
                Debug.WriteLine("CodeSource Edit Failed");
            }
        }

    }
}
