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
    public partial class frm_PaymentMethod : Form
    {

        //--------------------------- Global Variables ---------------------------\\
        List<Member> lstMembers = new List<Member>();
        List<Payment> lstPayments = new List<Payment>();
        List<PaymentMethod> lstPaymentMethods = new List<PaymentMethod>();
        List<PaymentDetails> lstPaymentDetails = new List<PaymentDetails>();
        List<PaymentMethod> lstMethodSearchResults = new List<PaymentMethod>();
        List<PaymentDetails> lstDetailsSearchResults = new List<PaymentDetails>();

        Member memberSelected = new Member();
        PaymentMethod currentlySelectedPaymentMethod = new PaymentMethod();
        PaymentDetails currentlySelectedPaymentDetails = new PaymentDetails();

        PaymentMethodTable payMethTable = new PaymentMethodTable();
        PaymentDetailsTable payDetTable = new PaymentDetailsTable();

        int posInMethodList = 0;
        int posInDetailsList = 0;

        int nextMethodID = 3;
        int nextDetailsID = 3;

        int paymentMethodIDInput = 0;
        int memberIDInput = 0;
        string cardTypeInput = "";
        string cardNumberInput = "";
        string expiryDateInput = "";
        string securityCodeInput = "";
        int monthInput = 1;
        int yearInput = 1;
        int currentMonth = DateTime.Today.Month;
        int currentYear = Convert.ToInt32(DateTime.Today.Year.ToString().Substring(2, 2));
        int selectedIndexFieldForSort = 0;
        int selectedAscendOrDescend = 0;
        int selectedSearchField = 0;

        //--------------------------- Constructors/Load/Closing Method ---------------------------\\

        public frm_PaymentMethod()
        {
            InitializeComponent();

        }//End Default Constructor


        public frm_PaymentMethod(List<Member> LstMembers, List<Payment> LstPayments, PaymentMethodTable PayMethTable, PaymentDetailsTable PayDetTable, List<PaymentMethod> LstPaymentMethods, List<PaymentDetails> LstPaymentDetails)
        {
            InitializeComponent();

            //assign to global variables
            lstMembers = LstMembers;
            lstPayments = LstPayments;
            payMethTable = PayMethTable;
            payDetTable = PayDetTable;
            lstPaymentMethods = LstPaymentMethods;
            lstPaymentDetails = LstPaymentDetails;

        }//End Overloaded Constructor


        private void frm_PaymentMethod_Load(object sender, EventArgs e)
        {
            try
            {
                //Add the Member IDs and the existing payment methods to their respective comboboxes

                //---------------------- Member ID ----------------------\\
                //Foreach member add their ID to the control
                foreach (Member member in lstMembers)
                {
                    cmb_MemberID.Items.Add(member.MemberID);

                }//End Foreach

                //---------------------- Closing Event Handler ----------------------\\
                //Create the event handler for form closing
                this.FormClosing += frm_PaymentMethod_FormClosing;

                //Set Data grid view data source
                dgv_PaymentMethodList.DataSource = lstPaymentMethods;

                //Set the next IDs

                //If there is at least one method
                if (lstPaymentMethods.Count > 0)
                {
                    //Set method to the ID + 1
                    nextMethodID = lstPaymentMethods[lstPaymentMethods.Count - 1].PaymentMethodID + 1;
                }
                else
                {
                    //Set to 1
                    nextMethodID = 1;

                }//End If


                //If there is at least one set of details
                if (lstPaymentDetails.Count > 0)
                {
                    //Set method to the ID + 1
                    nextDetailsID = lstPaymentDetails[lstPaymentDetails.Count - 1].PaymentDetailsID + 1;
                }
                else
                {
                    //Set to 1
                    nextDetailsID = 1;

                }//End If
                

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End frm_PaymentMethod_Load


        void frm_PaymentMethod_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //On the form's closing create a new version of the main menu, passing through the updated payment method list
                frm_MainMenu frm_UpdatedMenu = new frm_MainMenu();

                //Show the new form
                frm_UpdatedMenu.Show();

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End frm_PaymentMethod_FormClosing

        //--------------------------- CRUD+ Methods ---------------------------\\
        
        private void addPaymentMethod()
        {
            try
            {
                //enable the member ID combobox, groupbox for payment details and the submit button
                cmb_MemberID.Enabled = true;
                grp_AccountDetails.Enabled = true;
                grp_PaymentMethodDetails.Enabled = true;
                btn_AddSubmit.Enabled = true;

                //Disable all of the other controls
                disableOrEnablePaymentMethodButtons(false);

                //Create a new record for the new entry
                PaymentMethod newPaymentMethod = new PaymentMethod();
                PaymentDetails newPaymentDetails = new PaymentDetails();

                //Set the payment method ID
                newPaymentMethod.PaymentMethodID = nextMethodID;
                newPaymentDetails.PaymentDetailsID = nextDetailsID;

                //Add to the lists
                lstPaymentMethods.Add(newPaymentMethod);
                lstPaymentDetails.Add(newPaymentDetails);

                //Set the pos to the new pos
                posInMethodList = lstPaymentMethods.Count - 1;
                posInDetailsList = lstPaymentDetails.Count - 1;

                //Set payment Method ID Field
                txt_PaymentMethodID.Text = newPaymentMethod.PaymentMethodID.ToString();

                //Set the new record to the currently selected
                currentlySelectedPaymentMethod = newPaymentMethod;

                //Purge Autofilled fields
                cmb_MemberID.Text = "";
                txt_Address.Text = "";
                txt_FirstName.Text = "";
                txt_Surname.Text = "";
                txt_Town.Text = "";
                mst_CardNumber.Text = "";
                mst_ExpiryDate.Text = "";
                mst_PostCode.Text = "";
                mst_SecurityCode.Text = "";
                dtp_DOB.Value = DateTime.Today;

                //Display the new record
                displayPaymentMethodDetails(newPaymentMethod);

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End addPaymentMethod


        private void deletePaymentMethod()
        {
            //Declare Variables
            bool hasDependentRecord = false;
            PaymentDetails detailsToDelete = new PaymentDetails();

            try
            {
                //Check if there are any payments in list
                if (lstPaymentMethods.Count > 0)
                {
                    //Check if it has dependent records on the system
                    checkDependency(ref hasDependentRecord, lstPayments.Exists(payment => payment.PaymentMethodID.Equals(lstPaymentMethods[posInMethodList].PaymentMethodID)), "payment method", "payment");

                    //If it has no dependent records
                    if (!hasDependentRecord)
                    {
                        //Ask user if they wish to delete payment
                        DialogResult answer = MessageBox.Show("Are you sure you want to delete this payment method?", "Are You sure you want to delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        //check response
                        if (answer == DialogResult.Yes)
                        {
                            //Assign the payment details to delete
                            detailsToDelete = lstPaymentDetails.Find(payDets => payDets.PaymentDetailsID.Equals(lstPaymentMethods[posInMethodList].PaymentDetailsID));

                            //Remove details and method from the database
                            payDetTable.DeletePaymentDetailsRecord(detailsToDelete);
                            payMethTable.DeletePaymentMethodRecord(lstPaymentMethods[posInMethodList]);

                            //Refresh lists
                            refreshPaymentDetailsList();
                            refreshPaymentMethodList();

                            //Refresh data grid
                            refreshDataGrid();

                            //Inform user the payment has been deleted
                            informUser("Payment Method Deletion Successful.", "Payment Method Deleted");

                            //Display last payment if there is a payment to display
                            if (lstPaymentMethods.Count > 0)
                            {
                                displayPaymentMethodDetails(lstPaymentMethods[lstPaymentMethods.Count - 1]);

                            }//End If

                        }
                        else
                        {
                            informUser("Payment Method Deletion Cancelled", "Deletion Cancelled");

                        }//End If

                    }//End If

                }
                else
                {
                    informUser("Payment Method List Empty -  Deletion Cancelled", "Deletion Cancelled");

                }//End If

            }
            catch (Exception ex)
            {
                //show error message
                printErrorMessage(ex);
            }

        }//End deletePayment

        
        private void sortPaymentMethods()
        {
            try
            {
                //Check if the datasource is methods or details
                if (dgv_PaymentMethodList.DataSource == lstPaymentMethods)
                {
                    switch (selectedIndexFieldForSort)
                    {
                        case 0:

                            //if ascending
                            if (selectedAscendOrDescend == 0)
                            {
                                //Sort by ascending PaymentMethodID
                                lstPaymentMethods = lstPaymentMethods.OrderBy(PaymentMethod => PaymentMethod.PaymentMethodID).ToList();

                                //Refresh the data grid
                                refreshDataGrid();

                            }
                            else
                            {
                                //Sort by descending PaymentMethodID
                                lstPaymentMethods = lstPaymentMethods.OrderByDescending(PaymentMethod => PaymentMethod.PaymentMethodID).ToList();

                                //Refresh the data grid
                                refreshDataGrid();

                            }//end if

                            break;


                        case 1:

                            //if ascending
                            if (selectedAscendOrDescend == 0)
                            {
                                //Sort by ascending MemberID
                                lstPaymentMethods = lstPaymentMethods.OrderBy(PaymentMethod => PaymentMethod.MemberID).ToList();

                                //Refresh the data grid
                                refreshDataGrid();
                            }
                            else
                            {
                                //Sort by descending MemberID
                                lstPaymentMethods = lstPaymentMethods.OrderByDescending(PaymentMethod => PaymentMethod.MemberID).ToList();

                                //Refresh the data grid
                                refreshDataGrid();

                            }//end if

                            break;

                    }//End switch

                }
                else
                {
                    switch (selectedIndexFieldForSort)
                    {
                        case 0:

                            //if ascending
                            if (selectedAscendOrDescend == 0)
                            {
                                //Sort by ascending Payment Details ID
                                lstPaymentDetails = lstPaymentDetails.OrderBy(PaymentDetail => PaymentDetail.PaymentDetailsID).ToList();

                                //Refresh the data grid
                                refreshDataGrid();
                            }
                            else
                            {
                                //Sort by descending Payment Details ID
                                lstPaymentDetails = lstPaymentDetails.OrderByDescending(PaymentDetail => PaymentDetail.PaymentDetailsID).ToList();

                                //Refresh the data grid
                                refreshDataGrid();

                            }//end if

                            break;

                        case 1:

                            //if ascending
                            if (selectedAscendOrDescend == 0)
                            {
                                //Sort by ascending Card Type
                                lstPaymentDetails = lstPaymentDetails.OrderBy(PaymentDetail => PaymentDetail.CardType).ToList();

                                //Refresh the data grid
                                refreshDataGrid();
                            }
                            else
                            {
                                //Sort by descending Card Type
                                lstPaymentDetails = lstPaymentDetails.OrderByDescending(PaymentDetail => PaymentDetail.CardType).ToList();

                                //Refresh the data grid
                                refreshDataGrid();

                            }//end if

                            break;


                        case 2:

                            //if ascending
                            if (selectedAscendOrDescend == 0)
                            {
                                //Sort by ascending Expiry Date
                                lstPaymentDetails = lstPaymentDetails.OrderBy(PaymentDetail => PaymentDetail.ExpiryDate).ToList();

                                //Refresh the data grid
                                refreshDataGrid();
                            }
                            else
                            {
                                //Sort by descending Expiry Date
                                lstPaymentDetails = lstPaymentDetails.OrderByDescending(PaymentDetail => PaymentDetail.ExpiryDate).ToList();

                                //Refresh the data grid
                                refreshDataGrid();

                            }//end if

                            break;

                    }//End Switch

                }//End If

            }
            catch (Exception ex)
            {
                //print error to screen
                printErrorMessage(ex);

            }//End Catch

        }//End sortPaymentMethods


        private void searchForPaymentMethod()
        {
            string searchTerm = "";
            bool PaymentMethodFound = false;

            try
            {
                if (!String.IsNullOrWhiteSpace(mst_SearchTerm.Text))
                {
                    //Assign variable
                    searchTerm = mst_SearchTerm.Text.Trim().ToLower();

                    //Check if the datasource is methods or details
                    if (dgv_PaymentMethodList.DataSource == lstPaymentMethods)
                    {
                        //Switch on selected search field
                        switch (selectedSearchField)
                        {
                            case 0:

                                foreach (PaymentMethod PaymentMethod in lstPaymentMethods)
                                {
                                    if (PaymentMethod.PaymentMethodID.ToString() == searchTerm)
                                    {
                                        //Has the same PaymentMethod ID therefore assign to the list
                                        lstMethodSearchResults.Add(PaymentMethod);

                                        //PaymentMethod Found
                                        PaymentMethodFound = true;

                                    }//End If

                                }//End Foreach

                                //Display on screen message if no results found
                                messageForPaymentMethodFound(PaymentMethodFound, "Payment Method ID", searchTerm);

                                break;

                            case 1:

                                foreach (PaymentMethod PaymentMethod in lstPaymentMethods)
                                {
                                    if (PaymentMethod.MemberID.ToString() == searchTerm)
                                    {
                                        //Has the same MemberID therefore assign to the list
                                        lstMethodSearchResults.Add(PaymentMethod);

                                        //PaymentMethod Found
                                        PaymentMethodFound = true;

                                    }//End If

                                }//End Foreach

                                //Display on screen message if no results found
                                messageForPaymentMethodFound(PaymentMethodFound, "Member ID", searchTerm);

                                break;

                        }//End Switch

                        //Set the data source to the search results
                        dgv_PaymentMethodList.DataSource = lstMethodSearchResults;

                    }
                    else
                    {
                        //Switch on selected search field
                        switch (selectedSearchField)
                        {
                            case 0:

                                foreach (PaymentDetails PaymentDetails in lstPaymentDetails)
                                {
                                    if (PaymentDetails.PaymentDetailsID.ToString() == searchTerm)
                                    {
                                        //Has the same Payment Details ID therefore assign to the list
                                        lstDetailsSearchResults.Add(PaymentDetails);

                                        //PaymentMethod Found
                                        PaymentMethodFound = true;

                                    }//End If

                                }//End Foreach

                                //Display on screen message if no results found
                                messageForPaymentDetailsFound(PaymentMethodFound, "Payment Details ID", searchTerm);

                                break;


                            case 1:

                                foreach (PaymentDetails PaymentDetails in lstPaymentDetails)
                                {
                                    if (PaymentDetails.CardType.ToLower() == searchTerm || PaymentDetails.CardType.ToLower().Contains(searchTerm))
                                    {
                                        //Has the same Card Type therefore assign to the list
                                        lstDetailsSearchResults.Add(PaymentDetails);

                                        //PaymentMethod Found
                                        PaymentMethodFound = true;

                                    }//End If

                                }//End Foreach

                                //Display on screen message if no results found
                                messageForPaymentDetailsFound(PaymentMethodFound, "Card Type", searchTerm);

                                break;


                            case 2:

                                foreach (PaymentDetails PaymentDetails in lstPaymentDetails)
                                {
                                    if (PaymentDetails.CardNumber == searchTerm || PaymentDetails.CardNumber.Contains(searchTerm))
                                    {
                                        //Has the same Card Number therefore assign to the list
                                        lstDetailsSearchResults.Add(PaymentDetails);

                                        //PaymentMethod Found
                                        PaymentMethodFound = true;

                                    }//End If

                                }//End Foreach

                                //Display on screen message if no results found
                                messageForPaymentDetailsFound(PaymentMethodFound, "Card Number", searchTerm);

                                break;



                            case 3:

                                foreach (PaymentDetails PaymentDetails in lstPaymentDetails)
                                {
                                    if (PaymentDetails.ExpiryDate == searchTerm)
                                    {
                                        //Has the same Expiry Date therefore assign to the list
                                        lstDetailsSearchResults.Add(PaymentDetails);

                                        //PaymentMethod Found
                                        PaymentMethodFound = true;

                                    }//End If

                                }//End Foreach

                                //Display on screen message if no results found
                                messageForPaymentDetailsFound(PaymentMethodFound, "Expiry Date", searchTerm);

                                break;


                        }//End Switch

                        //Set the data source to the search results
                        dgv_PaymentMethodList.DataSource = lstDetailsSearchResults;

                    }//End If

                }
                else
                {
                    //Invalid Search
                    errorToUser("The search you tried to perform was using an invalid search term.\nPlease try again.", "Invalid Search Term");

                }//End If

            }
            catch (Exception ex)
            {
                //print error to screen
                printErrorMessage(ex);

            }//End Catch

        }//End searchForPaymentMethod


        //----------------------------- Click/Index Events -----------------------------\\

        private void btn_FirstPaymentMethod_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstPaymentMethods.Count >= 1)
                {
                    //The list is populated and should go to position 0
                    posInMethodList = 0;

                    //Retrieve member at position
                    currentlySelectedPaymentMethod = lstPaymentMethods[posInMethodList];

                    //Display details
                    displayPaymentMethodDetails(currentlySelectedPaymentMethod);

                }
                else
                {
                    //Inform user there are no members in list
                    MessageBox.Show("No payment methods exist.", "List Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            } 

        }//End btn_FirstPaymentMethod_Click


        private void btn_PreviousPaymentMethod_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstPaymentMethods.Count >= 1)
                {
                    //check it is not at the start of the list
                    if (posInMethodList != 0)
                    {
                        //The list is populated and should go to the previous position
                        posInMethodList--;

                        //Retrieve member at position
                        currentlySelectedPaymentMethod = lstPaymentMethods[posInMethodList];

                        //Display details
                        displayPaymentMethodDetails(currentlySelectedPaymentMethod);

                    }
                    else
                    {
                        //Inform user they are at the end of the list
                        informUser("You are at the start of the list", "Start of list");

                    }//End If


                }
                else
                {
                    //Inform user there are no members in list
                    errorToUser("No payment methods exist", "List Error");

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_PreviousPaymentMethod_Click


        private void btn_NextPaymentMethod_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstPaymentMethods.Count >= 1)
                {
                    //check it is not at the end of the list
                    if (posInMethodList != lstPaymentMethods.Count - 1)
                    {
                        //The list is populated and should go to the next position
                        posInMethodList++;

                        //Retrieve member at position
                        currentlySelectedPaymentMethod = lstPaymentMethods[posInMethodList];

                        //Display details
                        displayPaymentMethodDetails(currentlySelectedPaymentMethod);

                    }
                    else
                    {
                        //Inform user they are at the end of the list
                        informUser("You are at the end of the list", "End of list");

                    }//End If

                }
                else
                {
                    //Inform user there are no members in list
                    errorToUser("No payment methods exist.", "List Error");

                }//End If

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            } 

        }//End btn_NextPaymentMethod_Click


        private void btn_LastPaymentMethod_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstPaymentMethods.Count >= 1)
                {
                    //The list is populated and should go to position 0
                    posInMethodList = lstPaymentMethods.Count - 1;

                    //Retrieve member at position
                    currentlySelectedPaymentMethod = lstPaymentMethods[posInMethodList];

                    //Display details
                    displayPaymentMethodDetails(currentlySelectedPaymentMethod);

                }
                else
                {
                    //Inform user there are no members in list
                    errorToUser("No payment methods exist.", "List Error");

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            } 

        }//End btn_LastPaymentMethod_Click


        private void btn_AddPaymentMethod_Click(object sender, EventArgs e)
        {
            try
            {
                addPaymentMethod();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_AddPaymentMethod_Click

        
        private void btn_AddSubmit_Click(object sender, EventArgs e)
        {
            //Declare Variables
            bool ifAllValid = true;

            try
            {

                //Validate data entry
                validatePaymentMethodAndDetails(ref ifAllValid);

                //If all of the info is in valid format
                if (ifAllValid)
                {
                    //Payment Method ID Input assign
                    paymentMethodIDInput = nextMethodID;

                    //Assign details to the list and database
                    lstPaymentDetails[posInDetailsList] = new PaymentDetails(cardTypeInput, cardNumberInput, expiryDateInput, securityCodeInput);
                    payDetTable.AddNewPaymentDetails(lstPaymentDetails[posInDetailsList]);

                    //Update the list to get the real ID
                    //lstPaymentDetails = payDetTable.ReadPaymentDetailsRecordFromTable();

                    //Assign the methods to the list and the database
                    lstPaymentMethods[posInMethodList] = new PaymentMethod(paymentMethodIDInput, memberIDInput, nextDetailsID);
                    payMethTable.AddNewPaymentMethod(lstPaymentMethods[posInMethodList]);
                    

                    //Generate next details and method ID
                    nextMethodID++;
                    nextDetailsID++;

                    //Show message to user
                    MessageBox.Show("Payment Method Addition Successful", "Addition Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Refresh the payment details and method lists
                    refreshPaymentDetailsList();
                    refreshPaymentMethodList();

                    //Display the completed details
                    displayPaymentMethodDetails(lstPaymentMethods[posInMethodList]);

                    //Enable all of the neccessary buttons
                    disableOrEnablePaymentMethodButtons(true);

                    //Disable combobox, groupbox and submit button
                    cmb_MemberID.Enabled = false;
                    grp_AccountDetails.Enabled = false;
                    grp_PaymentMethodDetails.Enabled = false;
                    btn_AddSubmit.Enabled = false;


                    //refresh data grid view
                    refreshDataGrid();

                }//End If

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_AddSubmit_Click

        
        private void btn_DeletePaymentMethod_Click(object sender, EventArgs e)
        {
            try
            {
                deletePaymentMethod();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_DeletePaymentMethod_Click


        private void btn_EditPaymentMethod_Click(object sender, EventArgs e)
        {
            try
            {
                //enable the member ID combobox, groupbox for payment details and the submit button
                cmb_MemberID.Enabled = true;
                grp_AccountDetails.Enabled = true;
                grp_PaymentMethodDetails.Enabled = true;
                btn_EditSubmit.Enabled = true;

                //Disable all of the other controls
                disableOrEnablePaymentMethodButtons(false);

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
                        
        }//End btn_EditPaymentMethod_Click


        private void btn_EditSubmit_Click(object sender, EventArgs e)
        {
            //Declare Variables
            bool ifAllValid = true;

            try
            {
                //Validate the data entry
                validatePaymentMethodAndDetails(ref ifAllValid);

                if (ifAllValid)
                {
                    //Assign for ease of use
                    PaymentMethod methodUpdating = lstPaymentMethods[posInMethodList];
                    PaymentDetails detailsUpdating = lstPaymentDetails.Find(payDetails => payDetails.PaymentDetailsID.Equals(methodUpdating.PaymentDetailsID));

                    //Update details
                    methodUpdating.MemberID = memberIDInput;
                    detailsUpdating.CardType = cardTypeInput;
                    detailsUpdating.CardNumber = cardNumberInput;
                    detailsUpdating.ExpiryDate = expiryDateInput;
                    detailsUpdating.SecurityCode = securityCodeInput;

                    //Inform of successful update
                    informUser("Update Successful", "Successful Update");

                    //Enable the buttons
                    disableOrEnablePaymentMethodButtons(true);

                    //disable the member ID combobox, groupbox for payment details and the submit button
                    cmb_MemberID.Enabled = false;
                    grp_AccountDetails.Enabled = false;
                    grp_PaymentMethodDetails.Enabled = false;
                    btn_AddSubmit.Enabled = false;

                    //Edit the database                    
                    payDetTable.UpdatePaymentDetailsDatabase(detailsUpdating);
                    payMethTable.UpdatePaymentMethodDatabase(methodUpdating);

                    //Refresh the datagrid view
                    refreshDataGrid();

                }//End If

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
                        
        }//End btn_EditSubmit_Click


        private void btn_SubmitSort_Click(object sender, EventArgs e)
        {
            try
            {
                sortPaymentMethods();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_SubmitSort_Click


        private void btn_Search_Click(object sender, EventArgs e)
        {
            try
            {
                searchForPaymentMethod();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_Search_Click


        private void btn_UpdateAndClose_Click(object sender, EventArgs e)
        {   
            try
            {
                //Close this screen
                this.Close();

                //Triggers close event that loads new form with new details
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
                        
        }//End btn_UpdateAndClose_Click
        

        private void btn_FullList_Click(object sender, EventArgs e)
        {
            try
            {
                //Refresh the data grid
                refreshDataGrid();

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_FullList_Click


        private void cmb_MemberID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //On MemberID Change, Change the information below

                //Locate and assign the member
                memberSelected = lstMembers[cmb_MemberID.SelectedIndex];

                //Display Details on screen
                txt_Surname.Text = memberSelected.Surname.ToString();
                txt_FirstName.Text = memberSelected.FirstName.ToString();
                dtp_DOB.Value = memberSelected.DOB;
                txt_Address.Text = memberSelected.Address;
                txt_Town.Text = memberSelected.Town;
                mst_PostCode.Text = memberSelected.PostCode;

                //Assign the member ID
                memberIDInput = (int)cmb_MemberID.SelectedItem;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
                        
        }//End cmb_MemberID_SelectedIndexChanged


        private void cmb_CardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Assign text to the input variable
                cardTypeInput = cmb_CardType.SelectedItem.ToString();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End cmb_CardType_SelectedIndexChanged


        private void cmb_SearchTermOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Assign the index
                selectedSearchField = cmb_SearchTermOptions.SelectedIndex;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End cmb_SearchTermOptions_SelectedIndexChanged


        private void cmb_SortOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Assign the index
                selectedIndexFieldForSort = cmb_SortOptions.SelectedIndex;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End cmb_SortOptions_SelectedIndexChanged
        

        private void cmb_AscendOrDescend_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Assign the index
                selectedAscendOrDescend = cmb_AscendOrDescend.SelectedIndex;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End cmb_AscendOrDescend_SelectedIndexChanged


        private void txt_PaymentMethodID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Retrieve the info for the payment details
                currentlySelectedPaymentDetails = lstPaymentDetails.Find(details => details.PaymentDetailsID.Equals(currentlySelectedPaymentMethod.PaymentDetailsID));

                //Check if it is a new set of details by checking if the variable is null
                if (currentlySelectedPaymentDetails != null)
                {
                    //Display details on screen
                    cmb_CardType.SelectedItem = currentlySelectedPaymentDetails.CardType;
                    mst_CardNumber.Text = currentlySelectedPaymentDetails.CardNumber.ToString();
                    mst_ExpiryDate.Text = currentlySelectedPaymentDetails.ExpiryDate;
                    mst_SecurityCode.Text = currentlySelectedPaymentDetails.SecurityCode;

                }//End If
                
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End txt_PaymentMethodID_TextChanged


        //----------------------------- Validation Methods -----------------------------\\

        private void validatePaymentMethodAndDetails(ref bool ifAllValid)
        {
            try
            {
                //------------------------- Payment Method ID -------------------------\\
                //Auto generated

                //------------------------- Member ID -------------------------\\
                readComboBoxSelection(ref ifAllValid, cmb_MemberID.Text, "Member ID", ref memberIDInput);

                //------------------------- Card Type -------------------------\\
                readComboBoxSelection(ref ifAllValid, cmb_CardType.Text, "Card Type", ref cardTypeInput);

                //------------------------- Card Number -------------------------\\
                validateCardNumber(ref ifAllValid);

                //------------------------- Expiry Date -------------------------\\
                validateExpiryDate(ref ifAllValid);

                //------------------------- Security Code -------------------------\\
                validateSecurityCode(ref ifAllValid);
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End validatePaymentMethod


        private void validateSecurityCode(ref bool ifAllValid)
        {
            try
            {
                //Assign for use
                securityCodeInput = mst_SecurityCode.Text.Trim();

                //Check that the security code is the correct length, since it is masked it should be in the correct format
                if (securityCodeInput.Length != 3)
                {
                    //Invalid
                    ifAllValid = false;

                    errorToUser("The security code you entered was not valid./nPlease Try Again", "Input Error");

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End validateSecurityCode


        private void validateCardNumber(ref bool ifAllValid)
        {
            try
            {
                //Assign for use
                cardNumberInput = mst_CardNumber.Text.Trim();

                //Check that the card number is the correct length, since it is masked for exactly 16 numbers, Correct length = valid entry
                if (cardNumberInput.Length != 16)
                {
                    //It is less than 16 characters, therefore invalid
                    ifAllValid = false;

                    errorToUser("The card number you entered was not valid./nPlease Try Again", "Input Error");

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End validateCardNumber


        private void validateExpiryDate(ref bool ifAllValid)
        {
            try
            {
                //Assign for use
                expiryDateInput = mst_ExpiryDate.Text.Trim();

                //Check that the card number is the correct length, since it is masked it should be in the correct format
                if (expiryDateInput.Length == 5)
                {
                    //it is in valid format, need to check if numbers make sense
                    monthInput = Convert.ToInt32(expiryDateInput.Substring(0, 2));
                    yearInput = Convert.ToInt32(expiryDateInput.Substring(3, 2));


                    //if month is 1 to 12, valid month
                    if (monthInput >= 1 && monthInput <= 12)
                    {
                        //Check year is greater or equal to current year, if not it is invalid
                        if (yearInput < currentYear)
                        {
                            //Year is less than therefore is invalid
                            ifAllValid = false;

                            //Send Error To User
                            errorToUser("The expiry date you entered declares your card is out of date.\nPlease Try Again", "Input Error");
                        }
                        else
                        {
                            //Check if the month is invalid, if month is less than or equal to current month and the year the same as the current year the card is invalid
                            if (monthInput <= currentMonth && yearInput == currentYear)
                            {
                                //Set invalid
                                ifAllValid = false;

                                //Send Error To User
                                errorToUser("The expiry date entered declares your card out of date.\nPlease Try Again", "Input Error");

                            }//End If

                        }//End If

                    }
                    else
                    {
                        //Invalid entry
                        ifAllValid = false;

                        //Send Error To User
                        errorToUser("The month you entered for the expiry date was not valid.\nPlease Try Again", "Input Error");

                    }//End If

                }
                else
                {
                    //invalid entry
                    ifAllValid = false;

                    //Send Error To User
                    errorToUser("The expiry date you entered was not valid.\nPlease Try Again", "Input Error");

                }//End if
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End validateExpiryDate


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
        

        //----------------------------- General Methods -----------------------------\\

        private void readComboBoxSelection(ref bool ifAllValid, string inputFromCmb, string fieldName, ref string inputVariable)
        {
            try
            {
                //check if the combobox's selected item is not 0 i.e. chosen
                if (inputFromCmb != "")
                {
                    //If it is not 0 then assign to the variable
                    inputVariable = inputFromCmb;
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


        private void displayPaymentMethodDetails(PaymentMethod currentlySelectedPaymentMethod)
        {
            try
            {
                //Assign known values
                cmb_MemberID.SelectedItem = currentlySelectedPaymentMethod.MemberID;
                txt_PaymentMethodID.Text = currentlySelectedPaymentMethod.PaymentMethodID.ToString();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End displayPaymentMethodDetails


        private void disableOrEnablePaymentMethodButtons(bool onOrOff)
        {
            try
            {
                //Disable or enable all buttons that could interfere
                btn_FirstPaymentMethod.Enabled = onOrOff;
                btn_PreviousPaymentMethod.Enabled = onOrOff;
                btn_NextPaymentMethod.Enabled = onOrOff;
                btn_LastPaymentMethod.Enabled = onOrOff;
                btn_AddPaymentMethod.Enabled = onOrOff;
                btn_DeletePaymentMethod.Enabled = onOrOff;
                btn_EditPaymentMethod.Enabled = onOrOff;
                grp_SearchSortOptions.Enabled = onOrOff;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End disableOrEnablePaymentMethodButtons


        private void refreshDataGrid()
        {
            try
            {
                //Check if the datasource is details or method
                if (dgv_PaymentMethodList.DataSource.GetType().Equals(lstPaymentMethods.GetType()))
                {
                    //refresh the method source
                    dgv_PaymentMethodList.DataSource = "";
                    dgv_PaymentMethodList.DataSource = lstPaymentMethods;

                }
                else
                {
                    //Refresh the details source
                    dgv_PaymentMethodList.DataSource = "";
                    dgv_PaymentMethodList.DataSource = lstPaymentDetails;

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End refreshDataGrid


        private void refreshPaymentDetailsList()
        {
            try
            {
                //Create a new instance of the Payment Details table class
                payDetTable = new PaymentDetailsTable();

                //Read in the new values and assign to the Payment Details list
                lstPaymentDetails = payDetTable.ReadPaymentDetailsRecordFromTable();

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End refreshPaymentDetailsList


        private void refreshPaymentMethodList()
        {
            try
            {
                //Create a new instance of the Payment Methods table class
                payMethTable = new PaymentMethodTable();

                //Readn in the new values and assign to the Payment Methods list
                lstPaymentMethods = payMethTable.ReadPaymentMethodRecordFromTable();

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End refreshPaymentMethodList
        

        private void messageForPaymentMethodFound(bool paymentMethodFound, string fieldSearched, string searchTerm)
        {
            try
            {
                if (!paymentMethodFound)
                {
                    //Member not in list. Inform User
                    errorToUser(("A payment method with the " + fieldSearched + ": " + searchTerm + " does not exist in this list"), "Search Failed");

                }//End If
            }
            catch (Exception ex)
            {
                //print error message
                printErrorMessage(ex);
            }

        }//End messageForPaymentMethodFound


        private void messageForPaymentDetailsFound(bool paymentMethodFound, string fieldSearched, string searchTerm)
        {
            try
            {
                if (!paymentMethodFound)
                {
                    //Member not in list. Inform User
                    errorToUser(("Payment details with the " + fieldSearched + ": " + searchTerm + " does not exist in this list"), "Search Failed");

                }//End If
            }
            catch (Exception ex)
            {
                //print error message
                printErrorMessage(ex);
            }

        }//End messageForPaymentDetailsFound


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

        }//End informUser


        private void btn_DisplayMethods_Click(object sender, EventArgs e)
        {
            try
            {
                //Change the datasource to the method list
                dgv_PaymentMethodList.DataSource = lstPaymentMethods;

                //Display the correct sort options
                cmb_SortOptions.Items.Clear();
                cmb_SortOptions.Items.AddRange(new String[]{"Payment Method ID", "Member ID"});

                //Display the correct search options
                cmb_SearchTermOptions.Items.Clear();
                cmb_SearchTermOptions.Items.AddRange(new String[] { "Payment Method ID", "Member ID" });

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
                
            }

        }//End btn_DisplayMethods_Click


        private void btn_DisplayDetails_Click(object sender, EventArgs e)
        {
            try
            {
                //Change the datasource to the details list
                dgv_PaymentMethodList.DataSource = lstPaymentDetails;

                //Display the correct sort options
                cmb_SortOptions.Items.Clear();
                cmb_SortOptions.Items.AddRange(new String[] { "Payment Details ID", "Card Type", "Expiry Date" });

                //Display the correct search options
                cmb_SearchTermOptions.Items.Clear();
                cmb_SearchTermOptions.Items.AddRange(new String[] { "Payment Details ID", "Card Type", "Card Number", "Expiry Date" });

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);

            }

        }//End btn_DisplayDetails_Click


    }//End 
}
