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
    public class PaymentMethodTable
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
        public List<PaymentMethod> ReadPaymentMethodRecordFromTable()
        {
            //Declare list and connection
            List<PaymentMethod> lstPaymentMethods = new List<PaymentMethod>();
            con = new SqlConnection(connectionString);

            try
            {
                //Construct a query
                string queryString = "Select * from PaymentMethod";

                //Execute query
                da = new SqlDataAdapter(queryString, con);

                //Read in the results and fill into table
                da.Fill(ds, "PaymentMethod");


                //Instantiate a command builder
                cb = new SqlCommandBuilder(da);

                //Convert the data table to a list format
                lstPaymentMethods = ConvertDataTableToList(ds.Tables["PaymentMethod"]);

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

            //Return PaymentMethod list
            return lstPaymentMethods;

        }//End ReadPaymentMethodRecordFromTable


        public List<PaymentMethod> ConvertDataTableToList(DataTable dataTable)
        {
            //declare a list to store information
            List<PaymentMethod> lstPaymentMethods = new List<PaymentMethod>();

            try
            {
                //Foreach record in the table
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    //Create a temp PaymentMethod to assign info to
                    PaymentMethod currentPaymentMethod = new PaymentMethod();

                    currentPaymentMethod.PaymentMethodID = (int)dataRow["PaymentMethodID"];
                    currentPaymentMethod.MemberID = (int)dataRow["MemberID"];
                    currentPaymentMethod.PaymentDetailsID = (int)dataRow["PaymentDetailsID"];


                    //add to the list
                    lstPaymentMethods.Add(currentPaymentMethod);

                }//End foreach

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

            //return PaymentMethod list
            return lstPaymentMethods;

        }//End ConvertDataTableToList


        public void AddNewPaymentMethod(PaymentMethod newPaymentMethod)
        {

            try
            {
                //Create a new data row in the dataset
                DataRow row = ds.Tables["PaymentMethod"].NewRow();

                //Add the object information to the the row
                row["MemberID"] = newPaymentMethod.MemberID;
                row["PaymentDetailsID"] = newPaymentMethod.PaymentDetailsID;

                //Add the row to the data set
                ds.Tables["PaymentMethod"].Rows.Add(row);

                //Write the changes to the database
                writeChangesToPaymentMethodToTheDB();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End AddNewPaymentMethod


        public void UpdatePaymentMethodDatabase(PaymentMethod thisPaymentMethod)
        {
            try
            {
                //Write changes to the PaymentMethod database
                foreach (DataRow row in ds.Tables["PaymentMethod"].Rows)
                {
                    if ((int)row["PaymentMethodID"] == thisPaymentMethod.PaymentMethodID)
                    {
                        //Add the object information to the the row
                        row["MemberID"] = thisPaymentMethod.MemberID;
                        row["PaymentDetailsID"] = thisPaymentMethod.PaymentDetailsID;

                        //Write changes to the DB
                        writeChangesToPaymentMethodToTheDB();

                        //Break out
                        break;

                    }//End If

                }//End Foreach
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End UpdatePaymentMethodDatabase


        public void DeletePaymentMethodRecord(PaymentMethod thisPaymentMethod)
        {
            try
            {
                //Write changes to the PaymentMethod database
                foreach (DataRow row in ds.Tables["PaymentMethod"].Rows)
                {
                    if ((int)row["PaymentMethodID"] == thisPaymentMethod.PaymentMethodID)
                    {
                        //Delete the row
                        row.Delete();

                        //Write changes to the DB
                        writeChangesToPaymentMethodToTheDB();

                        //Break out
                        break;

                    }//End If

                }//End Foreach
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End DeletePaymentMethodRecord


        public void writeChangesToPaymentMethodToTheDB()
        {
            try
            {
                //Update the sql table to reflect the changes
                da.Update(ds.Tables["PaymentMethod"]);
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End writeChangesToPaymentMethodToTheDB


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
