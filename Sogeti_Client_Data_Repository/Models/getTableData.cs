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
                            try
                            {
                                while (sqlReader.Read())
                                {
                                    dataTableEntry newEntry = new dataTableEntry();

                                    newEntry.App_ID = (int)sqlReader["ApplicationID"];
                                    newEntry.App_name = (string)sqlReader["ApplicationName"];
                                    newEntry.Department = (string)sqlReader["DepartmentName"];
                                    string DeptManager = (string)sqlReader["DepartmentManagerFirstName"] + " " + (string)sqlReader["DepartmentManagerLastName"];
                                    newEntry.DepartmentManager = DeptManager;
                                    newEntry.Client = (string)sqlReader["ClientName"];
                                    newEntry.Criticality = (string)sqlReader["Criticality"];
                                    newEntry.FutureDevlopment = (string)sqlReader["Development"];
                                    newEntry.Stability = (string)sqlReader["Stability"];
                                    newEntry.Sensitivity = (string)sqlReader["Sensitivity"];
                                    newEntry.Repository = (string)sqlReader["Repository"];
                                    newEntry.CodeSource = (string)sqlReader["CodeSource"];
                                    newEntry.ApplicationType = (string)sqlReader["ApplicationType"];
                                    newEntry.Tech = (string)sqlReader["ApplicationTech"];


                                    //Append Object too array
                                    data.Add(newEntry);

                                }
                            }
                            catch (Exception e)
                            {
                                Debug.WriteLine(e.Message);
                            }
                        }
                    }

                    foreach (dataTableEntry entry in data)
                    {
                        try
                        {
                            SqlCommand com2 = new SqlCommand("Get_ApplicationServers", con);
                            com2.CommandType = CommandType.StoredProcedure;
                            com2.Parameters.AddWithValue("@ApplicationID", entry.App_ID);
                            using (SqlDataReader sqlReader2 = com2.ExecuteReader())
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
                        catch (Exception e)
                        {
                            Debug.WriteLine(e.Message);
                        }
                    }

                    foreach (dataTableEntry entry in data)
                    {
                        try
                        {
                            SqlCommand com3 = new SqlCommand("Get_ApplicationContacts", con);
                            com3.CommandType = CommandType.StoredProcedure;
                            com3.Parameters.AddWithValue("@ApplicationID", entry.App_ID);
                            using (SqlDataReader sqlReader3 = com3.ExecuteReader())
                            {
                                if (sqlReader3.HasRows)
                                {
                                    while (sqlReader3.Read())
                                    {
                                        if ((string) sqlReader3["Description"] == "Primary BA")
                                        {
                                            string PrimaryBA = sqlReader3.GetString(0) + " " + sqlReader3.GetString(1);
                                            entry.PrimaryBA = PrimaryBA;
                                        }
                                        else if ((string) sqlReader3["Description"] == "Technical")
                                        {

                                            string Technical = sqlReader3.GetString(0) + " " + sqlReader3.GetString(1);
                                            entry.TechContact = Technical;
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine(e.Message);
                        }
                    }

                    foreach (dataTableEntry entry in data)
                    {
                        try
                        {
                            SqlCommand com4 = new SqlCommand("Get_ApplicationUrl", con);
                            com4.CommandType = CommandType.StoredProcedure;
                            com4.Parameters.AddWithValue("@ApplicationID", entry.App_ID);
                            using (SqlDataReader sqlReader4 = com4.ExecuteReader())
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
                        catch (Exception e)
                        {
                            Debug.WriteLine(e.Message);
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
                Debug.WriteLine(entry.App_name + " || " + entry.App_ID + " || " + entry.PrimaryBA + " || " + entry.TechContact);
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
        public void editDept(int ID, string dept, string first, string last)
        {
            SqlCommand com = new SqlCommand("Update_Department", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ApplicationID", ID);
            com.Parameters.AddWithValue("@DeparmentName", dept);
            com.Parameters.AddWithValue("@ContactFirst", first);
            com.Parameters.AddWithValue("@ContactLast", last);

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
                Debug.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }


        public void editBA(int ID, string first, string last)
        {
            SqlCommand com = new SqlCommand("Update_BA", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ApplicationID", ID);
            com.Parameters.AddWithValue("@FirstName", first);
            com.Parameters.AddWithValue("@LastName", last);

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
                Debug.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void editContact(int ID, string first, string last)
        {
            SqlCommand com = new SqlCommand("Update_TechnicalContact", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ApplicationID", ID);
            com.Parameters.AddWithValue("@FirstName", first);
            com.Parameters.AddWithValue("@LastName", last);

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
                Debug.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void editAppType(int ID, string app)
        {
            SqlCommand com = new SqlCommand("Update_Type", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ApplicationID", ID);
            com.Parameters.AddWithValue("@Types", app); 

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
                Debug.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void editTech(int ID, string tech)
        {
            SqlCommand com = new SqlCommand("Update_Technology", con);     
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ApplicationID", ID);
            com.Parameters.AddWithValue("@Technologies", tech);   

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
                Debug.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void editURL(int ID, string prod, string qa, string dev)
        {
            SqlCommand com = new SqlCommand("Update_URL", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Application_ID", ID);
            com.Parameters.AddWithValue("@PROD_URL", prod);
            com.Parameters.AddWithValue("@DEV_URL", qa);
            com.Parameters.AddWithValue("@QA_URL", dev);

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
                Debug.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void editProdServer(int ID, string prod)
        {
            SqlCommand com = new SqlCommand("Update_ProdServers", con);       
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ApplicationID", ID);
            com.Parameters.AddWithValue("@ProdServers", prod);    

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
                Debug.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void editQAServer(int ID, string qa)
        {
            SqlCommand com = new SqlCommand("Update_QAServers", con);       
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ApplicationID", ID);
            com.Parameters.AddWithValue("@QAServers", qa);    

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
                Debug.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void editDevServer(int ID, string dev)
        {
            SqlCommand com = new SqlCommand("Update_DevServers", con); 
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ApplicationID", ID);
            com.Parameters.AddWithValue("@DevServers", dev);

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
                Debug.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void editSource(int ID, string source)
        {
            SqlCommand com = new SqlCommand("Update_CodeSource", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ApplicationID", ID);
            com.Parameters.AddWithValue("@CodeSource_ID", 1);
            com.Parameters.AddWithValue("@CodeSource", source);

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
                Debug.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void editRepo(int ID, string repo)
        {
            SqlCommand com = new SqlCommand("Update_Repository", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ApplicationID", ID);
            com.Parameters.AddWithValue("@Repository_ID", 1);
            com.Parameters.AddWithValue("@Repository", repo);

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
                Debug.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void editApplication(int ID, int crit, int future, int stable, int sensitive)
        {
            SqlCommand com = new SqlCommand("Update_Application", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ApplicationID", ID);
            com.Parameters.AddWithValue("@Criticality_ID", crit);
            com.Parameters.AddWithValue("@DevelopmentRating_ID", future);
            com.Parameters.AddWithValue("@Stability_ID", stable);
            com.Parameters.AddWithValue("@Sensitivity_ID", sensitive);

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
                Debug.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
