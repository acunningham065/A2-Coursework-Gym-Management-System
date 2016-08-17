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
    class RoomTable
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
        public List<Room> ReadRoomRecordFromTable()
        {
            //Declare list and connection
            List<Room> lstRooms = new List<Room>();
            con = new SqlConnection(connectionString);

            try
            {
                //Construct a query
                string queryString = "Select * from Room";

                //Execute query
                da = new SqlDataAdapter(queryString, con);

                //Read in the results and fill into table
                da.Fill(ds, "Room");

                //Instantiate a command builder
                cb = new SqlCommandBuilder(da);

                //Convert the data table to a list format
                lstRooms = ConvertDataTableToList(ds.Tables["Room"]);

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

            //Return Room list
            return lstRooms;

        }//End ReadRoomRecordFromTable


        public List<Room> ConvertDataTableToList(DataTable dataTable)
        {
            //declare a list to store information
            List<Room> lstRooms = new List<Room>();

            try
            {
                //Foreach record in the table
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    //Create a temp Room to assign info to
                    Room currentRoom = new Room();

                    currentRoom.RoomID = (int)dataRow["RoomID"];
                    currentRoom.RoomDescription = dataRow["Description"].ToString();
                    currentRoom.RoomLocation = dataRow["Location"].ToString();
                    currentRoom.Capacity = (int)dataRow["Capacity"];
                    currentRoom.HourlyHireCost = (decimal)dataRow["HourlyHireCost"];
                    currentRoom.AvailableToUse = (bool)dataRow["AvailableToUse"];


                    //add to the list
                    lstRooms.Add(currentRoom);

                }//End foreach

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

            //return Room list
            return lstRooms;

        }//End ConvertDataTableToList


        public void AddNewRoom(Room newRoom)
        {

            try
            {
                //Create a new data row in the dataset
                DataRow row = ds.Tables["Room"].NewRow();

                //Add the object information to the the row
                row["Description"] = newRoom.RoomDescription;
                row["Location"] = newRoom.RoomLocation;
                row["Capacity"] = newRoom.Capacity;
                row["HourlyHireCost"] = newRoom.HourlyHireCost;
                row["AvailableToUse"] = newRoom.AvailableToUse;

                //Add the row to the data set
                ds.Tables["Room"].Rows.Add(row);

                //Write the changes to the database
                writeChangesToRoomToTheDB();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End AddNewRoom


        public void UpdateRoomDatabase(Room thisRoom)
        {
            try
            {
                //Write changes to the Room database
                foreach (DataRow row in ds.Tables["Room"].Rows)
                {
                    if ((int)row["RoomID"] == thisRoom.RoomID)
                    {
                        //Add the object information to the the row
                        row["Description"] = thisRoom.RoomDescription;
                        row["Location"] = thisRoom.RoomLocation;
                        row["Capacity"] = thisRoom.Capacity;
                        row["HourlyHireCost"] = thisRoom.HourlyHireCost;
                        row["AvailableToUse"] = thisRoom.AvailableToUse;

                        //Write changes to the DB
                        writeChangesToRoomToTheDB();

                        //Break out
                        break;

                    }//End If

                }//End Foreach
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End UpdateRoomDatabase


        public void DeleteRoomRecord(Room thisRoom)
        {
            try
            {
                //Write changes to the Room database
                foreach (DataRow row in ds.Tables["Room"].Rows)
                {
                    if ((int)row["RoomID"] == thisRoom.RoomID)
                    {
                        //Delete the row
                        row.Delete();

                        //Write changes to the DB
                        writeChangesToRoomToTheDB();

                        //Break out
                        break;

                    }//End If

                }//End Foreach
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End DeleteRoomRecord


        public void writeChangesToRoomToTheDB()
        {
            try
            {
                //Update the sql table to reflect the changes
                da.Update(ds.Tables["Room"]);
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End writeChangesToRoomToTheDB


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
