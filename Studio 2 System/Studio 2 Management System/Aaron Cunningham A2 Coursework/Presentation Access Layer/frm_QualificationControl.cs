using Studio_2_Management_System.Business_Access_Layer;
using Studio_2_Management_System.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Studio_2_Management_System.Presentation_Access_Layer
{
    public partial class frm_QualificationControl : Form
    {
        //-------------------------- Fields --------------------------\\
        StaffQualificationTable staffQualTable = new StaffQualificationTable();
        QualificationTable qualTable = new QualificationTable();

        List<StaffQualification> lstStaffQualifications = new List<StaffQualification>();
        List<Qualification> lstQualifications = new List<Qualification>();
        List<Employee> lstEmployees = new List<Employee>();

        List<StaffQualification> lstStaffQualificationSearchResults = new List<StaffQualification>();
        List<Qualification> lstQualificationSearchResults = new List<Qualification>();

        StaffQualification currentlySelectedStaffQualification = new StaffQualification();
        Qualification currentlySelectedQualification = new Qualification();

        int posInStaffQualificationList = 0;
        int posInQualificationList = 0;
        int nextStaffQualID = 1;
        int nextQualID = 1;        

        int staffQualificationIDInput = 1;
        int qualificationIDInput = 1;
        int employeeIDInput = 1;
        DateTime issueDateInput = DateTime.Today;
        DateTime expiryDateInput = DateTime.Today;
        string descriptionInput = "";

        int selectedSearchField = 0;
        int selectedIndexFieldForSort = 0;
        int selectedAscendOrDescend = 0;
        
        //-------------------------- Constructors/Load/Close Methods --------------------------\\

        public frm_QualificationControl()
        {
            InitializeComponent();

        }//End Default Constructor


        public frm_QualificationControl(StaffQualificationTable StaffQualTable, QualificationTable QualTable, List<StaffQualification> LstStaffQualifications, List<Qualification> LstQualifications, List<Employee> LstEmployees)
        {
            InitializeComponent();

            //Read in the tables
            staffQualTable = StaffQualTable;
            qualTable = QualTable;
            lstStaffQualifications = LstStaffQualifications;
            lstQualifications = LstQualifications;
            lstEmployees = LstEmployees;            

        }//End Default Constructor


        private void frm_QualificationControl_Load(object sender, EventArgs e)
        {
            try
            {
                //Set the Min and max dates for the date time pickers
                dtp_StaffQualificationTabIssueDate.MinDate = DateTime.Today.AddYears(-50);
                dtp_StaffQualificationTabIssueDate.MaxDate = DateTime.Today;

                dtp_StaffQualificationTabExpiryDate.MinDate = DateTime.Today;
                dtp_StaffQualificationTabExpiryDate.MaxDate = DateTime.Today.AddYears(101);

                //Set up the staff qual tab
                setUpStaffQualificationsTab();


                //Assign the next IDs and display the details of the first Qual/StaffQual
                //Next qualification ID
                if (lstQualifications.Count > 0)
                {
                    //Assign the last ID + 1
                    nextQualID = lstQualifications[lstQualifications.Count - 1].QualificationID + 1;

                    //Display the first qualification
                    displayQualificationDetails(lstQualifications[0]);

                }//End If


                if (lstStaffQualifications.Count > 0)
                {
                    //Assign the last ID + 1
                    nextStaffQualID = lstStaffQualifications[lstStaffQualifications.Count - 1].StaffQualificationID + 1;

                    //Display the first staff qualification
                    displayStaffQualificationDetails(lstStaffQualifications[0]);

                }//End If
                
                //Add the on closing event
                this.FormClosing += frm_QualificationControl_FormClosing;

                //Set the datasources
                dgv_QualificationsList.DataSource = lstQualifications;
                dgv_StaffQualificationsList.DataSource = lstStaffQualifications;

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
        }//End frm_QualificationControl_Load


        void frm_QualificationControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //Create a new version of the main form
                frm_MainMenu frm_UpdatedMenu = new frm_MainMenu();

                //Show the other form
                frm_UpdatedMenu.Show();

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End frm_QualificationControl_FormClosing


        //---------------------------------- Addition ----------------------------------\\

        private void addStaffQualification()
        {
            try
            {
                //Create new record and Add to List
                lstStaffQualifications.Add(new StaffQualification());

                //Set position in list
                posInStaffQualificationList = lstStaffQualifications.Count - 1;

                //Display blank record
                displayStaffQualificationDetails(lstStaffQualifications[posInStaffQualificationList]);

                //Disable controls
                disableOrEnableStaffQualificationControls(false);

                //Set ID field
                txt_StaffQualificationTabStaffQualificationID.Text = nextStaffQualID.ToString();

                //Clear all of the autofilled fields
                txt_StaffQualificationTabDescription.Text = "";
                txt_StaffQualificationTabFullName.Text = "";
                cmb_StaffQualificationTabEmployeeID.Text = "";
                cmb_StaffQualificationTabQualificationID.Text = "";

                //Enable group boxes and submit button
                grp_StaffQualificationsTabEmployeeDetails.Enabled = true;
                grp_StaffQualificationsTabQualificationDetails.Enabled = true;
                btn_StaffQualificationTabAddSubmitStaffQualification.Enabled = true;

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End addStaffQualification


        private void addQualification()
        {
            try
            {
                //Create new record and Add to List
                lstQualifications.Add(new Qualification());

                //Set position in list
                posInQualificationList = lstQualifications.Count - 1;

                //Display blank record
                displayQualificationDetails(lstQualifications[posInQualificationList]);

                //Disable controls
                disableOrEnableQualificationControls(false);

                //Set ID field
                txt_QualificationTabQualificationID.Text = nextQualID.ToString();

                //Enable group boxes and submit button
                grp_QualificationTabQualificationDetails.Enabled = true;
                btn_QualificationTabAddSubmit.Enabled = true;

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End addQualification

        //---------------------------------- Deletion ----------------------------------\\

        private void deleteStaffQualification()
        {
            try
            {
                //Check if there are any StaffQualifications in list
                if (lstStaffQualifications.Count > 0)
                {
                    //Ask user if they wish to delete user
                    DialogResult answer = MessageBox.Show("Are you sure you want to delete the record of " + txt_StaffQualificationTabFullName.Text + "'s qualification?", "Are You sure you want to delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    //check response
                    if (answer == DialogResult.Yes)
                    {
                        //Delete from the database
                        staffQualTable.DeleteStaffQualificationRecord(lstStaffQualifications[posInStaffQualificationList]);

                        //Refresh List
                        refreshStaffQualificationList();

                        //Refresh data grid
                        refreshStaffQualificationDataGrid();

                        //Inform user the account has been deleted
                        informUser("Staff Qualification Record Deletion Successful.", "Staff Qualification Record Deleted");

                    }
                    else
                    {
                        informUser("Staff Qualification Record Deletion Cancelled", "Deletion Cancelled");

                    }//End If

                }
                else
                {
                    informUser("Staff Qualification List Empty -  Deletion Cancelled", "Deletion Cancelled");

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End deleteStaffQualification


        private void deleteQualification()
        {
            //Declare Variables
            bool hasDependentRecord = false;

            try
            {                
                //Check if there are any Qualifications in list
                if (lstQualifications.Count > 0)
                {
                    //Check if it has dependent records on the system
                    checkDependency(ref hasDependentRecord, lstStaffQualifications.Exists(staffQual => staffQual.QualificationID.Equals(lstQualifications[posInQualificationList].QualificationID)), "qualification", "staff qualification");

                    //If no dependent records
                    if (!hasDependentRecord)
                    {
                        //Ask user if they wish to delete user
                        DialogResult answer = MessageBox.Show("Are you sure you want to delete the record of " + lstQualifications[posInQualificationList].Description + "?", "Are You sure you want to delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        //check response
                        if (answer == DialogResult.Yes)
                        {
                            //Delete from the database
                            qualTable.DeleteQualificationRecord(lstQualifications[posInQualificationList]);

                            //refresh list
                            refreshQualificationList();

                            //Refresh data grid
                            refreshQualificationDataGrid();

                            //Inform user the account has been deleted
                            informUser("Account Deletion Successful.", "Account Deleted");
                                                        
                        }
                        else
                        {
                            informUser(" Qualification Record Deletion Cancelled", "Deletion Cancelled");

                        }//End If

                    }//End If                    

                }
                else
                {
                    informUser(" Qualification List Empty -  Deletion Cancelled", "Deletion Cancelled");

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End deleteQualification

        //---------------------------------- Search ----------------------------------\\
                
        private void searchStaffQualification()
        {
            string searchTerm = "";
            bool StaffQualificationFound = false;

            try
            {
                //Clear the current search list and data grid view
                lstStaffQualificationSearchResults.Clear();
                dgv_StaffQualificationsList.DataSource = "";

                if (!String.IsNullOrWhiteSpace(mst_StaffQualificationTabSearchTerm.Text))
                {
                    //Assign variable
                    searchTerm = mst_StaffQualificationTabSearchTerm.Text.Trim().ToLower();

                    //Switch on selected search field
                    switch (selectedSearchField)
                    {

                        case 0:

                            foreach (StaffQualification StaffQualification in lstStaffQualifications)
                            {
                                if (StaffQualification.StaffQualificationID.ToString() == searchTerm)
                                {
                                    //Has the same StaffQualification ID therefore assign to the list
                                    lstStaffQualificationSearchResults.Add(StaffQualification);

                                    //StaffQualification Found
                                    StaffQualificationFound = true;

                                }//End If

                            }//End Foreach

                            //Display on screen message if no results found
                            messageForStaffQualificationFound(StaffQualificationFound, "Staff Qualification ID", searchTerm);

                            break;

                        case 1:

                            foreach (StaffQualification StaffQualification in lstStaffQualifications)
                            {
                                if (StaffQualification.QualificationID.ToString() == searchTerm)
                                {
                                    //Has the same MemberID therefore assign to the list
                                    lstStaffQualificationSearchResults.Add(StaffQualification);

                                    //StaffQualification Found
                                    StaffQualificationFound = true;

                                }//End If

                            }//End Foreach

                            //Display on screen message if no results found
                            messageForStaffQualificationFound(StaffQualificationFound, "Qualification ID", searchTerm);

                            break;


                        case 2:

                            foreach (StaffQualification StaffQualification in lstStaffQualifications)
                            {
                                if (StaffQualification.EmployeeID.ToString() == searchTerm)
                                {
                                    //Has the same Booking ID therefore assign to the list
                                    lstStaffQualificationSearchResults.Add(StaffQualification);

                                    //StaffQualification Found
                                    StaffQualificationFound = true;

                                }//End If

                            }//End Foreach

                            //Display on screen message if no results found
                            messageForStaffQualificationFound(StaffQualificationFound, "Employee ID", searchTerm);

                            break;



                        case 3:

                            foreach (StaffQualification StaffQualification in lstStaffQualifications)
                            {
                                if (StaffQualification.IssueDate.ToString() == searchTerm)
                                {
                                    //Has the same StaffQualification Method ID therefore assign to the list
                                    lstStaffQualificationSearchResults.Add(StaffQualification);

                                    //StaffQualification Found
                                    StaffQualificationFound = true;

                                }//End If

                            }//End Foreach

                            //Display on screen message if no results found
                            messageForStaffQualificationFound(StaffQualificationFound, "StaffQualification Method ID", searchTerm);

                            break;



                        case 4:

                            foreach (StaffQualification StaffQualification in lstStaffQualifications)
                            {
                                if (StaffQualification.ExpiryDate.ToString() == searchTerm)
                                {
                                    //Has the same Amount Paid therefore assign to the list
                                    lstStaffQualificationSearchResults.Add(StaffQualification);

                                    //StaffQualification Found
                                    StaffQualificationFound = true;

                                }//End If

                            }//End Foreach

                            //Display on screen message if no results found
                            messageForStaffQualificationFound(StaffQualificationFound, "Expiry Date", searchTerm);

                            break;

                    }//End Switch

                    //set the data source to the search results
                    dgv_StaffQualificationsList.DataSource = lstStaffQualificationSearchResults;

                }
                else
                {
                    //Invalid Search
                    errorToUser("The search you tried to perform was using an invalid search term.\nPlease try again.", "Invalid Search Term");

                }//End If

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End searchStaffQualification


        private void searchQualification()
        {
            string searchTerm = "";
            bool QualificationFound = false;

            try
            {
                //Clear the current search list and data grid view
                lstQualificationSearchResults.Clear();
                dgv_QualificationsList.DataSource = "";

                if (!String.IsNullOrWhiteSpace(mst_QualificationsTabSearchTerm.Text))
                {
                    //Assign variable
                    searchTerm = mst_QualificationsTabSearchTerm.Text.Trim().ToLower();

                    //Switch on selected search field
                    switch (selectedSearchField)
                    {

                        case 0:

                            foreach (Qualification Qualification in lstQualifications)
                            {
                                if (Qualification.QualificationID.ToString() == searchTerm)
                                {
                                    //Has the same Qualification ID therefore assign to the list
                                    lstQualificationSearchResults.Add(Qualification);

                                    //Qualification Found
                                    QualificationFound = true;

                                }//End If

                            }//End Foreach

                            //Display on screen message if no results found
                            messageForQualificationFound(QualificationFound, " Qualification ID", searchTerm);

                            break;

                        case 1:

                            foreach (Qualification Qualification in lstQualifications)
                            {
                                if (Qualification.Description.ToLower().Contains(searchTerm))
                                {
                                    //Has the same description therefore assign to the list
                                    lstQualificationSearchResults.Add(Qualification);

                                    //Qualification Found
                                    QualificationFound = true;

                                }//End If

                            }//End Foreach

                            //Display on screen message if no results found
                            messageForQualificationFound(QualificationFound, "Description", searchTerm);

                            break;

                    }//End Switch

                    //set the data source to the search results
                    dgv_QualificationsList.DataSource = lstQualificationSearchResults;

                }
                else
                {
                    //Invalid Search
                    errorToUser("The search you tried to perform was using an invalid search term.\nPlease try again.", "Invalid Search Term");

                }//End If

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End searchQualification

        //---------------------------------- Sort ----------------------------------\\

        private void sortStaffQualification()
        {
            try
            {
                switch (selectedIndexFieldForSort)
                {
                    case 0:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending StaffQualificationID
                            lstStaffQualifications = lstStaffQualifications.OrderBy(StaffQualification => StaffQualification.StaffQualificationID).ToList();

                            //Refresh the data grid
                            refreshStaffQualificationDataGrid();

                        }
                        else
                        {
                            //Sort by descending StaffQualificationID
                            lstStaffQualifications = lstStaffQualifications.OrderByDescending(StaffQualification => StaffQualification.StaffQualificationID).ToList();

                            //Refresh the data grid
                            refreshStaffQualificationDataGrid();

                        }//end if

                        break;


                    case 1:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending QualificationID
                            lstStaffQualifications = lstStaffQualifications.OrderBy(StaffQualification => StaffQualification.QualificationID).ToList();

                            //Refresh the data grid
                            refreshStaffQualificationDataGrid();
                        }
                        else
                        {
                            //Sort by descending QualificationID
                            lstStaffQualifications = lstStaffQualifications.OrderByDescending(StaffQualification => StaffQualification.QualificationID).ToList();

                            //Refresh the data grid
                            refreshStaffQualificationDataGrid();

                        }//end if

                        break;


                    case 2:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending EmployeeID
                            lstStaffQualifications = lstStaffQualifications.OrderBy(StaffQualification => StaffQualification.EmployeeID).ToList();

                            //Refresh the data grid
                            refreshStaffQualificationDataGrid();
                        }
                        else
                        {
                            //Sort by descending EmployeeID
                            lstStaffQualifications = lstStaffQualifications.OrderByDescending(StaffQualification => StaffQualification.EmployeeID).ToList();

                            //Refresh the data grid
                            refreshStaffQualificationDataGrid();

                        }//end if

                        break;


                    case 3:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending IssueDate
                            lstStaffQualifications = lstStaffQualifications.OrderBy(StaffQualification => StaffQualification.IssueDate).ToList();

                            //Refresh the data grid
                            refreshStaffQualificationDataGrid();
                        }
                        else
                        {
                            //Sort by descending IssueDate
                            lstStaffQualifications = lstStaffQualifications.OrderByDescending(StaffQualification => StaffQualification.IssueDate).ToList();

                            //Refresh the data grid
                            refreshStaffQualificationDataGrid();

                        }//end if

                        break;


                    case 4:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending Date Of ExpiryDate
                            lstStaffQualifications = lstStaffQualifications.OrderBy(StaffQualification => StaffQualification.ExpiryDate).ToList();

                            //Refresh the data grid
                            refreshStaffQualificationDataGrid();
                        }
                        else
                        {
                            //Sort by descending Date Of ExpiryDate
                            lstStaffQualifications = lstStaffQualifications.OrderByDescending(StaffQualification => StaffQualification.ExpiryDate).ToList();

                            //Refresh the data grid
                            refreshStaffQualificationDataGrid();

                        }//end if

                        break;

                }//End Switch
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End sortStaffQualification


        private void sortQualification()
        {
            try
            {
                switch (selectedIndexFieldForSort)
                {
                    case 0:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending QualificationID
                            lstQualifications = lstQualifications.OrderBy(Qualification => Qualification.QualificationID).ToList();

                            //Refresh the data grid
                            refreshQualificationDataGrid();

                        }
                        else
                        {
                            //Sort by descending QualificationID
                            lstQualifications = lstQualifications.OrderByDescending(Qualification => Qualification.QualificationID).ToList();

                            //Refresh the data grid
                            refreshQualificationDataGrid();

                        }//end if

                        break;


                    case 1:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending Description
                            lstQualifications = lstQualifications.OrderBy(Qualification => Qualification.Description).ToList();

                            //Refresh the data grid
                            refreshQualificationDataGrid();
                        }
                        else
                        {
                            //Sort by descending Description
                            lstQualifications = lstQualifications.OrderByDescending(Qualification => Qualification.Description).ToList();

                            //Refresh the data grid
                            refreshQualificationDataGrid();

                        }//end if

                        break;

                }//End Switch
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End sortQualification

        //---------------------------------- Validation ----------------------------------\\

        private void validateStaffQualification(ref bool ifAllValid)
        {
            try
            {
                //-------------------------- Issue Date --------------------------\\

                //Read in the issue date as it is validated by the date time picker
                issueDateInput = dtp_StaffQualificationTabIssueDate.Value;

                //-------------------------- Expiry Date --------------------------\\

                //Determine if the expiry date is required
                if (chb_StaffQualificationTabRequiresRepeat.Checked)
                {
                    //Read in the expiry date
                    expiryDateInput = dtp_StaffQualificationTabExpiryDate.Value;

                }
                else
                {
                    //Else add 100 years to Today's date
                    expiryDateInput = DateTime.Today.AddYears(100);

                }//End If


                //-------------------------- Qualification ID --------------------------\\
                readComboBoxSelection(ref ifAllValid, cmb_StaffQualificationTabQualificationID.Text, "Qualification ID", ref qualificationIDInput);

                //-------------------------- Employee ID --------------------------\\
                readComboBoxSelection(ref ifAllValid, cmb_StaffQualificationTabEmployeeID.Text, "Employee ID", ref employeeIDInput);

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End validateStaffQualification


        private void validateQualification(ref bool ifAllValid)
        {
            try
            {
                //------------------ Description ------------------\\
                //If it is less than the char limit
                if (txt_QualificationTabDescription.Text.Length <= 100)
                {
                    //Read in the description
                    descriptionInput = txt_QualificationTabDescription.Text;
                }
                else
                {
                    //Mark invalid
                    ifAllValid = false;

                    //Inform user
                    errorToUser("The description entered was too long.\nIt must be at max. 100 characters long,\nPlease Try Again", "Invalid Description Entry");

                }//End If                

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End validateQualification


        private void readComboBoxSelection(ref bool ifAllValid, string inputFromCmb, string fieldName, ref int inputVariable)
        {
            try
            {
                //check if the combobox's selected item is not 0 i.e. chosen
                if (inputFromCmb != "")
                {
                    //If it is not 0 then convert to int and assign to the variable
                    inputVariable = Convert.ToInt32(inputFromCmb);
                }
                else
                {
                    //inform user no *Insert field here* has been selected
                    errorToUser(fieldName + " was not selected\nPlease Try Again", fieldName + " Error");

                    //mark invalid
                    ifAllValid = false;

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }


        }//End readComboBoxSelection


        private void checkDependency(ref bool hasDependentRecord, bool dependentRecordExists, string fieldDeleting, string fieldDependent)
        {
            try
            {
                //if there is a dependent record
                if (dependentRecordExists)
                {
                    //mark has dependent true
                    hasDependentRecord = true;

                    //Inform user of issue
                    errorToUser("The " + fieldDeleting + " you are trying to delete has " + fieldDependent + " records that need to be removed first.\nPlease delete these before proceeding", "Dependent Record Found");

                }//End If

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);

            }

        }//End checkDependency

        //---------------------------------- Staff Qualification Tab ----------------------------------\\

        private void btn_StaffQualificationTabFirstStaffQualification_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstStaffQualifications.Count >= 1)
                {
                    //The list is populated and should go to position 0
                    posInStaffQualificationList = 0;

                    //Retrieve StaffQualification at position
                    currentlySelectedStaffQualification = lstStaffQualifications[posInStaffQualificationList];

                    //Display details
                    displayStaffQualificationDetails(currentlySelectedStaffQualification);

                }
                else
                {
                    //Inform user there are no StaffQualifications in list
                    errorToUser("No StaffQualification Records exist.", "List Error");

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            } 

        }//End btn_StaffQualificationTabFirstStaffQualification_Click
               

        private void btn_StaffQualificationTabPreviousStaffQualification_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstStaffQualifications.Count >= 1)
                {
                    //check it is not at the start of the list
                    if (posInStaffQualificationList != 0)
                    {
                        //The list is populated and should go to the previous position
                        posInStaffQualificationList--;

                        //Retrieve StaffQualification at position
                        currentlySelectedStaffQualification = lstStaffQualifications[posInStaffQualificationList];

                        //Display details
                        displayStaffQualificationDetails(currentlySelectedStaffQualification);

                    }
                    else
                    {
                        //Inform user they are at the end of the list
                        informUser("You are at the start of the list", "Start of list");

                    }//End If

                }
                else
                {
                    //Inform user there are no StaffQualifications in list
                    errorToUser("No StaffQualification Records exist.", "List Error");

                }//End If

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            } 

        }//End btn_StaffQualificationTabPreviousStaffQualification_Click


        private void btn_StaffQualificationTabNextStaffQualification_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstStaffQualifications.Count >= 1)
                {
                    //check it is not at the end of the list
                    if (posInStaffQualificationList != lstStaffQualifications.Count - 1)
                    {
                        //The list is populated and should go to the next position
                        posInStaffQualificationList++;

                        //Retrieve StaffQualification at position
                        currentlySelectedStaffQualification = lstStaffQualifications[posInStaffQualificationList];

                        //Display details
                        displayStaffQualificationDetails(currentlySelectedStaffQualification);

                    }
                    else
                    {
                        //Inform user they are at the end of the list
                        informUser("You are at the end of the list", "End of list");

                    }//End If

                }
                else
                {
                    //Inform user there are no StaffQualifications in list
                    errorToUser("No StaffQualification Records exist.", "List Error");

                }//End If

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            } 

        }//End btn_StaffQualificationTabNextStaffQualification_Click


        private void btn_StaffQualificationTabLastStaffQualification_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstStaffQualifications.Count >= 1)
                {
                    //The list is populated and should go to position 0
                    posInStaffQualificationList = lstStaffQualifications.Count - 1;

                    //Retrieve member at position
                    currentlySelectedStaffQualification = lstStaffQualifications[posInStaffQualificationList];

                    //Display details
                    displayStaffQualificationDetails(currentlySelectedStaffQualification);

                }
                else
                {
                    //Inform user there are no StaffQualifications in list
                    errorToUser("No StaffQualification Records exist.", "List Error");

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            } 

        }//End btn_StaffQualificationTabLastStaffQualification_Click


        private void btn_StaffQualificationTabAddStaffQualification_Click(object sender, EventArgs e)
        {
            try
            {
                addStaffQualification();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_StaffQualificationTabAddStaffQualification_Click


        private void btn_StaffQualificationTabAddSubmitStaffQualification_Click(object sender, EventArgs e)
        {
            //Declare Variables
            bool ifAllValid = true;

            try
            {
                //Validate the details
                validateStaffQualification(ref ifAllValid);

                //If all of the entries are valid
                if (ifAllValid)
                {
                    //Assign to the ID input
                    staffQualificationIDInput = nextStaffQualID;

                    //Increase next ID
                    nextStaffQualID++;

                    //Assign details to the record
                    lstStaffQualifications[posInStaffQualificationList] = new StaffQualification(staffQualificationIDInput, qualificationIDInput, employeeIDInput, issueDateInput, expiryDateInput);

                    //re-enable all controls again
                    disableOrEnableStaffQualificationControls(true);

                    //disable submit and groupboxes
                    grp_StaffQualificationsTabEmployeeDetails.Enabled = false;
                    grp_StaffQualificationsTabQualificationDetails.Enabled = false;
                    btn_StaffQualificationTabAddSubmitStaffQualification.Enabled = false;

                    //Add to database
                    staffQualTable.AddNewStaffQualification(lstStaffQualifications[posInStaffQualificationList]);

                    //Refresh list from database
                    refreshStaffQualificationList();

                    //Refresh data source
                    refreshStaffQualificationDataGrid();

                    //Inform user that the Staff Qual has been added
                    informUser("Staff Qualification addition successful", "Addition Successful");

                }//End If

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_StaffQualificationTabAddSubmitStaffQualification_Click


        private void btn_StaffQualificationTabDeleteStaffQualification_Click(object sender, EventArgs e)
        {
            try
            {
                deleteStaffQualification();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_StaffQualificationTabDeleteStaffQualification_Click


        private void btn_StaffQualificationTabEditStaffQualification_Click(object sender, EventArgs e)
        {
            try
            {
                //Disable controls
                disableOrEnableStaffQualificationControls(false);

                //Enable group boxes and submit button
                grp_StaffQualificationsTabEmployeeDetails.Enabled = true;
                grp_StaffQualificationsTabQualificationDetails.Enabled = true;
                btn_StaffQualificationTabEditSubmitStaffQualification.Enabled = true;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_StaffQualificationTabEditStaffQualification_Click


        private void btn_StaffQualificationTabEditSubmitStaffQualification_Click(object sender, EventArgs e)
        {
            //Declare Variables
            bool ifAllValid = true;

            try
            {
                //Validate the edits
                validateStaffQualification(ref ifAllValid);

                //If the edits are valid
                if (ifAllValid)
                {
                    //Assign record
                    StaffQualification staffQualUpdating = lstStaffQualifications[posInStaffQualificationList];

                    //update details
                    staffQualUpdating.QualificationID = qualificationIDInput;
                    staffQualUpdating.EmployeeID = employeeIDInput;
                    staffQualUpdating.IssueDate = issueDateInput;
                    staffQualUpdating.ExpiryDate = expiryDateInput;

                    //reactivate buttons
                    disableOrEnableStaffQualificationControls(true);

                    //disable submit and group boxes
                    grp_StaffQualificationsTabEmployeeDetails.Enabled = false;
                    grp_StaffQualificationsTabQualificationDetails.Enabled = false;
                    btn_StaffQualificationTabEditSubmitStaffQualification.Enabled = false;

                    //Update database
                    staffQualTable.UpdateStaffQualificationDatabase(staffQualUpdating);

                    //refresh datasource
                    refreshStaffQualificationDataGrid();

                    //Inform user of success
                    informUser("Update Successful", "Successful Update");

                }//End If

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_StaffQualificationTabEditSubmitStaffQualification_Click


        private void btn_StaffQualificationsTabSort_Click(object sender, EventArgs e)
        {
            try
            {
                sortStaffQualification();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_StaffQualificationsTabSort_Click


        private void btn_StaffQualificationsTabSearch_Click(object sender, EventArgs e)
        {
            try
            {
                searchStaffQualification();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_StaffQualificationsTabSearch_Click


        private void btn_StaffQualificationsTabShowFullList_Click(object sender, EventArgs e)
        {
            try
            {
                //Refresh data source
                dgv_StaffQualificationsList.DataSource = "";
                dgv_StaffQualificationsList.DataSource = lstStaffQualifications;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_StaffQualificationsTabShowFullList_Click


        private void chb_StaffQualificationTabRequiresRepeat_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //Set the state of the expiry date time picker to the same as the checkbox
                dtp_StaffQualificationTabExpiryDate.Enabled = chb_StaffQualificationTabRequiresRepeat.Checked;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);

            }

        }//End chb_StaffQualificationTabRequiresRepeat_CheckedChanged


        private void cmb_StaffQualificationTabSortOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Assign the index to sort by
                selectedIndexFieldForSort = cmb_StaffQualificationTabSortOptions.SelectedIndex;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End cmb_StaffQualificationTabSortOptions_SelectedIndexChanged


        private void cmb_StaffQualificationTabAscendOrDescend_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Assign whether to sort in ascending or descending
                selectedAscendOrDescend = cmb_StaffQualificationTabAscendOrDescend.SelectedIndex;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End cmb_StaffQualificationTabAscendOrDescend_SelectedIndexChanged


        private void cmb_StaffQualificationTabSearchField_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Assign field by which to search
                selectedSearchField = cmb_StaffQualificationTabSearchField.SelectedIndex;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End cmb_StaffQualificationTabSearchField_SelectedIndexChanged


        private void cmb_StaffQualificationTabQualificationID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Set the textbox to the description of the qualification selected
                txt_StaffQualificationTabDescription.Text = lstQualifications.Find(qual => qual.QualificationID.Equals((int)cmb_StaffQualificationTabQualificationID.SelectedItem)).Description;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End cmb_StaffQualificationTabQualificationID_SelectedIndexChanged


        private void cmb_StaffQualificationTabEmployeeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Find the employee and temp assign them
                Employee employeeSelected = lstEmployees.Find(employee => employee.EmployeeID.Equals(cmb_StaffQualificationTabEmployeeID.SelectedItem));

                //Set the textbox to the full name of the employee selected
                txt_StaffQualificationTabFullName.Text = employeeSelected.FirstName + " " + employeeSelected.Surname;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End cmb_StaffQualificationTabEmployeeID_SelectedIndexChanged

        //---------------------------------- Qualification Tab ----------------------------------\\

        private void btn_QualificationsTabFirstQualification_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstQualifications.Count >= 1)
                {
                    //The list is populated and should go to position 0
                    posInQualificationList = 0;

                    //Retrieve Qualification at position
                    currentlySelectedQualification = lstQualifications[posInQualificationList];

                    //Display details
                    displayQualificationDetails(currentlySelectedQualification);

                }
                else
                {
                    //Inform user there are no Qualifications in list
                    errorToUser("No Qualification Records exist.", "List Error");

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_QualificationTabFirstQualification_Click


        private void btn_QualificationsTabPreviousQualification_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstQualifications.Count >= 1)
                {
                    //check it is not at the start of the list
                    if (posInQualificationList != 0)
                    {
                        //The list is populated and should go to the previous position
                        posInQualificationList--;

                        //Retrieve Qualification at position
                        currentlySelectedQualification = lstQualifications[posInQualificationList];

                        //Display details
                        displayQualificationDetails(currentlySelectedQualification);

                    }
                    else
                    {
                        //Inform user they are at the end of the list
                        informUser("You are at the start of the list", "Start of list");

                    }//End If

                }
                else
                {
                    //Inform user there are no Qualifications in list
                    errorToUser("No Qualification Records exist.", "List Error");

                }//End If

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_QualificationTabPreviousQualification_Click


        private void btn_QualificationsTabNextQualification_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstQualifications.Count >= 1)
                {
                    //check it is not at the end of the list
                    if (posInQualificationList != lstQualifications.Count - 1)
                    {
                        //The list is populated and should go to the next position
                        posInQualificationList++;

                        //Retrieve Qualification at position
                        currentlySelectedQualification = lstQualifications[posInQualificationList];

                        //Display details
                        displayQualificationDetails(currentlySelectedQualification);

                    }
                    else
                    {
                        //Inform user they are at the end of the list
                        informUser("You are at the end of the list", "End of list");

                    }//End If

                }
                else
                {
                    //Inform user there are no Qualifications in list
                    errorToUser("No Qualification Records exist.", "List Error");

                }//End If

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_QualificationTabNextQualification_Click


        private void btn_QualificationsTabLastQualification_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstQualifications.Count >= 1)
                {
                    //The list is populated and should go to position 0
                    posInQualificationList = lstQualifications.Count - 1;

                    //Retrieve member at position
                    currentlySelectedQualification = lstQualifications[posInQualificationList];

                    //Display details
                    displayQualificationDetails(currentlySelectedQualification);

                }
                else
                {
                    //Inform user there are no Qualifications in list
                    errorToUser("No Qualification Records exist.", "List Error");

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_QualificationTabLastQualification_Click


        private void btn_QualificationsTabAddQualification_Click(object sender, EventArgs e)
        {
            try
            {
                addQualification();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_QualificationTabAddQualification_Click


        private void btn_QualificationsTabAddSubmit_Click(object sender, EventArgs e)
        {
            bool ifAllValid = true;

            try
            {
                //Validate the details
                validateQualification(ref ifAllValid);

                //If all of the entries are valid
                if (ifAllValid)
                {
                    //Assign to the ID input
                    qualificationIDInput = nextQualID;

                    //Increase next ID
                    nextQualID++;

                    //Assign details to the record
                    lstQualifications[posInQualificationList] = new Qualification(qualificationIDInput, descriptionInput);

                    //re-enable all controls again
                    disableOrEnableQualificationControls(true);

                    //disable submit and groupboxes
                    grp_QualificationTabQualificationDetails.Enabled = false;
                    btn_QualificationTabAddSubmit.Enabled = false;

                    //Add to database
                    qualTable.AddNewQualification(lstQualifications[posInQualificationList]);

                    //Refresh List from Database
                    refreshQualificationList();

                    //Refresh data source
                    refreshQualificationDataGrid();

                    //Inform user that the Qual has been added
                    informUser("Qualification addition successful", "Addition Successful");

                }//End If

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_QualificationTabAddSubmitQualification_Click


        private void btn_QualificationsTabDeleteQualification_Click(object sender, EventArgs e)
        {
            try
            {
                deleteQualification();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_QualificationTabDeleteQualification_Click


        private void btn_QualificationsTabEditQualification_Click(object sender, EventArgs e)
        {
            try
            {
                //Disable controls
                disableOrEnableQualificationControls(false);

                //Enable group boxes and submit button
                grp_QualificationTabQualificationDetails.Enabled = true;
                btn_QualificationTabEditSubmit.Enabled = true;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_QualificationTabEditQualification_Click


        private void btn_QualificationsTabEditSubmit_Click(object sender, EventArgs e)
        {
            //Declare Variables
            bool ifAllValid = true;

            try
            {
                //Validate the edits
                validateQualification(ref ifAllValid);

                //If edits were valid
                if (ifAllValid)
                {
                    //Assign record
                    Qualification QualUpdating = lstQualifications[posInQualificationList];

                    //update details
                    QualUpdating.Description = descriptionInput;

                    //reactivate buttons
                    disableOrEnableQualificationControls(true);

                    //disable submit and group boxes
                    grp_QualificationTabQualificationDetails.Enabled = false;
                    btn_QualificationTabEditSubmit.Enabled = false;

                    //Update database
                    qualTable.UpdateQualificationDatabase(QualUpdating);

                    //refresh datasource
                    refreshQualificationDataGrid();

                    //Inform user of success
                    informUser("Update Successful", "Successful Update");

                }//End If               

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_QualificationTabEditSubmitQualification_Click


        private void btn_QualificationsTabSort_Click(object sender, EventArgs e)
        {
            try
            {
                sortQualification();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_QualificationsTabSort_Click


        private void btn_QualificationsTabSearch_Click(object sender, EventArgs e)
        {
            try
            {
                searchQualification();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_QualificationsTabSearch_Click


        private void btn_QualificationsTabShowFullList_Click(object sender, EventArgs e)
        {
            try
            {
                //Refresh data source
                dgv_QualificationsList.DataSource = "";
                dgv_QualificationsList.DataSource = lstQualifications;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_QualificationsTabShowFullList_Click


        private void cmb_QualificationsTabSortOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Assign the index to sort by
                selectedIndexFieldForSort = cmb_QualificationsTabSortOptions.SelectedIndex;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End cmb_QualificationTabSortOptions_SelectedIndexChanged


        private void cmb_QualificationsTabAscendingOrDescending_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Assign whether to sort in ascending or descending
                selectedAscendOrDescend = cmb_QualificationsTabAscendingOrDescending.SelectedIndex;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End cmb_QualificationTabAscendOrDescend_SelectedIndexChanged


        private void cmb_QualificationsTabSearchField_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Assign field by which to search
                selectedSearchField = cmb_QualificationsTabSearchField.SelectedIndex;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End cmb_QualificationTabSearchField_SelectedIndexChanged
        
        //---------------------------------- Display/Disable/Enable Methods ----------------------------------\\

        private void displayStaffQualificationDetails(StaffQualification currentlySelectedStaffQualification)
        {
            try
            {
                //Set onscreen controls to field values
                txt_StaffQualificationTabStaffQualificationID.Text = currentlySelectedStaffQualification.StaffQualificationID.ToString();
                dtp_StaffQualificationTabIssueDate.Value = currentlySelectedStaffQualification.IssueDate;
                cmb_StaffQualificationTabQualificationID.SelectedItem = currentlySelectedStaffQualification.QualificationID;
                cmb_StaffQualificationTabEmployeeID.SelectedItem = currentlySelectedStaffQualification.EmployeeID;

                //Check if the qualification has an expiry date less than 70 years from now
                if (currentlySelectedStaffQualification.ExpiryDate < DateTime.Today.AddYears(70))
                {
                    //Display date and set the checkbox to checked
                    dtp_StaffQualificationTabExpiryDate.Value = currentlySelectedStaffQualification.ExpiryDate;
                    chb_StaffQualificationTabRequiresRepeat.Checked = true;

                }
                else
                {
                    //Set  the checkbox to false
                    chb_StaffQualificationTabRequiresRepeat.Checked = false;

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }      

        }//End displayStaffQualificationDetails


        private void displayQualificationDetails(Qualification currentlySelectedQualification)
        {
            try
            {
                txt_QualificationTabQualificationID.Text = currentlySelectedQualification.QualificationID.ToString();
                txt_QualificationTabDescription.Text = currentlySelectedQualification.Description;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End displayStaffQualificationDetails


        private void disableOrEnableStaffQualificationControls(bool onOrOff)
        {
            try
            {
                grp_StaffQualificationsTabSearchAndSortOptions.Enabled = onOrOff;
                btn_StaffQualificationTabAddStaffQualification.Enabled = onOrOff;
                btn_StaffQualificationTabDeleteStaffQualification.Enabled = onOrOff;
                btn_StaffQualificationTabEditStaffQualification.Enabled = onOrOff;
                btn_StaffQualificationTabFirstStaffQualification.Enabled = onOrOff;
                btn_StaffQualificationTabLastStaffQualification.Enabled = onOrOff;
                btn_StaffQualificationTabNextStaffQualification.Enabled = onOrOff;
                btn_StaffQualificationTabPreviousStaffQualification.Enabled = onOrOff;

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
        
        }//End disableOrEnableStaffQualificationControls


        private void disableOrEnableQualificationControls(bool onOrOff)
        {
            try
            {
                grp_QualificationsTabSearchAndSortOptions.Enabled = onOrOff;
                btn_QualificationTabAddQualification.Enabled = onOrOff;
                btn_QualificationTabDeleteQualification.Enabled = onOrOff;
                btn_QualificationTabEditQualification.Enabled = onOrOff;

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End disableOrEnableQualificationControls


        private void messageForStaffQualificationFound(bool StaffQualificationFound, string fieldSearched, string searchTerm)
        {
            try
            {
                if (!StaffQualificationFound)
                {
                    //StaffQualification not in list. Inform User
                    errorToUser(("A Staff Qualification with the " + fieldSearched + ": " + searchTerm + " does not exist in this list"), "Search Failed");

                }//End If
            }
            catch (Exception ex)
            {
                //print error message
                printErrorMessage(ex);
            }

        }//End messageForStaffQualificationFound


        private void messageForQualificationFound(bool QualificationFound, string fieldSearched, string searchTerm)
        {
            try
            {
                if (!QualificationFound)
                {
                    //StaffQualification not in list. Inform User
                    errorToUser(("A Qualification with the " + fieldSearched + ": " + searchTerm + " does not exist in this list"), "Search Failed");

                }//End If
            }
            catch (Exception ex)
            {
                //print error message
                printErrorMessage(ex);
            }

        }//End messageForQualificationFound


        private void refreshStaffQualificationDataGrid()
        {
            try
            {
                //refresh list
                dgv_StaffQualificationsList.DataSource = "";
                dgv_StaffQualificationsList.DataSource = lstStaffQualifications;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End refreshStaffQualificationDataGrid


        private void refreshStaffQualificationList()
        {
            try
            {
                //Create a new instance of the staff qualification table class
                staffQualTable = new StaffQualificationTable();

                //Readn in the new values and assign to the staff qualification list
                lstStaffQualifications = staffQualTable.ReadStaffQualificationRecordFromTable();

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End refreshStaffQualificationList


        private void refreshQualificationDataGrid()
        {
            try
            {
                //refresh list
                dgv_QualificationsList.DataSource = "";
                dgv_QualificationsList.DataSource = lstQualifications;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End refreshQualificationDataGrid


        private void refreshQualificationList()
        {
            try
            {
                //Create a new instance of the qualification table class
                qualTable = new QualificationTable();

                //Readn in the new values and assign to the qualification list
                lstQualifications = qualTable.ReadQualificationRecordFromTable();

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End refreshStaffQualificationList
        
        //---------------------------------- General Methods ----------------------------------\\

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


        private void informUser(string messageToPost, string header)
        {
            try
            {
                //Post the custom message
                MessageBox.Show(messageToPost, header);
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End informUser


        private void errorToUser(string messageToPost, string header)
        {
            try
            {
                //Post the custom message
                MessageBox.Show(messageToPost, header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End errorToUser


        private void setUpStaffQualificationsTab()
        {
            try
            {
                if (lstQualifications.Count > 0)
                {
                    //Clear the combobox
                    cmb_StaffQualificationTabQualificationID.Items.Clear();

                    foreach (Qualification qual in lstQualifications)
                    {
                        //Add to the combobox list
                        cmb_StaffQualificationTabQualificationID.Items.Add(qual.QualificationID);

                    }//End Foreach

                }//End If


                if (lstEmployees.Count > 0)
                {
                    //Clear the combobox
                    cmb_StaffQualificationTabEmployeeID.Items.Clear();

                    foreach (Employee employee in lstEmployees)
                    {
                        //Add to the combobox list
                        cmb_StaffQualificationTabEmployeeID.Items.Add(employee.EmployeeID);

                    }//End Foreach

                }//End If

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End setUpStaffQualificationsTab


        private void tab_StaffQualifications_Click(object sender, EventArgs e)
        {
            try
            {
                //Set up the staff qual tab
                setUpStaffQualificationsTab();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End tab_StaffQualifications_Click

        


    }//End Of Form
}
