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
        public List<dataTableEntry> getDataTableEntries() {
            List<dataTableEntry> data = new List<dataTableEntry>();

            SqlCommand com = new SqlCommand("Get_ApplicationsByClient", con);
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
                                dataTableEntry newEntry = new dataTableEntry();

                                newEntry.App_ID = sqlReader.GetString(0);
                                newEntry.Criticality = sqlReader.GetString(1);
                                newEntry.FutureDevlopment = sqlReader.GetString(2);
                                newEntry.Stability = sqlReader.GetString(3);
                                newEntry.Sensitivity = sqlReader.GetString(4);
                                newEntry.Department = sqlReader.GetString(5);
                                newEntry.Repository = sqlReader.GetString(6);
                                newEntry.App_name = sqlReader.GetString(7);
                                newEntry.CodeSource = sqlReader.GetString(8);

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
            return data;
        } 


    }
}
