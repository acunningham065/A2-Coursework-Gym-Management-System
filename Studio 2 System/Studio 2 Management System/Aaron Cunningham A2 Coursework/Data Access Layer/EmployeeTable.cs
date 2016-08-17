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
    public class EmployeeTable
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
        public List<Employee> ReadEmployeeRecordFromTable()
        {
            //Declare list and connection
            List<Employee> lstEmployees = new List<Employee>();
            con = new SqlConnection(connectionString);

            try
            {
                //Construct a query
                string queryString = "Select * from Employee";

                //Execute query
                da = new SqlDataAdapter(queryString, con);

                //Read in the results and fill into table
                da.Fill(ds, "Employee");

                //Instantiate a command builder
                cb = new SqlCommandBuilder(da);

                //Convert the data table to a list format
                lstEmployees = ConvertDataTableToList(ds.Tables["Employee"]);

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

            //Return Employee list
            return lstEmployees;

        }//End ReadEmployeeRecordFromTable


        public List<Employee> ConvertDataTableToList(DataTable dataTable)
        {
            //declare a list to store information
            List<Employee> lstEmployees = new List<Employee>();

            try
            {
                //Foreach record in the table
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    //Create a temp Employee to assign info to
                    Employee currentEmployee = new Employee();

                    currentEmployee.EmployeeID = (int)dataRow["EmployeeID"];
                    currentEmployee.Title = dataRow["Title"].ToString();
                    currentEmployee.Surname = dataRow["Surname"].ToString();
                    currentEmployee.FirstName = dataRow["FirstName"].ToString();
                    currentEmployee.Address = dataRow["Address"].ToString();
                    currentEmployee.Town = dataRow["Town"].ToString();
                    currentEmployee.PostCode = dataRow["PostCode"].ToString();
                    currentEmployee.TelNo = dataRow["TelNo"].ToString();
                    currentEmployee.Email = dataRow["EmailAddress"].ToString();
                    currentEmployee.DOB = (DateTime)dataRow["DateOfBirth"];
                    currentEmployee.NationalInsuranceNumber = dataRow["NationalInsuranceNumber"].ToString();
                    currentEmployee.ContractType = dataRow["ContractType"].ToString();

                    //add to the list
                    lstEmployees.Add(currentEmployee);

                }//End foreach

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

            //return Employee list
            return lstEmployees;

        }//End ConvertDataTableToList


        public void AddNewEmployee(Employee newEmployee)
        {

            try
            {
                //Create a new data row in the dataset
                DataRow row = ds.Tables["Employee"].NewRow();

                //Add the object information to the the row
                row["Title"] = newEmployee.Title;
                row["Surname"] = newEmployee.Surname;
                row["FirstName"] = newEmployee.FirstName;
                row["Address"] = newEmployee.Address;
                row["Town"] = newEmployee.Town;
                row["PostCode"] = newEmployee.PostCode;
                row["TelNo"] = newEmployee.TelNo;
                row["EmailAddress"] = newEmployee.Email;
                row["DateOfBirth"] = newEmployee.DOB;
                row["NationalInsuranceNumber"] = newEmployee.NationalInsuranceNumber;
                row["ContractType"] = newEmployee.ContractType;

                //Add the row to the data set
                ds.Tables["Employee"].Rows.Add(row);

                //Write the changes to the database
                writeChangesToEmployeeToTheDB();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End AddNewEmployee


        public void UpdateEmployeeDatabase(Employee thisEmployee)
        {
            try
            {
                //Write changes to the Employee database
                foreach (DataRow row in ds.Tables["Employee"].Rows)
                {
                    if ((int)row["EmployeeID"] == thisEmployee.EmployeeID)
                    {
                        //Add the object information to the the row
                        row["Title"] = thisEmployee.Title;
                        row["Surname"] = thisEmployee.Surname;
                        row["FirstName"] = thisEmployee.FirstName;
                        row["Address"] = thisEmployee.Address;
                        row["Town"] = thisEmployee.Town;
                        row["PostCode"] = thisEmployee.PostCode;
                        row["TelNo"] = thisEmployee.TelNo;
                        row["EmailAddress"] = thisEmployee.Email;
                        row["DateOfBirth"] = thisEmployee.DOB;
                        row["NationalInsuranceNumber"] = thisEmployee.NationalInsuranceNumber;
                        row["ContractType"] = thisEmployee.ContractType;

                        //Write changes to the DB
                        writeChangesToEmployeeToTheDB();

                        //Break out
                        break;

                    }//End If

                }//End Foreach
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End UpdateEmployeeDatabase


        public void DeleteEmployeeRecord(Employee thisEmployee)
        {
            try
            {
                //Write changes to the Employee database
                foreach (DataRow row in ds.Tables["Employee"].Rows)
                {
                    if ((int)row["EmployeeID"] == thisEmployee.EmployeeID)
                    {
                        //Delete the row
                        row.Delete();

                        //Write changes to the DB
                        writeChangesToEmployeeToTheDB();

                        //Break out
                        break;

                    }//End If

                }//End Foreach
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End DeleteEmployeeRecord


        public void writeChangesToEmployeeToTheDB()
        {
            try
            {
                //Update the sql table to reflect the changes
                da.Update(ds.Tables["Employee"]);
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End writeChangesToEmployeeToTheDB


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
