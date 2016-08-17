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
    class PaymentTable
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
        public List<Payment> ReadPaymentRecordFromTable()
        {
            //Declare list and connection
            List<Payment> lstPayments = new List<Payment>();
            con = new SqlConnection(connectionString);

            try
            {
                //Construct a query
                string queryString = "Select * from Payment";

                //Execute query
                da = new SqlDataAdapter(queryString, con);

                //Read in the results and fill into table
                da.Fill(ds, "Payment");

                //Instantiate a command builder
                cb = new SqlCommandBuilder(da);

                //Convert the data table to a list format
                lstPayments = ConvertDataTableToList(ds.Tables["Payment"]);

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

            //Return Payment list
            return lstPayments;

        }//End ReadPaymentRecordFromTable


        public List<Payment> ConvertDataTableToList(DataTable dataTable)
        {
            //declare a list to store information
            List<Payment> lstPayments = new List<Payment>();

            try
            {
                //Foreach record in the table
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    //Create a temp Payment to assign info to
                    Payment currentPayment = new Payment();

                    currentPayment.PaymentID = (int)dataRow["PaymentID"];
                    currentPayment.MemberID = (int)dataRow["MemberID"];                    
                    
                    currentPayment.DateOfPayment = (DateTime)dataRow["DateOfPayment"];
                    currentPayment.AmountPaid = (decimal)dataRow["AmountPaid"];

                    //Check if there is a booking ID to read in
                    if (dataRow["BookingID"].ToString() != "")
                    {
                        //Read in the booking ID
                        currentPayment.BookingID = (int)dataRow["BookingID"];

                    }//End If


                    //Check that they used a card
                    if (dataRow["PaymentMethodID"].ToString() != "")
                    {
                        //If they did read in the Payment Method ID
                        currentPayment.PaymentMethodID = (int)dataRow["PaymentMethodID"];

                    }//End If

                    //add to the list
                    lstPayments.Add(currentPayment);

                }//End foreach

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

            //return Payment list
            return lstPayments;

        }//End ConvertDataTableToList


        public void AddNewPayment(Payment newPayment)
        {

            try
            {
                //Create a new data row in the dataset
                DataRow row = ds.Tables["Payment"].NewRow();

                //Add the object information to the the row
                row["MemberID"] = newPayment.MemberID;                

                row["DateOfPayment"] = newPayment.DateOfPayment;
                row["AmountPaid"] = newPayment.AmountPaid;

                //Check if there is a booking ID
                if (newPayment.BookingID != 0)
                {
                    //Assign to the database
                    row["BookingID"] = newPayment.BookingID;

                }//End If

                //Check that they used a card
                if (newPayment.PaymentMethodID != 0)
                {
                    //If they did assign the Payment Method ID
                    row["PaymentMethodID"] = newPayment.PaymentMethodID;

                }//End If

                //Add the row to the data set
                ds.Tables["Payment"].Rows.Add(row);

                //Write the changes to the database
                writeChangesToPaymentToTheDB();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End AddNewPayment


        public void UpdatePaymentDatabase(Payment thisPayment)
        {
            try
            {
                //Write changes to the Payment database
                foreach (DataRow row in ds.Tables["Payment"].Rows)
                {
                    if ((int)row["PaymentID"] == thisPayment.PaymentID)
                    {
                        //Add the object information to the the row
                        row["MemberID"] = thisPayment.MemberID;
                        row["PaymentMethodID"] = thisPayment.PaymentMethodID;
                        row["DateOfPayment"] = thisPayment.DateOfPayment;
                        row["AmountPaid"] = thisPayment.AmountPaid;

                        //Check if there is a booking ID
                        if (thisPayment.BookingID != 0)
                        {
                            //Assign to the database
                            row["BookingID"] = thisPayment.BookingID;

                        }//End If


                        //Check that they used a card
                        if (thisPayment.PaymentMethodID != 0)
                        {
                            //If they did assign the Payment Method ID
                            row["PaymentMethodID"] = thisPayment.PaymentMethodID;

                        }
                        else
                        {
                            row["PaymentMethodID"] = DBNull.Value;

                        }//End If

                        //Write changes to the DB
                        writeChangesToPaymentToTheDB();

                        //Break out
                        break;

                    }//End If

                }//End Foreach
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End UpdatePaymentDatabase


        public void DeletePaymentRecord(Payment thisPayment)
        {
            try
            {
                //Write changes to the Payment database
                foreach (DataRow row in ds.Tables["Payment"].Rows)
                {
                    if ((int)row["PaymentID"] == thisPayment.PaymentID)
                    {
                        //Delete the row
                        row.Delete();

                        //Write changes to the DB
                        writeChangesToPaymentToTheDB();

                        //Break out
                        break;

                    }//End If

                }//End Foreach
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End DeletePaymentRecord


        public void writeChangesToPaymentToTheDB()
        {
            try
            {
                //Update the sql table to reflect the changes
                da.Update(ds.Tables["Payment"]);
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End writeChangesToPaymentToTheDB


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
