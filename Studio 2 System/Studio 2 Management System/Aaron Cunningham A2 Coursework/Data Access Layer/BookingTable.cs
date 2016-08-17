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
    class BookingTable
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
        public List<Booking> ReadBookingRecordFromTable()
        {
            //Declare list and connection
            List<Booking> lstBookings = new List<Booking>();
            con = new SqlConnection(connectionString);

            try
            {
                //Construct a query
                string queryString = "Select * from Booking";

                //Execute query
                da = new SqlDataAdapter(queryString, con);

                //Read in the results and fill into table
                da.Fill(ds, "Booking");

                //Instantiate a command builder
                cb = new SqlCommandBuilder(da);

                //Convert the data table to a list format
                lstBookings = ConvertDataTableToList(ds.Tables["Booking"]);

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

            //Return Booking list
            return lstBookings;

        }//End ReadBookingRecordFromTable


        public List<Booking> ConvertDataTableToList(DataTable dataTable)
        {
            //declare a list to store information
            List<Booking> lstBookings = new List<Booking>();

            try
            {
                //Foreach record in the table
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    //Create a temp Booking to assign info to
                    Booking currentBooking = new Booking();

                    currentBooking.BookingID = (int)dataRow["BookingID"];
                    currentBooking.MemberID = (int)dataRow["MemberID"];
                    currentBooking.ExerciseClassID = (int)dataRow["ExerciseClassID"];
                    currentBooking.EmployeeID = (int)dataRow["EmployeeID"];
                    currentBooking.DateOfBooking = (DateTime)dataRow["DateOfBooking"];
                    currentBooking.AmountCharged = (decimal)dataRow["AmountCharged"];
                    currentBooking.NoOfPeopleBooking = (int)dataRow["NoOfPeopleBooking"];

                    //add to the list
                    lstBookings.Add(currentBooking);

                }//End foreach

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

            //return Booking list
            return lstBookings;

        }//End ConvertDataTableToList


        public void AddNewBooking(Booking newBooking)
        {

            try
            {
                //Create a new data row in the dataset
                DataRow row = ds.Tables["Booking"].NewRow();

                //Add the object information to the the row
                row["MemberID"] = newBooking.MemberID;
                row["ExerciseClassID"] = newBooking.ExerciseClassID;
                row["EmployeeID"] = newBooking.EmployeeID;
                row["DateOfBooking"] = newBooking.DateOfBooking;
                row["AmountCharged"] = newBooking.AmountCharged;
                row["NoOfPeopleBooking"] = newBooking.NoOfPeopleBooking;

                //Add the row to the data set
                ds.Tables["Booking"].Rows.Add(row);

                //Write the changes to the database
                writeChangesToBookingToTheDB();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End AddNewBooking


        public void UpdateBookingDatabase(Booking thisBooking)
        {
            try
            {
                //Write changes to the Booking database
                foreach (DataRow row in ds.Tables["Booking"].Rows)
                {
                    if ((int)row["BookingID"] == thisBooking.BookingID)
                    {
                        //Add the object information to the the row
                        row["MemberID"] = thisBooking.MemberID;
                        row["ExerciseClassID"] = thisBooking.ExerciseClassID;
                        row["EmployeeID"] = thisBooking.EmployeeID;
                        row["DateOfBooking"] = thisBooking.DateOfBooking;
                        row["AmountCharged"] = thisBooking.AmountCharged;
                        row["NoOfPeopleBooking"] = thisBooking.NoOfPeopleBooking;

                        //Write changes to the DB
                        writeChangesToBookingToTheDB();

                        //Break out
                        break;

                    }//End If

                }//End Foreach
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End UpdateBookingDatabase


        public void DeleteBookingRecord(Booking thisBooking)
        {
            try
            {
                //Write changes to the Booking database
                foreach (DataRow row in ds.Tables["Booking"].Rows)
                {
                    if ((int)row["BookingID"] == thisBooking.BookingID)
                    {
                        //Delete the row
                        row.Delete();

                        //Write changes to the DB
                        writeChangesToBookingToTheDB();

                        //Break out
                        break;

                    }//End If

                }//End Foreach
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End DeleteBookingRecord


        public void writeChangesToBookingToTheDB()
        {
            try
            {
                //Update the sql table to reflect the changes
                da.Update(ds.Tables["Booking"]);
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End writeChangesToBookingToTheDB


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
