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
    class SessionTable
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
        public List<Session> ReadSessionRecordFromTable()
        {
            //Declare list and connection
            List<Session> lstSessions = new List<Session>();
            con = new SqlConnection(connectionString);

            try
            {
                //Construct a query
                string queryString = "Select * from Session";

                //Execute query
                da = new SqlDataAdapter(queryString, con);

                //Read in the results and fill into table
                da.Fill(ds, "Session");

                //Instantiate a command builder
                cb = new SqlCommandBuilder(da);

                //Convert the data table to a list format
                lstSessions = ConvertDataTableToList(ds.Tables["Session"]);

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

            //Return Session list
            return lstSessions;

        }//End ReadSessionRecordFromTable


        public List<Session> ConvertDataTableToList(DataTable dataTable)
        {
            //declare a list to store information
            List<Session> lstSessions = new List<Session>();

            try
            {
                //Foreach record in the table
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    //Create a temp Session to assign info to
                    Session currentSession = new Session();

                    //Assign values to the object
                    currentSession.SessionID = (int)dataRow["SessionID"];
                    currentSession.ExerciseClassID = (int)dataRow["ExerciseClassID"];               
                    currentSession.DateOfClass = (DateTime)dataRow["DateOfClass"];
                    currentSession.StartTimeOfClass = (TimeSpan)dataRow["StartTimeOfClass"];
                    currentSession.LengthOfClass = (int)dataRow["LengthOfClass"];
                    currentSession.EndTimeOfClass = (TimeSpan)dataRow["EndTimeOfClass"];
                   

                    //add to the list
                    lstSessions.Add(currentSession);

                }//End foreach

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

            //return Session list
            return lstSessions;

        }//End ConvertDataTableToList


        public void AddNewSession(Session newSession)
        {

            try
            {
                //Create a new data row in the dataset
                DataRow dataRow = ds.Tables["Session"].NewRow();

                //Add the object information to the the row
                dataRow["ExerciseClassID"] = newSession.ExerciseClassID;
                dataRow["DateOfClass"] = newSession.DateOfClass;
                dataRow["StartTimeOfClass"] = newSession.StartTimeOfClass;
                dataRow["LengthOfClass"] = newSession.LengthOfClass;
                dataRow["EndTimeOfClass"] = newSession.EndTimeOfClass;

                //Add the row to the data set
                ds.Tables["Session"].Rows.Add(dataRow);

                //Write the changes to the database
                writeChangesToSessionToTheDB();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End AddNewSession


        public void UpdateSessionDatabase(Session thisSession)
        {
            try
            {
                //Write changes to the Session database
                foreach (DataRow dataRow in ds.Tables["Session"].Rows)
                {
                    if ((int)dataRow["SessionID"] == thisSession.SessionID)
                    {
                        //Add the object information to the the row
                        dataRow["ExerciseClassID"] = thisSession.ExerciseClassID;
                        dataRow["DateOfClass"] = thisSession.DateOfClass;
                        dataRow["StartTimeOfClass"] = thisSession.StartTimeOfClass;
                        dataRow["LengthOfClass"] = thisSession.LengthOfClass;
                        dataRow["EndTimeOfClass"] = thisSession.EndTimeOfClass;

                        //Write changes to the DB
                        writeChangesToSessionToTheDB();

                        //Break out
                        break;

                    }//End If

                }//End Foreach
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End UpdateSessionDatabase


        public void DeleteSessionRecord(Session thisSession)
        {
            try
            {
                //Write changes to the Session database
                foreach (DataRow row in ds.Tables["Session"].Rows)
                {
                    if ((int)row["SessionID"] == thisSession.SessionID)
                    {
                        //Delete the row
                        row.Delete();

                        //Write changes to the DB
                        writeChangesToSessionToTheDB();

                        //Break out
                        break;

                    }//End If

                }//End Foreach
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End DeleteSessionRecord


        public void writeChangesToSessionToTheDB()
        {
            try
            {
                //Update the sql table to reflect the changes
                da.Update(ds.Tables["Session"]);
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End writeChangesToSessionToTheDB


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
