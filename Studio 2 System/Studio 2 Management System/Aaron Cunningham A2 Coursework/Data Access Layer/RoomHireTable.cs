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
    class RoomHireTable
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
        public List<RoomHire> ReadRoomHireRecordFromTable()
        {
            //Declare list and connection
            List<RoomHire> lstRoomHires = new List<RoomHire>();
            con = new SqlConnection(connectionString);

            try
            {
                //Construct a query
                string queryString = "Select * from RoomHire";

                //Execute query
                da = new SqlDataAdapter(queryString, con);

                //Read in the results and fill into table
                da.Fill(ds, "RoomHire");

                //Instantiate a command builder
                cb = new SqlCommandBuilder(da);

                //Convert the data table to a list format
                lstRoomHires = ConvertDataTableToList(ds.Tables["RoomHire"]);

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

            //Return RoomHire list
            return lstRoomHires;

        }//End ReadRoomHireRecordFromTable


        public List<RoomHire> ConvertDataTableToList(DataTable dataTable)
        {
            //declare a list to store information
            List<RoomHire> lstRoomHires = new List<RoomHire>();

            try
            {
                //Foreach record in the table
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    //Create a temp RoomHire to assign info to
                    RoomHire currentRoomHire = new RoomHire();

                    currentRoomHire.RoomHireID = (int)dataRow["RoomHireID"];
                    currentRoomHire.RoomID = (int)dataRow["RoomID"];
                    currentRoomHire.ExternalCompanyID = (int)dataRow["ExternalCompanyID"];
                    currentRoomHire.StartDate = (DateTime)dataRow["StartDate"];
                    currentRoomHire.HireDuration = (int)dataRow["HireDuration"];
                    currentRoomHire.EndDate = (DateTime)dataRow["EndDate"];
                    currentRoomHire.HoursPerWeek = (int)dataRow["HoursPerWeek"];
                    currentRoomHire.MonthlyHireCost = (decimal)dataRow["MonthlyHireCost"];
                    currentRoomHire.TotalHireCost = (decimal)dataRow["TotalHireCost"];


                    //add to the list
                    lstRoomHires.Add(currentRoomHire);

                }//End foreach

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

            //return RoomHire list
            return lstRoomHires;

        }//End ConvertDataTableToList


        public void AddNewRoomHire(RoomHire newRoomHire)
        {

            try
            {
                //Create a new data row in the dataset
                DataRow row = ds.Tables["RoomHire"].NewRow();

                //Add the object information to the the row
                row["RoomID"] = newRoomHire.RoomID;
                row["ExternalCompanyID"] = newRoomHire.ExternalCompanyID;
                row["StartDate"] = newRoomHire.StartDate;
                row["HireDuration"] = newRoomHire.HireDuration;
                row["EndDate"] = newRoomHire.EndDate;
                row["HoursPerWeek"] = newRoomHire.HoursPerWeek;
                row["MonthlyHireCost"] = newRoomHire.MonthlyHireCost;
                row["TotalHireCost"] = newRoomHire.TotalHireCost;

                //Add the row to the data set
                ds.Tables["RoomHire"].Rows.Add(row);

                //Write the changes to the database
                writeChangesToRoomHireToTheDB();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End AddNewRoomHire


        public void UpdateRoomHireDatabase(RoomHire thisRoomHire)
        {
            try
            {
                //Write changes to the RoomHire database
                foreach (DataRow row in ds.Tables["RoomHire"].Rows)
                {
                    if ((int)row["RoomHireID"] == thisRoomHire.RoomHireID)
                    {
                        //Add the object information to the the row
                        row["RoomID"] = thisRoomHire.RoomID;
                        row["ExternalCompanyID"] = thisRoomHire.ExternalCompanyID;
                        row["StartDate"] = thisRoomHire.StartDate;
                        row["HireDuration"] = thisRoomHire.HireDuration;
                        row["EndDate"] = thisRoomHire.EndDate;
                        row["HoursPerWeek"] = thisRoomHire.HoursPerWeek;
                        row["MonthlyHireCost"] = thisRoomHire.MonthlyHireCost;
                        row["TotalHireCost"] = thisRoomHire.TotalHireCost;

                        //Write changes to the DB
                        writeChangesToRoomHireToTheDB();

                        //Break out
                        break;

                    }//End If

                }//End Foreach
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End UpdateRoomHireDatabase


        public void DeleteRoomHireRecord(RoomHire thisRoomHire)
        {
            try
            {
                //Write changes to the RoomHire database
                foreach (DataRow row in ds.Tables["RoomHire"].Rows)
                {
                    if ((int)row["RoomHireID"] == thisRoomHire.RoomHireID)
                    {
                        //Delete the row
                        row.Delete();

                        //Write changes to the DB
                        writeChangesToRoomHireToTheDB();

                        //Break out
                        break;

                    }//End If

                }//End Foreach
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End DeleteRoomHireRecord


        public void writeChangesToRoomHireToTheDB()
        {
            try
            {
                //Update the sql table to reflect the changes
                da.Update(ds.Tables["RoomHire"]);
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End writeChangesToRoomHireToTheDB


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
