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
    public class StaffQualificationTable
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
        public List<StaffQualification> ReadStaffQualificationRecordFromTable()
        {
            //Declare list and connection
            List<StaffQualification> lstStaffQualifications = new List<StaffQualification>();
            con = new SqlConnection(connectionString);

            try
            {
                //Construct a query
                string queryString = "Select * from StaffQualification";

                //Execute query
                da = new SqlDataAdapter(queryString, con);

                //Read in the results and fill into table
                da.Fill(ds, "StaffQualification");

                //Instantiate a command builder
                cb = new SqlCommandBuilder(da);

                //Convert the data table to a list format
                lstStaffQualifications = ConvertDataTableToList(ds.Tables["StaffQualification"]);

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

            //Return StaffQualification list
            return lstStaffQualifications;

        }//End ReadStaffQualificationRecordFromTable


        public List<StaffQualification> ConvertDataTableToList(DataTable dataTable)
        {
            //declare a list to store information
            List<StaffQualification> lstStaffQualifications = new List<StaffQualification>();

            try
            {
                //Foreach record in the table
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    //Create a temp StaffQualification to assign info to
                    StaffQualification currentStaffQualification = new StaffQualification();

                    currentStaffQualification.StaffQualificationID = (int)dataRow["StaffQualificationID"];
                    currentStaffQualification.EmployeeID = (int)dataRow["EmployeeID"];
                    currentStaffQualification.QualificationID = (int)dataRow["QualificationID"];
                    currentStaffQualification.IssueDate = (DateTime)dataRow["IssueDate"];
                    currentStaffQualification.ExpiryDate = (DateTime)dataRow["ExpiryDate"];

                    //add to the list
                    lstStaffQualifications.Add(currentStaffQualification);

                }//End foreach

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

            //return StaffQualification list
            return lstStaffQualifications;

        }//End ConvertDataTableToList


        public void AddNewStaffQualification(StaffQualification newStaffQualification)
        {
            try
            {
                //Create a new data row in the dataset
                DataRow row = ds.Tables["StaffQualification"].NewRow();

                //Add the object information to the the row
                row["EmployeeID"] = newStaffQualification.EmployeeID;
                row["QualificationID"] = newStaffQualification.QualificationID;
                row["IssueDate"] = newStaffQualification.IssueDate;
                row["ExpiryDate"] = newStaffQualification.ExpiryDate;

                //Add the row to the data set
                ds.Tables["StaffQualification"].Rows.Add(row);

                //Write the changes to the database
                writeChangesToStaffQualificationToTheDB();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End AddNewStaffQualification


        public void UpdateStaffQualificationDatabase(StaffQualification thisStaffQualification)
        {
            try
            {
                //Write changes to the StaffQualification database
                foreach (DataRow row in ds.Tables["StaffQualification"].Rows)
                {
                    if ((int)row["StaffQualificationID"] == thisStaffQualification.StaffQualificationID)
                    {
                        //Add the object information to the the row
                        row["EmployeeID"] = thisStaffQualification.EmployeeID;
                        row["QualificationID"] = thisStaffQualification.QualificationID;
                        row["IssueDate"] = thisStaffQualification.IssueDate;
                        row["ExpiryDate"] = thisStaffQualification.ExpiryDate;

                        //Write changes to the DB
                        writeChangesToStaffQualificationToTheDB();

                        //Break out
                        break;

                    }//End If

                }//End Foreach
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End UpdateStaffQualificationDatabase


        public void DeleteStaffQualificationRecord(StaffQualification thisStaffQualification)
        {
            try
            {
                //Write changes to the StaffQualification database
                foreach (DataRow row in ds.Tables["StaffQualification"].Rows)
                {
                    if ((int)row["StaffQualificationID"] == thisStaffQualification.StaffQualificationID)
                    {
                        //Delete the row
                        row.Delete();

                        //Write changes to the DB
                        writeChangesToStaffQualificationToTheDB();

                        //Break out
                        break;

                    }//End If

                }//End Foreach
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End DeleteStaffQualificationRecord


        public void writeChangesToStaffQualificationToTheDB()
        {
            try
            {
                //Update the sql table to reflect the changes
                da.Update(ds.Tables["StaffQualification"]);
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End writeChangesToStaffQualificationToTheDB


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
