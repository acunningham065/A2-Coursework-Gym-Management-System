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
    public class PaymentDetailsTable
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
        public List<PaymentDetails> ReadPaymentDetailsRecordFromTable()
        {
            //Declare list and connection
            List<PaymentDetails> lstPaymentDetails = new List<PaymentDetails>();
            con = new SqlConnection(connectionString);

            try
            {
                //Construct a query
                string queryString = "Select * from PaymentDetails";

                //Execute query
                da = new SqlDataAdapter(queryString, con);

                //Read in the results and fill into table
                da.Fill(ds, "PaymentDetails");

                //Instantiate a command builder
                cb = new SqlCommandBuilder(da);

                //Convert the data table to a list format
                lstPaymentDetails = ConvertDataTableToList(ds.Tables["PaymentDetails"]);

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

            //Return PaymentDetails list
            return lstPaymentDetails;

        }//End ReadPaymentDetailsRecordFromTable


        public List<PaymentDetails> ConvertDataTableToList(DataTable dataTable)
        {
            //declare a list to store information
            List<PaymentDetails> lstPaymentDetails = new List<PaymentDetails>();

            try
            {
                //Foreach record in the table
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    //Create a temp PaymentDetails to assign info to
                    PaymentDetails currentPaymentDetails = new PaymentDetails();

                    currentPaymentDetails.PaymentDetailsID = (int)dataRow["PaymentDetailsID"];
                    currentPaymentDetails.CardNumber = dataRow["CardNumber"].ToString();
                    currentPaymentDetails.CardType = dataRow["CardType"].ToString();
                    currentPaymentDetails.ExpiryDate = dataRow["ExpiryDate"].ToString();
                    currentPaymentDetails.SecurityCode = dataRow["SecurityCode"].ToString();
                    
                    //add to the list
                    lstPaymentDetails.Add(currentPaymentDetails);

                }//End foreach

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

            //return PaymentDetails list
            return lstPaymentDetails;

        }//End ConvertDataTableToList


        public void AddNewPaymentDetails(PaymentDetails newPaymentDetails)
        {

            try
            {
                //Create a new data row in the dataset
                DataRow row = ds.Tables["PaymentDetails"].NewRow();

                //Add the object information to the the row
                row["CardNumber"] = newPaymentDetails.CardNumber;
                row["CardType"] = newPaymentDetails.CardType;
                row["ExpiryDate"] = newPaymentDetails.ExpiryDate;
                row["SecurityCode"] = newPaymentDetails.SecurityCode;

                //Add the row to the data set
                ds.Tables["PaymentDetails"].Rows.Add(row);

                //Write the changes to the database
                writeChangesToPaymentDetailsToTheDB();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End AddNewPaymentDetails


        public void UpdatePaymentDetailsDatabase(PaymentDetails thisPaymentDetails)
        {
            try
            {
                //Write changes to the PaymentDetails database
                foreach (DataRow row in ds.Tables["PaymentDetails"].Rows)
                {
                    if ((int)row["PaymentDetailsID"] == thisPaymentDetails.PaymentDetailsID)
                    {
                        //Add the object information to the the row
                        row["CardNumber"] = thisPaymentDetails.CardNumber;
                        row["CardType"] = thisPaymentDetails.CardType;
                        row["ExpiryDate"] = thisPaymentDetails.ExpiryDate;
                        row["SecurityCode"] = thisPaymentDetails.SecurityCode;

                        //Write changes to the DB
                        writeChangesToPaymentDetailsToTheDB();

                        //Break out
                        break;

                    }//End If

                }//End Foreach
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End UpdatePaymentDetailsDatabase


        public void DeletePaymentDetailsRecord(PaymentDetails thisPaymentDetails)
        {
            try
            {
                //Write changes to the PaymentDetails database
                foreach (DataRow row in ds.Tables["PaymentDetails"].Rows)
                {
                    if ((int)row["PaymentDetailsID"] == thisPaymentDetails.PaymentDetailsID)
                    {
                        //Delete the row
                        row.Delete();

                        //Write changes to the DB
                        writeChangesToPaymentDetailsToTheDB();

                        //Break out
                        break;

                    }//End If

                }//End Foreach
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End DeletePaymentDetailsRecord


        public void writeChangesToPaymentDetailsToTheDB()
        {
            try
            {
                //Update the sql table to reflect the changes
                da.Update(ds.Tables["PaymentDetails"]);
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End writeChangesToPaymentDetailsToTheDB


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
