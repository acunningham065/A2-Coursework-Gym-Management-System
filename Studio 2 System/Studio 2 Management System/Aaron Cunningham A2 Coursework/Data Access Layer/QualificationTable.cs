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
    public class QualificationTable
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
        public List<Qualification> ReadQualificationRecordFromTable()
        {
            //Declare list and connection
            List<Qualification> lstQualifications = new List<Qualification>();
            con = new SqlConnection(connectionString);

            try
            {
                //Construct a query
                string queryString = "Select * from Qualification";

                //Execute query
                da = new SqlDataAdapter(queryString, con);

                //Read in the results and fill into table
                da.Fill(ds, "Qualification");

                //Instantiate a command builder
                cb = new SqlCommandBuilder(da);

                //Convert the data table to a list format
                lstQualifications = ConvertDataTableToList(ds.Tables["Qualification"]);

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

            //Return Qualification list
            return lstQualifications;

        }//End ReadQualificationRecordFromTable


        public List<Qualification> ConvertDataTableToList(DataTable dataTable)
        {
            //declare a list to store information
            List<Qualification> lstQualifications = new List<Qualification>();

            try
            {
                //Foreach record in the table
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    //Create a temp Qualification to assign info to
                    Qualification currentQualification = new Qualification();

                    currentQualification.QualificationID = (int)dataRow["QualificationID"];
                    currentQualification.Description = dataRow["Description"].ToString();
                    
                    //add to the list
                    lstQualifications.Add(currentQualification);

                }//End foreach

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

            //return Qualification list
            return lstQualifications;

        }//End ConvertDataTableToList


        public void AddNewQualification(Qualification newQualification)
        {

            try
            {
                //Create a new data row in the dataset
                DataRow row = ds.Tables["Qualification"].NewRow();

                //Add the object information to the the row
                row["Description"] = newQualification.Description;
                
                //Add the row to the data set
                ds.Tables["Qualification"].Rows.Add(row);

                //Write the changes to the database
                writeChangesToQualificationToTheDB();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End AddNewQualification


        public void UpdateQualificationDatabase(Qualification thisQualification)
        {
            try
            {
                //Write changes to the Qualification database
                foreach (DataRow row in ds.Tables["Qualification"].Rows)
                {
                    if ((int)row["QualificationID"] == thisQualification.QualificationID)
                    {
                        //Add the object information to the the row
                        row["Description"] = thisQualification.Description;                        

                        //Write changes to the DB
                        writeChangesToQualificationToTheDB();

                        //Break out
                        break;

                    }//End If

                }//End Foreach
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End UpdateQualificationDatabase


        public void DeleteQualificationRecord(Qualification thisQualification)
        {
            try
            {
                //Write changes to the Qualification database
                foreach (DataRow row in ds.Tables["Qualification"].Rows)
                {
                    if ((int)row["QualificationID"] == thisQualification.QualificationID)
                    {
                        //Delete the row
                        row.Delete();

                        //Write changes to the DB
                        writeChangesToQualificationToTheDB();

                        //Break out
                        break;

                    }//End If

                }//End Foreach
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End DeleteQualificationRecord


        public void writeChangesToQualificationToTheDB()
        {
            try
            {
                //Update the sql table to reflect the changes
                da.Update(ds.Tables["Qualification"]);
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End writeChangesToQualificationToTheDB


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
