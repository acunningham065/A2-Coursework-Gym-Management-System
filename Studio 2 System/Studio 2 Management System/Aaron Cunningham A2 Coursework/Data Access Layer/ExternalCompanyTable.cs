using Studio_2_Management_System.Business_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Studio_2_Management_System.Data_Access_Layer
{
    class ExternalCompanyTable
    {
        //-------------------------- Fields --------------------------\\

        //Define the database connections
        //string connectionString = "user id=0002010-VDI-041\\DevUser;" + "password=''; server=LOCALHOST;" + "Trusted_Connection=yes;" + "database=STUDIO2;" + "connection timeout=30;";
        string connectionString = "user id=SLY-BACON\\Aaron;" + "password=''; server=SLY-BACON\\SQLEXPRESS;" + "Trusted_Connection=yes;" + "database=STUDIO2;" + "connection timeout=30;";

        //Declare a data set for storage
        DataSet ds = new DataSet();

        //Declare a data adapter
        SqlDataAdapter da = new SqlDataAdapter();

        //Declare a command builder
        SqlCommandBuilder cb = new SqlCommandBuilder();

        //Declare a SQL connection
        SqlConnection con = new SqlConnection();


        //-------------------------- Methods --------------------------\\
        public List<ExternalCompany> ReadExternalCompanyRecordFromTable()
        {
            //Declare list and connection
            List<ExternalCompany> lstExternalCompanies = new List<ExternalCompany>();
            con = new SqlConnection(connectionString);

            try
            {
                //Construct a query
                string queryString = "Select * from ExternalCompany";

                //Execute query
                da = new SqlDataAdapter(queryString, con);

                //Read in the results and fill into table
                da.Fill(ds, "ExternalCompany");

                //Instantiate a command builder
                cb = new SqlCommandBuilder(da);

                //Convert the data table to a list format
                lstExternalCompanies = ConvertDataTableToList(ds.Tables["ExternalCompany"]);

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

            //Return ExternalCompany list
            return lstExternalCompanies;

        }//End ReadExternalCompanyRecordFromTable


        public List<ExternalCompany> ConvertDataTableToList(DataTable dataTable)
        {
            //declare a list to store information
            List<ExternalCompany> lstExternalCompanies = new List<ExternalCompany>();

            try
            {
                //Foreach record in the table
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    //Create a temp ExternalCompany to assign info to
                    ExternalCompany currentExternalCompany = new ExternalCompany();

                    currentExternalCompany.ExternalCompanyID = (int)dataRow["ExternalCompanyID"];
                    currentExternalCompany.CompanyName = dataRow["CompanyName"].ToString();
                    currentExternalCompany.CompanyAddress = dataRow["CompanyAddress"].ToString();
                    currentExternalCompany.CompanyTown = dataRow["CompanyTown"].ToString();
                    currentExternalCompany.CompanyPostCode = dataRow["CompanyPostCode"].ToString();
                    currentExternalCompany.CompanyPractice = dataRow["CompanyPractice"].ToString();
                    currentExternalCompany.ContactName = dataRow["ContactName"].ToString();
                    currentExternalCompany.ContactTelNo = dataRow["ContactTelNo"].ToString();
                    currentExternalCompany.ContactEmail = dataRow["ContactEmail"].ToString();

                    //add to the list
                    lstExternalCompanies.Add(currentExternalCompany);

                }//End foreach

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

            //return ExternalCompany list
            return lstExternalCompanies;

        }//End ConvertDataTableToList


        public void AddNewExternalCompany(ExternalCompany newExternalCompany)
        {

            try
            {
                //Create a new data row in the dataset
                DataRow row = ds.Tables["ExternalCompany"].NewRow();

                //Add the object information to the the row
                row["CompanyName"] = newExternalCompany.CompanyName;
                row["CompanyAddress"] = newExternalCompany.CompanyAddress;
                row["CompanyTown"] = newExternalCompany.CompanyTown;
                row["CompanyPostCode"] = newExternalCompany.CompanyPostCode;
                row["CompanyPractice"] = newExternalCompany.CompanyPractice;
                row["ContactName"] = newExternalCompany.ContactName;
                row["ContactTelNo"] = newExternalCompany.ContactTelNo;
                row["ContactEmail"] = newExternalCompany.ContactEmail;

                //Add the row to the data set
                ds.Tables["ExternalCompany"].Rows.Add(row);

                //Write the changes to the database
                writeChangesToExternalCompanyToTheDB();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End AddNewExternalCompany


        public void UpdateExternalCompanyDatabase(ExternalCompany thisExternalCompany)
        {
            try
            {
                //Write changes to the ExternalCompany database
                foreach (DataRow row in ds.Tables["ExternalCompany"].Rows)
                {
                    if ((int)row["ExternalCompanyID"] == thisExternalCompany.ExternalCompanyID)
                    {
                        //Add the object information to the the row
                        row["CompanyName"] = thisExternalCompany.CompanyName;
                        row["CompanyAddress"] = thisExternalCompany.CompanyAddress;
                        row["CompanyTown"] = thisExternalCompany.CompanyTown;
                        row["CompanyPostCode"] = thisExternalCompany.CompanyPostCode;
                        row["CompanyPractice"] = thisExternalCompany.CompanyPractice;
                        row["ContactName"] = thisExternalCompany.ContactName;
                        row["ContactTelNo"] = thisExternalCompany.ContactTelNo;
                        row["ContactEmail"] = thisExternalCompany.ContactEmail;

                        //Write changes to the DB
                        writeChangesToExternalCompanyToTheDB();

                        //Break out
                        break;

                    }//End If

                }//End Foreach
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End UpdateExternalCompanyDatabase


        public void DeleteExternalCompanyRecord(ExternalCompany thisExternalCompany)
        {
            try
            {
                //Write changes to the ExternalCompany database
                foreach (DataRow row in ds.Tables["ExternalCompany"].Rows)
                {
                    if ((int)row["ExternalCompanyID"] == thisExternalCompany.ExternalCompanyID)
                    {
                        //Delete the row
                        row.Delete();

                        //Write changes to the DB
                        writeChangesToExternalCompanyToTheDB();

                        //Break out
                        break;

                    }//End If

                }//End Foreach
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End DeleteExternalCompanyRecord


        public void writeChangesToExternalCompanyToTheDB()
        {
            try
            {
                //Update the sql table to reflect the changes
                da.Update(ds.Tables["ExternalCompany"]);
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End writeChangesToExternalCompanyToTheDB


        public static void printErrorMessage(Exception ex)
        {
            try
            {
                //Print Error Message
                MessageBox.Show("\nError Found: " + ex.Message + "\n\nError occured in " + ex.StackTrace.ToString(), "An Error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex2)
            {
                printErrorMessage(ex2);
            }

        }//End printErrorMessage





    }
}
