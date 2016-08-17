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
    class MembershipTypeTable
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
        public List<MembershipType> ReadMembershipTypeFromTable()
        {
            //Declare list and connection
            List<MembershipType> lstMembershipTypes = new List<MembershipType>();
            con = new SqlConnection(connectionString);

            try
            {
                //Construct a query
                string queryString = "Select * from MembershipType";

                //Execute query
                da = new SqlDataAdapter(queryString, con);

                //Read in the results and fill into table
                da.Fill(ds, "MembershipType");

                //Instantiate a command builder
                cb = new SqlCommandBuilder(da);

                //Convert the data table to a list format
                lstMembershipTypes = ConvertDataTableToList(ds.Tables["MembershipType"]);

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

            //Return MembershipType list
            return lstMembershipTypes;

        }//End ReadMemberRecordFromTable


        public List<MembershipType> ConvertDataTableToList(DataTable dataTable)
        {
            //declare a list to store information
            List<MembershipType> lstMembershipTypes = new List<MembershipType>();

            try
            {
                //Foreach record in the table
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    //Create a temp MembershipType to assign info to
                    MembershipType currentMembershipType = new MembershipType();

                    currentMembershipType.MembershipTypeID = (int)dataRow["MembershipTypeID"];
                    currentMembershipType.Description = dataRow["Description"].ToString();
                    currentMembershipType.MembershipCost = (decimal)dataRow["MembershipCost"];
                    
                    //add to the list
                    lstMembershipTypes.Add(currentMembershipType);

                }//End foreach

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

            //return MembershipType list
            return lstMembershipTypes;

        }//End ConvertDataTableToList


        public void AddNewMembershipType(MembershipType newMembershipType)
        {

            try
            {
                //Create a new data row in the dataset
                DataRow row = ds.Tables["MembershipType"].NewRow();

                //Add the object information to the the row
                row["MembershipTypeID"] = newMembershipType.MembershipTypeID;
                row["Description"] = newMembershipType.Description;
                row["MembershipCost"] = newMembershipType.MembershipCost;
               
                //Add the row to the data set
                ds.Tables["MembershipType"].Rows.Add(row);

                //Write the changes to the database
                writeChangesToMembershipTypeToTheDB();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End AddNewMember


        public void UpdateMembershipTypeDatabase(MembershipType newMembershipType)
        {
            try
            {
                //Write changes to the MembershipType database
                foreach (DataRow row in ds.Tables["MembershipType"].Rows)
                {
                    if ((int)row["MembershipTypeID"] == newMembershipType.MembershipTypeID)
                    {
                        //Add the object information to the the row
                        row["MembershipTypeID"] = newMembershipType.MembershipTypeID;
                        row["Description"] = newMembershipType.Description;
                        row["MembershipCost"] = newMembershipType.MembershipCost;
                        
                        //Write changes to the DB
                        writeChangesToMembershipTypeToTheDB();

                        //Break out
                        break;

                    }//End If

                }//End Foreach
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End UpdateMemberDatabase


        public void DeleteMembershipType(MembershipType thisMembershipType)
        {
            try
            {
                //Write changes to the MembershipType database
                foreach (DataRow row in ds.Tables["MembershipType"].Rows)
                {
                    if ((int)row["MembershipTypeID"] == thisMembershipType.MembershipTypeID)
                    {
                        //Delete the row
                        row.Delete();

                        //Write changes to the DB
                        writeChangesToMembershipTypeToTheDB();

                        //Break out
                        break;

                    }//End If

                }//End Foreach
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End DeleteMemberRecord


        public void writeChangesToMembershipTypeToTheDB()
        {
            try
            {
                //Update the sql table to reflect the changes
                da.Update(ds.Tables["MembershipType"]);
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End writeChangesToMemberToTheDB


        private static void printErrorMessage(Exception ex)
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
