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

        /// <summary>
        /// Sets up the connection string for the SQL client
        /// </summary>
        /// <returns> IConfigurationRoot </returns>
        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .AddUserSecrets<Startup>()
                .AddEnvironmentVariables();
            return builder.Build();
        }
        /// <summary>
        /// This class is used for making calls to the database to edit and or add an application. The application object is large, and we wanted to have a dedicated class for making these calls.
        /// </summary>
        /// <param name="clientIDparm"></param>
        /// <returns> List<dataTableEntry> data </returns>
        public List<dataTableEntry> getDataTableEntries(int clientIDparm) {
            //Create a Array List to store the data
            List<dataTableEntry> data = new List<dataTableEntry>();
            //make a new SQL Connection
            SqlCommand com = new SqlCommand("Get_AllApplicationsByUserID", con);
            //Set Command Type to stored procedures
            com.CommandType = CommandType.StoredProcedure;
            //Add the User ID as a parameter
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
                                    //Make new DateTable Entry Object
                                    dataTableEntry newEntry = new dataTableEntry();

                                    //Read in the response to the object
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

                    //Make Get_ApplicationServerData call to the server to fill in the object
                    foreach (dataTableEntry entry in data)
                    {
                        try
                        {
                            //Set up the Stored Procedure connection
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

                    //Make the Get_ApplicationContacts call to the server
                    foreach (dataTableEntry entry in data)
                    {
                        try
                        {
                            //Setup the Stored Procedure call to the database.
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

                    //Make the Get_ApplicationUrl to the database
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
            //return the array list
            return data;
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
