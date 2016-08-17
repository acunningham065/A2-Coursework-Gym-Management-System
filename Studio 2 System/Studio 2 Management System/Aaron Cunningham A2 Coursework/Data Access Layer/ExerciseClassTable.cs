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
    class ExerciseClassTable
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
        public List<ExerciseClass> ReadExerciseClassRecordFromTable()
        {
            //Declare list and connection
            List<ExerciseClass> lstExerciseClasses = new List<ExerciseClass>();
            con = new SqlConnection(connectionString);

            try
            {
                //Construct a query
                string queryString = "Select * from ExerciseClass";

                //Execute query
                da = new SqlDataAdapter(queryString, con);

                //Read in the results and fill into table
                da.Fill(ds, "ExerciseClass");

                //Instantiate a command builder
                cb = new SqlCommandBuilder(da);

                //Convert the data table to a list format
                lstExerciseClasses = ConvertDataTableToList(ds.Tables["ExerciseClass"]);

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

            //Return ExerciseClass list
            return lstExerciseClasses;

        }//End ReadExerciseClassRecordFromTable


        public List<ExerciseClass> ConvertDataTableToList(DataTable dataTable)
        {
            //declare a list to store information
            List<ExerciseClass> lstExerciseClasses = new List<ExerciseClass>();

            try
            {
                //Foreach record in the table
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    //Create a temp ExerciseClass to assign info to
                    ExerciseClass currentExerciseClass = new ExerciseClass();

                    currentExerciseClass.ExerciseClassID = (int)dataRow["ExerciseClassID"];                    
                    currentExerciseClass.EmployeeID = (int)dataRow["EmployeeID"];
                    currentExerciseClass.RoomID = (int)dataRow["RoomID"];
                    currentExerciseClass.Description = dataRow["Description"].ToString();
                    currentExerciseClass.Difficulty = dataRow["Difficulty"].ToString();
                    currentExerciseClass.StartDateOfClass = (DateTime)dataRow["StartDateOfClass"];
                    currentExerciseClass.NoOfWeeks = (int)dataRow["NoOfWeeks"];
                    currentExerciseClass.EndDateOfClass = (DateTime)dataRow["EndDateOfClass"];
                    currentExerciseClass.CurrentNumberOfParticipants = (int)dataRow["CurrentNoOfParticipants"];
                    currentExerciseClass.MaxNumberOfParticipants = (int)dataRow["MaxNoOfParticipants"];
                    currentExerciseClass.ExternalClass = (bool)dataRow["ExternalClass"];
                    currentExerciseClass.WeeklyCostOfClass = (decimal)dataRow["WeeklyCostOfClass"];
                    currentExerciseClass.TotalCostOfClass = (decimal)dataRow["TotalCostOfClass"];

                    //Check if the external company field is null
                    if (dataRow["ExternalCompanyID"].ToString() != "")
                    {
                        //If it is not null, convert
                        currentExerciseClass.ExternalCompanyID = (int)dataRow["ExternalCompanyID"];
                    }
                    else
                    {
                        //If it is assign the value 0
                        currentExerciseClass.ExternalCompanyID = 0;

                    }//End If   
                 
                    //add to the list
                    lstExerciseClasses.Add(currentExerciseClass);

                }//End foreach

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

            //return ExerciseClass list
            return lstExerciseClasses;

        }//End ConvertDataTableToList


        public void AddNewExerciseClass(ExerciseClass newExerciseClass)
        {

            try
            {
                //Create a new data row in the dataset
                DataRow dataRow = ds.Tables["ExerciseClass"].NewRow();

                //Add the object information to the the row                
                dataRow["EmployeeID"] = newExerciseClass.EmployeeID;
                dataRow["RoomID"] = newExerciseClass.RoomID;
                dataRow["Description"] = newExerciseClass.Description;
                dataRow["Difficulty"] = newExerciseClass.Difficulty;
                dataRow["StartDateOfClass"] = newExerciseClass.StartDateOfClass;
                dataRow["NoOfWeeks"] = newExerciseClass.NoOfWeeks;
                dataRow["EndDateOfClass"] = newExerciseClass.EndDateOfClass;
                dataRow["CurrentNoOfParticipants"] = newExerciseClass.CurrentNumberOfParticipants;
                dataRow["MaxNoOfParticipants"] = newExerciseClass.MaxNumberOfParticipants;
                dataRow["ExternalClass"] = newExerciseClass.ExternalClass;
                dataRow["WeeklyCostOfClass"] = newExerciseClass.WeeklyCostOfClass;
                dataRow["TotalCostOfClass"] = newExerciseClass.TotalCostOfClass;

                //Check if the external company field is 0
                if (newExerciseClass.ExternalCompanyID != 0)
                {
                    //If it is not 0, convert
                    dataRow["ExternalCompanyID"] = newExerciseClass.ExternalCompanyID;
                }
                else
                {
                    //If it is assign null
                    dataRow["ExternalCompanyID"] = null;

                }//End If  

                

                //Add the row to the data set
                ds.Tables["ExerciseClass"].Rows.Add(dataRow);

                //Write the changes to the database
                writeChangesToExerciseClassToTheDB();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End AddNewExerciseClass


        public void UpdateExerciseClassDatabase(ExerciseClass thisExerciseClass)
        {
            try
            {
                //Write changes to the ExerciseClass database
                foreach (DataRow dataRow in ds.Tables["ExerciseClass"].Rows)
                {
                    if ((int)dataRow["ExerciseClassID"] == thisExerciseClass.ExerciseClassID)
                    {
                        //Add the object information to the the row
                        dataRow["EmployeeID"] = thisExerciseClass.EmployeeID;
                        dataRow["RoomID"] = thisExerciseClass.RoomID;
                        dataRow["Description"] = thisExerciseClass.Description;
                        dataRow["Difficulty"] = thisExerciseClass.Difficulty;
                        dataRow["StartDateOfClass"] = thisExerciseClass.StartDateOfClass;
                        dataRow["NoOfWeeks"] = thisExerciseClass.NoOfWeeks;
                        dataRow["EndDateOfClass"] = thisExerciseClass.EndDateOfClass;
                        dataRow["CurrentNoOfParticipants"] = thisExerciseClass.CurrentNumberOfParticipants;
                        dataRow["MaxNoOfParticipants"] = thisExerciseClass.MaxNumberOfParticipants;
                        dataRow["ExternalClass"] = thisExerciseClass.ExternalClass;
                        dataRow["WeeklyCostOfClass"] = thisExerciseClass.WeeklyCostOfClass;
                        dataRow["TotalCostOfClass"] = thisExerciseClass.TotalCostOfClass;

                        //Check if the external company field is 0
                        if (thisExerciseClass.ExternalCompanyID != 0)
                        {
                            //If it is not 0, convert
                            dataRow["ExternalCompanyID"] = thisExerciseClass.ExternalCompanyID;
                        }
                        else
                        {
                            //If it is assign null
                            dataRow["ExternalCompanyID"] = null;

                        }//End If  


                        //Write changes to the DB
                        writeChangesToExerciseClassToTheDB();

                        //Break out
                        break;

                    }//End If

                }//End Foreach
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End UpdateExerciseClassDatabase


        public void DeleteExerciseClassRecord(ExerciseClass thisExerciseClass)
        {
            try
            {
                //Write changes to the ExerciseClass database
                foreach (DataRow row in ds.Tables["ExerciseClass"].Rows)
                {
                    if ((int)row["ExerciseClassID"] == thisExerciseClass.ExerciseClassID)
                    {
                        //Delete the row
                        row.Delete();

                        //Write changes to the DB
                        writeChangesToExerciseClassToTheDB();

                        //Break out
                        break;

                    }//End If

                }//End Foreach
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End DeleteExerciseClassRecord


        public void writeChangesToExerciseClassToTheDB()
        {
            try
            {
                //Update the sql table to reflect the changes
                da.Update(ds.Tables["ExerciseClass"]);
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End writeChangesToExerciseClassToTheDB


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
