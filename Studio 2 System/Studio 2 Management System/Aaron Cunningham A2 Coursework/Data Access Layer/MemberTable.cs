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
    class MemberTable
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
        public List<Member> ReadMemberRecordFromTable()
        {
            //Declare list and connection
            List<Member> lstMembers = new List<Member>();
            con = new SqlConnection(connectionString);

            try
            {
                //Construct a query
                string queryString = "Select * from Member";

                //Execute query
                da = new SqlDataAdapter(queryString, con);

                //Read in the results and fill into table
                da.Fill(ds, "Member");

                //Instantiate a command builder
                cb = new SqlCommandBuilder(da);

                //Convert the data table to a list format
                lstMembers = ConvertDataTableToList(ds.Tables["Member"]);

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

            //Return member list
            return lstMembers;

        }//End ReadMemberRecordFromTable


        public List<Member> ConvertDataTableToList(DataTable dataTable)
        {
            //declare a list to store information
            List<Member> lstMembers = new List<Member>();

            try
            {
                //Foreach record in the table
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    //Create a temp member to assign info to
                    Member currentMember = new Member();

                    currentMember.MemberID = (int)dataRow["MemberID"];
                    currentMember.MembershipTypeID = (int)dataRow["MembershipTypeID"];
                    currentMember.Title = dataRow["Title"].ToString();
                    currentMember.Surname = dataRow["Surname"].ToString();
                    currentMember.FirstName = dataRow["FirstName"].ToString();
                    currentMember.Address = dataRow["Address"].ToString();
                    currentMember.Town = dataRow["Town"].ToString();
                    currentMember.PostCode = dataRow["PostCode"].ToString();
                    currentMember.TelNo = dataRow["TelNo"].ToString();
                    currentMember.Email = dataRow["EmailAddress"].ToString();
                    currentMember.DOB = (DateTime)dataRow["DateOfBirth"];

                    //add to the list
                    lstMembers.Add(currentMember);

                }//End foreach

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

            //return member list
            return lstMembers;
            
        }//End ConvertDataTableToList


        public void AddNewMember(Member newMember)
        {

            try
            {
                //Create a new data row in the dataset
                DataRow row = ds.Tables["Member"].NewRow();

                //Add the object information to the the row
                row["MembershipTypeID"] = newMember.MembershipTypeID;
                row["Title"] = newMember.Title;
                row["Surname"] = newMember.Surname;
                row["FirstName"] = newMember.FirstName;
                row["DateOfBirth"] = newMember.DOB;
                row["Address"] = newMember.Address;
                row["Town"] = newMember.Town;
                row["PostCode"] = newMember.PostCode;
                row["TelNo"] = newMember.TelNo;
                row["EmailAddress"] = newMember.Email;

                //Add the row to the data set
                ds.Tables["Member"].Rows.Add(row);

                //Write the changes to the database
                writeChangesToMemberToTheDB();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }            

        }//End AddNewMember


        public void UpdateMemberDatabase(Member thisMember)
        {
            try
            {
                //Write changes to the member database
                foreach (DataRow row in ds.Tables["Member"].Rows)
                {
                    if ((int)row["MemberID"] == thisMember.MemberID)
                    {
                        //Add the object information to the the row
                        row["MembershipTypeID"] = thisMember.MembershipTypeID;
                        row["Title"] = thisMember.Title;
                        row["Surname"] = thisMember.Surname;
                        row["FirstName"] = thisMember.FirstName;
                        row["DateOfBirth"] = thisMember.DOB;
                        row["Address"] = thisMember.Address;
                        row["Town"] = thisMember.Town;
                        row["PostCode"] = thisMember.PostCode;
                        row["TelNo"] = thisMember.TelNo;
                        row["EmailAddress"] = thisMember.Email;

                        //Write changes to the DB
                        writeChangesToMemberToTheDB();

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


        public void DeleteMemberRecord(Member thisMember)
        {
            try
            {
                //Write changes to the member database
                foreach (DataRow row in ds.Tables["Member"].Rows)
                {
                    if ((int)row["MemberID"] == thisMember.MemberID)
                    {
                        //Delete the row
                        row.Delete();

                        //Write changes to the DB
                        writeChangesToMemberToTheDB();

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


        public void writeChangesToMemberToTheDB()
        {
            try
            {
                //Update the sql table to reflect the changes
                da.Update(ds.Tables["Member"]);
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
