using Studio_2_Management_System.Presentation_Access_Layer;
using Studio_2_Management_System.Business_Access_Layer;
using Studio_2_Management_System.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Studio_2_Management_System
{
    public partial class frm_MainMenu : Form
    {
        /*
         * --------------------------- TO-DO IN THE NOT-SO DISTANT FUTURE ---------------------------
         * Fix current number of participants - Bookings Tab Calculation
         */

        //--------------------------- Global Declaration of variables ---------------------------\\
        List<Member> lstMembers = new List<Member>();
        List<MembershipType> lstMemberships = new List<MembershipType>();
        List<ExerciseClass> lstExerciseClasses = new List<ExerciseClass>();        
        List<Booking> lstBookings = new List<Booking>();
        List<Payment> lstPayments = new List<Payment>();
        List<PaymentMethod> lstPaymentMethods = new List<PaymentMethod>();
        List<PaymentDetails> lstPaymentDetails = new List<PaymentDetails>();
        List<Employee> lstEmployees = new List<Employee>();
        List<Room> lstRooms = new List<Room>();
        List<RoomHire> lstRoomHire = new List<RoomHire>();
        List<ExternalCompany> lstExternalCompanies = new List<ExternalCompany>();
        List<Qualification> lstQualifications = new List<Qualification>();
        List<StaffQualification> lstStaffQualifications = new List<StaffQualification>();
        List<StaffQualification> lstIndividualQualifications = new List<StaffQualification>();
        List<Session> lstSessions = new List<Session>();
        
        List<Member> lstMemberSearchResults = new List<Member>();
        List<ExerciseClass> lstExerciseClassSearchResults = new List<ExerciseClass>();
        List<Booking> lstBookingSearchResults = new List<Booking>();
        List<Payment> lstPaymentSearchResults = new List<Payment>();
        List<Room> lstRoomSearchResults = new List<Room>();
        List<RoomHire> lstRoomHireSearchResults = new List<RoomHire>();
        List<Session> lstSessionSearchResults = new List<Session>();
        List<ExternalCompany> lstExternalCompanySearchResults = new List<ExternalCompany>();
        List<Employee> lstEmployeeSearchResults = new List<Employee>();

        Member currentSelectedMember = new Member();
        ExerciseClass currentSelectedExerciseClass = new ExerciseClass();
        Booking currentlySelectedBooking = new Booking();
        Payment currentlySelectedPayment = new Payment();
        Room currentlySelectedRoom = new Room();
        RoomHire currentlySelectedRoomHire = new RoomHire();
        ExternalCompany currentlySelectedExternalCompany = new ExternalCompany();
        Employee currentlySelectedEmployee = new Employee();

        //---------------------------- Tables ----------------------------\\
        MemberTable memberTable = new MemberTable();
        ExerciseClassTable exClassTable = new ExerciseClassTable();
        SessionTable sesTable = new SessionTable();
        EmployeeTable employeeTable = new EmployeeTable();
        MembershipTypeTable membershipTypeTable = new MembershipTypeTable();
        BookingTable bookingTable = new BookingTable();
        PaymentTable payTable = new PaymentTable();
        RoomTable roomTable = new RoomTable();
        RoomHireTable roomHireTable = new RoomHireTable();
        ExternalCompanyTable extCompTable = new ExternalCompanyTable();
        PaymentMethodTable payMethTable = new PaymentMethodTable();
        PaymentDetailsTable payDetTable = new PaymentDetailsTable();
        QualificationTable qualTable = new QualificationTable();
        StaffQualificationTable staffQualTable = new StaffQualificationTable();
        

        int posInMembersList = 0;
        int posInExerciseClassList = 0;
        int posInBookingsList = 0;
        int posInPaymentsList = 0;
        int posInRoomsList = 0;
        int posInRoomHireList = 0;
        int posInExternalCompanyList = 0;
        int posInEmployeeList = 0;

        int nextMemberID = 1;
        int nextExerciseClassID = 1;
        int nextSessionID = 1;
        int nextBookingID = 1;
        int nextPaymentID = 1;
        int nextRoomID = 1;
        int nextRoomHireID = 1;
        int nextExternalCompanyID = 1;
        int nextEmployeeID = 1;

        //----------------- General Input Variables -----------------\\
        bool editMode = false;
        int memberIDInput = 1;
        int membershipTypeIDInput = 1;
        int exerciseClassIDInput = 1;
        int bookingIDInput = 1;
        int employeeIDInput = 1;
        int roomIDInput = 1;
        int roomHireIDInput = 1;
        int paymentIDInput = 1;
        int paymentMethodIDInput = 1;
        int externalCompanyIDInput = 1;

        int selectedIndexFieldForSort = 0;
        int selectedAscendOrDescend = 0;
        int selectedSearchField = 0;

        int employeeIDLoggedIn = 0;

        //----------------- Member/Employee Input Variables -----------------\\        
        int selectedTitle = 0;
        string titleInput = "";
        string surnameInput = "";
        string firstNameInput = "";
        DateTime dateOfBirthInput;
        string addressInput = "";
        string townInput = "";
        string postCodeInput = "";
        string telNoInput = "";
        string emailInput = "";
        string nationalInsuranceNumberInput = "";
        string contractTypeInput = "";

        //----------------- Exercise Class Input Variables -----------------\\        
        string descriptionInput = "";
        string difficultyInput = "";
        int noOfWeeksInput = 1;
        TimeSpan startTimeInput = new TimeSpan(7, 0, 0);
        TimeSpan endTimeInput = new TimeSpan(8, 30, 0);
        TimeSpan startTimeCalculationInput;
        TimeSpan endTimeCalculationInput;
        int classLengthInput = 0;
        int currentNoOfParticipantsInput = 0;
        int maxParticipantsInput = 0;
        bool externalClassInput = false;
        decimal weeklyCostOfClassInput = 0;
        decimal totalCostOfClassInput = 0;

        //----------------- Booking Input Variables -----------------\\
        decimal amountChargedInput = 0;
        int noOfPeopleBookingInput = 1;

        //----------------- Payment Input Variables -----------------\\
        bool isMembership = true;
        DateTime dateOfPaymentInput = DateTime.Now;
        decimal amountToPayInput = 0;

        //----------------- Room Input Variables -----------------\\
        bool roomAvailableForUseInput = true;
        decimal hourlyHireCostInput = 0;
        int roomCapacityInput = 0;
        string roomDescriptionInput = "";
        string roomLocationInput = "";

        //----------------- Room Hire Input Variables -----------------\\
        DateTime startDateInput = DateTime.Today;
        DateTime endDateInput = DateTime.Today;
        int hireDurationInput = 0;
        int hoursPerWeek = 0;
        decimal monthlyHireCost = 0;
        decimal totalHireCost = 0;

        //----------------- External Company Input Variables -----------------\\
        string companyNameInput = "";
        string companyAddressInput = "";
        string companyTownInput = "";
        string companyPostCodeInput = "";
        string companyPracticeInput = "";
        string contactNameInput = "";
        string contactTelNoInput = "";
        string contactEmailInput = "";

        //----------------- Other Variables -----------------\\
        int currentHour = DateTime.Now.Hour;
        int currentMinute = DateTime.Now.Minute;
        

        //--------------------------- Constructor and Load Method ---------------------------\\

        public frm_MainMenu()
        {
            InitializeComponent();

        }//End Constructor


        private void frm_MainMenu_Load(object sender, EventArgs e)
        {
            //Declare Variables
            DateTime dateOfClassInput = startDateInput;

            try
            {
                //Create new member, class, employee and room objects and add to the list

                //------------------ Member ------------------\\                
                //Read in the member details
                lstMembers = memberTable.ReadMemberRecordFromTable();

                //------------------ Class ------------------\\                 
                //read in the class and session details
                lstExerciseClasses = exClassTable.ReadExerciseClassRecordFromTable();
                lstSessions = sesTable.ReadSessionRecordFromTable();

                //------------------ Employee ------------------\\
                //Read in the employee details
                lstEmployees = employeeTable.ReadEmployeeRecordFromTable();
                
                //------------------ Room ------------------\\
                //Read in the Room details
                lstRooms = roomTable.ReadRoomRecordFromTable();

                //------------------ Bookings ------------------\\
                //read in the booking table
                lstBookings = bookingTable.ReadBookingRecordFromTable();

                //------------------ Membership types ------------------\\
                //Read in the membership type details
                lstMemberships = membershipTypeTable.ReadMembershipTypeFromTable();

                //------------------ Payment Methods ------------------\\
                //Read in the payment methods table
                lstPaymentMethods = payMethTable.ReadPaymentMethodRecordFromTable();
                
                //------------------ Payment Details ------------------\\
                //Read in the payment methods table
                lstPaymentDetails = payDetTable.ReadPaymentDetailsRecordFromTable();

                //------------------ Payments ------------------\\
                //Read in the payment details
                lstPayments = payTable.ReadPaymentRecordFromTable();

                //------------------ Room Hire ------------------\\
                //Read in the room hire table
                lstRoomHire = roomHireTable.ReadRoomHireRecordFromTable();

                //------------------ External Company ------------------\\
                //Read in from the external company table
                lstExternalCompanies.AddRange(extCompTable.ReadExternalCompanyRecordFromTable());

                //------------------ Qualifications ------------------\\
                //read in the qualifications table
                lstQualifications = qualTable.ReadQualificationRecordFromTable();
                
                //------------------ Staff Qualifications ------------------\\
                //read in the staff qualifications table
                lstStaffQualifications = staffQualTable.ReadStaffQualificationRecordFromTable();

                //Load the data view grid
                dgv_MembersList.DataSource = lstMembers;
                dgv_ExerciseClassList.DataSource = lstExerciseClasses;
                dgv_SessionList.DataSource = lstSessions;
                dgv_BookingList.DataSource = lstBookings;
                dgv_PaymentList.DataSource = lstPayments;
                dgv_RoomList.DataSource = lstRooms;
                dgv_RoomHireList.DataSource = lstRoomHire;
                dgv_ExternalCompanyList.DataSource = lstExternalCompanies;
                dgv_EmployeeList.DataSource = lstEmployees;

                //Set the nextID's
                //---------------------- Booking ID ----------------------\\
                if (lstBookings.Count > 0)
                {
                    nextBookingID = lstBookings[lstBookings.Count - 1].BookingID + 1;
                }
                else
                {
                    nextBookingID = 1;

                }//End If

                //---------------------- Member ID ----------------------\\
                if (lstMembers.Count > 0)
                {
                    nextMemberID = lstMembers[lstMembers.Count - 1].MemberID + 1;
                }
                else
                {
                    nextMemberID = 1;

                }//End If


                //---------------------- ExerciseClass ID ----------------------\\
                if (lstExerciseClasses.Count > 0)
                {
                    nextExerciseClassID = lstExerciseClasses[lstExerciseClasses.Count - 1].ExerciseClassID + 1;
                }
                else
                {
                    nextExerciseClassID = 1;

                }//End If

                //---------------------- Session ID ----------------------\\
                if (lstSessions.Count > 0)
                {
                    nextSessionID = lstSessions[lstSessions.Count - 1].SessionID + 1;
                }
                else
                {
                    nextSessionID = 1;

                }//End If

                //---------------------- Payment ID ----------------------\\
                if (lstPayments.Count > 0)
                {
                    nextPaymentID = lstPayments[lstPayments.Count - 1].PaymentID + 1;
                }
                else
                {
                    nextPaymentID = 1;

                }//End If


                //---------------------- Room ID ----------------------\\
                if (lstRooms.Count > 0)
                {
                    nextRoomID = lstRooms[lstRooms.Count - 1].RoomID + 1;
                }
                else
                {
                    nextRoomID = 1;

                }//End If


                //---------------------- RoomHire ID ----------------------\\
                if (lstRoomHire.Count > 0)
                {
                    nextRoomHireID = lstRoomHire[lstRoomHire.Count - 1].RoomHireID + 1;
                }
                else
                {
                    nextRoomHireID = 1;

                }//End If


                //---------------------- ExternalCompany ID ----------------------\\
                if (lstExternalCompanies.Count > 0)
                {
                    nextExternalCompanyID = lstExternalCompanies[lstExternalCompanies.Count - 1].ExternalCompanyID + 1;
                }
                else
                {
                    nextExternalCompanyID = 1;

                }//End If

                //---------------------- Employee ID ----------------------\\
                if (lstEmployees.Count > 0)
                {
                    nextEmployeeID = lstEmployees[lstEmployees.Count - 1].EmployeeID + 1;
                }
                else
                {
                    nextEmployeeID = 1;

                }//End If                


                //If there are any employees add their ID to the current working ID so as to "Log in"
                if (lstEmployees.Count > 0)
                {
                    //Foreach employee
                    foreach (Employee employee in lstEmployees)
                    {
                        //Add ID to the Control's Items
                        cmb_CurrentEmployeeID.Items.Add(employee.EmployeeID);

                    }//End Foreach

                }//End If

                //Add Times to the start time combobox
                TimeSpan timeSpan = new TimeSpan(7, 30, 0);

                for (int halfHoursAdded = 0; halfHoursAdded < 24; halfHoursAdded++)
                {
                    //Add to combobox control
                    cmb_ClassTabTimeOfClass.Items.Add(timeSpan);

                    timeSpan = timeSpan.Add(new TimeSpan(0, 30, 0));

                }//End For

                //Check if there are existing classes and employees and add them to the combo boxes
                //Also display the first exercise class if possible
                setUpClassTab();

                //set up the booking page with the relevant info
                setUpBookingTab();

                //Set up the payments tab with the relevant with info
                setUpPaymentTab();

                //Set up the room hire tab with the relevant info
                setUpRoomHireTab();

                //Display the first record's info on each of the tabs where possible
                displayFirstRecords();

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End frm_MainMenu_Load


        //--------------------------- CRUD+ Methods ---------------------------\\

        //--------------------------- Addition ---------------------------\\

        private void addMember()
        {
            try
            {
                //Create a new member
                Member newMember = new Member();

                //Add to the list
                lstMembers.Add(newMember);

                //Position in list is the last one
                posInMembersList = lstMembers.Count - 1;

                //Display blank member
                displayMemberDetails(newMember);

                //Disable all buttons except the submit
                disableOrEnableAllMemberButtons(false);

                //Set the memberID field
                txt_MemberID.Text = nextMemberID.ToString();

                //Enable Submit Button and the groupbox
                btn_MemberTabSubmit.Enabled = true;
                grp_MemberDetails.Enabled = true;

                //Set date time picker max date
                dtp_DOB.MaxDate = DateTime.Today.AddYears(-16);

            }
            catch (Exception ex)
            {
                //show error message
                printErrorMessage(ex);
            }

        }//End addMember


        private void addClass()
        {           
            //Add Class
            try
            {
                //Create a new member
                ExerciseClass newClass = new ExerciseClass();

                //Add to the list
                lstExerciseClasses.Add(newClass);

                //Position in list is the last one
                posInExerciseClassList = lstExerciseClasses.Count - 1;

                //Display blank member
                displayClassDetails(newClass);

                //Clear all comboboxes
                cmb_ClassTabDifficultyLevels.Text = "";
                cmb_ClassTabEmployeeID.Text = "";
                nud_ClassTabLengthOfClass.Value = 60;
                cmb_ClassTabRoomID.Text = "";
                cmb_ClassTabTimeOfClass.Text = "";
                cmb_ClassTabExternalCompanyID.Text = "";
                txt_ClassTabExternalCompanyName.Text = "";

                //Disable all buttons except the submit
                disableOrEnableAllExerciseClassButtons(false);

                //Set the memberID field
                txt_ClassTabClassID.Text = nextExerciseClassID.ToString();

                //Enable Submit Button and the groupboxes
                btn_ClassTabAddSubmit.Enabled = true;
                grp_ClassDetails.Enabled = true;
                grp_ClassTabSessionDetails.Enabled = true;

                //Set date time picker min and max date
                dtp_ClassTabStartDateOfClass.MinDate = DateTime.Today.AddDays(1);
                dtp_ClassTabStartDateOfClass.MaxDate = DateTime.Today.AddMonths(2);

            }
            catch (Exception ex)
            {
                //show error message
                printErrorMessage(ex);
            }

        }//End addClass


        private void addBooking()
        {
            //activate the groupboxes that need to be edited
            grp_BookingsTabMemberID.Enabled = true;
            grp_BookingsTabExerciseClassID.Enabled = true;
            grp_BookingsTabClassDetails.Enabled = true;

            try
            {
                //Create a new booking
                Booking newBooking = new Booking();

                //Add to the list
                lstBookings.Add(newBooking);

                //Change current booking list pos to the last position
                posInBookingsList = lstBookings.Count - 1;

                //Display the blank booking
                displayBookingDetails(newBooking);

                //Clear all autofilled fields
                nud_BookingsTabCostOfBooking.Text = "";
                txt_BookingsTabCurrentNoOfParticipants.Text = "";
                txt_BookingsTabDescription.Text = "";
                txt_BookingsTabDifficulty.Text = "";
                txt_BookingsTabExternalClass.Text = "";
                txt_BookingsTabFirstName.Text = "";
                txt_BookingsTabMaxParticipants.Text = "";
                txt_BookingsTabSurname.Text = "";
                txt_BookingsTabTitle.Text = "";
                chb_BookingsTabToCharge.Checked = false;
                cmb_BookingsTabExerciseClassID.Text = "";
                cmb_BookingsTabMemberID.Text = "";

                //Disable all of the unnecesary buttons
                disableOrEnableAllBookingButtons(false);

                //Set the booking ID field
                txt_BookingsTabBookingID.Text = nextBookingID.ToString();

                //Set the employee ID Field
                txt_BookingsTabEmployeeID.Text = employeeIDLoggedIn.ToString();

                //Enable Submit Button and the groupboxes for the employee and room
                btn_BookingsTabAddSubmit.Enabled = true;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }


        }//End addBooking


        private void addPayment()
        {
            //activate the groupboxes that need to be edited and the edit mode marker
            grp_PaymentsTabAccountDetails.Enabled = true;
            grp_PaymentMethodDetails.Enabled = true;
            editMode = true;

            try
            {
                //Create a new payment
                Payment newPayment = new Payment();

                //Add to the list
                lstPayments.Add(newPayment);

                //Change current payment list pos to the last position
                posInPaymentsList = lstPayments.Count - 1;

                //Display the blank Payment
                displayPaymentDetails(newPayment);

                //Clear all autofill fields
                cmb_PaymentTabBookingID.Text = "";
                cmb_PaymentTabMemberID.Text = "";
                cmb_PaymentTabPaymentMethodID.Text = "";
                txt_PaymentTabSurname.Text = "";
                txt_PaymentTabFirstName.Text = "";
                mst_PaymentTabTelNo.Text = "";
                txt_PaymentTabEmail.Text = "";
                txt_PaymentTabCardType.Text = "";
                txt_PaymentTabCardNumber.Text = "";
                mst_PaymentTabExpiryDate.Text = "";
                txt_PaymentTabAmountToPay.Text = "";

                //Disable all of the unnecesary buttons
                disableOrEnableAllPaymentButtons(false);

                //Set the Payment ID field
                txt_PaymentTabPaymentID.Text = nextPaymentID.ToString();

                //Enable Submit Button
                btn_PaymentTabAddSubmit.Enabled = true;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End addPayment


        private void addRoom()
        {
            //activate the groupboxes that need to be edited
            grp_RoomTabRoomDetails.Enabled = true;

            //Enable Submit Button
            btn_RoomTabAddSubmit.Enabled = true;

            try
            {
                //Create a new Room
                Room newRoom = new Room();

                //Add to the list
                lstRooms.Add(newRoom);

                //Change current Room list pos to the last position
                posInRoomsList = lstRooms.Count - 1;

                //Display the blank Room
                displayRoomDetails(newRoom);

                //Clear autofilled Fields
                cmb_RoomTabDescription.Text = "";
                cmb_RoomTabLocation.Text = "";

                //Disable all of the unnecesary buttons
                disableOrEnableAllRoomButtons(false);

                //Set the Room ID field
                txt_RoomTabRoomID.Text = nextRoomID.ToString();
                
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End addRoom


        private void addRoomHire()
        {
            //activate the groupboxes that need to be edited
            grp_RoomHireTabRoomHireDetails.Enabled = true;
            grp_RoomHireTabRoomDetails.Enabled = true;
            grp_RoomHireTabCompanyDetails.Enabled = true;

            //Enable Submit Button
            btn_RoomHireTabAddSubmit.Enabled = true;

            try
            {
                //Create a new RoomHire
                RoomHire newRoomHire = new RoomHire();

                //Add to the list
                lstRoomHire.Add(newRoomHire);

                //Change current Room Hire list pos to the last position
                posInRoomHireList = lstRoomHire.Count - 1;

                //Display the blank Room Hire
                displayRoomHireDetails(newRoomHire);

                //Set min hire start date to today
                dtp_RoomHireTabStartDate.MinDate = DateTime.Today;

                //Clear autofilled controls
                txt_RoomHireTabCapacity.Text = "";
                txt_RoomHireTabCompanyName.Text = "";
                txt_RoomHireTabCompanyPractice.Text = "";
                txt_RoomHireTabContactName.Text = "";
                mst_RoomHireTabContactNo.Text = "";
                txt_RoomHireTabDescription.Text = "";
                txt_RoomHireTabHourlyHireCost.Text = "";
                cmb_RoomHireTabExternalCompanyID.Text = "";
                cmb_RoomHireTabHireDuration.Text = "";
                cmb_RoomHireTabRoomID.Text = "";                

                //Disable all of the unnecesary buttons
                disableOrEnableAllRoomHireButtons(false);

                //Set the Room Hire ID field
                txt_RoomHireTabRoomHireID.Text = nextRoomHireID.ToString();

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End addRoomHire


        private void addExternalCompany()
        {
            //activate the groupboxes that need to be edited
            grp_ExternalCompanyTabCompanyDetails.Enabled = true;

            //Enable Submit Button
            btn_ExternalCompanyTabAddSubmit.Enabled = true;

            try
            {
                //Create a new ExternalCompany
                ExternalCompany newExternalCompany = new ExternalCompany();

                //Add to the list
                lstExternalCompanies.Add(newExternalCompany);

                //Change current Room Hire list pos to the last position
                posInExternalCompanyList = lstExternalCompanies.Count - 1;

                //Display the blank Room Hire
                displayExternalCompanyDetails(newExternalCompany);

                //Clear autofilled controls
                txt_ExternalCompanyTabCompanyName.Text = "";
                txt_ExternalCompanyTabCompanyAddress.Text = "";
                txt_ExternalCompanyTabCompanyTown.Text = "";
                mst_ExternalCompanyTabCompanyPostCode.Text = "";
                cmb_ExternalCompanyTabCompanyPractice.Text = "";
                txt_ExternalCompanyTabContactName.Text = "";
                mst_ExternalCompanyTabContactTelNo.Text = "";
                txt_ExternalCompanyTabExternalCompanyID.Text = "";
                txt_ExternalCompanyTabContactEmail.Text = "";

                //Disable all of the unnecesary buttons
                disableOrEnableAllExternalCompanyButtons(false);

                //Set the Room Hire ID field
                txt_ExternalCompanyTabExternalCompanyID.Text = nextExternalCompanyID.ToString();

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End addExternalCompany


        private void addEmployee()
        {
            try
            {
                //Create a new Employee
                Employee newEmployee = new Employee();

                //Add to the list
                lstEmployees.Add(newEmployee);

                //Position in list is the last one
                posInEmployeeList = lstEmployees.Count - 1;

                //Display blank Employee
                displayEmployeeDetails(newEmployee);

                //Disable all buttons except the submit
                disableOrEnableAllEmployeeButtons(false);

                //Set the EmployeeID field
                txt_EmployeeTabEmployeeID.Text = nextEmployeeID.ToString();

                //Enable Submit Button and the groupbox
                btn_EmployeeTabAddSubmit.Enabled = true;
                grp_EmployeeTabEmployeeDetails.Enabled = true;
                grp_EmployeeTabPersonalDetails.Enabled = true;

                //Set date time picker max date
                dtp_EmployeeTabDOB.MaxDate = DateTime.Today.AddYears(-18);

            }
            catch (Exception ex)
            {
                //show error message
                printErrorMessage(ex);
            }

        }//End addEmployee


        //--------------------------- Deletion ---------------------------\\
        
        private void deleteMember()
        {
            //Declare variables
            bool hasDependentRecord = false;

            try
            {
                //Check if there are any bookings in list
                if (lstMembers.Count > 0)
                {
                    //Check if this member has dependent records
                    checkDependency(ref hasDependentRecord, lstBookings.Exists(booking => booking.MemberID.Equals(lstMembers[posInMembersList].MemberID)), "member", "booking");
                    checkDependency(ref hasDependentRecord, lstPayments.Exists(payment => payment.MemberID.Equals(lstMembers[posInMembersList].MemberID)), "member", "payment");
                    checkDependency(ref hasDependentRecord, lstPaymentMethods.Exists(paymentMethod => paymentMethod.MemberID.Equals(lstMembers[posInMembersList].MemberID)), "member", "payment method");

                    //If they do not have a dependent record
                    if (!hasDependentRecord)
                    {
                        //Ask user if they wish to delete user
                        DialogResult answer = MessageBox.Show("Are you sure you want to delete the account of " + lstMembers[posInMembersList].FirstName + " " + lstMembers[posInMembersList].Surname + "?", "Are You sure you want to delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        //check response
                        if (answer == DialogResult.Yes)
                        {
                            //Delete from the database
                            memberTable.DeleteMemberRecord(lstMembers[posInMembersList]);

                            //Delete user at the current position
                            lstMembers.RemoveAt(posInMembersList);

                            //Inform user the account has been deleted
                            informUser("Account Deletion Successful.", "Account Deleted");

                            //Refresh data grid
                            refreshMemberDataGrid();

                        }
                        else
                        {
                            informUser("Member Deletion Cancelled", "Deletion Cancelled");

                        }//End If

                    }//End If                   

                }
                else
                {
                    informUser("Member List Empty -  Deletion Cancelled", "Deletion Cancelled");

                }//End If
                
            }
            catch (Exception ex)
            {
                //show error message
                printErrorMessage(ex);
            }


        }//End deleteMember


        private void deleteClass()
        {
            //Declare variables
            bool hasDependentRecord = false;

            try
            {
                //Check if there are any classes in list
                if (lstExerciseClasses.Count > 0)
                {
                    //Check if it has a booking on the system
                    checkDependency(ref hasDependentRecord, lstBookings.Exists(booking => booking.ExerciseClassID.Equals(lstExerciseClasses[posInExerciseClassList].ExerciseClassID)), "exercise class", "booking");
                                        
                    //If they do not have a dependent record
                    if (!hasDependentRecord)
                    {
                        //Ask user if they wish to delete user
                        DialogResult answer = MessageBox.Show("Are you sure you want to delete this class?", "Are You sure you want to delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        //check response
                        if (answer == DialogResult.Yes)
                        {
                            //Delete all sessions for this class from the database
                            foreach (Session session in lstSessions)
                            {
                                //If the exercise class IDs are the same
                                if (session.ExerciseClassID == lstExerciseClasses[posInExerciseClassList].ExerciseClassID)
                                {
                                    //Remove from the database
                                    sesTable.DeleteSessionRecord(session);

                                }//End If

                            }//End Foreach

                            //remove all sessions for this class from list
                            lstSessions.RemoveAll(session => session.ExerciseClassID.Equals(lstExerciseClasses[posInExerciseClassList].ExerciseClassID));

                            //Delete from the database
                            exClassTable.DeleteExerciseClassRecord(lstExerciseClasses[posInExerciseClassList]);

                            //Delete user at the current position
                            lstExerciseClasses.RemoveAt(posInExerciseClassList);

                            //Inform user the account has been deleted
                            informUser("Class Deletion Successful.", "Class Deleted");

                            //Display First Class if there is a class to display
                            if (lstExerciseClasses.Count > 0)
                            {
                                displayClassDetails(lstExerciseClasses[lstExerciseClasses.Count - 1]);

                            }//End If

                            //Refresh data grid
                            refreshClassDataGrid();

                        }
                        else
                        {
                            informUser("Exercise Class Deletion Cancelled", "Deletion Cancelled");

                        }//End If

                    }//End If

                }
                else
                {
                    informUser("Exercise Class List Empty -  Deletion Cancelled", "Deletion Cancelled");

                }//End If

            }
            catch (Exception ex)
            {
                //show error message
                printErrorMessage(ex);
            }

        }//End deleteClass


        private void deleteBooking()
        {
            //Declare variables
            bool hasDependentRecord = false;

            try
            {
                //Check if there are any bookings in list
                if (lstBookings.Count > 0)
                {
                    //Check if it has a payment on the system
                    checkDependency(ref hasDependentRecord, lstPayments.Exists(payment => payment.BookingID.Equals(lstBookings[posInBookingsList].BookingID)), "booking", "payment");

                    //If they do not have a dependent Record
                    if (!hasDependentRecord)
                    {
                        //Ask user if they wish to delete booking
                        DialogResult answer = MessageBox.Show("Are you sure you want to delete this booking?", "Are You sure you want to delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        //check response
                        if (answer == DialogResult.Yes)
                        {
                            //Delete from the database
                            bookingTable.DeleteBookingRecord(lstBookings[posInBookingsList]);

                            //Delete booking at the current position
                            lstBookings.RemoveAt(posInBookingsList);

                            //Inform user the booking has been deleted
                            informUser("Booking Deletion Successful.", "Booking Deleted");

                            //Display First booking if there is a booking to display
                            if (lstBookings.Count > 0)
                            {
                                displayBookingDetails(lstBookings[lstBookings.Count - 1]);

                            }//End If

                            //Refresh data grid
                            refreshBookingDataGrid();

                        }
                        else
                        {
                            informUser("Booking Deletion Cancelled", "Deletion Cancelled");

                        }//End If

                    }//End If

                }
                else
                {
                    informUser("Booking List Empty -  Deletion Cancelled", "Deletion Cancelled");

                }//End If

            }
            catch (Exception ex)
            {
                //show error message
                printErrorMessage(ex);
            }

        }//End deleteBooking


        private void deletePayment()
        {
            try
            {
                //Check if there are any payments in list
                if (lstPayments.Count > 0)
                {
                    //Ask user if they wish to delete payment
                    DialogResult answer = MessageBox.Show("Are you sure you want to delete this payment?", "Are You sure you want to delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    //check response
                    if (answer == DialogResult.Yes)
                    {
                        //Delete from the database
                        payTable.DeletePaymentRecord(lstPayments[posInPaymentsList]);

                        //Delete payment at the current position
                        lstPayments.RemoveAt(posInPaymentsList);

                        //Inform user the payment has been deleted
                        informUser("Payment Deletion Successful.", "Payment Deleted");

                        //Display First payment if there is a payment to display
                        if (lstPayments.Count > 0)
                        {
                            //displayPaymentDetails(lstPayments[lstPayments.Count - 1]);

                        }//End If
                                               
                        //Refresh data grid
                        refreshPaymentDataGrid();

                    }
                    else
                    {
                        informUser("Payment Deletion Cancelled", "Deletion Cancelled");

                    }//End If

                }
                else
                {
                    informUser("Payment List Empty -  Deletion Cancelled", "Deletion Cancelled");

                }//End If

            }
            catch (Exception ex)
            {
                //show error message
                printErrorMessage(ex);
            }

        }//End deletePayment


        private void deleteRoom()
        {
            //Declare variables
            bool hasDependentRecord = false;

            try
            {
                //Check if there are any Rooms in list
                if (lstRooms.Count > 0)
                {
                    //Check if it has dependent records on the system
                    checkDependency(ref hasDependentRecord, lstExerciseClasses.Exists(exClass => exClass.RoomID.Equals(lstRooms[posInRoomsList].RoomID)), "room", "exercise class");
                    checkDependency(ref hasDependentRecord, lstRoomHire.Exists(roomHire => roomHire.RoomID.Equals(lstRooms[posInRoomsList].RoomID)), "room", "room hire");
                    
                    //If no dependent record found
                    if (!hasDependentRecord)
                    {
                        //Ask user if they wish to delete Room
                        DialogResult answer = MessageBox.Show("Are you sure you want to delete this Room?", "Are You sure you want to delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        //check response
                        if (answer == DialogResult.Yes)
                        {
                            //delete room from database
                            roomTable.DeleteRoomRecord(lstRooms[posInRoomsList]);

                            //Delete Room at the current position
                            lstRooms.RemoveAt(posInRoomsList);

                            //Inform user the Room has been deleted
                            informUser("Room Deletion Successful.", "Room Deleted");

                            //Display First Room if there is a Room to display
                            if (lstRooms.Count > 0)
                            {
                                displayRoomDetails(lstRooms[lstRooms.Count - 1]);

                            }//End If

                            //Refresh data grid
                            refreshRoomDataGrid();

                        }
                        else
                        {
                            informUser("Room Deletion Cancelled", "Deletion Cancelled");

                        }//End If

                    }//End If

                }
                else
                {
                    informUser("Room List Empty -  Deletion Cancelled", "Deletion Cancelled");

                }//End If

            }
            catch (Exception ex)
            {
                //show error message
                printErrorMessage(ex);
            }

        }//End deleteRoom


        private void deleteRoomHire()
        {            
            try
            {
                //Check if there are any RoomHires in list
                if (lstRoomHire.Count > 0)
                {
                    //Ask user if they wish to delete RoomHire
                    DialogResult answer = MessageBox.Show("Are you sure you want to delete this Room Hire?", "Are You sure you want to delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    //check response
                    if (answer == DialogResult.Yes)
                    {
                        //Delete from the database
                        roomHireTable.DeleteRoomHireRecord(lstRoomHire[posInRoomHireList]);

                        //Delete RoomHire at the current position
                        lstRoomHire.RemoveAt(posInRoomHireList);

                        //Inform user the RoomHire has been deleted
                        informUser("Room Hire Deletion Successful.", "Room Hire Deleted");

                        //Display First RoomHire if there is a RoomHire to display
                        if (lstRoomHire.Count > 0)
                        {
                            displayRoomHireDetails(lstRoomHire[lstRoomHire.Count - 1]);

                        }//End If

                        //Refresh data grid
                        refreshRoomHireDataGrid();

                    }
                    else
                    {
                        informUser("Room Hire Deletion Cancelled", "Deletion Cancelled");

                    }//End If

                }
                else
                {
                    informUser("Room Hire List Empty -  Deletion Cancelled", "Deletion Cancelled");

                }//End If

            }
            catch (Exception ex)
            {
                //show error message
                printErrorMessage(ex);
            }

        }//End deleteRoomHire


        private void deleteExternalCompany()
        {
            //Declare variables
            bool hasDependentRecord = false;

            try
            {
                //Check if there are any ExternalCompanies in list
                if (lstExternalCompanies.Count > 0)
                {
                    //Check if it has a dependent record on the system
                    checkDependency(ref hasDependentRecord, lstExerciseClasses.Exists(exClass => exClass.ExternalCompanyID.Equals(lstExternalCompanies[posInExternalCompanyList].ExternalCompanyID)), "external company", "exercise class");
                    checkDependency(ref hasDependentRecord, lstRoomHire.Exists(roomHire => roomHire.ExternalCompanyID.Equals(lstExternalCompanies[posInExternalCompanyList].ExternalCompanyID)), "external company", "room hire");
                    
                    //If no dependent record found
                    if (!hasDependentRecord)
                    {
                        //Ask user if they wish to delete ExternalCompany
                        DialogResult answer = MessageBox.Show("Are you sure you want to delete this External Company?", "Are You sure you want to delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        //check response
                        if (answer == DialogResult.Yes)
                        {
                            //Delete from the database
                            extCompTable.DeleteExternalCompanyRecord(lstExternalCompanies[posInExternalCompanyList]);

                            //Delete ExternalCompany at the current position
                            lstExternalCompanies.RemoveAt(posInExternalCompanyList);

                            //Inform user the ExternalCompany has been deleted
                            informUser("External Company Deletion Successful.", "External Company Deleted");

                            //Display First ExternalCompany if there is a ExternalCompany to display
                            if (lstExternalCompanies.Count > 0)
                            {
                                displayExternalCompanyDetails(lstExternalCompanies[lstExternalCompanies.Count - 1]);

                            }//End If

                            //Refresh data grid
                            refreshExternalCompanyDataGrid();

                        }
                        else
                        {
                            informUser("External Company Deletion Cancelled", "Deletion Cancelled");

                        }//End If

                    }//End If
                }
                else
                {
                    informUser("External Company List Empty -  Deletion Cancelled", "Deletion Cancelled");

                }//End If

            }
            catch (Exception ex)
            {
                //show error message
                printErrorMessage(ex);
            }

        }//End deleteExternalCompany


        private void deleteEmployee()
        {
            //Declare variables
            bool hasDependentRecord = false;

            try
            {
                //Check if there are any Employees in list
                if (lstEmployees.Count > 0)
                {
                    //Check if it has a dependent record on the system
                    checkDependency(ref hasDependentRecord, lstBookings.Exists(booking => booking.EmployeeID.Equals(lstEmployees[posInEmployeeList].EmployeeID)), "employee", "booking");
                    checkDependency(ref hasDependentRecord, lstExerciseClasses.Exists(exClass => exClass.EmployeeID.Equals(lstEmployees[posInEmployeeList].EmployeeID)), "employee", "exercise class");
                    checkDependency(ref hasDependentRecord, lstStaffQualifications.Exists(staffQual => staffQual.EmployeeID.Equals(lstEmployees[posInEmployeeList].EmployeeID)), "employee", "staff qualification");
                    
                    //If it does not have dependent records
                    if (!hasDependentRecord)
                    {
                        //Ask user if they wish to delete user
                        DialogResult answer = MessageBox.Show("Are you sure you want to delete the account of " + lstEmployees[posInEmployeeList].FirstName + " " + lstEmployees[posInEmployeeList].Surname + "?", "Are You sure you want to delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        //check response
                        if (answer == DialogResult.Yes)
                        {
                            //delete from the database
                            employeeTable.DeleteEmployeeRecord(lstEmployees[posInEmployeeList]);

                            //Delete user at the current position
                            lstEmployees.RemoveAt(posInEmployeeList);

                            //Inform user the account has been deleted
                            informUser("Employment Record Deletion Successful.", "Employment Record Deleted");

                            //Refresh data grid
                            refreshEmployeeDataGrid();

                        }
                        else
                        {
                            informUser("Employment Record Deletion Cancelled", "Deletion Cancelled");

                        }//End If

                    }//End If                    

                }
                else
                {
                    informUser("Employee List Empty -  Deletion Cancelled", "Deletion Cancelled");

                }//End If

            }
            catch (Exception ex)
            {
                //show error message
                printErrorMessage(ex);
            }

        }//End deleteEmployee


        //--------------------------- Search ---------------------------\\

        private void searchForMember()
        {
            //Declare Variables                
            string searchTerm = "";
            bool memberFound = false;

            try
            {
                //clear the current search list and data grid
                lstMemberSearchResults.Clear();
                dgv_MembersList.DataSource = "";
                
                //Validate Entry
                if (!String.IsNullOrWhiteSpace(mst_MemberTabSearchTerm.Text))
                {
                    //Assign variable
                    searchTerm = mst_MemberTabSearchTerm.Text.Trim().ToLower(); ;

                    //Search according to the field
                    switch (selectedSearchField)
                    {
                        case 0:

                            //Search List
                            foreach (Member member in lstMembers)
                            {

                                if (member.Surname.ToLower() == searchTerm || member.Surname.ToLower().StartsWith(searchTerm))
                                {
                                    //Member was found
                                    memberFound = true;

                                    //Add Member to search results
                                    lstMemberSearchResults.Add(member);

                                }//End If

                            }//End Foreach


                            //If member was not found
                            messageForMemberFound(memberFound, "surname", searchTerm);

                            break;


                        case 1:

                            //Search List
                            foreach (Member member in lstMembers)
                            {
                                if (member.FirstName.ToLower() == searchTerm || member.FirstName.ToLower().StartsWith(searchTerm))
                                {
                                    //Member was found
                                    memberFound = true;

                                    //Add Member to search results
                                    lstMemberSearchResults.Add(member);

                                }//End If

                            }//End Foreach

                            //If member was not found
                            messageForMemberFound(memberFound, "first name", searchTerm);

                            break;


                        case 2:

                            //Search List
                            foreach (Member member in lstMembers)
                            {
                                if (member.Address == searchTerm || member.Address.ToLower().StartsWith(searchTerm))
                                {
                                    //Member was found
                                    memberFound = true;

                                    //Add Member to search results
                                    lstMemberSearchResults.Add(member);

                                }//End If

                            }//End Foreach

                            //If member was not found
                            messageForMemberFound(memberFound, "address", searchTerm);

                            break;


                        case 3:

                            //Search List
                            foreach (Member member in lstMembers)
                            {
                                if (member.Town.ToLower() == searchTerm || member.Town.ToLower().StartsWith(searchTerm))
                                {
                                    //Member was found
                                    memberFound = true;

                                    //Add Member to search results
                                    lstMemberSearchResults.Add(member);

                                }//End If

                            }//End Foreach

                            //If member was not found
                            messageForMemberFound(memberFound, "town", searchTerm);

                            break;

                        case 4:

                            //Search List
                            foreach (Member member in lstMembers)
                            {
                                if (member.PostCode == searchTerm || member.PostCode.StartsWith(searchTerm))
                                {
                                    //Member was found
                                    memberFound = true;

                                    //Add Member to search results
                                    lstMemberSearchResults.Add(member);

                                }//End If

                            }//End Foreach

                            //If member was not found
                            messageForMemberFound(memberFound, "postcode", searchTerm);

                            break;

                        case 5:

                            //Search List
                            foreach (Member member in lstMembers)
                            {
                                if (member.TelNo == searchTerm || member.TelNo.StartsWith(searchTerm))
                                {
                                    //Member was found
                                    memberFound = true;

                                    //Add Member to search results
                                    lstMemberSearchResults.Add(member);

                                }//End If

                            }//End Foreach

                            //If member was not found
                            messageForMemberFound(memberFound, "telephone number", searchTerm);

                            break;

                        case 6:

                            //Search List
                            foreach (Member member in lstMembers)
                            {
                                if (member.Email == searchTerm || member.Email.StartsWith(searchTerm))
                                {
                                    //Member was found
                                    memberFound = true;

                                    //Add Member to search results
                                    lstMemberSearchResults.Add(member);

                                }//End If

                            }//End Foreach

                            //If member was not found
                            messageForMemberFound(memberFound, "email", searchTerm);

                            break;

                    }//End Switch

                    //Change data grid view to search results
                    dgv_MembersList.DataSource = lstMemberSearchResults;

                }
                else
                {
                    //Invalid Search
                    errorToUser("The search you tried to perform was using an invalid search term.\nPlease try again.", "Invalid Search Term");

                }//End If


                //Reset the bool to false
                memberFound = false;

                //clear textbox
                mst_MemberTabSearchTerm.Clear();
                mst_MemberTabSearchTerm.Focus();

            }
            catch (Exception ex)
            {
                //print error message
                printErrorMessage(ex);
            }


        }//End searchForMember


        private void searchForExerciseClass()
        {
            //Declare Variables                
            string searchTerm = "";
            bool classFound = false;

            try
            {
                //clear the current search list and data grid
                lstExerciseClassSearchResults.Clear();
                dgv_ExerciseClassList.DataSource = "";
                

                //Validate Entry
                if (!String.IsNullOrWhiteSpace(mst_ClassTabSearchTerm.Text))
                {
                    //Assign variable
                    searchTerm = mst_ClassTabSearchTerm.Text.Trim().ToLower();

                    //Search according to the field
                    switch (selectedSearchField)
                    {
                        case 0:

                            //Search List
                            foreach (ExerciseClass exerciseClass in lstExerciseClasses)
                            {

                                if (exerciseClass.ExerciseClassID.ToString() == searchTerm)
                                {
                                    //class was found
                                    classFound = true;

                                    //Add class to search results
                                    lstExerciseClassSearchResults.Add(exerciseClass);

                                }//End If

                            }//End Foreach


                            //If class was not found
                            messageForClassFound(classFound, "classID", searchTerm);

                            break;


                        case 1:

                            //Search List
                            foreach (ExerciseClass exerciseClass in lstExerciseClasses)
                            {
                                if (exerciseClass.EmployeeID.ToString() == searchTerm)
                                {
                                    //class was found
                                    classFound = true;

                                    //Add class to search results
                                    lstExerciseClassSearchResults.Add(exerciseClass);

                                }//End If

                            }//End Foreach

                            //If class was not found
                            messageForClassFound(classFound, "employeeID", searchTerm);

                            break;


                        case 2:

                            //Search List
                            foreach (ExerciseClass exerciseClass in lstExerciseClasses)
                            {
                                if (exerciseClass.RoomID.ToString() == searchTerm)
                                {
                                    //class was found
                                    classFound = true;

                                    //Add class to search results
                                    lstExerciseClassSearchResults.Add(exerciseClass);

                                }//End If

                            }//End Foreach

                            //If class was not found
                            messageForClassFound(classFound, "roomID", searchTerm);

                            break;


                        case 3:

                            //Search List
                            foreach (ExerciseClass exerciseClass in lstExerciseClasses)
                            {
                                if (exerciseClass.Description.ToLower() == searchTerm || exerciseClass.Description.ToLower().StartsWith(searchTerm))
                                {
                                    //class was found
                                    classFound = true;

                                    //Add class to search results
                                    lstExerciseClassSearchResults.Add(exerciseClass);

                                }//End If

                            }//End Foreach

                            //If member was not found
                            messageForClassFound(classFound, "description", searchTerm);

                            break;


                        case 4:

                            //Search List
                            foreach (ExerciseClass exerciseClass in lstExerciseClasses)
                            {
                                if (exerciseClass.Difficulty.ToLower() == searchTerm || exerciseClass.Difficulty.StartsWith(searchTerm))
                                {
                                    //class was found
                                    classFound = true;

                                    //Add class to search results
                                    lstExerciseClassSearchResults.Add(exerciseClass);

                                }//End If

                            }//End Foreach

                            //If class was not found
                            messageForClassFound(classFound, "difficulty", searchTerm);

                            break;

                       
                        case 5:

                            //Search List
                            foreach (ExerciseClass exerciseClass in lstExerciseClasses)
                            {
                                if (exerciseClass.MaxNumberOfParticipants.ToString() == searchTerm)
                                {
                                    //class was found
                                    classFound = true;

                                    //Add class to search results
                                    lstExerciseClassSearchResults.Add(exerciseClass);

                                }//End If

                            }//End Foreach

                            //If class was not found
                            messageForClassFound(classFound, "number of participants", searchTerm);

                            break;
                            
                    }//End Switch

                    //Change data grid view to search results
                    dgv_ExerciseClassList.DataSource = lstExerciseClassSearchResults;

                }
                else
                {
                    //Invalid Search
                    errorToUser("The search you tried to perform was using an invalid search term.\nPlease try again.", "Invalid Search Term");

                }//End If


                //Reset the bool to false
                classFound = false;

                //clear textbox
                mst_ClassTabSearchTerm.Clear();
                mst_ClassTabSearchTerm.Focus();

            }
            catch (Exception ex)
            {
                //print error message
                printErrorMessage(ex);
            }


        }//End searchForClass


        private void searchForBooking()
        {
            //declare variables
            string searchTerm = "";
            bool bookingFound = false;

            try
            {
                //Clear the current search list and data grid view
                lstBookingSearchResults.Clear();
                dgv_BookingList.DataSource = "";

                //Validate Entry
                if (!String.IsNullOrWhiteSpace(mst_BookingsTabSearchTerm.Text))
                {
                    //Assign variable
                    searchTerm = mst_BookingsTabSearchTerm.Text.Trim().ToLower();

                    //Switch on selected search field
                    switch (selectedSearchField)
                    {
                        //Booking ID
                        case 0:

                            foreach (Booking booking in lstBookings)
                            {
                                if (booking.BookingID.ToString() == searchTerm)
                                {
                                    //Has the same booking ID therefore assign to the list
                                    lstBookingSearchResults.Add(booking);

                                    //Booking Found
                                    bookingFound = true;

                                }//End If
                                
                            }//End Foreach

                            //Display on screen message if no results found
                            messageForBookingFound(bookingFound, "Booking ID", searchTerm);
                            
                            break;


                        //Member ID
                        case 1:

                            foreach (Booking booking in lstBookings)
                            {
                                if (booking.MemberID.ToString() == searchTerm)
                                {
                                    //Has the same member ID therefore assign to the list
                                    lstBookingSearchResults.Add(booking);

                                    //Booking Found
                                    bookingFound = true;

                                }//End If

                            }//End Foreach

                            //Display on screen message if no results found
                            messageForBookingFound(bookingFound, "Member ID", searchTerm);

                            break;


                        //Exercise Class ID
                        case 2:

                            foreach (Booking booking in lstBookings)
                            {
                                if (booking.ExerciseClassID.ToString() == searchTerm)
                                {
                                    //Has the same Exercise Class ID therefore assign to the list
                                    lstBookingSearchResults.Add(booking);

                                    //Booking Found
                                    bookingFound = true;

                                }//End If

                            }//End Foreach

                            //Display on screen message if no results found
                            messageForBookingFound(bookingFound, "Exercise Class ID", searchTerm);

                            break;


                        //Employee ID
                        case 3:

                            foreach (Booking booking in lstBookings)
                            {
                                if (booking.EmployeeID.ToString() == searchTerm)
                                {
                                    //Has the same Employee ID therefore assign to the list
                                    lstBookingSearchResults.Add(booking);

                                    //Booking Found
                                    bookingFound = true;

                                }//End If

                            }//End Foreach

                            //Display on screen message if no results found
                            messageForBookingFound(bookingFound, "Employee ID", searchTerm);

                            break;

                    }//End Switch

                    //Change the data source of the data grid view to the search results
                    dgv_BookingList.DataSource = lstBookingSearchResults;

                }
                else
                {
                    //Invalid Search
                    errorToUser("The search you tried to perform was using an invalid search term.\nPlease try again.", "Invalid Search Term");

                }//End If


                //Reset the bool to false
                bookingFound = false;

                //clear textbox and focus
                mst_BookingsTabSearchTerm.Clear();
                mst_BookingsTabSearchTerm.Focus();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }


        }//End searchForBooking


        private void searchForPayment()
        {
            string searchTerm = "";
            bool paymentFound = false;

            try
            {
                //Clear the current search list and data grid view
                lstPaymentSearchResults.Clear();
                dgv_PaymentList.DataSource = "";

                if (!String.IsNullOrWhiteSpace(mst_PaymentTabSearchTerm.Text))
                {
                    //Assign variable
                    searchTerm = mst_PaymentTabSearchTerm.Text.Trim().ToLower();

                    //Switch on selected search field
                    switch (selectedSearchField)
                    {

                        case 0:

                            foreach (Payment payment in lstPayments)
                            {
                                if (payment.PaymentID.ToString() == searchTerm)
                                {
                                    //Has the same payment ID therefore assign to the list
                                    lstPaymentSearchResults.Add(payment);

                                    //payment Found
                                    paymentFound = true;

                                }//End If

                            }//End Foreach

                            //Display on screen message if no results found
                            messageForPaymentFound(paymentFound, "Payment ID", searchTerm);

                            break;

                        case 1:

                            foreach (Payment payment in lstPayments)
                            {
                                if (payment.MemberID.ToString() == searchTerm)
                                {
                                    //Has the same MemberID therefore assign to the list
                                    lstPaymentSearchResults.Add(payment);

                                    //payment Found
                                    paymentFound = true;

                                }//End If

                            }//End Foreach

                            //Display on screen message if no results found
                            messageForPaymentFound(paymentFound, "Member ID", searchTerm);

                            break;


                        case 2:

                            foreach (Payment payment in lstPayments)
                            {
                                if (payment.BookingID.ToString() == searchTerm)
                                {
                                    //Has the same Booking ID therefore assign to the list
                                    lstPaymentSearchResults.Add(payment);

                                    //payment Found
                                    paymentFound = true;

                                }//End If

                            }//End Foreach

                            //Display on screen message if no results found
                            messageForPaymentFound(paymentFound, "Booking ID", searchTerm);

                            break;



                        case 3:

                            foreach (Payment payment in lstPayments)
                            {
                                if (payment.PaymentMethodID.ToString() == searchTerm)
                                {
                                    //Has the same Payment Method ID therefore assign to the list
                                    lstPaymentSearchResults.Add(payment);

                                    //payment Found
                                    paymentFound = true;

                                }//End If

                            }//End Foreach

                            //Display on screen message if no results found
                            messageForPaymentFound(paymentFound, "Payment Method ID", searchTerm);

                            break;



                        case 4:

                            foreach (Payment payment in lstPayments)
                            {
                                if (payment.AmountPaid.ToString() == searchTerm)
                                {
                                    //Has the same Amount Paid therefore assign to the list
                                    lstPaymentSearchResults.Add(payment);

                                    //payment Found
                                    paymentFound = true;

                                }//End If

                            }//End Foreach

                            //Display on screen message if no results found
                            messageForPaymentFound(paymentFound, "Amount Paid", searchTerm);

                            break;

                    }//End Switch

                    //set the data source to the search results
                    dgv_PaymentList.DataSource = lstPaymentSearchResults;

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

        }//End searchForPayment


        private void searchForRoom()
        {
            string searchTerm = "";
            bool roomFound = false;

            try
            {
                //Clear the current search list and data grid view
                lstRoomSearchResults.Clear();
                dgv_RoomList.DataSource = "";

                if (!String.IsNullOrWhiteSpace(mst_RoomTabSearchTerm.Text))
                {
                    //Assign variable
                    searchTerm = mst_RoomTabSearchTerm.Text.Trim().ToLower();

                    //Switch on selected search field
                    switch (selectedSearchField)
                    {
                        
                        case 0:

                            foreach (Room Room in lstRooms)
                            {
                                if (Room.RoomID.ToString() == searchTerm)
                                {
                                    //Has the same Room ID therefore assign to the list
                                    lstRoomSearchResults.Add(Room);

                                    //Room Found
                                    roomFound = true;

                                }//End If

                            }//End Foreach

                            //Display on screen message if no results found
                            messageForRoomFound(roomFound, "Room ID", searchTerm);

                            break;

                        case 1:

                            foreach (Room Room in lstRooms)
                            {
                                if (Room.RoomDescription.ToLower() == searchTerm || Room.RoomDescription.ToLower().Contains(searchTerm))
                                {
                                    //Has the same Room Description therefore assign to the list
                                    lstRoomSearchResults.Add(Room);

                                    //Room Found
                                    roomFound = true;

                                }//End If

                            }//End Foreach

                            //Display on screen message if no results found
                            messageForRoomFound(roomFound, "Room Description", searchTerm);

                            break;


                        case 2:

                            foreach (Room Room in lstRooms)
                            {
                                if (Room.RoomLocation.ToLower() == searchTerm || Room.RoomLocation.ToLower().Contains(searchTerm))
                                {
                                    //Has the same Room Location therefore assign to the list
                                    lstRoomSearchResults.Add(Room);

                                    //Room Found
                                    roomFound = true;

                                }//End If

                            }//End Foreach

                            //Display on screen message if no results found
                            messageForRoomFound(roomFound, "Room Location", searchTerm);

                            break;



                        case 3:

                            foreach (Room Room in lstRooms)
                            {
                                if (Room.Capacity.ToString() == searchTerm)
                                {
                                    //Has the same Capacity therefore assign to the list
                                    lstRoomSearchResults.Add(Room);

                                    //Room Found
                                    roomFound = true;

                                }//End If

                            }//End Foreach

                            //Display on screen message if no results found
                            messageForRoomFound(roomFound, "Capacity", searchTerm);

                            break;



                        case 4:

                            foreach (Room Room in lstRooms)
                            {
                                if (Room.HourlyHireCost.ToString() == searchTerm || Room.HourlyHireCost.ToString().Contains(searchTerm))
                                {
                                    //Has the same Hourly Hire Cost therefore assign to the list
                                    lstRoomSearchResults.Add(Room);

                                    //Room Found
                                    roomFound = true;

                                }//End If

                            }//End Foreach

                            //Display on screen message if no results found
                            messageForRoomFound(roomFound, "Hourly Hire Cost", searchTerm);

                            break;

                    }//End Switch

                    //set the data source to the search results
                    dgv_RoomList.DataSource = lstRoomSearchResults;

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

        }//End searchForRoom

        
        private void searchForRoomHire()
        {
            string searchTerm = "";
            bool roomHireFound = false;

            try
            {
                //Clear the current search list and data grid view
                lstRoomHireSearchResults.Clear();
                dgv_RoomHireList.DataSource = "";

                if (!String.IsNullOrWhiteSpace(mst_RoomHireTabSearchTerm.Text))
                {
                    //Assign variable
                    searchTerm = mst_RoomHireTabSearchTerm.Text.Trim().ToLower();

                    //Switch on selected search field
                    switch (selectedSearchField)
                    {

                        case 0:

                            foreach (RoomHire roomHire in lstRoomHire)
                            {
                                if (roomHire.RoomHireID.ToString() == searchTerm)
                                {
                                    //Has the same Room Hire ID therefore assign to the list
                                    lstRoomHireSearchResults.Add(roomHire);

                                    //RoomHire Found
                                    roomHireFound = true;

                                }//End If

                            }//End Foreach

                            //Display on screen message if no results found
                            messageForRoomHireFound(roomHireFound, "RoomHire ID", searchTerm);

                            break;

                        case 1:

                            foreach (RoomHire roomHire in lstRoomHire)
                            {
                                if (roomHire.RoomID.ToString() == searchTerm)
                                {
                                    //Has the same Room ID therefore assign to the list
                                    lstRoomHireSearchResults.Add(roomHire);

                                    //RoomHire Found
                                    roomHireFound = true;

                                }//End If

                            }//End Foreach

                            //Display on screen message if no results found
                            messageForRoomHireFound(roomHireFound, "RoomHire Description", searchTerm);

                            break;


                        case 2:

                            foreach (RoomHire roomHire in lstRoomHire)
                            {
                                if (roomHire.ExternalCompanyID.ToString() == searchTerm)
                                {
                                    //Has the same External Company ID therefore assign to the list
                                    lstRoomHireSearchResults.Add(roomHire);

                                    //Room Found
                                    roomHireFound = true;

                                }//End If

                            }//End Foreach

                            //Display on screen message if no results found
                            messageForRoomHireFound(roomHireFound, "External Company ID", searchTerm);

                            break;



                        case 3:

                            foreach (RoomHire roomHire in lstRoomHire)
                            {
                                if (roomHire.StartDate.ToString() == searchTerm || roomHire.StartDate.ToString().StartsWith(searchTerm))
                                {
                                    //Has the same Start Date therefore assign to the list
                                    lstRoomHireSearchResults.Add(roomHire);

                                    //Room Found
                                    roomHireFound = true;

                                }//End If

                            }//End Foreach

                            //Display on screen message if no results found
                            messageForRoomHireFound(roomHireFound, "Start Date", searchTerm);

                            break;



                        case 4:

                            foreach (RoomHire roomHire in lstRoomHire)
                            {
                                if (roomHire.HireDuration.ToString() == searchTerm)
                                {
                                    //Has the same Hire Duration therefore assign to the list
                                    lstRoomHireSearchResults.Add(roomHire);

                                    //Room Found
                                    roomHireFound = true;

                                }//End If

                            }//End Foreach

                            //Display on screen message if no results found
                            messageForRoomHireFound(roomHireFound, "Hire Duration", searchTerm);

                            break;


                        case 5:

                            foreach (RoomHire roomHire in lstRoomHire)
                            {
                                if (roomHire.EndDate.ToString() == searchTerm || roomHire.EndDate.ToString().StartsWith(searchTerm))
                                {
                                    //Has the same Hire Duration therefore assign to the list
                                    lstRoomHireSearchResults.Add(roomHire);

                                    //Room Found
                                    roomHireFound = true;

                                }//End If

                            }//End Foreach

                            //Display on screen message if no results found
                            messageForRoomHireFound(roomHireFound, "End Date", searchTerm);

                            break;


                        case 6:

                            foreach (RoomHire roomHire in lstRoomHire)
                            {
                                if (roomHire.HoursPerWeek.ToString() == searchTerm)
                                {
                                    //Has the same Hours Per Week therefore assign to the list
                                    lstRoomHireSearchResults.Add(roomHire);

                                    //Room Found
                                    roomHireFound = true;

                                }//End If

                            }//End Foreach

                            //Display on screen message if no results found
                            messageForRoomHireFound(roomHireFound, "Hours Per Week", searchTerm);

                            break;

                        case 7:

                            foreach (RoomHire roomHire in lstRoomHire)
                            {
                                if (roomHire.MonthlyHireCost.ToString() == searchTerm || roomHire.MonthlyHireCost.ToString().Contains(searchTerm))
                                {
                                    //Has the same Monthly Hire Cost therefore assign to the list
                                    lstRoomHireSearchResults.Add(roomHire);

                                    //Room Found
                                    roomHireFound = true;

                                }//End If

                            }//End Foreach

                            //Display on screen message if no results found
                            messageForRoomHireFound(roomHireFound, "Monthly Hire Cost", searchTerm);

                            break;

                        case 8:

                            foreach (RoomHire roomHire in lstRoomHire)
                            {
                                if (roomHire.TotalHireCost.ToString() == searchTerm || roomHire.TotalHireCost.ToString().Contains(searchTerm))
                                {
                                    //Has the same Total Hire Cost therefore assign to the list
                                    lstRoomHireSearchResults.Add(roomHire);

                                    //Room Found
                                    roomHireFound = true;

                                }//End If

                            }//End Foreach

                            //Display on screen message if no results found
                            messageForRoomHireFound(roomHireFound, "Total Hire Cost", searchTerm);

                            break;

                    }//End Switch


                    //set the data source to the search results
                    dgv_RoomHireList.DataSource = lstRoomHireSearchResults;


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

        }//End searchForRoomHire


        private void searchForExternalCompany()
        {
            //Declare Variables                
            string searchTerm = "";
            bool externalCompanyFound = false;

            try
            {
                //clear the current search list and data grid
                lstExternalCompanySearchResults.Clear();
                dgv_ExternalCompanyList.DataSource = "";

                //Validate Entry
                if (!String.IsNullOrWhiteSpace(mst_ExternalCompanyTabSearchTerm.Text))
                {
                    //Assign variable
                    searchTerm = mst_ExternalCompanyTabSearchTerm.Text.Trim().ToLower(); ;

                    //Search according to the field
                    switch (selectedSearchField)
                    {
                        case 0:

                            //Search List
                            foreach (ExternalCompany externalCompany in lstExternalCompanies)
                            {

                                if (externalCompany.ExternalCompanyID.ToString() == searchTerm)
                                {
                                    //ExternalCompany was found
                                    externalCompanyFound = true;

                                    //Add ExternalCompany to search results
                                    lstExternalCompanySearchResults.Add(externalCompany);

                                }//End If

                            }//End Foreach


                            //If ExternalCompany was not found
                            messageForExternalCompanyFound(externalCompanyFound, "External Company ID", searchTerm);

                            break;


                        case 1:

                            //Search List
                            foreach (ExternalCompany externalCompany in lstExternalCompanies)
                            {
                                if (externalCompany.CompanyName.ToLower() == searchTerm || externalCompany.CompanyName.ToLower().StartsWith(searchTerm))
                                {
                                    //ExternalCompany was found
                                    externalCompanyFound = true;

                                    //Add ExternalCompany to search results
                                    lstExternalCompanySearchResults.Add(externalCompany);

                                }//End If

                            }//End Foreach

                            //If ExternalCompany was not found
                            messageForExternalCompanyFound(externalCompanyFound, "Company Name", searchTerm);

                            break;


                        case 2:

                            //Search List
                            foreach (ExternalCompany ExternalCompany in lstExternalCompanies)
                            {
                                if (ExternalCompany.CompanyAddress == searchTerm || ExternalCompany.CompanyAddress.ToLower().StartsWith(searchTerm))
                                {
                                    //ExternalCompany was found
                                    externalCompanyFound = true;

                                    //Add ExternalCompany to search results
                                    lstExternalCompanySearchResults.Add(ExternalCompany);

                                }//End If

                            }//End Foreach

                            //If ExternalCompany was not found
                            messageForExternalCompanyFound(externalCompanyFound, "Company Address", searchTerm);

                            break;


                        case 3:

                            //Search List
                            foreach (ExternalCompany ExternalCompany in lstExternalCompanies)
                            {
                                if (ExternalCompany.CompanyTown.ToLower() == searchTerm || ExternalCompany.CompanyTown.ToLower().StartsWith(searchTerm))
                                {
                                    //ExternalCompany was found
                                    externalCompanyFound = true;

                                    //Add ExternalCompany to search results
                                    lstExternalCompanySearchResults.Add(ExternalCompany);

                                }//End If

                            }//End Foreach

                            //If ExternalCompany was not found
                            messageForExternalCompanyFound(externalCompanyFound, "Company Town", searchTerm);

                            break;


                        case 4:

                            //Search List
                            foreach (ExternalCompany ExternalCompany in lstExternalCompanies)
                            {
                                if (ExternalCompany.CompanyPostCode == searchTerm || ExternalCompany.CompanyPostCode.StartsWith(searchTerm))                                
                                {
                                    //ExternalCompany was found
                                    externalCompanyFound = true;

                                    //Add ExternalCompany to search results
                                    lstExternalCompanySearchResults.Add(ExternalCompany);

                                }//End If

                            }//End Foreach

                            //If ExternalCompany was not found
                            messageForExternalCompanyFound(externalCompanyFound, "Company Postcode", searchTerm);

                            break;

                        case 5:

                            //Search List
                            foreach (ExternalCompany ExternalCompany in lstExternalCompanies)
                            {
                                if (ExternalCompany.CompanyPractice.ToLower() == searchTerm || ExternalCompany.CompanyPractice.ToLower().StartsWith(searchTerm))
                                {
                                    //ExternalCompany was found
                                    externalCompanyFound = true;

                                    //Add ExternalCompany to search results
                                    lstExternalCompanySearchResults.Add(ExternalCompany);

                                }//End If

                            }//End Foreach

                            //If ExternalCompany was not found
                            messageForExternalCompanyFound(externalCompanyFound, "Company Practice", searchTerm);

                            break;

                        case 6:

                            //Search List
                            foreach (ExternalCompany ExternalCompany in lstExternalCompanies)
                            {
                                if (ExternalCompany.ContactName.ToLower() == searchTerm || ExternalCompany.ContactName.ToLower().StartsWith(searchTerm))
                                {
                                    //ExternalCompany was found
                                    externalCompanyFound = true;

                                    //Add ExternalCompany to search results
                                    lstExternalCompanySearchResults.Add(ExternalCompany);

                                }//End If

                            }//End Foreach

                            //If ExternalCompany was not found
                            messageForExternalCompanyFound(externalCompanyFound, "Contact Name", searchTerm);

                            break;

                        case 7:

                            //Search List
                            foreach (ExternalCompany ExternalCompany in lstExternalCompanies)
                            {
                                if (ExternalCompany.ContactTelNo == searchTerm || ExternalCompany.ContactTelNo.StartsWith(searchTerm))
                                {
                                    //ExternalCompany was found
                                    externalCompanyFound = true;

                                    //Add ExternalCompany to search results
                                    lstExternalCompanySearchResults.Add(ExternalCompany);

                                }//End If

                            }//End Foreach

                            //If ExternalCompany was not found
                            messageForExternalCompanyFound(externalCompanyFound, "Contact Telephone Number", searchTerm);

                            break;

                        case 8:

                            //Search List
                            foreach (ExternalCompany ExternalCompany in lstExternalCompanies)
                            {
                                if (ExternalCompany.ContactEmail == searchTerm || ExternalCompany.ContactEmail.StartsWith(searchTerm))
                                {
                                    //ExternalCompany was found
                                    externalCompanyFound = true;

                                    //Add ExternalCompany to search results
                                    lstExternalCompanySearchResults.Add(ExternalCompany);

                                }//End If

                            }//End Foreach

                            //If ExternalCompany was not found
                            messageForExternalCompanyFound(externalCompanyFound, "Contact Email", searchTerm);

                            break;

                    }//End Switch

                    //Change data grid view to search results
                    dgv_ExternalCompanyList.DataSource = lstExternalCompanySearchResults;

                }
                else
                {
                    //Invalid Search
                    errorToUser("The search you tried to perform was using an invalid search term.\nPlease try again.", "Invalid Search Term");

                }//End If


                //Reset the bool to false
                externalCompanyFound = false;

                //clear textbox
                mst_ExternalCompanyTabSearchTerm.Clear();
                mst_ExternalCompanyTabSearchTerm.Focus();

            }
            catch (Exception ex)
            {
                //print error message
                printErrorMessage(ex);
            }


        }//End searchForExternalCompany

       
        private void searchForEmployee()
        {
            //Declare Variables                
            string searchTerm = "";
            bool employeeFound = false;

            try
            {
                //clear the current search list and data grid
                lstEmployeeSearchResults.Clear();
                dgv_EmployeeList.DataSource = "";

                //Validate Entry
                if (!String.IsNullOrWhiteSpace(mst_EmployeeTabSearchTerm.Text))
                {
                    //Assign variable
                    searchTerm = mst_EmployeeTabSearchTerm.Text.Trim().ToLower(); ;

                    //Search according to the field
                    switch (selectedSearchField)
                    {

                        case 0:

                            //Search List
                            foreach (Employee employee in lstEmployees)
                            {

                                if (employee.EmployeeID.ToString() == searchTerm || employee.EmployeeID.ToString().Contains(searchTerm))
                                {
                                    //Employee was found
                                    employeeFound = true;

                                    //Add Employee to search results
                                    lstEmployeeSearchResults.Add(employee);

                                }//End If

                            }//End Foreach


                            //If employee was not found
                            messageForEmployeeFound(employeeFound, "employee ID", searchTerm);

                            break;


                        case 1:

                            //Search List
                            foreach (Employee employee in lstEmployees)
                            {

                                if (employee.Surname.ToLower() == searchTerm || employee.Surname.ToLower().Contains(searchTerm))
                                {
                                    //Employee was found
                                    employeeFound = true;

                                    //Add Employee to search results
                                    lstEmployeeSearchResults.Add(employee);

                                }//End If

                            }//End Foreach


                            //If employee was not found
                            messageForEmployeeFound(employeeFound, "surname", searchTerm);

                            break;


                        case 2:

                            //Search List
                            foreach (Employee employee in lstEmployees)
                            {
                                if (employee.FirstName.ToLower() == searchTerm || employee.FirstName.ToLower().Contains(searchTerm))
                                {
                                    //Employee was found
                                    employeeFound = true;

                                    //Add Employee to search results
                                    lstEmployeeSearchResults.Add(employee);

                                }//End If

                            }//End Foreach

                            //If employee was not found
                            messageForEmployeeFound(employeeFound, "first name", searchTerm);

                            break;


                        case 3:

                            //Search List
                            foreach (Employee employee in lstEmployees)
                            {
                                if (employee.Address == searchTerm || employee.Address.ToLower().Contains(searchTerm))
                                {
                                    //Employee was found
                                    employeeFound = true;

                                    //Add Employee to search results
                                    lstEmployeeSearchResults.Add(employee);

                                }//End If

                            }//End Foreach

                            //If employee was not found
                            messageForEmployeeFound(employeeFound, "address", searchTerm);

                            break;


                        case 4:

                            //Search List
                            foreach (Employee employee in lstEmployees)
                            {
                                if (employee.Town.ToLower() == searchTerm || employee.Town.ToLower().Contains(searchTerm))
                                {
                                    //Employee was found
                                    employeeFound = true;

                                    //Add Employee to search results
                                    lstEmployeeSearchResults.Add(employee);

                                }//End If

                            }//End Foreach

                            //If employee was not found
                            messageForEmployeeFound(employeeFound, "town", searchTerm);

                            break;

                        case 5:

                            //Search List
                            foreach (Employee employee in lstEmployees)
                            {
                                if (employee.PostCode == searchTerm || employee.PostCode.Contains(searchTerm))
                                {
                                    //Employee was found
                                    employeeFound = true;

                                    //Add Employee to search results
                                    lstEmployeeSearchResults.Add(employee);

                                }//End If

                            }//End Foreach

                            //If employee was not found
                            messageForEmployeeFound(employeeFound, "postcode", searchTerm);

                            break;

                        case 6:

                            //Search List
                            foreach (Employee employee in lstEmployees)
                            {
                                if (employee.TelNo == searchTerm || employee.TelNo.Contains(searchTerm))
                                {
                                    //Employee was found
                                    employeeFound = true;

                                    //Add Employee to search results
                                    lstEmployeeSearchResults.Add(employee);

                                }//End If

                            }//End Foreach

                            //If employee was not found
                            messageForEmployeeFound(employeeFound, "telephone number", searchTerm);

                            break;

                        case 7:

                            //Search List
                            foreach (Employee employee in lstEmployees)
                            {
                                if (employee.Email == searchTerm || employee.Email.Contains(searchTerm))
                                {
                                    //Employee was found
                                    employeeFound = true;

                                    //Add Employee to search results
                                    lstEmployeeSearchResults.Add(employee);

                                }//End If

                            }//End Foreach

                            //If employee was not found
                            messageForEmployeeFound(employeeFound, "email", searchTerm);

                            break;


                        case 8:

                            //Search List
                            foreach (Employee employee in lstEmployees)
                            {
                                if (employee.NationalInsuranceNumber == searchTerm || employee.NationalInsuranceNumber.Contains(searchTerm))
                                {
                                    //Employee was found
                                    employeeFound = true;

                                    //Add Employee to search results
                                    lstEmployeeSearchResults.Add(employee);

                                }//End If

                            }//End Foreach

                            //If employee was not found
                            messageForEmployeeFound(employeeFound, "national insurance number", searchTerm);

                            break;



                        case 9:

                            //Search List
                            foreach (Employee employee in lstEmployees)
                            {
                                if (employee.ContractType == searchTerm || employee.ContractType.Contains(searchTerm))
                                {
                                    //Employee was found
                                    employeeFound = true;

                                    //Add Employee to search results
                                    lstEmployeeSearchResults.Add(employee);

                                }//End If

                            }//End Foreach

                            //If employee was not found
                            messageForEmployeeFound(employeeFound, "contract type", searchTerm);

                            break;

                    }//End Switch

                    //Change data grid view to search results
                    dgv_EmployeeList.DataSource = lstEmployeeSearchResults;

                }
                else
                {
                    //Invalid Search
                    errorToUser("The search you tried to perform was using an invalid search term.\nPlease try again.", "Invalid Search Term");

                }//End If


                //Reset the bool to false
                employeeFound = false;

                //clear textbox
                mst_EmployeeTabSearchTerm.Clear();
                mst_EmployeeTabSearchTerm.Focus();

            }
            catch (Exception ex)
            {
                //print error message
                printErrorMessage(ex);
            }


        }//End searchForEmployee


        //--------------------------- Sort ---------------------------\\

        private void sortMembers()
        {
            try
            {
                switch (selectedIndexFieldForSort)
                {
                    case 0:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending MemberID
                            lstMembers = lstMembers.OrderBy(member => member.MemberID).ToList();

                            //Refresh the data grid
                            refreshMemberDataGrid();

                        }
                        else
                        {
                            //Sort by descending MemberID
                            lstMembers = lstMembers.OrderByDescending(member => member.MemberID).ToList();

                            //Refresh the data grid
                            refreshMemberDataGrid();

                        }//end if

                        break;


                    case 1:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending Title
                            lstMembers = lstMembers.OrderBy(member => member.Title).ToList();

                            //Refresh the data grid
                            refreshMemberDataGrid();

                        }
                        else
                        {
                            //Sort by descending Title
                            lstMembers = lstMembers.OrderByDescending(member => member.Title).ToList();

                            //Refresh the data grid
                            refreshMemberDataGrid();

                        }//end if

                        break;


                    case 2:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending surname
                            lstMembers = lstMembers.OrderBy(member => member.Surname).ToList();

                            //Refresh the data grid
                            refreshMemberDataGrid();
                        }
                        else
                        {
                            //Sort by descending surname
                            lstMembers = lstMembers.OrderByDescending(member => member.Surname).ToList();

                            //Refresh the data grid
                            refreshMemberDataGrid();

                        }//end if

                        break;


                    case 3:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending FirstName
                            lstMembers = lstMembers.OrderBy(member => member.FirstName).ToList();

                            //Refresh the data grid
                            refreshMemberDataGrid();
                        }
                        else
                        {
                            //Sort by descending FirstName
                            lstMembers = lstMembers.OrderByDescending(member => member.FirstName).ToList();

                            //Refresh the data grid
                            refreshMemberDataGrid();

                        }//end if

                        break;


                    case 4:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending Address
                            lstMembers = lstMembers.OrderBy(member => member.Address).ToList();

                            //Refresh the data grid
                            refreshMemberDataGrid();
                        }
                        else
                        {
                            //Sort by descending Address
                            lstMembers = lstMembers.OrderByDescending(member => member.Address).ToList();

                            //Refresh the data grid
                            refreshMemberDataGrid();

                        }//end if

                        break;


                    case 5:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending Town
                            lstMembers = lstMembers.OrderBy(member => member.Town).ToList();

                            //Refresh the data grid
                            refreshMemberDataGrid();
                        }
                        else
                        {
                            //Sort by descending Town
                            lstMembers = lstMembers.OrderByDescending(member => member.Town).ToList();

                            //Refresh the data grid
                            refreshMemberDataGrid();

                        }//end if

                        break;


                    case 6:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending PostCode
                            lstMembers = lstMembers.OrderBy(member => member.PostCode).ToList();

                            //Refresh the data grid
                            refreshMemberDataGrid();
                        }
                        else
                        {
                            //Sort by descending PostCode
                            lstMembers = lstMembers.OrderByDescending(member => member.PostCode).ToList();

                            //Refresh the data grid
                            refreshMemberDataGrid();

                        }//end if

                        break;


                    case 7:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending TelNo
                            lstMembers = lstMembers.OrderBy(member => member.TelNo).ToList();

                            //Refresh the data grid
                            refreshMemberDataGrid();
                        }
                        else
                        {
                            //Sort by descending TelNo
                            lstMembers = lstMembers.OrderByDescending(member => member.TelNo).ToList();

                            //Refresh the data grid
                            refreshMemberDataGrid();

                        }//end if

                        break;


                    case 8:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending Email
                            lstMembers = lstMembers.OrderBy(member => member.Email).ToList();

                            //Refresh the data grid
                            refreshMemberDataGrid();
                        }
                        else
                        {
                            //Sort by descending Email
                            lstMembers = lstMembers.OrderByDescending(member => member.Email).ToList();

                            //Refresh the data grid
                            refreshMemberDataGrid();

                        }//end if

                        break;

                }//End Switch
            }
            catch (Exception ex)
            {
                //show error message
                printErrorMessage(ex);
            }


        }//End sortMembers


        private void sortClasses()
        {
            try
            {
                switch (selectedIndexFieldForSort)
                {
                    case 0:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending surname
                            lstExerciseClasses = lstExerciseClasses.OrderBy(exerciseClass => exerciseClass.ExerciseClassID).ToList();

                            //Refresh the data grid
                            refreshClassDataGrid();

                        }
                        else
                        {
                            //Sort by descending surname
                            lstExerciseClasses = lstExerciseClasses.OrderByDescending(exerciseClass => exerciseClass.ExerciseClassID).ToList();

                            //Refresh the data grid
                            refreshClassDataGrid();

                        }//end if

                        break;


                    case 1:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending surname
                            lstExerciseClasses = lstExerciseClasses.OrderBy(exerciseClass => exerciseClass.EmployeeID).ToList();

                            //Refresh the data grid
                            refreshClassDataGrid();
                        }
                        else
                        {
                            //Sort by descending surname
                            lstExerciseClasses = lstExerciseClasses.OrderByDescending(exerciseClass => exerciseClass.EmployeeID).ToList();

                            //Refresh the data grid
                            refreshClassDataGrid();

                        }//end if

                        break;


                    case 2:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending surname
                            lstExerciseClasses = lstExerciseClasses.OrderBy(exerciseClass => exerciseClass.RoomID).ToList();

                            //Refresh the data grid
                            refreshClassDataGrid();
                        }
                        else
                        {
                            //Sort by descending surname
                            lstExerciseClasses = lstExerciseClasses.OrderByDescending(exerciseClass => exerciseClass.RoomID).ToList();

                            //Refresh the data grid
                            refreshClassDataGrid();

                        }//end if

                        break;


                    case 3:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending surname
                            lstExerciseClasses = lstExerciseClasses.OrderBy(exerciseClass => exerciseClass.Description).ToList();

                            //Refresh the data grid
                            refreshClassDataGrid();
                        }
                        else
                        {
                            //Sort by descending surname
                            lstExerciseClasses = lstExerciseClasses.OrderByDescending(exerciseClass => exerciseClass.Description).ToList();

                            //Refresh the data grid
                            refreshClassDataGrid();

                        }//end if

                        break;


                    case 4:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending surname
                            lstExerciseClasses = lstExerciseClasses.OrderBy(exerciseClass => exerciseClass.Difficulty).ToList();

                            //Refresh the data grid
                            refreshClassDataGrid();
                        }
                        else
                        {
                            //Sort by descending surname
                            lstExerciseClasses = lstExerciseClasses.OrderByDescending(exerciseClass => exerciseClass.Difficulty).ToList();

                            //Refresh the data grid
                            refreshClassDataGrid();

                        }//end if

                        break;


                    case 5:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending surname
                            lstSessions = lstSessions.OrderBy(Session => Session.DateOfClass).ToList();

                            //Refresh the data grid
                            refreshClassDataGrid();
                        }
                        else
                        {
                            //Sort by descending surname
                            lstSessions = lstSessions.OrderByDescending(session => session.DateOfClass).ToList();

                            //Refresh the data grid
                            refreshClassDataGrid();

                        }//end if

                        break;


                    case 6:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending surname
                            lstExerciseClasses = lstExerciseClasses.OrderBy(exerciseClass => exerciseClass.MaxNumberOfParticipants).ToList();

                            //Refresh the data grid
                            refreshClassDataGrid();
                        }
                        else
                        {
                            //Sort by descending surname
                            lstExerciseClasses = lstExerciseClasses.OrderByDescending(exerciseClass => exerciseClass.MaxNumberOfParticipants).ToList();

                            //Refresh the data grid
                            refreshClassDataGrid();

                        }//end if

                        break;

                }//End Switch
            }
            catch (Exception ex)
            {
                //show error message
                printErrorMessage(ex);
            }
        }//End sortClasses


        private void sortBookings()
        {
            try
            {
                switch (selectedIndexFieldForSort)
                {
                    case 0:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending surname
                            lstBookings = lstBookings.OrderBy(booking => booking.BookingID).ToList();

                            //Refresh the data grid
                            refreshBookingDataGrid();

                        }
                        else
                        {
                            //Sort by descending surname
                            lstBookings = lstBookings.OrderByDescending(booking => booking.BookingID).ToList();

                            //Refresh the data grid
                            refreshBookingDataGrid();

                        }//end if

                        break;


                    case 1:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending surname
                            lstBookings = lstBookings.OrderBy(booking => booking.ExerciseClassID).ToList();

                            //Refresh the data grid
                            refreshBookingDataGrid();
                        }
                        else
                        {
                            //Sort by descending surname
                            lstBookings = lstBookings.OrderByDescending(booking => booking.ExerciseClassID).ToList();

                            //Refresh the data grid
                            refreshBookingDataGrid();

                        }//end if

                        break;


                    case 2:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending surname
                            lstBookings = lstBookings.OrderBy(booking => booking.EmployeeID).ToList();

                            //Refresh the data grid
                            refreshBookingDataGrid();
                        }
                        else
                        {
                            //Sort by descending surname
                            lstBookings = lstBookings.OrderByDescending(booking => booking.EmployeeID).ToList();

                            //Refresh the data grid
                            refreshBookingDataGrid();

                        }//end if

                        break;


                    case 3:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending surname
                            lstBookings = lstBookings.OrderBy(booking => booking.MemberID).ToList();

                            //Refresh the data grid
                            refreshBookingDataGrid();
                        }
                        else
                        {
                            //Sort by descending surname
                            lstBookings = lstBookings.OrderByDescending(booking => booking.MemberID).ToList();

                            //Refresh the data grid
                            refreshBookingDataGrid();

                        }//end if

                        break;


                    case 4:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending surname
                            lstBookings = lstBookings.OrderBy(booking => booking.DateOfBooking).ToList();

                            //Refresh the data grid
                            refreshBookingDataGrid();
                        }
                        else
                        {
                            //Sort by descending surname
                            lstBookings = lstBookings.OrderByDescending(booking => booking.DateOfBooking).ToList();

                            //Refresh the data grid
                            refreshBookingDataGrid();

                        }//end if

                        break;

                }//End Switch

            }
            catch (Exception ex)
            {
                //print error to screen
                printErrorMessage(ex);

            }//End Catch

        }//End sortBookings


        private void sortPayments()
        {
            try
            {
                switch (selectedIndexFieldForSort)
                {
                    case 0:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending PaymentID
                            lstPayments = lstPayments.OrderBy(Payment => Payment.PaymentID).ToList();

                            //Refresh the data grid
                            refreshPaymentDataGrid();

                        }
                        else
                        {
                            //Sort by descending PaymentID
                            lstPayments = lstPayments.OrderByDescending(Payment => Payment.PaymentID).ToList();

                            //Refresh the data grid
                            refreshPaymentDataGrid();

                        }//end if

                        break;


                    case 1:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending MemberID
                            lstPayments = lstPayments.OrderBy(Payment => Payment.MemberID).ToList();

                            //Refresh the data grid
                            refreshPaymentDataGrid();
                        }
                        else
                        {
                            //Sort by descending MemberID
                            lstPayments = lstPayments.OrderByDescending(Payment => Payment.MemberID).ToList();

                            //Refresh the data grid
                            refreshPaymentDataGrid();

                        }//end if

                        break;


                    case 2:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending BookingID
                            lstPayments = lstPayments.OrderBy(Payment => Payment.BookingID).ToList();

                            //Refresh the data grid
                            refreshPaymentDataGrid();
                        }
                        else
                        {
                            //Sort by descending BookingID
                            lstPayments = lstPayments.OrderByDescending(Payment => Payment.BookingID).ToList();

                            //Refresh the data grid
                            refreshPaymentDataGrid();

                        }//end if

                        break;


                    case 3:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending PaymentMethodID
                            lstPayments = lstPayments.OrderBy(Payment => Payment.PaymentMethodID).ToList();

                            //Refresh the data grid
                            refreshPaymentDataGrid();
                        }
                        else
                        {
                            //Sort by descending PaymentMethodID
                            lstPayments = lstPayments.OrderByDescending(Payment => Payment.PaymentMethodID).ToList();

                            //Refresh the data grid
                            refreshPaymentDataGrid();

                        }//end if

                        break;


                    case 4:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending Date Of Payment
                            lstPayments = lstPayments.OrderBy(Payment => Payment.DateOfPayment).ToList();

                            //Refresh the data grid
                            refreshPaymentDataGrid();
                        }
                        else
                        {
                            //Sort by descending Date Of Payment
                            lstPayments = lstPayments.OrderByDescending(Payment => Payment.DateOfPayment).ToList();

                            //Refresh the data grid
                            refreshPaymentDataGrid();

                        }//end if

                        break;


                    case 5:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending AmountPaid
                            lstPayments = lstPayments.OrderBy(Payment => Payment.AmountPaid).ToList();

                            //Refresh the data grid
                            refreshPaymentDataGrid();
                        }
                        else
                        {
                            //Sort by descending AmountPaid
                            lstPayments = lstPayments.OrderByDescending(Payment => Payment.AmountPaid).ToList();

                            //Refresh the data grid
                            refreshPaymentDataGrid();

                        }//end if

                        break;

                }//End Switch

            }
            catch (Exception ex)
            {
                //print error to screen
                printErrorMessage(ex);

            }//End Catch

        }//End sortPayments


        private void sortRooms()
        {
            try
            {
                switch (selectedIndexFieldForSort)
                {
                    case 0:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending RoomID
                            lstRooms = lstRooms.OrderBy(Room => Room.RoomID).ToList();

                            //Refresh the data grid
                            refreshRoomDataGrid();

                        }
                        else
                        {
                            //Sort by descending RoomID
                            lstRooms = lstRooms.OrderByDescending(Room => Room.RoomID).ToList();

                            //Refresh the data grid
                            refreshRoomDataGrid();

                        }//end if

                        break;


                    case 1:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending RoomDescription
                            lstRooms = lstRooms.OrderBy(Room => Room.RoomDescription).ToList();

                            //Refresh the data grid
                            refreshRoomDataGrid();
                        }
                        else
                        {
                            //Sort by descending RoomDescription
                            lstRooms = lstRooms.OrderByDescending(Room => Room.RoomDescription).ToList();

                            //Refresh the data grid
                            refreshRoomDataGrid();

                        }//end if

                        break;


                    case 2:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending RoomLocation
                            lstRooms = lstRooms.OrderBy(Room => Room.RoomLocation).ToList();

                            //Refresh the data grid
                            refreshRoomDataGrid();
                        }
                        else
                        {
                            //Sort by descending RoomLocation
                            lstRooms = lstRooms.OrderByDescending(Room => Room.RoomLocation).ToList();

                            //Refresh the data grid
                            refreshRoomDataGrid();

                        }//end if

                        break;


                    case 3:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending Capacity
                            lstRooms = lstRooms.OrderBy(Room => Room.Capacity).ToList();

                            //Refresh the data grid
                            refreshRoomDataGrid();
                        }
                        else
                        {
                            //Sort by descending Capacity
                            lstRooms = lstRooms.OrderByDescending(Room => Room.Capacity).ToList();

                            //Refresh the data grid
                            refreshRoomDataGrid();

                        }//end if

                        break;


                    
                    case 4:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending HourlyHireCost
                            lstRooms = lstRooms.OrderBy(Room => Room.HourlyHireCost).ToList();

                            //Refresh the data grid
                            refreshRoomDataGrid();
                        }
                        else
                        {
                            //Sort by descending HourlyHireCost
                            lstRooms = lstRooms.OrderByDescending(Room => Room.HourlyHireCost).ToList();

                            //Refresh the data grid
                            refreshRoomDataGrid();

                        }//end if

                        break;


                    case 5:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending AvailableToUse
                            lstRooms = lstRooms.OrderBy(Room => Room.AvailableToUse).ToList();

                            //Refresh the data grid
                            refreshRoomDataGrid();
                        }
                        else
                        {
                            //Sort by descending AvailableToUse
                            lstRooms = lstRooms.OrderByDescending(Room => Room.AvailableToUse).ToList();

                            //Refresh the data grid
                            refreshRoomDataGrid();

                        }//end if

                        break;

                }//End Switch

            }
            catch (Exception ex)
            {
                //print error to screen
                printErrorMessage(ex);

            }//End Catch

        }//End sortRooms


        private void sortRoomHire()
        {
            try
            {
                switch (selectedIndexFieldForSort)
                {
                    case 0:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending RoomHireID
                            lstRoomHire = lstRoomHire.OrderBy(RoomHire => RoomHire.RoomHireID).ToList();

                            //Refresh the data grid
                            refreshRoomHireDataGrid();

                        }
                        else
                        {
                            //Sort by descending RoomHireID
                            lstRoomHire = lstRoomHire.OrderByDescending(RoomHire => RoomHire.RoomHireID).ToList();

                            //Refresh the data grid
                            refreshRoomHireDataGrid();

                        }//end if

                        break;


                    case 1:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending Room ID
                            lstRoomHire = lstRoomHire.OrderBy(RoomHire => RoomHire.RoomID).ToList();

                            //Refresh the data grid
                            refreshRoomHireDataGrid();
                        }
                        else
                        {
                            //Sort by descending Room ID
                            lstRoomHire = lstRoomHire.OrderByDescending(RoomHire => RoomHire.RoomID).ToList();

                            //Refresh the data grid
                            refreshRoomHireDataGrid();

                        }//end if

                        break;


                    case 2:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending ExternalCompanyID
                            lstRoomHire = lstRoomHire.OrderBy(Room => Room.ExternalCompanyID).ToList();

                            //Refresh the data grid
                            refreshRoomHireDataGrid();
                        }
                        else
                        {
                            //Sort by descending ExternalCompanyID
                            lstRoomHire = lstRoomHire.OrderByDescending(Room => Room.ExternalCompanyID).ToList();

                            //Refresh the data grid
                            refreshRoomHireDataGrid();

                        }//end if

                        break;


                    case 3:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending StartDate
                            lstRoomHire = lstRoomHire.OrderBy(Room => Room.StartDate).ToList();

                            //Refresh the data grid
                            refreshRoomHireDataGrid();
                        }
                        else
                        {
                            //Sort by descending StartDate
                            lstRoomHire = lstRoomHire.OrderByDescending(Room => Room.StartDate).ToList();

                            //Refresh the data grid
                            refreshRoomHireDataGrid();

                        }//end if

                        break;



                    case 4:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending HireDuration
                            lstRoomHire = lstRoomHire.OrderBy(Room => Room.HireDuration).ToList();

                            //Refresh the data grid
                            refreshRoomHireDataGrid();
                        }
                        else
                        {
                            //Sort by descending HireDuration
                            lstRoomHire = lstRoomHire.OrderByDescending(Room => Room.HireDuration).ToList();

                            //Refresh the data grid
                            refreshRoomHireDataGrid();

                        }//end if

                        break;


                    case 5:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending EndDate
                            lstRoomHire = lstRoomHire.OrderBy(Room => Room.EndDate).ToList();

                            //Refresh the data grid
                            refreshRoomHireDataGrid();
                        }
                        else
                        {
                            //Sort by descending EndDate
                            lstRoomHire = lstRoomHire.OrderByDescending(Room => Room.EndDate).ToList();

                            //Refresh the data grid
                            refreshRoomHireDataGrid();

                        }//end if

                        break;

                    case 6:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending HoursPerWeek
                            lstRoomHire = lstRoomHire.OrderBy(Room => Room.HoursPerWeek).ToList();

                            //Refresh the data grid
                            refreshRoomHireDataGrid();
                        }
                        else
                        {
                            //Sort by descending HoursPerWeek
                            lstRoomHire = lstRoomHire.OrderByDescending(Room => Room.HoursPerWeek).ToList();

                            //Refresh the data grid
                            refreshRoomHireDataGrid();

                        }//end if

                        break;

                    case 7:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending MonthlyHireCost
                            lstRoomHire = lstRoomHire.OrderBy(Room => Room.MonthlyHireCost).ToList();

                            //Refresh the data grid
                            refreshRoomHireDataGrid();
                        }
                        else
                        {
                            //Sort by descending MonthlyHireCost
                            lstRoomHire = lstRoomHire.OrderByDescending(Room => Room.MonthlyHireCost).ToList();

                            //Refresh the data grid
                            refreshRoomHireDataGrid();

                        }//end if

                        break;

                    case 8:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending TotalHireCost
                            lstRoomHire = lstRoomHire.OrderBy(Room => Room.TotalHireCost).ToList();

                            //Refresh the data grid
                            refreshRoomHireDataGrid();
                        }
                        else
                        {
                            //Sort by descending TotalHireCost
                            lstRoomHire = lstRoomHire.OrderByDescending(Room => Room.TotalHireCost).ToList();

                            //Refresh the data grid
                            refreshRoomHireDataGrid();

                        }//end if

                        break;

                }//End Switch

            }
            catch (Exception ex)
            {
                //print error to screen
                printErrorMessage(ex);

            }//End Catch

        }//End sortRoomHire


        private void sortExternalCompanies()
        {
            try
            {
                switch (selectedIndexFieldForSort)
                {
                    case 0:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending ExternalCompanyID
                            lstExternalCompanies = lstExternalCompanies.OrderBy(externalCompany => externalCompany.ExternalCompanyID).ToList();

                            //Refresh the data grid
                            refreshExternalCompanyDataGrid();

                        }
                        else
                        {
                            //Sort by descending ExternalCompanyID
                            lstExternalCompanies = lstExternalCompanies.OrderByDescending(externalCompany => externalCompany.ExternalCompanyID).ToList();

                            //Refresh the data grid
                            refreshExternalCompanyDataGrid();

                        }//end if

                        break;


                    case 1:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending CompanyName
                            lstExternalCompanies = lstExternalCompanies.OrderBy(externalCompany => externalCompany.CompanyName).ToList();

                            //Refresh the data grid
                            refreshExternalCompanyDataGrid();
                        }
                        else
                        {
                            //Sort by descending CompanyName
                            lstExternalCompanies = lstExternalCompanies.OrderByDescending(externalCompany => externalCompany.CompanyName).ToList();

                            //Refresh the data grid
                            refreshExternalCompanyDataGrid();

                        }//end if

                        break;


                    case 2:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending CompanyAddress
                            lstExternalCompanies = lstExternalCompanies.OrderBy(externalCompany => externalCompany.CompanyAddress).ToList();

                            //Refresh the data grid
                            refreshExternalCompanyDataGrid();
                        }
                        else
                        {
                            //Sort by descending CompanyAddress
                            lstExternalCompanies = lstExternalCompanies.OrderByDescending(externalCompany => externalCompany.CompanyAddress).ToList();

                            //Refresh the data grid
                            refreshExternalCompanyDataGrid();

                        }//end if

                        break;


                    case 3:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending CompanyTown
                            lstExternalCompanies = lstExternalCompanies.OrderBy(externalCompany => externalCompany.CompanyTown).ToList();

                            //Refresh the data grid
                            refreshExternalCompanyDataGrid();
                        }
                        else
                        {
                            //Sort by descending CompanyTown
                            lstExternalCompanies = lstExternalCompanies.OrderByDescending(externalCompany => externalCompany.CompanyTown).ToList();

                            //Refresh the data grid
                            refreshExternalCompanyDataGrid();

                        }//end if

                        break;


                    case 4:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending CompanyPostCode
                            lstExternalCompanies = lstExternalCompanies.OrderBy(externalCompany => externalCompany.CompanyPostCode).ToList();

                            //Refresh the data grid
                            refreshExternalCompanyDataGrid();
                        }
                        else
                        {
                            //Sort by descending CompanyPostCode
                            lstExternalCompanies = lstExternalCompanies.OrderByDescending(externalCompany => externalCompany.CompanyPostCode).ToList();

                            //Refresh the data grid
                            refreshExternalCompanyDataGrid();

                        }//end if

                        break;

                    case 5:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending CompanyPractice
                            lstExternalCompanies = lstExternalCompanies.OrderBy(externalCompany => externalCompany.CompanyPractice).ToList();

                            //Refresh the data grid
                            refreshExternalCompanyDataGrid();
                        }
                        else
                        {
                            //Sort by descending CompanyPractice
                            lstExternalCompanies = lstExternalCompanies.OrderByDescending(externalCompany => externalCompany.CompanyPractice).ToList();

                            //Refresh the data grid
                            refreshExternalCompanyDataGrid();

                        }//end if

                        break;

                    case 6:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending CompanyName
                            lstExternalCompanies = lstExternalCompanies.OrderBy(externalCompany => externalCompany.ContactName).ToList();

                            //Refresh the data grid
                            refreshExternalCompanyDataGrid();
                        }
                        else
                        {
                            //Sort by descending ContactName
                            lstExternalCompanies = lstExternalCompanies.OrderByDescending(externalCompany => externalCompany.ContactName).ToList();

                            //Refresh the data grid
                            refreshExternalCompanyDataGrid();

                        }//end if

                        break;

                    case 7:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending ContactTelNo
                            lstExternalCompanies = lstExternalCompanies.OrderBy(externalCompany => externalCompany.ContactTelNo).ToList();

                            //Refresh the data grid
                            refreshExternalCompanyDataGrid();
                        }
                        else
                        {
                            //Sort by descending ContactTelNo
                            lstExternalCompanies = lstExternalCompanies.OrderByDescending(externalCompany => externalCompany.ContactTelNo).ToList();

                            //Refresh the data grid
                            refreshExternalCompanyDataGrid();

                        }//end if

                        break;


                    case 8:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending ContactEmail
                            lstExternalCompanies = lstExternalCompanies.OrderBy(externalCompany => externalCompany.ContactEmail).ToList();

                            //Refresh the data grid
                            refreshExternalCompanyDataGrid();
                        }
                        else
                        {
                            //Sort by descending ContactEmail
                            lstExternalCompanies = lstExternalCompanies.OrderByDescending(externalCompany => externalCompany.ContactEmail).ToList();

                            //Refresh the data grid
                            refreshExternalCompanyDataGrid();

                        }//end if

                        break;

                }//End Switch
            }
            catch (Exception ex)
            {
                //show error message
                printErrorMessage(ex);
            }


        }//End sortExternalCompanies
        
        
        private void sortEmployees()
        {
            try
            {
                switch (selectedIndexFieldForSort)
                {
                    case 0:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending EmployeeID
                            lstEmployees = lstEmployees.OrderBy(employee => employee.EmployeeID).ToList();

                            //Refresh the data grid
                            refreshEmployeeDataGrid();

                        }
                        else
                        {
                            //Sort by descending EmployeeID
                            lstEmployees = lstEmployees.OrderByDescending(employee => employee.EmployeeID).ToList();

                            //Refresh the data grid
                            refreshEmployeeDataGrid();

                        }//end if

                        break;


                    case 1:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending Title
                            lstEmployees = lstEmployees.OrderBy(employee => employee.Title).ToList();

                            //Refresh the data grid
                            refreshEmployeeDataGrid();

                        }
                        else
                        {
                            //Sort by descending Title
                            lstEmployees = lstEmployees.OrderByDescending(employee => employee.Title).ToList();

                            //Refresh the data grid
                            refreshEmployeeDataGrid();

                        }//end if

                        break;


                    case 2:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending surname
                            lstEmployees = lstEmployees.OrderBy(employee => employee.Surname).ToList();

                            //Refresh the data grid
                            refreshEmployeeDataGrid();
                        }
                        else
                        {
                            //Sort by descending surname
                            lstEmployees = lstEmployees.OrderByDescending(employee => employee.Surname).ToList();

                            //Refresh the data grid
                            refreshEmployeeDataGrid();

                        }//end if

                        break;


                    case 3:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending FirstName
                            lstEmployees = lstEmployees.OrderBy(employee => employee.FirstName).ToList();

                            //Refresh the data grid
                            refreshEmployeeDataGrid();
                        }
                        else
                        {
                            //Sort by descending FirstName
                            lstEmployees = lstEmployees.OrderByDescending(employee => employee.FirstName).ToList();

                            //Refresh the data grid
                            refreshEmployeeDataGrid();

                        }//end if

                        break;


                    case 4:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending Address
                            lstEmployees = lstEmployees.OrderBy(employee => employee.Address).ToList();

                            //Refresh the data grid
                            refreshEmployeeDataGrid();
                        }
                        else
                        {
                            //Sort by descending Address
                            lstEmployees = lstEmployees.OrderByDescending(employee => employee.Address).ToList();

                            //Refresh the data grid
                            refreshEmployeeDataGrid();

                        }//end if

                        break;


                    case 5:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending Town
                            lstEmployees = lstEmployees.OrderBy(employee => employee.Town).ToList();

                            //Refresh the data grid
                            refreshEmployeeDataGrid();
                        }
                        else
                        {
                            //Sort by descending Town
                            lstEmployees = lstEmployees.OrderByDescending(employee => employee.Town).ToList();

                            //Refresh the data grid
                            refreshEmployeeDataGrid();

                        }//end if

                        break;


                    case 6:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending PostCode
                            lstEmployees = lstEmployees.OrderBy(employee => employee.PostCode).ToList();

                            //Refresh the data grid
                            refreshEmployeeDataGrid();
                        }
                        else
                        {
                            //Sort by descending PostCode
                            lstEmployees = lstEmployees.OrderByDescending(employee => employee.PostCode).ToList();

                            //Refresh the data grid
                            refreshEmployeeDataGrid();

                        }//end if

                        break;


                    case 7:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending TelNo
                            lstEmployees = lstEmployees.OrderBy(employee => employee.TelNo).ToList();

                            //Refresh the data grid
                            refreshEmployeeDataGrid();
                        }
                        else
                        {
                            //Sort by descending TelNo
                            lstEmployees = lstEmployees.OrderByDescending(employee => employee.TelNo).ToList();

                            //Refresh the data grid
                            refreshEmployeeDataGrid();

                        }//end if

                        break;


                    case 8:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending Email
                            lstEmployees = lstEmployees.OrderBy(employee => employee.Email).ToList();

                            //Refresh the data grid
                            refreshEmployeeDataGrid();
                        }
                        else
                        {
                            //Sort by descending Email
                            lstEmployees = lstEmployees.OrderByDescending(employee => employee.Email).ToList();

                            //Refresh the data grid
                            refreshEmployeeDataGrid();

                        }//end if

                        break;


                    case 9:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending Email
                            lstEmployees = lstEmployees.OrderBy(employee => employee.Email).ToList();

                            //Refresh the data grid
                            refreshEmployeeDataGrid();
                        }
                        else
                        {
                            //Sort by descending Email
                            lstEmployees = lstEmployees.OrderByDescending(employee => employee.Email).ToList();

                            //Refresh the data grid
                            refreshEmployeeDataGrid();

                        }//end if

                        break;

                    case 10:

                        //if ascending
                        if (selectedAscendOrDescend == 0)
                        {
                            //Sort by ascending Email
                            lstEmployees = lstEmployees.OrderBy(employee => employee.Email).ToList();

                            //Refresh the data grid
                            refreshEmployeeDataGrid();
                        }
                        else
                        {
                            //Sort by descending Email
                            lstEmployees = lstEmployees.OrderByDescending(employee => employee.Email).ToList();

                            //Refresh the data grid
                            refreshEmployeeDataGrid();

                        }//end if

                        break;

                }//End Switch
            }
            catch (Exception ex)
            {
                //show error message
                printErrorMessage(ex);
            }


        }//End sortEmployees


        //--------------------------- Validation Methods ---------------------------\\
                
        private void validateMemberDetails(ref bool validInput, ref bool ifAllValid)
        {
            try
            {
                //-------------------------------- Membership ID --------------------------------\\
                //Check a membership type has been selected
                if (cmb_MemberTabMembership.Text != "")
                {   
                    //Membership ID is the index of the combobox + 1
                    membershipTypeIDInput = cmb_MemberTabMembership.SelectedIndex + 1;

                }
                else
                {
                    //Else inform user
                    errorToUser("A membership type was not selected.\nPlease select a membership type", "Membership Type not selected");

                    //Mark invalid
                    ifAllValid = false;

                }//End If

                //--------------------------------DOB--------------------------------\\
                //Assign the DOB as it has to be valid input
                dateOfBirthInput = dtp_DOB.Value;

                //validate Title, Surname, First Name, DOB, Address, Town, Postcode, Tel No and Email
                ifAllValid = validatePersonalDetails(ifAllValid, cmb_Title.Text, txt_Surname.Text, txt_FirstName.Text, txt_Address.Text, txt_Town.Text, mst_PostCode.Text, mst_TelNo.Text, txt_Email.Text);

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }


        }//End validateMemberDetails


        private void validateExerciseClass(ref bool validInput, ref bool ifAllValid)
        {
            //Declare Variables
            List<Session> lstFutureSessions = new List<Session>();
            DateTime futureDate = DateTime.Today;
            int sessionInstructor = 0;
            int sessionVenue = 0;
            bool qualifiedForClass = false;

            ErrorProvider errP = new ErrorProvider();

            try
            {
                //----------------------- Employee ID -----------------------\\
                //Check a number has been selected
                readComboBoxSelection(ref ifAllValid, cmb_ClassTabEmployeeID.Text.ToString().Trim(), "Employee ID", ref employeeIDInput);

                //Load qualifications for the selected employee
                loadIndividualQualifications(lstEmployees.Find(employee => employee.EmployeeID.Equals(employeeIDInput)));

                //----------------------- External Company ID -----------------------\\
                //If the class is an external class
                if (chb_ClassTabExternalClass.Checked)
                {
                    //Check a company has been selected
                    readComboBoxSelection(ref ifAllValid, cmb_ClassTabExternalCompanyID.Text.ToString(), "External Company ID", ref externalCompanyIDInput);

                }//End If
                              

                //----------------------- Room ID -----------------------\\
                //Check a number has been selected
                readComboBoxSelection(ref ifAllValid, cmb_ClassTabRoomID.Text.ToString().Trim(), "Room ID", ref roomIDInput);


                //----------------------- Description -----------------------\\
                readComboBoxSelection(ref ifAllValid, cmb_ClassTabClassDescriptions.Text.ToString(), "Class Description", ref descriptionInput);

                //Check if the employee selected is qualified to run the course
                foreach (StaffQualification staffQual in lstIndividualQualifications)
                {
                    //Find the description for the qualification
                    Qualification qualCheck = lstQualifications.Find(qual => qual.QualificationID.Equals(staffQual.QualificationID));

                    //If the qual description contains the class description
                    if (qualCheck.Description.ToLower().Contains(descriptionInput.ToLower()))
                    {
                        //check if the qualification is valid
                        if (staffQual.ExpiryDate > DateTime.Today)
                        {
                            //they are qualified therefore mark valid
                            qualifiedForClass = true;

                            //Therefore break out of class
                            break;

                        }//End If

                    }//End If

                }//End Foreach

                //If they were not qualified
                if (!qualifiedForClass)
                {
                    //Mark invalid
                    ifAllValid = false;

                    //Inform user of error
                    errorToUser("The employee you selected is not qualified to run this class.\nPlease Select a different class description or Employee", "Employee Not Qualified");

                }//End If

                //----------------------- Difficulty -----------------------\\
                readComboBoxSelection(ref ifAllValid, cmb_ClassTabDifficultyLevels.Text.ToString(), "Class Difficulty", ref difficultyInput);


                //----------------------- Start and End Dates Of Class -----------------------\\
                //Assign to variable
                startDateInput = dtp_ClassTabStartDateOfClass.Value;
                endDateInput = dtp_ClassTabEndDateOfClass.Value;

                
                //----------------------- Start Time Of Class -----------------------\\
                //check if the combobox's selected item is not 0 i.e. chosen
                if (cmb_ClassTabTimeOfClass.Text != "")
                {
                    //If it is not null then convert to timespan and assign to the variable
                    startTimeInput = TimeSpan.Parse(cmb_ClassTabTimeOfClass.Text);
                }
                else
                {
                    //inform user no start time has been selected
                    errorToUser("The start time was not selected\nPlease Try Again", "Start Time Error");

                    //mark invalid
                    ifAllValid = false;

                }//End If

                //----------------------- Length Of Class -----------------------\\
                classLengthInput = (int)nud_ClassTabLengthOfClass.Value;

                //----------------------- End Time Of Class -----------------------\\
                endTimeInput = endTimeCalculationInput;

                //----------------------- Max No Of Participants -----------------------\\
                //Only if all of the previous are valid run
                if (ifAllValid)
                {
                    //Number of participants is and integer
                    validInput = int.TryParse(nud_ClassTabMaxNoOfParticipants.Value.ToString(), out maxParticipantsInput);

                    //Assign to the overall valid bool
                    ifAllValid = validInput;

                    //if more participants than expected
                    if (maxParticipantsInput > 15)
                    {
                        DialogResult answer = MessageBox.Show("The number of participants entered is greater than 15.\nIs this correct?", "The maximum number of participants input", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (answer == DialogResult.No)
                        {
                            //Mark invalid so as the class is not created
                            ifAllValid = false;

                        }//End If

                    }//End If

                }//End If
                

                //----------------------- External Class -----------------------\\
                //If the check box is checked
                if (chb_ClassTabExternalClass.Checked)
                {
                    //Assign to variable
                    externalClassInput = true;
                }
                else
                {
                    //Assign to variable
                    externalClassInput = false;

                }//End If


                //----------------------- Cost Of Class -----------------------\\
                //Read in the cost of the class
                weeklyCostOfClassInput = nud_ClassTabWeeklyCostOfClass.Value;


                //If weekly cost is greater than or equal to £25
                if (weeklyCostOfClassInput >= 25)
                {
                    //Request confirmation from user
                    DialogResult answer = MessageBox.Show("The weekly cost you entered was over £25.\nIs this correct?", "Price Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                    //If the answer is no 
                    if (answer == DialogResult.No)
                    {
                        //mark invalid so as to not allow the record to be saved
                        ifAllValid = false;

                    }//End If

                }//End If


                //Finally check that the class does not conflict with another class
                //Only if all of the previous details have been valid
                if (ifAllValid)
                {
                    //Create a list of temp sessions
                    for (int sessionsCreated = 0; sessionsCreated < noOfWeeksInput; sessionsCreated++)
                    {
                        //Create new sessions
                        lstFutureSessions.Add(new Session(sessionsCreated, exerciseClassIDInput, startDateInput, startTimeInput, classLengthInput, endTimeInput));
                    
                        //Increase the week
                        futureDate = futureDate.AddDays(7);
                    
                    }//End For

                    //Check the date, time, room and employee against all other classes
                    for (int sessionsChecked = 0; sessionsChecked < lstFutureSessions.Count; sessionsChecked++)
                    {
                        //Assign the date that is to be checked
                        futureDate = lstFutureSessions[sessionsChecked].DateOfClass;
                        
                        foreach (Session session in lstSessions)
                        {
                            //Assign the roomID and the employeeID for the session being checked
                            sessionVenue = lstExerciseClasses.Find(exClass => exClass.ExerciseClassID.Equals(exerciseClassIDInput)).RoomID;
                            sessionInstructor = lstExerciseClasses.Find(exClass => exClass.ExerciseClassID.Equals(exerciseClassIDInput)).EmployeeID;

                            //If the date and time are the same but it is not the same exercise class
                            if (session.DateOfClass == futureDate && session.StartTimeOfClass == startTimeInput && session.ExerciseClassID != exerciseClassIDInput)
                            {
                                //Check if the room is the same
                                if (sessionVenue == roomIDInput)
                                {
                                    //If true the room is already in use at this time therefore is invalid
                                    ifAllValid = false;

                                    //Inform user of the error
                                    errorToUser("The room chosen for this class is already in use on the date and at the time specified.\nPlease enter a different date, time or room", "Room Conflict");

                                    //If the same break out of loop
                                    break;

                                }//or the employee is the same
                                else if (sessionInstructor == employeeIDInput)
                                {
                                    //If true the employee is already in another class at this time therefore is invalid
                                    ifAllValid = false;

                                    //Inform user of the error
                                    errorToUser("The employee chosen for this class is already in another class on the date and at the time specified.\nPlease enter a different date, time or employee", "Room Conflict");

                                    //If the same break out of loop
                                    break;

                                }//End If for venue and employee check

                            }//End If for date and time check
                        
                        }//End Foreach

                        //If not true then there was an issue in the sessions that has already been brought up
                        if (!ifAllValid)
                        {
                            //Issue has arisen and therefore break out of the for loop as the remainder of the checks are unneccesary
                            break;

                        }//End If

                    }//End For

                    //Clear the temp list for future sessions
                    lstFutureSessions.Clear();
                                        
                }//End If

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
                        
        }//End validateExerciseClass


        private void validateBooking(ref bool validInput, ref bool ifAllValid)
        {
            try
            {
                //----------------- Member ID -----------------\\
                readComboBoxSelection(ref ifAllValid, cmb_BookingsTabMemberID.SelectedItem.ToString(), "Member ID", ref memberIDInput);


                //----------------- Exercise Class ID -----------------\\
                readComboBoxSelection(ref ifAllValid, cmb_BookingsTabExerciseClassID.SelectedItem.ToString(), "Exercise Class ID", ref exerciseClassIDInput);


                //----------------- No Of Participants -----------------\\
                //read in the current no of participants
                ExerciseClass validatingExClass = lstExerciseClasses.Find(exClass => exClass.ExerciseClassID.Equals((int)cmb_BookingsTabExerciseClassID.SelectedItem));

                //Read in the number of people booking and current number of participants
                noOfPeopleBookingInput = (int)nud_BookingsTabNumberOfParticipantsBooking.Value;
                currentNoOfParticipantsInput = Convert.ToInt32(txt_BookingsTabCurrentNoOfParticipants.Text);

                //Check if adding the number booking would make it exceed the max number
                if (currentNoOfParticipantsInput + noOfPeopleBookingInput > validatingExClass.MaxNumberOfParticipants)
                {
                    //Inform user of error
                    errorToUser("The number of people you are trying to book for exceeds the maximum number.\nPlease enter a lower number", "Maximum number of people exceeded");

                    //Mark invalid
                    ifAllValid = false;

                }
                else
                {
                    //Add them together and assign to the class
                    currentNoOfParticipantsInput = currentNoOfParticipantsInput + (int)nud_BookingsTabNumberOfParticipantsBooking.Value;

                }//End If

                //----------------- Cost of Booking -----------------\\
                //This is validated by the control and therefore can be read in
                amountChargedInput = nud_BookingsTabCostOfBooking.Value;

                //----------------- Charge Applicable -----------------\\

                //Check if the box is not checked
                if (!chb_BookingsTabToCharge.Checked)
                {
                    //then the charge is not to be applied
                    amountChargedInput = 0;

                }//End If

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End validateBooking


        private void validatePayment(ref bool ifAllValid)
        {
            try
            {
                //------------------------ Member ID ------------------------\\
                readComboBoxSelection(ref ifAllValid, cmb_PaymentTabMemberID.Text.ToString(), "Member ID", ref memberIDInput);

                //------------------------ Booking ID ------------------------\\
                //If it is not a membership payment
                if (!isMembership)
                {
                    //Check a booking field has been entered
                    readComboBoxSelection(ref ifAllValid, cmb_PaymentTabBookingID.Text.ToString(), "Booking ID", ref bookingIDInput);

                }//End If
                

                //------------------------ Payment Method ID ------------------------\\
                //If check box is unchecked (i.e. they are not paying by card)
                if (!chb_PaymentTabCardUsed.Checked)
                {
                    //Using cash
                    paymentMethodIDInput = 0;

                }
                else
                {
                    //Check that a payment method was selected
                    readComboBoxSelection(ref ifAllValid, cmb_PaymentTabPaymentMethodID.Text.ToString(), "Payment Method ID", ref paymentMethodIDInput);

                }//End If


                //------------------------ Date Of payment ------------------------\\
                //Will always be that day
                dateOfPaymentInput = DateTime.Now;

                //------------------------ Amount to pay ------------------------\\
                //read in and assigned at an earlier stage to display onscreen

                
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End validatePayment


        private void validateRoom(ref bool ifAllValid)
        {
            try
            {
                //-------------------------- Room ID --------------------------\\
                //Auto Set on creation

                //-------------------------- Room Description --------------------------\\
                readComboBoxSelection(ref ifAllValid, cmb_RoomTabDescription.Text.ToString(), "Room Description", ref roomDescriptionInput);

                //-------------------------- Room Location --------------------------\\
                readComboBoxSelection(ref ifAllValid, cmb_RoomTabLocation.Text.ToString(), "Room Location", ref roomLocationInput);

                //-------------------------- Capacity --------------------------\\                
                //If pre requisites are valid
                if (ifAllValid)
                {
                    //if valid int then it is correct
                    ifAllValid = int.TryParse(nud_RoomTabCapacity.Value.ToString(), out roomCapacityInput);

                    //If it is an int
                    if (ifAllValid)
                    {
                        //test if it is greater or equal 25
                        if (roomCapacityInput >= 25)
                        {
                            //Request Confirmation this is correct
                            DialogResult answer = MessageBox.Show("The capacity you entered was above 25.\nIs this correct?", "Capacity Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                            //if dialog box is no then mark invalid so as it does not process
                            if (answer == DialogResult.No)
                            {
                                //Mark invalid
                                ifAllValid = false;

                            }//End If

                            //Otherwise the capacity will remain the number it began as and is already assigned

                        }//End If

                    }
                    else
                    {
                        //Invalid entry
                        ifAllValid = false;

                        //Inform User
                        errorToUser("The capacity entered was not an integer.\nPlease insert an integer above 0", "Invalid Capacity");

                    }//End If
                    
                }//End If                

                //-------------------------- Hourly Hire Cost --------------------------\\

                //if all pre-requistes are valid
                if (ifAllValid)
                {
                    //Read in the hourly hire cost
                    hourlyHireCostInput = nud_RoomTabHourlyHireCost.Value;

                    //test if it is greater than or equal to £100
                    if (hourlyHireCostInput >= 100)
                    {
                        //Request Confirmation this is correct
                        DialogResult answer = MessageBox.Show("The hourly hire cost you entered was above £100.\nIs this correct?", "Capacity Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                        //if dialog box is no then mark invalid so as it does not process
                        if (answer == DialogResult.No)
                        {
                            //Mark invalid
                            ifAllValid = false;

                        }//End If

                        //Otherwise the hourly Hire Cost will remain the number it began as and is already assigned

                    }//End If

                }//End If


                //-------------------------- Available For Use --------------------------\\
                //Read in if the box is ticked
                roomAvailableForUseInput = chb_RoomTabAvailable.Checked;

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End validateRoom


        private void validateRoomHire(ref bool ifAllValid)
        {
            try
            {
                //------------------------ Room Hire ID ------------------------\\
                //Auto-generated when add is pressed

                //------------------------ Room ID ------------------------\\
                readComboBoxSelection(ref ifAllValid, cmb_RoomHireTabRoomID.Text, "Room ID", ref roomIDInput);

                //------------------------ External Company ID ------------------------\\
                readComboBoxSelection(ref ifAllValid, cmb_RoomHireTabExternalCompanyID.Text, "External Company ID", ref externalCompanyIDInput);

                //------------------------ Start date ------------------------\\
                //Read in from date time picker
                startDateInput = dtp_RoomHireTabStartDate.Value;

                //------------------------ Hire duration ------------------------\\
                readComboBoxSelection(ref ifAllValid, cmb_RoomHireTabHireDuration.Text.Substring(0, 2), "Hire duration", ref hireDurationInput);

                //------------------------ End Date ------------------------\\
                endDateInput = dtp_RoomHireTabEndDate.Value;

                //------------------------ Hours Per Week ------------------------\\
                //Read in from control
                hoursPerWeek = (int)nud_RoomHireTabHoursPerWeek.Value;

                //------------------------ Monthly and Total Hire Costs ------------------------\\
                //Calculated previously and therefore assigned
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End validateRoomHire


        private void validateExternalCompany(ref bool ifAllValid)
        {
            try
            {
                //-------------------------------- Company Name --------------------------------\\
                //check length
                if (txt_ExternalCompanyTabCompanyName.Text.Trim().Length > 3)
                {
                    //Validate the name
                    validateAStringWithOutNumbersOrSpecialCharacters(ref ifAllValid, txt_ExternalCompanyTabCompanyName.Text.Trim(), "Company Name", ref companyNameInput);
                }
                else
                {
                    //Mark invalid
                    ifAllValid = false;

                    //Inform user
                    errorToUser("The Company Name entered was too short.\nPlease enter a name of at least 3 characters", "Company Name Entry Error");

                }//End If
                
                //-------------------------------- Company Address --------------------------------\\
                //check length
                if (txt_ExternalCompanyTabCompanyAddress.Text.Trim().Length >= 8)
                {
                    //Allow anything for the Address so long as it is sufficiently long
                    companyAddressInput = txt_ExternalCompanyTabCompanyAddress.Text.Trim();
                }
                else
                {
                    //Mark invalid
                    ifAllValid = false;

                    //Inform user
                    errorToUser("The Company Address entered was too short.\nPlease enter an Address of at least 8 characters", "Company Address Entry Error");

                }//End If
                

                //-------------------------------- Company Town --------------------------------\\
                //if all previous are valid
                if (ifAllValid)
                {
                    //check length
                    if (txt_ExternalCompanyTabCompanyTown.Text.Trim().Length >= 4)
                    {
                        //Allow anything for the town so long as it is sufficiently long
                        companyTownInput = txt_ExternalCompanyTabCompanyTown.Text.Trim();
                    }
                    else
                    {
                        //Mark invalid
                        ifAllValid = false;

                        //Inform user
                        errorToUser("The Company Town entered was too short.\nPlease enter an Town of at least 4 characters", "Company Town Entry Error");

                    }//End If

                }//End If                

                //-------------------------------- Company PostCode --------------------------------\\
                //If the text property is correct length then post code must be in correct format
                if (mst_ExternalCompanyTabCompanyPostCode.Text.Length == 8)
                {
                    //Assign to variable
                    companyPostCodeInput = mst_ExternalCompanyTabCompanyPostCode.Text;
                }
                else
                {
                    //Mark Invalid
                    ifAllValid = false;

                    //Inform user
                    errorToUser("The company postcode entered is invalid.\nPlease enter a valid postcode containing 8 characters\ne.g. BT1 0AB", "Company Post Code Entry Invalid");

                }//End If


                //-------------------------------- Company Practice --------------------------------\\
                readComboBoxSelection(ref ifAllValid, cmb_ExternalCompanyTabCompanyPractice.Text, "Company Practice", ref companyPracticeInput);

                //-------------------------------- Contact Name --------------------------------\\
                //if all previous is valid
                if (ifAllValid)
                {
                    //check length
                    if (txt_ExternalCompanyTabContactName.Text.Trim().Length >= 3)
                    {
                        //Allow only letters for the name
                        validateAStringWithOutNumbersOrSpecialCharacters(ref ifAllValid, txt_ExternalCompanyTabContactName.Text.Trim(), "Contact Name", ref contactNameInput);

                    }
                    else
                    {
                        //Mark invalid
                        ifAllValid = false;

                        //Inform user
                        errorToUser("The Contact Name entered was too short.\nPlease enter a name of more than 3 characters", "Contact Name Entry Error");

                    }//End If

                }//End If               

                //-------------------------------- Contact Tel No --------------------------------\\
                //If the text property is correct length then tel no must be in correct format
                if (mst_ExternalCompanyTabContactTelNo.Text.Length == 11)
                {
                    //Assign to variable
                    contactTelNoInput = mst_ExternalCompanyTabContactTelNo.Text;
                }
                else
                {
                    //Mark Invalid
                    ifAllValid = false;

                    //Inform user
                    errorToUser("The company telephone number entered is invalid.\nPlease enter a valid telephone number", "Contact Telephone Number Entry Invalid");

                }//End If


                //-------------------------------- Contact Email Address --------------------------------\\
                //check it contains a common email extension
                string contactEmail = txt_ExternalCompanyTabContactEmail.Text.Trim();

                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(contactEmail);

                if (!match.Success)
                {
                    //Mark Invalid
                    ifAllValid = false;

                    //Inform user
                    errorToUser("The Contact email address you entered was invalid.\nPlease enter a valid email address", "Email Entry Error");

                    //set focus to the invalid entry
                    txt_ExternalCompanyTabContactEmail.Focus();

                }
                else
                {
                    //Assign across
                    contactEmailInput = contactEmail;

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End validateExternalCompany


        private void validateEmployee(ref bool ifAllValid)
        {
            try
            {
                //validate Title, Surname, First Name, Address, Town, Postcode, Tel No and Email
                ifAllValid = validatePersonalDetails(ifAllValid, cmb_EmployeeTabTitle.Text, txt_EmployeeTabSurname.Text, txt_EmployeeTabFirstName.Text, txt_EmployeeTabAddress.Text, txt_EmployeeTabTown.Text, mst_EmployeeTabPostCode.Text, mst_EmployeeTabTelNo.Text, txt_EmployeeTabEmail.Text);

                //--------------------------------DOB--------------------------------\\
                //Assign the DOB as it has to be valid input
                dateOfBirthInput = dtp_EmployeeTabDOB.Value;

                //------------------- National Insurance Number ------------------- \\
                //check length
                if (mst_EmployeeTabNIN.Text.Length == 13)
                {
                    nationalInsuranceNumberInput = mst_EmployeeTabNIN.Text;
                }
                else
                {
                    //Mark invalid
                    ifAllValid = false;

                    //Inform user
                    errorToUser("The National Insurance Number entered was too short.\nPlease enter a valid National Insurance Number", "National Insurance Number Entry Error");

                }//End If


                //------------------- Contract Type ------------------- \\
                readComboBoxSelection(ref ifAllValid, cmb_EmployeeTabContractType.Text, "Contract Type", ref contractTypeInput);


            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End validateEmployee


        private bool validatePersonalDetails(bool ifAllValid, string title, string surname, string firstName, string address, string town, string postCode, string telNo, string emailAddress)
        {
            try
            {
                //--------------------------------Title--------------------------------\\
                readComboBoxSelection(ref ifAllValid, title, "Title", ref titleInput);

                //-------------------------------- Surname --------------------------------\\                
                //If false inform user else assign to member
                if (surname.Trim().Length < 3)
                {
                    //Mark Invalid
                    ifAllValid = false;

                    //if invalid inform user
                    errorToUser("The Surname entered was not deemed valid.\nPlease enter a valid Surname of at least 3 characters.", "Surname Entry Invalid");

                }
                else
                {
                    //Validate to ensure only letters
                    validateAStringWithOutNumbersOrSpecialCharacters(ref ifAllValid, surname, "Surname", ref surnameInput);

                }//End If


                //--------------------------------FirstName--------------------------------\\
                //Check if the previous entries are valid
                if (ifAllValid)
                {
                    //If false inform user else assign to member
                    if (firstName.Trim().Length < 3)
                    {
                        //Mark invalid
                        ifAllValid = false;

                        //if invalid inform user
                        errorToUser("The First Name entered was not deemed valid.\nPlease enter a valid first name of at least 3 characters.", "First Name Entry Invalid");

                    }
                    else
                    {
                        //Validate to ensure only letters
                        validateAStringWithOutNumbersOrSpecialCharacters(ref ifAllValid, firstName, "First Name", ref firstNameInput);

                    }//End If

                }//End If                

                //--------------------------------Address--------------------------------\\
                //Check if the previous entries are valid
                if (ifAllValid)
                {

                    //Check it is longer than 8 characters long
                    if (address.Trim().Length < 8)
                    {
                        //Mark invalid
                        ifAllValid = false;

                        //if invalid inform user
                        errorToUser("The Address entered was not deemed valid.\nPlease enter a valid address of at least 8 characters.", "Address Entry Invalid");

                    }
                    else
                    {
                        //Validate to ensure only letters
                        validateAStringWithOutSpecialCharacters(ref ifAllValid, address, "Address", ref addressInput);

                    }//End If

                }//End If


                //--------------------------------Town--------------------------------\\
                //Check if the previous entries are valid
                if (ifAllValid)
                {
                    //If false inform user
                    if (town.Trim().Length < 4)
                    {
                        //Mark invalid
                        ifAllValid = false;

                        //if invalid inform user
                        errorToUser("The Town entered was not deemed valid.\nPlease enter a valid town name of at least 4 characters.", "Town Entry Invalid");

                    }
                    else
                    {
                        //Validate to ensure only letters
                        validateAStringWithOutNumbersOrSpecialCharacters(ref ifAllValid, town, "Town", ref townInput);

                    }//End If

                }//End If



                //--------------------------------PostCode--------------------------------\\
                //Check if the previous entries are valid
                if (ifAllValid)
                {
                    //Check if the length is correct
                    if (postCode.Trim().Length != 8)
                    {
                        //mark invalid
                        ifAllValid = false;

                        //if invalid inform user
                        errorToUser("The Postcode entered was not deemed valid.\nPlease enter a valid Postcode.", "Postcode Entry Invalid");

                    }
                    else
                    {
                        //Post Code is in valid format therefore assign
                        postCodeInput = postCode.Trim();

                    }//End if


                }//End If

                //--------------------------------TelNo--------------------------------\\
                //Check if the previous entries are valid
                if (ifAllValid)
                {
                    //TelNo is in valid format but length check required
                    if (telNo.Trim().Length != 11)
                    {
                        //Mark Invalid
                        ifAllValid = false;

                        //if invalid inform user
                        errorToUser("The Telephone Number entered did not match the required format.\nPlease enter a valid Tel No in the form:\n00000000000", "Telephone Number Entry Invalid");

                    }
                    else
                    {
                        //Assign input
                        telNoInput = telNo.Trim();

                    }//End if

                }//End If

                //--------------------------------Email Address--------------------------------\\
                //Check if the previous entries are valid
                if (ifAllValid)
                {
                    //assign and trim the entry for validation
                    string userEmail = emailAddress.Trim();

                    //Define the regex
                    Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    Match match = regex.Match(userEmail);

                    if (!match.Success)
                    {
                        //Mark Invalid
                        ifAllValid = false;

                        //if invalid inform user
                        errorToUser("The Email address entered did not match the standard format.\nPlease enter a valid email in the form:\njsmith@gmail.com", "Email Address Entry Invalid");

                    }
                    else
                    {
                        //Assign across
                        emailInput = userEmail;

                    }//End If

                }//End If               
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

            //return the bool
            return ifAllValid;

        }//End validatePersonalDetails


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


        //--------------------------- Click and Index Methods ---------------------------\\

        //--------------------------------- Login ---------------------------------\\

        private void btn_EmployeeLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(cmb_CurrentEmployeeID.Text, out employeeIDLoggedIn))
                {              
                    //Enable the tab control and the log out button
                    tbc_MainMenu.Enabled = true;
                    btn_EmployeeLogOut.Enabled = true;

                    //Disable the login box and button
                    cmb_CurrentEmployeeID.Enabled = false;
                    btn_EmployeeLogIn.Enabled = false;

                }
                else
                {
                    //Inform user of error
                    errorToUser("The Employee ID that you entered was not valid.\nPlease log in with a valid ID.\nPlease Try Again", "Log In Details are invalid");

                }//End If               

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_EmployeeLogIn_Click


        private void btn_EmployeeLogOut_Click(object sender, EventArgs e)
        {
            try
            {
                //Disable the tab control and the log out button
                tbc_MainMenu.Enabled = false;
                btn_EmployeeLogOut.Enabled = false;

                //Enable the login box and button
                cmb_CurrentEmployeeID.Enabled = true;
                btn_EmployeeLogIn.Enabled = true;

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_EmployeeLogOut_Click


        //--------------------------------- Member Tab ---------------------------------\\

        private void btn_MemberTabFirstMember_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstMembers.Count >= 1)
                {
                    //The list is populated and should go to position 0
                    posInMembersList = 0;

                    //Retrieve member at position
                    currentSelectedMember = lstMembers[posInMembersList];

                    //Display details
                    displayMemberDetails(currentSelectedMember);

                }
                else
                {
                    //Inform user there are no members in list
                    errorToUser("No members exist", "List Error");

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_MemberTabFirstMember_Click


        private void btn_MemberTabPreviousName_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstMembers.Count >= 1)
                {
                    //check it is not at the start of the list
                    if (posInMembersList != 0)
                    {
                        //The list is populated and should go to the previous position
                        posInMembersList--;

                        //Retrieve member at position
                        currentSelectedMember = lstMembers[posInMembersList];

                        //Display details
                        displayMemberDetails(currentSelectedMember);

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
                    errorToUser("No members exist", "List Error");

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_MemberTabPreviousName_Click


        private void btn_MemberTabNextName_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstMembers.Count >= 1)
                {
                    //check it is not at the end of the list
                    if (posInMembersList != (lstMembers.Count - 1))
                    {
                        //The list is populated and should go to the next position
                        posInMembersList++;

                        //Retrieve member at position
                        currentSelectedMember = lstMembers[posInMembersList];

                        //Display details
                        displayMemberDetails(currentSelectedMember);

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
                    errorToUser("No members exist", "List Error");

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }



        }//End btn_MemberTabNextName_Click


        private void btn_MemberTabLastMember_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstMembers.Count >= 1)
                {
                    //The list is populated and should go to the last position 
                    posInMembersList = (lstMembers.Count - 1);

                    //Retrieve member at position
                    currentSelectedMember = lstMembers[posInMembersList];

                    //Display details
                    displayMemberDetails(currentSelectedMember);

                }
                else
                {
                    //Inform user there are no members in list
                    errorToUser("No members exist", "List Error");

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }



        }//End btn_MemberTabLastMember_Click
        

        private void btn_MemberTabAddMember_Click(object sender, EventArgs e)
        {
            try
            {
                //Add Member
                addMember();

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_MemberTabAddMember_Click


        private void btn_MemberTabSubmit_Click(object sender, EventArgs e)
        {
            //Declare Variables
            bool validInput = true;
            bool ifAllValid = true;
           
            try
            {
                //Validate all of the member's details
                validateMemberDetails(ref validInput, ref ifAllValid);


                //If all valid user details are entered
                if (ifAllValid)
                {
                    //Assign memberID
                    memberIDInput = nextMemberID;

                    //Increase max memberID for next member
                    nextMemberID++;

                    //Create a new member with all the info
                    lstMembers[posInMembersList] = new Member(memberIDInput, membershipTypeIDInput, titleInput, surnameInput, firstNameInput, dateOfBirthInput, addressInput, townInput, postCodeInput, telNoInput, emailInput);

                    //Re-enable all of the buttons again
                    disableOrEnableAllMemberButtons(true);

                    //Disable Submit Button
                    btn_MemberTabSubmit.Enabled = false;

                    //Disable the group box again
                    grp_MemberDetails.Enabled = false;

                    //Set date time picker min date
                    dtp_DOB.MinDate = DateTime.Today.AddYears(-100);

                    //Add the Member to the database
                    memberTable.AddNewMember(lstMembers[posInMembersList]);

                    //Refresh Member List
                    refreshMemberList();

                    //Set up all tabs that involve Member ID
                    setUpBookingTab();
                    setUpPaymentTab();                    

                    //refresh data source and update the record onscreen
                    refreshMemberDataGrid();
                    displayMemberDetails(lstMembers[posInMembersList]);
                    
                    //Inform user that the member has been added
                    informUser("Member addition successful", "Addition Successful");
                    
                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_MemberTabSubmit_Click


        private void btn_MemberTabDelete_Click(object sender, EventArgs e)
        {
            try
            {
                deleteMember();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

            
        }//End btn_MemberTabDelete_Click


        private void btn_MemberTabEdit_Click(object sender, EventArgs e)
        {
            try
            {
                //Enable the groupbox and the submit button
                grp_MemberDetails.Enabled = true;
                btn_MemberTabEditSubmit.Enabled = true;

                //Disable the rest of the controls
                disableOrEnableAllMemberButtons(false);

                //Set date time picker max date
                dtp_DOB.MaxDate = DateTime.Today.AddYears(-16);
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            

        }//End btn_MemberTabEdit_Click


        private void btn_MemberTabEditSubmit_Click(object sender, EventArgs e)
        {
            //Declaration of variables
            bool validInput = true;
            bool ifAllValid = true;
           
            try
            {
                //Validate the current entries
                validateMemberDetails(ref validInput, ref ifAllValid);

                if (ifAllValid)
                {
                    //Assign member to update
                    Member memberUpdating = lstMembers[posInMembersList];

                    //Update details
                    memberUpdating.Title = titleInput;
                    memberUpdating.Surname = surnameInput;
                    memberUpdating.FirstName = firstNameInput;
                    memberUpdating.DOB = dateOfBirthInput;
                    memberUpdating.Address = addressInput;
                    memberUpdating.Town = townInput;
                    memberUpdating.PostCode = postCodeInput;
                    memberUpdating.TelNo = telNoInput;
                    memberUpdating.Email = emailInput;

                    //Reactivate the buttons
                    disableOrEnableAllMemberButtons(true);

                    //Disable the edit submit and the group box
                    btn_MemberTabEditSubmit.Enabled = false;
                    grp_MemberDetails.Enabled = false;

                    //Update the member in the database
                    memberTable.UpdateMemberDatabase(memberUpdating);

                    //Set date time picker min date
                    dtp_DOB.MinDate = DateTime.Today.AddYears(-100);

                    //Set up all tabs that involve Member ID
                    setUpBookingTab();
                    setUpPaymentTab();      

                    //Refresh datasource
                    refreshMemberDataGrid();

                    //Inform user member has been updated
                    informUser("Update successful", "Successful Update");

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            

        }//End btn_MemberTabEditSubmit_Click


        private void btn_MemberTabSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //If the search index is within correct count and the text is not null
                if (selectedSearchField < cmb_MemberTabSearchTermOptions.Items.Count && cmb_MemberTabSearchTermOptions.Text != "")
                {
                    //Search
                    searchForMember();

                }//End If   
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }



        }//End btn_MemberTabSearch_Click


        private void btn_MemberTabSubmitSort_Click(object sender, EventArgs e)
        {
            try
            {
                //Sorts members
                sortMembers();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }


        }//End btn_MemberTabSubmitSort_Click


        private void btn_MemberTabFullList_Click(object sender, EventArgs e)
        {
            try
            {
                //Re-Order to show standard form
                lstMembers = lstMembers.OrderBy(Member => Member.MemberID).ToList();

                //Refresh the list
                refreshMemberDataGrid();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_MemberTabFullList_Click


        private void btn_MemberTabReport_Click(object sender, EventArgs e)
        {
            try
            {
                //Open the Member Report Form
                //frm_MemberReport reportForm = new frm_MemberReport();

                //Show the report form
                //reportForm.Show();

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_MemberTabReport_Click


        private void cmb_MemberTabTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedTitle = cmb_Title.SelectedIndex;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End cmb_MemberTabTitle_SelectedIndexChanged


        private void cmb_MemberTabSearchTermOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Assign selected index
                selectedSearchField = cmb_MemberTabSearchTermOptions.SelectedIndex;

                //Check if post code or tel no
                if (selectedSearchField == 5)
                {
                    mst_MemberTabSearchTerm.Mask = ">LL00 0LL";
                }
                else if (selectedSearchField == 6)
                {
                    mst_MemberTabSearchTerm.Mask = "00000000000";
                }
                else
                {
                    mst_MemberTabSearchTerm.Mask = "";

                }//End If
            }
            catch (Exception ex)
            {
                //print error message
                printErrorMessage(ex);
            }
        }//End cmb_MemberTabSearchTermOptions_SelectedIndexChanged


        private void cmb_MemberTabSortOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Assign which field to sort by
                selectedIndexFieldForSort = cmb_MemberTabSortOptions.SelectedIndex;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }


        }//End cmb_MemberTabSortOptions_SelectedIndexChanged


        private void cmb_MemberTabAscendOrDescend_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //assign which way to order them
                selectedAscendOrDescend = cmb_MemberTabAscendOrDescend.SelectedIndex;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }


        }//End cmb_MemberTabAscendOrDescend_SelectedIndexChanged


        //--------------------------------- ExerciseClass Tab ---------------------------------\\

        private void btn_ClassTabFirstClass_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstExerciseClasses.Count >= 1)
                {
                    //The list is populated and should go to position 0
                    posInExerciseClassList = 0;

                    //Retrieve member at position
                    currentSelectedExerciseClass = lstExerciseClasses[posInExerciseClassList];

                    //Display details
                    displayClassDetails(currentSelectedExerciseClass);
                    

                }
                else
                {
                    //Inform user there are no members in list
                    errorToUser("No classes exist.", "List Error");

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_ClassTabFirstMember_Click


        private void btn_ClassTabPreviousClass_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstExerciseClasses.Count >= 1)
                {
                    //check it is not at the start of the list
                    if (posInExerciseClassList != 0)
                    {
                        //The list is populated and should go to the previous position
                        posInExerciseClassList--;

                        //Retrieve member at position
                        currentSelectedExerciseClass = lstExerciseClasses[posInExerciseClassList];

                        //Display details
                        displayClassDetails(currentSelectedExerciseClass);

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
                    errorToUser("No classes exist", "List Error");

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_ClassTabPreviousClass_Click


        private void btn_ClassTabNextClass_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstExerciseClasses.Count >= 1)
                {
                    //check it is not at the start of the list
                    if (posInExerciseClassList != (lstExerciseClasses.Count - 1))
                    {
                        //The list is populated and should go to the previous position
                        posInExerciseClassList++;

                        //Retrieve member at position
                        currentSelectedExerciseClass = lstExerciseClasses[posInExerciseClassList];

                        //Display details
                        displayClassDetails(currentSelectedExerciseClass);

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
                    errorToUser("No classes exist", "List Error");

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_ClassTabNextClass_Click


        private void btn_ClassTabLastClass_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstExerciseClasses.Count >= 1)
                {
                    //The list is populated and should go to position 0
                    posInExerciseClassList = lstExerciseClasses.Count - 1;

                    //Retrieve member at position
                    currentSelectedExerciseClass = lstExerciseClasses[posInExerciseClassList];

                    //Display details
                    displayClassDetails(currentSelectedExerciseClass);

                }
                else
                {
                    //Inform user there are no members in list
                    errorToUser("No classes exist.", "List Error");

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_ClassTabLastClass_Click


        private void btn_ClassTabAddClass_Click(object sender, EventArgs e)
        {
            try
            {
                //add a class
                addClass();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            

        }//End btn_ClassTabAddClass_Click


        private void btn_ClassTabAddSubmit_Click(object sender, EventArgs e)
        {
            //Declare Variables
            bool validInput = false;
            bool ifAllValid = true;

            try
            {
                //Validate the class details
                validateExerciseClass(ref validInput, ref ifAllValid);

                //Assign dates
                DateTime dateOfClassInput = startDateInput;

                if (ifAllValid)
                {
                    //Assign the ID
                    exerciseClassIDInput = nextExerciseClassID;

                    //Increase max exerciseClassID for next exercise class
                    nextExerciseClassID++;

                    //Create class and assign
                    lstExerciseClasses[posInExerciseClassList] = new ExerciseClass(exerciseClassIDInput, employeeIDInput, externalCompanyIDInput, roomIDInput, descriptionInput, difficultyInput, startDateInput, noOfWeeksInput, endDateInput, 0, maxParticipantsInput, externalClassInput, weeklyCostOfClassInput, totalCostOfClassInput);

                    //Add to the database
                    exClassTable.AddNewExerciseClass(lstExerciseClasses[posInExerciseClassList]);

                    //refresh List
                    refreshExerciseClassList();

                    //Assign date of class
                    dateOfClassInput = startDateInput;

                    //Create and assign the sessions
                    for (int sessionCreated = 0; sessionCreated < noOfWeeksInput; sessionCreated++)
                    {
                        //Create the session
                        lstSessions.Add(new Session(nextSessionID, lstExerciseClasses[posInExerciseClassList].ExerciseClassID, dateOfClassInput, startTimeInput, classLengthInput, endTimeInput));

                        //Add the session to the database
                        sesTable.AddNewSession(lstSessions[lstSessions.Count - 1]);

                        //Increase by 1 week
                        dateOfClassInput = dateOfClassInput.AddDays(7);

                        //Increase ID
                        nextSessionID++;

                    }//End For loop

                    //refresh List
                    refreshSessionList();

                    //Display class details
                    displayClassDetails(lstExerciseClasses[posInExerciseClassList]);

                    //Enable all the buttons again
                    disableOrEnableAllExerciseClassButtons(true);

                    //disable the three detail groupboxes and the AddSubmit Button
                    grp_ClassDetails.Enabled = false;
                    grp_ClassTabSessionDetails.Enabled = false;
                    btn_ClassTabAddSubmit.Enabled = false;

                    //Set date time picker min and max date
                    dtp_ClassTabStartDateOfClass.MinDate = DateTime.Today.AddYears(-10);
                    dtp_ClassTabStartDateOfClass.MaxDate = DateTime.Today.AddYears(10);
                                        
                    //Set up all tabs that involve Exercise Class ID
                    setUpBookingTab();                         

                    //Refresh data source
                    refreshClassDataGrid();
                    refreshSessionDataGrid();

                    //Inform user that the member has been added
                    informUser("Class addition successful", "Addition Successful");

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
            

        }//End btn_ClassTabAddSubmit_Click


        private void btn_ClassTabDeleteClass_Click(object sender, EventArgs e)
        {
            try
            {
                //delete class
                deleteClass();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
        }//End btn_ClassTabDeleteClass_Click


        private void btn_ClassTabEditClass_Click(object sender, EventArgs e)
        {
            try
            {
                //Enable Submit button and groupboxes
                btn_ClassTabEditSubmit.Enabled = true;
                grp_ClassDetails.Enabled = true;
                grp_ClassTabSessionDetails.Enabled = true;

                //Disable add, delete, edit and the search/sort groupbox
                disableOrEnableAllExerciseClassButtons(false);

                //Set date time picker min and max date
                dtp_ClassTabStartDateOfClass.MinDate = DateTime.Today.AddDays(1);
                dtp_ClassTabStartDateOfClass.MaxDate = DateTime.Today.AddMonths(2);

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
           

        }//End btn_ClassTabEditClass_Click

        
        private void btn_ClassTabEditSubmit_Click(object sender, EventArgs e)
        {
            //Declare variables
            bool validInput = true;
            bool ifAllValid = true;
            List<Session> lstSessionsToDelete = new List<Session>();

            try
            {
                validateExerciseClass(ref validInput, ref ifAllValid);

                //Assign dates
                DateTime dateOfClassInput = startDateInput;
                
                if (ifAllValid)
                {
                    //Assign member to update
                    ExerciseClass exerciseClassUpdating = lstExerciseClasses[posInExerciseClassList];

                    //Add the sessions to a list for deletion from the database
                    lstSessionsToDelete = lstSessions.FindAll(session => session.ExerciseClassID.Equals(exerciseClassUpdating.ExerciseClassID));

                    //remove all from list
                    lstSessions.RemoveAll(session => session.ExerciseClassID.Equals(exerciseClassUpdating.ExerciseClassID));

                    //Find and delete the sessions that are for this exercise class
                    foreach(Session session in lstSessionsToDelete)
                    {
                        if (session.ExerciseClassID == exerciseClassUpdating.ExerciseClassID)
                        {                            
                            //Remove from the database
                            sesTable.DeleteSessionRecord(session);

                            //delete the session
                            lstSessions.Remove(session);
                            
                        }//End If

                    }//End Foreach

                    //Update details
                    exerciseClassIDInput = exerciseClassUpdating.ExerciseClassID;
                    exerciseClassUpdating.StartDateOfClass = startDateInput;  
                    exerciseClassUpdating.NoOfWeeks = noOfWeeksInput;
                    exerciseClassUpdating.EndDateOfClass = endDateInput;
                    exerciseClassUpdating.EmployeeID = employeeIDInput;
                    exerciseClassUpdating.RoomID = roomIDInput;
                    exerciseClassUpdating.Description = descriptionInput;                    
                    exerciseClassUpdating.Difficulty = difficultyInput;
                    exerciseClassUpdating.MaxNumberOfParticipants = maxParticipantsInput;
                    exerciseClassUpdating.ExternalClass = externalClassInput;

                    //Update the exercise class on the Database
                    exClassTable.UpdateExerciseClassDatabase(exerciseClassUpdating);


                    //Create and assign the sessions
                    for (int sessionCreated = 0; sessionCreated < noOfWeeksInput; sessionCreated++)
                    {
                        //Create the session
                        lstSessions.Add(new Session(nextSessionID, exerciseClassIDInput, dateOfClassInput, startTimeInput, classLengthInput, endTimeInput));

                        //Add the new session to the database
                        sesTable.AddNewSession(lstSessions[lstSessions.Count - 1]);

                        //Increase by 1 week
                        dateOfClassInput = dateOfClassInput.AddDays(7);

                        //Increase ID
                        nextSessionID++;

                    }//End For loop

                    //Reactivate the buttons
                    disableOrEnableAllExerciseClassButtons(true);

                    //Disable the edit submit and the group box
                    btn_ClassTabEditSubmit.Enabled = false;
                    grp_ClassDetails.Enabled = false;
                    grp_ClassTabSessionDetails.Enabled = false;

                    //Set date time picker min and max date
                    dtp_ClassTabStartDateOfClass.MinDate = DateTime.Today.AddYears(-10);
                    dtp_ClassTabStartDateOfClass.MaxDate = DateTime.Today.AddYears(10);

                    //refresh Lists
                    refreshExerciseClassList();
                    refreshSessionList();

                    //Refresh datasources
                    refreshClassDataGrid();
                    refreshSessionDataGrid();

                    //Inform user member has been updated
                    informUser("Update successful", "Successful Update");

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
           

        }//End btn_ClassTabEditSubmit_Click


        private void btn_ClassTabSort_Click(object sender, EventArgs e)
        {    
            try
            {
                sortClasses();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
        
        }//End btn_ClassTabSort_Click


        private void btn_ClassTabShowFullList_Click(object sender, EventArgs e)
        {
            try
            {
                //Re-Order to show standard form
                lstExerciseClasses = lstExerciseClasses.OrderBy(ExerciseClass => ExerciseClass.ExerciseClassID).ToList();

                //Refresh the list
                refreshClassDataGrid();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_ClassTabShowFullList_Click


        private void btn_ClassTabSearchSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //If the search index is within correct count and the selected item is not null
                if (selectedSearchField < cmb_ClassTabSearchField.Items.Count && cmb_ClassTabSearchField.SelectedItem != null)
                {
                    //Search
                    searchForExerciseClass();

                }//End If   
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
                     

        }//End btn_ClassTabSearchSubmit_Click


        private void btn_ClassTabReport_Click(object sender, EventArgs e)
        {
            try
            {
                //Create new instance of form
                //frm_ExerciseClassReport reportForm = new frm_ExerciseClassReport();

                //Show form
                //reportForm.Show();

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
        }//End btn_ClassTabReport_Click


        private void cmb_ClassTabEmployeeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Read selected index
                int selectedEmployee = cmb_ClassTabEmployeeID.SelectedIndex;

                //Show the employee details
                txt_ClassTabEmployeeFullName.Text = lstEmployees[selectedEmployee].FirstName + " " + lstEmployees[selectedEmployee].Surname;

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End cmb_ClassTabEmployeeID_SelectedIndexChanged

       
        private void cmb_RoomID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int selectedRoom = cmb_ClassTabRoomID.SelectedIndex;

                //Show the room details
                txt_ClassTabRoomDescription.Text = lstRooms[selectedRoom].RoomDescription;
                txt_ClassTabRoomLocation.Text = lstRooms[selectedRoom].RoomLocation;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            

        }//End cmb_RoomID_SelectedIndexChanged


        private void cmb_ClassTabSortOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Assign the index
                selectedIndexFieldForSort = cmb_ClassTabSortOptions.SelectedIndex;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            

        }//End cmb_ClassTabSortOptions_SelectedIndexChanged


        private void cmb_ClassTabAscendOrDescend_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Assign ascend or descend
                selectedAscendOrDescend = cmb_ClassTabAscendOrDescend.SelectedIndex;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
        }//End cmb_ClassTabAscendOrDescend_SelectedIndexChanged


        private void cmb_ClassTabSearchField_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Assign the the field wanted
                selectedSearchField = cmb_ClassTabSearchField.SelectedIndex;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
        }//End cmb_ClassTabSearchField_SelectedIndexChanged


        private void cmb_ClassTabTimeOfClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Assign the new time to the time input
                startTimeInput = (TimeSpan)cmb_ClassTabTimeOfClass.SelectedItem;

                //Calculate the end time
                calculateEndTimeOfClass();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
           
        }//End cmb_ClassTimeOfClass_SelectedIndexChanged


        private void cmb_ClassTabExternalCompanyID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Show the company name on screen
                txt_ClassTabExternalCompanyName.Text = lstExternalCompanies[cmb_ClassTabExternalCompanyID.SelectedIndex].CompanyName;

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End cmb_ClassTabExternalCompanyID_SelectedIndexChanged


        private void chb_ClassTabExternalClass_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //Change the external Company ID cmb is necessary
                cmb_ClassTabExternalCompanyID.Enabled = chb_ClassTabExternalClass.Checked;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End chb_ClassTabExternalClass_CheckedChanged


        private void dtp_DateOfClass_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                //Check if the selected day is a sunday
                if (dtp_ClassTabStartDateOfClass.Value.DayOfWeek == DayOfWeek.Sunday)
                {                   
                    //If a sunday - no classes on sundays
                    errorToUser("There are no classes on Sundays", "Date Selection Error");

                    //reset value to today
                    dtp_ClassTabStartDateOfClass.Value = DateTime.Today;

                }
                else
                {
                    //Calculate the new end date
                    calculateEndDate();

                }//End If

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End dtp_DateOfClass_ValueChanged


        private void nud_ClassTabNumberOfWeeks_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                //Read in and set the number of weeks input
                noOfWeeksInput = (int)nud_ClassTabNumberOfWeeks.Value;

                //Calculate a new end date if necessary
                calculateEndDate();

                //Calculate a new total cost if necessary
                calculatePrice();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End nud_ClassTabNumberOfWeeks_ValueChanged


        private void nud_ClassTabLengthOfClass_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                calculateEndTimeOfClass();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            

        }//End nud_ClassTabLengthOfClass_ValueChanged

        
        private void nud_ClassTabWeeklyCostOfClass_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                //Calculate a new total cost if necessary
                calculatePrice();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End nud_ClassTabWeeklyCostOfClass_ValueChanged


        //------------------------------- Bookings Tab -------------------------------\\
        
        private void btn_BookingsTabFirstBooking_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstBookings.Count >= 1)
                {
                    //The list is populated and should go to position 0
                    posInBookingsList = 0;

                    //Retrieve member at position
                    currentlySelectedBooking = lstBookings[posInBookingsList];

                    //Display details
                    displayBookingDetails(currentlySelectedBooking);

                }
                else
                {
                    //Inform user there are no members in list
                    errorToUser("No bookings exist.", "List Error");

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            } 
            
        }//End btn_BookingsTabFirstBooking_Click


        private void btn_BookingsTabPreviousBooking_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstBookings.Count >= 1)
                {
                    //check it is not at the start of the list
                    if (posInBookingsList != 0)
                    {
                        //The list is populated and should go to the previous position
                        posInBookingsList--;

                        //Retrieve member at position
                        currentlySelectedBooking = lstBookings[posInBookingsList];

                        //Display details
                        displayBookingDetails(currentlySelectedBooking);

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
                    errorToUser("No bookings exist.", "List Error");

                }//End If

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            } 

        }//End btn_BookingsTabPreviousBooking_Click


        private void btn_BookingsTabNextBooking_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstBookings.Count >= 1)
                {
                    //check it is not at the end of the list
                    if (posInBookingsList != lstBookings.Count - 1)
                    {
                        //The list is populated and should go to the next position
                        posInBookingsList++;

                        //Retrieve member at position
                        currentlySelectedBooking = lstBookings[posInBookingsList];

                        //Display details
                        displayBookingDetails(currentlySelectedBooking);

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
                    errorToUser("No bookings exist.", "List Error");

                }//End If

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            } 

        }//End btn_BookingsTabNextBooking_Click


        private void btn_BookingsTabLastBooking_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstBookings.Count >= 1)
                {
                    //The list is populated and should go to position 0
                    posInBookingsList = lstBookings.Count - 1;

                    //Retrieve member at position
                    currentlySelectedBooking = lstBookings[posInBookingsList];

                    //Display details
                    displayBookingDetails(currentlySelectedBooking);

                }
                else
                {
                    //Inform user there are no members in list
                    errorToUser("No bookings exist.", "List Error");

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            } 

        }//End btn_BookingsTabLastBooking_Click


        private void btn_BookingsTabAddBooking_Click(object sender, EventArgs e)
        {
            try
            {
                //add booking
                addBooking();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
        }//End btn_BookingsTabAddBooking_Click


        private void btn_BookingsTabAddSubmit_Click(object sender, EventArgs e)
        {
            //Declare Variables
            bool validInput = false;
            bool ifAllValid = true;
            
            try
            {
                //Validate the class details
                validateBooking(ref validInput, ref ifAllValid);

                if (ifAllValid)
                {
                    //Assign the ID
                    bookingIDInput = nextBookingID;

                    //Increase max exerciseClassID for next exercise class
                    nextBookingID++;

                    //Assign booking
                    lstBookings[posInBookingsList] = new Booking(bookingIDInput, memberIDInput, exerciseClassIDInput, employeeIDInput, amountChargedInput, noOfPeopleBookingInput);

                    //Write to the database
                    bookingTable.AddNewBooking(lstBookings[posInBookingsList]);
                    exClassTable.UpdateExerciseClassDatabase(lstExerciseClasses.Find(exClass => exClass.ExerciseClassID.Equals(exerciseClassIDInput)));

                    //refresh Lists
                    refreshBookingList();

                    //Display class details
                    displayBookingDetails(lstBookings[posInBookingsList]);

                    //Enable all the buttons again
                    disableOrEnableAllBookingButtons(true);

                    //disable the three detail groupboxes and the AddSubit Button
                    grp_BookingsTabMemberID.Enabled = false;
                    grp_BookingsTabExerciseClassID.Enabled = false;
                    grp_BookingsTabClassDetails.Enabled = false;
                    btn_BookingsTabAddSubmit.Enabled = false;

                    //Set up the payments tab
                    setUpPaymentTab();                    

                    //Refresh data source
                    refreshBookingDataGrid();
                    
                    //Inform user that the member has been added
                    informUser("Booking made successfully", "Booking Successful");
                    
                }//End If

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_BookingsTabAddSubmit_Click


        private void btn_BookingsTabDeleteBooking_Click(object sender, EventArgs e)
        {
            try
            {
                //Delete booking
                deleteBooking();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            

        }//End btn_BookingsTabDeleteBooking_Click


        private void btn_BookingsTabEditBooking_Click(object sender, EventArgs e)
        {
            try
            {
                //activate the groupboxes that need to be edited
                btn_BookingsTabEditSubmit.Enabled = true;
                grp_BookingsTabMemberID.Enabled = true;
                grp_BookingsTabExerciseClassID.Enabled = true;
                grp_BookingsTabClassDetails.Enabled = true;

                //Disable all of the unnecessary buttons
                disableOrEnableAllBookingButtons(false);

                //Edit the classes current participants to remove the number from the booking
                ExerciseClass exClass = lstExerciseClasses.Find(exerClass => exerClass.ExerciseClassID.Equals(currentlySelectedBooking.ExerciseClassID));

                //Remove the number of participants
                currentNoOfParticipantsInput = exClass.CurrentNumberOfParticipants - currentlySelectedBooking.NoOfPeopleBooking;

                //Update the on screen control
                txt_BookingsTabCurrentNoOfParticipants.Text = currentNoOfParticipantsInput.ToString();

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            

        }//End btn_BookingsTabEditBooking_Click


        private void btn_BookingsTabEditSubmit_Click(object sender, EventArgs e)
        {
            //Declare variables
            bool validInput = true;
            bool ifAllValid = true;

            try
            {
                validateBooking(ref validInput, ref ifAllValid);

                if (ifAllValid)
                {
                    //Assign booking to update
                    Booking updatedBooking = lstBookings[posInBookingsList];
                    ExerciseClass updatingClass = lstExerciseClasses.Find(exClass => exClass.ExerciseClassID.Equals(exerciseClassIDInput));

                    //Update details
                    updatedBooking.MemberID = memberIDInput;
                    updatedBooking.ExerciseClassID = exerciseClassIDInput;
                    updatedBooking.EmployeeID = employeeIDInput;
                    updatedBooking.AmountCharged = amountChargedInput;
                    updatedBooking.NoOfPeopleBooking = noOfPeopleBookingInput;
                    updatingClass.CurrentNumberOfParticipants = currentNoOfParticipantsInput;

                    //Update the database
                    bookingTable.UpdateBookingDatabase(updatedBooking);
                    exClassTable.UpdateExerciseClassDatabase(updatingClass);

                    //Reactivate the buttons
                    disableOrEnableAllBookingButtons(true);

                    //Disable the edit submit and the group boxes
                    btn_BookingsTabEditSubmit.Enabled = false;
                    grp_BookingsTabMemberID.Enabled = false;
                    grp_BookingsTabExerciseClassID.Enabled = false;
                    grp_BookingsTabClassDetails.Enabled = false;

                    //refresh Lists
                    refreshBookingList();

                    //Set up the payments tab
                    setUpPaymentTab();    

                    //Refresh datasource
                    refreshBookingDataGrid();

                    //Display details on screen
                    displayBookingDetails(updatedBooking);

                    //Inform user member has been updated
                    informUser("Update successful", "Successful Update");
                    
                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            

        }//End btn_BookingsTabEditSubmit_Click
        

        private void btn_BookingsTabSort_Click(object sender, EventArgs e)
        {
            try
            {
                //Sort Bookings
                sortBookings();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
        }//End btn_BookingsTabSort_Click


        private void btn_BookingsTabSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //If the search index is within correct count and the selected item is not null
                if (selectedSearchField < cmb_BookingsTabSearchField.Items.Count && cmb_BookingsTabSearchField.SelectedItem != null)
                {
                    //Search
                    searchForBooking();

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
            

        }//End btn_BookingsTabSearch_Click


        private void btn_BookingsTabShowFullList_Click(object sender, EventArgs e)
        {
            try
            {
                //Re-Order to show standard form
                lstBookings = lstBookings.OrderBy(Booking => Booking.BookingID).ToList();

                //Refresh the list
                refreshBookingDataGrid();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_BookingsTabShowFullList_Click


        private void btn_BookingTabReport_Click(object sender, EventArgs e)
        {
            try
            {
                //Create new instance of form
                //frm_BookingReport reportForm = new frm_BookingReport();

                //Show form
                //reportForm.Show();

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_BookingTabReport_Click


        private void cmb_BookingsTabMemberID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstMembers.Count > 0)
                {
                    //Assign the member that is booking a class
                    Member currentMemberBooking = lstMembers[cmb_BookingsTabMemberID.SelectedIndex];

                    //display the member details
                    txt_BookingsTabTitle.Text = currentMemberBooking.Title.ToString();
                    txt_BookingsTabSurname.Text = currentMemberBooking.Surname.ToString();
                    txt_BookingsTabFirstName.Text = currentMemberBooking.FirstName.ToString();
                    dtp_BookingsTabDOB.Value = currentMemberBooking.DOB;

                }
                else
                {
                    //Show error message
                    errorToUser("No members exist", "List Error");

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            

        }//End cmb_BookingsTabMemberID_SelectedIndexChanged


        private void cmb_BookingsTabExerciseClassID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstExerciseClasses.Count > 0)
                {
                    //Assign the class that is being booked
                    ExerciseClass exerciseClassBeingBooked = lstExerciseClasses[cmb_BookingsTabExerciseClassID.SelectedIndex];

                    //Set the exercise class input
                    exerciseClassIDInput = exerciseClassBeingBooked.ExerciseClassID;

                    //Assign details to onscreen controls
                    dtp_BookingsTabDateOfClass.Value = exerciseClassBeingBooked.StartDateOfClass;
                    txt_BookingsTabDescription.Text = exerciseClassBeingBooked.Description;
                    txt_BookingsTabDifficulty.Text = exerciseClassBeingBooked.Difficulty;
                    txt_BookingsTabCurrentNoOfParticipants.Text = exerciseClassBeingBooked.CurrentNumberOfParticipants.ToString();
                    txt_BookingsTabMaxParticipants.Text = exerciseClassBeingBooked.MaxNumberOfParticipants.ToString();
                    txt_BookingsTabExternalClass.Text = exerciseClassBeingBooked.ExternalClass.ToString();

                    //Set the max value to the cost of the class per person * the number of people booking
                    nud_BookingsTabCostOfBooking.Maximum = exerciseClassBeingBooked.TotalCostOfClass * nud_BookingsTabNumberOfParticipantsBooking.Value;

                    //Set the value to the control
                    nud_BookingsTabCostOfBooking.Value = exerciseClassBeingBooked.TotalCostOfClass;

                    //Set the increment to the cost of the class per person
                    nud_BookingsTabCostOfBooking.Increment = exerciseClassBeingBooked.TotalCostOfClass;
                    

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            //check if there are exercie classes
            

        }//End cmb_BookingsTabExerciseClassID_SelectedIndexChanged


        private void cmb_BookingsTabSortOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Assign the index
                selectedIndexFieldForSort = cmb_BookingsTabSortOptions.SelectedIndex;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            

        }//End cmb_BookingsTabSortOptions_SelectedIndexChanged


        private void cmb_BookingsTabAscendingOrDescending_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Assign ascend or descend
                selectedAscendOrDescend = cmb_BookingsTabAscendingOrDescending.SelectedIndex;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
        }//End cmb_BookingsTabAscendingOrDescending_SelectedIndexChanged


        private void cmb_BookingsTabSearchField_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Assign Index
                selectedSearchField = cmb_BookingsTabSearchField.SelectedIndex;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End cmb_BookingsTabSearchField_SelectedIndexChanged

        
        private void nud_BookingsTabNumberOfParticipantsBooking_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                //Find the cost of the class for one person
                decimal costOfClass = lstExerciseClasses.Find(exClass => exClass.ExerciseClassID.Equals(exerciseClassIDInput)).TotalCostOfClass;

                //calculate the max value that can be charged and set to the nud max value property
                nud_BookingsTabCostOfBooking.Maximum = costOfClass * nud_BookingsTabNumberOfParticipantsBooking.Value;

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End nud_BookingsTabNumberOfParticipantsBooking_ValueChanged 
        

        //--------------------------- Payment Tab ---------------------------\\

        private void btn_PaymentTabMembership_Click(object sender, EventArgs e)
        {
            try
            {
                //Enable MemberID Combobox
                cmb_PaymentTabMemberID.Enabled = true;

                //Disable the booking combobox
                cmb_PaymentTabBookingID.Enabled = false;

                //mark the payment as membership
                isMembership = true;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            

        }//End btn_PaymentTabMembership_Click


        private void btn_PaymentTabBooking_Click(object sender, EventArgs e)
        {
            try
            {
                //Enable the Member and booking comboboxes
                cmb_PaymentTabMemberID.Enabled = true;
                cmb_PaymentTabBookingID.Enabled = true;

                //mark the payment as booking
                isMembership = false;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            

        }//End btn_PaymentTabBooking_Click       


        private void btn_PaymentTabFirstPayment_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstPayments.Count >= 1)
                {
                    //The list is populated and should go to position 0
                    posInPaymentsList = 0;

                    //Retrieve member at position
                    currentlySelectedPayment = lstPayments[posInPaymentsList];

                    //Display details
                    displayPaymentDetails(currentlySelectedPayment);

                }
                else
                {
                    //Inform user there are no members in list
                    errorToUser("No payments exist.", "List Error");

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            } 
        }//End btn_PaymentTabFirstPayment_Click


        private void btn_PaymentTabPreviousPayment_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstPayments.Count >= 1)
                {
                    //check it is not at the start of the list
                    if (posInPaymentsList != 0)
                    {
                        //The list is populated and should go to the previous position
                        posInPaymentsList--;

                        //Retrieve member at position
                        currentlySelectedPayment = lstPayments[posInPaymentsList];

                        //Display details
                        displayPaymentDetails(currentlySelectedPayment);

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
                    errorToUser("No Payments exist.", "List Error");

                }//End If

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            } 
        }//End btn_PaymentTabPreviousPayment_Click


        private void btn_PaymentTabNextPayment_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstPayments.Count >= 1)
                {
                    //check it is not at the end of the list
                    if (posInPaymentsList != lstPayments.Count - 1)
                    {
                        //The list is populated and should go to the next position
                        posInPaymentsList++;

                        //Retrieve member at position
                        currentlySelectedPayment = lstPayments[posInPaymentsList];

                        //Display details
                        displayPaymentDetails(currentlySelectedPayment);

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
                    errorToUser("No payments exist.", "List Error");

                }//End If

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            } 
        }//End btn_PaymentTabNextPayment_Click


        private void btn_PaymentTabLastPayment_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstPayments.Count >= 1)
                {
                    //The list is populated and should go to position 0
                    posInPaymentsList = lstPayments.Count - 1;

                    //Retrieve member at position
                    currentlySelectedPayment = lstPayments[posInPaymentsList];

                    //Display details
                    displayPaymentDetails(currentlySelectedPayment);

                }
                else
                {
                    //Inform user there are no members in list
                    errorToUser("No payments exist.", "List Error");

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            } 
        }//End btn_PaymentTabLastPayment_Click


        private void btn_PaymentTabAddPayment_Click(object sender, EventArgs e)
        {
            try
            {
                //Call Add payment
                addPayment();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
              
        }//End btn_PaymentTabAddPayment_Click


        private void btn_PaymentTabAddSubmit_Click(object sender, EventArgs e)
        {
            //Assign the appropriate values to their variables
            bool ifAllValid = true;

            try
            {
                validatePayment(ref ifAllValid);

                if (ifAllValid)
                {
                    //If it is a booking payment
                    if (!isMembership)
                    {
                        //Set paymentIDInput
                        paymentIDInput = nextPaymentID;

                        //Increase max Payment ID for payment
                        nextPaymentID++;

                        //Assign payment with bookingID
                        lstPayments[posInPaymentsList] = new Payment(paymentIDInput, memberIDInput, bookingIDInput, paymentMethodIDInput, amountToPayInput);
                    }
                    else
                    {
                        //Set paymentIDInput
                        paymentIDInput = nextPaymentID;

                        //Increase max Payment ID for payment
                        nextPaymentID++;

                        //Assign payment without bookingID
                        lstPayments[posInPaymentsList] = new Payment(paymentIDInput, memberIDInput, paymentMethodIDInput, amountToPayInput);

                    }//End If

                    //Add to the database
                    payTable.AddNewPayment(lstPayments[posInPaymentsList]);

                    //refresh Lists
                    refreshPaymentList(); 

                    //Display class details
                    displayPaymentDetails(lstPayments[posInPaymentsList]);

                    //Enable all the buttons again
                    disableOrEnableAllPaymentButtons(true);

                    //disable the three detail groupboxes, the AddSubit Button and the editMode Marker
                    grp_PaymentsTabAccountDetails.Enabled = false;
                    grp_PaymentMethodDetails.Enabled = false;
                    btn_PaymentTabAddSubmit.Enabled = false;
                    editMode = false;

                    //Refresh data source and re-set-up the booking and Payment method ID comboboxes
                    refreshPaymentDataGrid();
                    setUpPaymentTab();

                    //Inform user that the member has been added
                    informUser("Payment made successfully", "Payment Successful");
                    
                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
            

        }//End btn_PaymentTabAddSubmit_Click


        private void btn_PaymentTabDeletePayment_Click(object sender, EventArgs e)
        {
            try
            {
                //delete payment
                deletePayment();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            

        }//End btn_PaymentTabDeletePayment_Click


        private void btn_PaymentTabEditPayment_Click(object sender, EventArgs e)
        {
            try
            {
                //Enable the groupboxes that need to be edited and the editMode marker
                grp_PaymentsTabAccountDetails.Enabled = true;
                grp_PaymentMethodDetails.Enabled = true;
                editMode = true;

                //Enable the edit submit button
                btn_PaymentTabEditSubmit.Enabled = true;

                //Disable the rest of the controls
                disableOrEnableAllPaymentButtons(false);
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            

        }//End btn_PaymentTabEditPayment_Click


        private void btn_PaymentTabEditSubmit_Click(object sender, EventArgs e)
        {
            //Declare variables
            Payment updatedPayment = lstPayments[posInPaymentsList];
            bool ifAllValid = true;

            try
            {
                //Validate and Assign the appropriate values to their variables
                validatePayment(ref ifAllValid);

                //If all entries were valid
                if (ifAllValid)
                {
                    //If it is a booking payment
                    if (!isMembership)
                    {
                        //Update with booking ID
                        updatedPayment.BookingID = memberIDInput;
                        updatedPayment.BookingID = bookingIDInput;
                        updatedPayment.PaymentMethodID = paymentMethodIDInput;
                        updatedPayment.AmountPaid = amountToPayInput;
                    }
                    else
                    {
                        //Update without booking ID
                        updatedPayment.BookingID = memberIDInput;
                        updatedPayment.PaymentMethodID = paymentMethodIDInput;
                        updatedPayment.AmountPaid = amountToPayInput;

                    }//End If

                    //Display class details
                    displayPaymentDetails(lstPayments[posInPaymentsList]);

                    //Enable all the buttons again
                    disableOrEnableAllPaymentButtons(true);

                    //disable the three detail groupboxes, the AddSubit Button and the edit mode marker
                    grp_PaymentsTabAccountDetails.Enabled = false;
                    grp_PaymentMethodDetails.Enabled = false;
                    btn_PaymentTabEditSubmit.Enabled = false;
                    editMode = false;

                    //Update the database
                    payTable.UpdatePaymentDatabase(updatedPayment);

                    //refresh Lists
                    refreshPaymentList(); 

                    //Refresh data source
                    refreshPaymentDataGrid();

                    //Inform user that the member has been added
                    informUser("Payment updated successfully", "Update Successful");
                    

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
            
        }//End btn_PaymentTabEditSubmit_Click


        private void btn_PaymentTabSort_Click(object sender, EventArgs e)
        {
            try
            {
                //Sort List
                sortPayments();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            

        }//End btn_PaymentTabSort_Click


        private void btn_PaymentTabShowFullList_Click(object sender, EventArgs e)
        {
            try
            {
                //Re-Order to show standard form
                lstPayments = lstPayments.OrderBy(Payment => Payment.PaymentID).ToList();

                //Refresh the data source
                refreshPaymentDataGrid();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            

        }//End btn_PaymentTabShowFullList_Click


        private void btn_PaymentTabSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //Search List
                searchForPayment();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
        }//End btn_PaymentTabSearch_Click


        private void btn_PaymentTabNewPaymentMethod_Click(object sender, EventArgs e)
        {
            try
            {
                //Open the payment method form
                frm_PaymentMethod frm_NewPaymentMethod = new frm_PaymentMethod(lstMembers, lstPayments, payMethTable, payDetTable, lstPaymentMethods, lstPaymentDetails);

                //Show new form 
                frm_NewPaymentMethod.Show();

                //Close main form
                this.Hide();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
        }//End btn_PaymentTabNewPaymentMethod_Click


        private void cmb_PaymentTabMemberID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Declare variables
            bool bookingFound = false;
            bool paymentMethodFound = false;

            //assign member pos to a variable for ease of use
            int memberPosInList = cmb_PaymentTabMemberID.SelectedIndex;

            try
            {
                //Assign the values onto the screen
                txt_PaymentTabFirstName.Text = lstMembers[memberPosInList].FirstName;
                txt_PaymentTabSurname.Text = lstMembers[memberPosInList].Surname;
                dtp_PaymentTabDOB.Value = lstMembers[memberPosInList].DOB;
                mst_PaymentTabTelNo.Text = lstMembers[memberPosInList].TelNo;
                txt_PaymentTabEmail.Text = lstMembers[memberPosInList].Email;

                //Nullify the payment method controls
                cmb_PaymentTabPaymentMethodID.Text = "";
                txt_PaymentTabCardNumber.Text = "";
                txt_PaymentTabCardType.Text = "";
                mst_PaymentTabExpiryDate.Text = "";

                //ID customisation
                //If the ID is being changed due to scrolling through, do nothing, otherwise customise the IDs
                if (editMode)
                {

                    //Check if the payment will be a membership payment or a booking
                    if (isMembership)
                    {
                        //It is a membership payment therefore find the membership cost
                        int membershipOfCurrent = lstMembers[memberPosInList].MembershipTypeID;

                        //Set the input Variable
                        amountToPayInput = lstMemberships[membershipOfCurrent].MembershipCost;

                        //Assign to screen
                        txt_PaymentTabAmountToPay.Text = amountToPayInput.ToString("C2");

                    }
                    else
                    {
                        //--------------- Setting up the Booking IDs ---------------\\
                        //Clear Combobox
                        cmb_PaymentTabBookingID.Items.Clear();
                        cmb_PaymentTabBookingID.Text = "";


                        //Adjust the bookingIDs so that only the customer's bookings are displayed
                        foreach (Booking booking in lstBookings)
                        {
                            //If the currently selected member has made this booking
                            if (booking.MemberID.ToString() == cmb_PaymentTabMemberID.SelectedItem.ToString())
                            {
                                //Assign it to the combobox
                                cmb_PaymentTabBookingID.Items.Add(booking.BookingID);

                                //Adjust variable
                                bookingFound = true;

                            }//End If

                        }//End foreach


                        //If there was no bookings inform user
                        if (!bookingFound)
                        {
                            errorToUser("No bookings found for the specified member", "No bookings found");

                        }//End If

                    }//End If

                    //--------------- Setting up the Payment Method IDs ---------------\\

                    //Clear the combobox
                    cmb_PaymentTabPaymentMethodID.Items.Clear();

                    //Assign the MemberID
                    memberIDInput = (int)cmb_PaymentTabMemberID.SelectedItem;

                    //Foreach payment method
                    foreach (PaymentMethod paymentMethod in lstPaymentMethods)
                    {
                        //If they share the same member ID
                        if (memberIDInput == paymentMethod.MemberID)
                        {
                            //Assign to the combobox
                            cmb_PaymentTabPaymentMethodID.Items.Add(paymentMethod.PaymentMethodID);

                            //Mark at least one method found
                            paymentMethodFound = true;

                        }//End If

                    }//End Foreach


                    //if none were found
                    if (!paymentMethodFound)
                    {
                        errorToUser("No payment methods found for the specified member", "No payment methods found");

                    }//End If

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End cmb_PaymentTabMemberID_SelectedIndexChanged


        private void cmb_PaymentTabBookingID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //assign booking ID to a variable for ease of use
                bookingIDInput = (int)cmb_PaymentTabBookingID.SelectedItem;

                //assign price that is to be charged
                amountToPayInput = lstBookings.Find(booking => booking.BookingID.Equals(bookingIDInput)).AmountCharged;

                //assign to screen
                txt_PaymentTabAmountToPay.Text = amountToPayInput.ToString("C2");
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
        }//End cmb_PaymentTabBookingID_SelectedIndexChanged


        private void chb_PaymentTabCashOrCard_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //Check if checked or not
                if (chb_PaymentTabCardUsed.Checked)
                {
                    //Enable the relevant boxes
                    cmb_PaymentTabPaymentMethodID.Enabled = true;

                }
                else
                {
                    //Disable the boxes
                    cmb_PaymentTabPaymentMethodID.Enabled = false;

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
        }//End chb_PaymentTabCashOrCard_CheckedChanged


        private void cmb_PaymentTabPaymentMethodID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Declare Variables
            int posInPaymentMethodList = 0;

            try
            {
                //assign selected payment method
                paymentMethodIDInput = (int)cmb_PaymentTabPaymentMethodID.SelectedItem;

                //Find the position of the payment Method in the main list
                foreach (PaymentMethod paymentMethod in lstPaymentMethods)
                {
                    if (paymentMethod.PaymentMethodID == paymentMethodIDInput)
                    {
                        //Break out of foreach
                        break;
                    }
                    else
                    {
                        //increase position in list
                        posInPaymentMethodList++;

                    }//End If

                }//End Foreach

                //Find and Assign the details of the payment method
                PaymentDetails selectedDetails = lstPaymentDetails.Find(details => details.PaymentDetailsID.Equals(lstPaymentMethods[posInPaymentMethodList].PaymentDetailsID));
                
                //For Security Reasons star out all but the last 4 digits of the Card Number
                string cardNumberToShow = "**** **** **** " + selectedDetails.CardNumber.Substring(11, 4);

                //Display details on screen
                txt_PaymentTabCardType.Text = selectedDetails.CardType;
                txt_PaymentTabCardNumber.Text = cardNumberToShow;
                mst_PaymentTabExpiryDate.Text = selectedDetails.ExpiryDate;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }            

        }//End cmb_PaymentTabPaymentMethodID_SelectedIndexChanged


        private void cmb_PaymentTabSortOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Assign Index
                selectedIndexFieldForSort = cmb_PaymentTabSortOptions.SelectedIndex;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
        }//End cmb_PaymentTabSortOptions_SelectedIndexChanged


        private void cmb_PaymentTabAscendOrDescend_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Assign Index
                selectedAscendOrDescend = cmb_PaymentTabAscendOrDescend.SelectedIndex;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
        }//End cmb_PaymentTabAscendOrDescend_SelectedIndexChanged


        private void cmb_PaymentTabSearchField_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Assign Index
                selectedSearchField = cmb_PaymentTabSearchField.SelectedIndex;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
        }//End cmb_PaymentTabSearchTerm_SelectedIndexChanged
        

        //--------------------------- Room Tab ---------------------------\\
        
        private void btn_RoomTabFirstRoom_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstRooms.Count >= 1)
                {
                    //The list is populated and should go to position 0
                    posInRoomsList = 0;

                    //Retrieve member at position
                    currentlySelectedRoom = lstRooms[posInRoomsList];

                    //Display details
                    displayRoomDetails(currentlySelectedRoom);

                }
                else
                {
                    //Inform user there are no members in list
                    errorToUser("No Rooms exist.", "List Error");

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            } 
        }//End btn_RoomTabFirstRoom_Click


        private void btn_RoomTabPreviousRoom_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstRooms.Count >= 1)
                {
                    //check it is not at the start of the list
                    if (posInRoomsList != 0)
                    {
                        //The list is populated and should go to the previous position
                        posInRoomsList--;

                        //Retrieve member at position
                        currentlySelectedRoom = lstRooms[posInRoomsList];

                        //Display details
                        displayRoomDetails(currentlySelectedRoom);

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
                    errorToUser("No Rooms exist.", "List Error");

                }//End If

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            } 
        }//End btn_RoomTabPreviousRoom_Click


        private void btn_RoomTabNextRoom_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstRooms.Count >= 1)
                {
                    //check it is not at the end of the list
                    if (posInRoomsList != lstRooms.Count - 1)
                    {
                        //The list is populated and should go to the next position
                        posInRoomsList++;

                        //Retrieve member at position
                        currentlySelectedRoom = lstRooms[posInRoomsList];

                        //Display details
                        displayRoomDetails(currentlySelectedRoom);

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
                    errorToUser("No Rooms exist.", "List Error");

                }//End If

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            } 
        }//End btn_RoomTabNextRoom_Click


        private void btn_RoomTabLastRoom_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstRooms.Count >= 1)
                {
                    //The list is populated and should go to position 0
                    posInRoomsList = lstRooms.Count - 1;

                    //Retrieve member at position
                    currentlySelectedRoom = lstRooms[posInRoomsList];

                    //Display details
                    displayRoomDetails(currentlySelectedRoom);

                }
                else
                {
                    //Inform user there are no members in list
                    errorToUser("No Rooms exist.", "List Error");

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            } 
        }//End btn_RoomTabLastRoom_Click


        private void btn_RoomTabAddRoom_Click(object sender, EventArgs e)
        {
            try
            {
                addRoom();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
        }//End btn_RoomTabAddRoom_Click


        private void btn_RoomTabAddSubmit_Click(object sender, EventArgs e)
        {
            //Declare Variables
            bool ifAllValid = true;

            try
            {
                validateRoom(ref ifAllValid);

                //If all of the inputs have been valid
                if (ifAllValid)
                {
                    //Assign the ID
                    roomIDInput = nextRoomID;

                    //Increase max exerciseClassID for next exercise class
                    nextRoomID++;

                    //Assign booking
                    lstRooms[posInRoomsList] = new Room(roomIDInput, roomDescriptionInput, roomLocationInput, roomCapacityInput, hourlyHireCostInput, roomAvailableForUseInput);

                    //Display class details
                    displayRoomDetails(lstRooms[posInRoomsList]);

                    //Enable all the buttons again
                    disableOrEnableAllRoomButtons(true);

                    //disable the three detail groupboxes and the AddSubit Button
                    grp_RoomTabRoomDetails.Enabled = false;
                    btn_RoomTabAddSubmit.Enabled = false;

                    //Add Room to database
                    roomTable.AddNewRoom(lstRooms[posInRoomsList]);

                    //refresh Lists
                    refreshRoomList();

                    //Refresh data source and set up room hire
                    refreshRoomDataGrid();
                    setUpRoomHireTab();

                    //Inform user that the member has been added
                    informUser("Room made successfully", "Room Creation Successful");

                }//End If 
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
                       
        }//End btn_RoomTabAddSubmit_Click


        private void btn_RoomTabDeleteRoom_Click(object sender, EventArgs e)
        {
            try
            {
                deleteRoom();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }            

        }//End btn_RoomTabDeleteRoom_Click


        private void btn_RoomTabEditRoom_Click(object sender, EventArgs e)
        {
            try
            {
                //activate the groupboxes that need to be edited
                grp_RoomTabRoomDetails.Enabled = true;

                //Enable Submit Button
                btn_RoomTabEditSubmit.Enabled = true;

                //Disable all of the other buttons
                disableOrEnableAllRoomButtons(false);

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_RoomTabEditRoom_Click


        private void btn_RoomTabEditSubmit_Click(object sender, EventArgs e)
        {
            //Declare Variables
            bool ifAllValid = true;

            try
            {
                validateRoom(ref ifAllValid);

                if (ifAllValid)
                {
                    //Assign booking to update
                    Room updatedRoom = lstRooms[posInRoomsList];

                    //Update details
                    updatedRoom.RoomDescription = roomDescriptionInput;
                    updatedRoom.RoomLocation = roomLocationInput;
                    updatedRoom.Capacity = roomCapacityInput;
                    updatedRoom.HourlyHireCost = hourlyHireCostInput;
                    updatedRoom.AvailableToUse = roomAvailableForUseInput;

                    //Reactivate the buttons
                    disableOrEnableAllRoomButtons(true);

                    //Disable the groupboxes that need to be edited
                    grp_RoomTabRoomDetails.Enabled = false;

                    //Disable Submit Button
                    btn_RoomTabEditSubmit.Enabled = false;

                    //Update the database
                    roomTable.UpdateRoomDatabase(updatedRoom);

                    //refresh Lists
                    refreshRoomList();

                    //Refresh data source and set up room hire
                    refreshRoomDataGrid();
                    setUpRoomHireTab();

                    //Inform user member has been updated
                    informUser("Update successful", "Successful Update");

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
        }//End btn_RoomTabEditSubmit_Click


        private void btn_RoomTabSort_Click(object sender, EventArgs e)
        {
            try
            {
                sortRooms();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }            

        }//End btn_RoomTabSort_Click


        private void btn_RoomTabShowFullList_Click(object sender, EventArgs e)
        {
            try
            {
                //Re-Order to show standard form
                lstRooms = lstRooms.OrderBy(Room => Room.RoomID).ToList();

                //Refresh
                refreshRoomDataGrid();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
        }//End btn_RoomTabShowFullList_Click


        private void btn_RoomTabSearch_Click(object sender, EventArgs e)
        {
            try
            {
                searchForRoom();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
        }//End btn_RoomTabSearch_Click


        private void cmb_RoomTabSortOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Assign Index
                selectedIndexFieldForSort = cmb_RoomTabSortOptions.SelectedIndex;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
        }//End cmb_RoomTabSortOptions_SelectedIndexChanged


        private void cmb_RoomTabAscendOrDescend_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Assign Index
                selectedAscendOrDescend = cmb_RoomTabAscendOrDescend.SelectedIndex;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
        }//End cmb_RoomTabAscendOrDescend_SelectedIndexChanged


        private void cmb_RoomTabSearchField_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Assign Index
                selectedSearchField = cmb_RoomTabSearchField.SelectedIndex;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
        }//End cmb_RoomTabSearchField_SelectedIndexChanged


        //--------------------------- Room Hire Tab ---------------------------\\

        private void btn_RoomHireTabFirstRoomHire_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstRoomHire.Count >= 1)
                {
                    //The list is populated and should go to position 0
                    posInRoomHireList = 0;

                    //Retrieve member at position
                    currentlySelectedRoomHire = lstRoomHire[posInRoomHireList];

                    //Display details
                    displayRoomHireDetails(currentlySelectedRoomHire);

                }
                else
                {
                    //Inform user there are no members in list
                    errorToUser("No Room Hire Records exist.", "List Error");

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            } 

        }//End btn_RoomHireTabFirstRoomHire_Click


        private void btn_RoomHireTabPreviousRoomHire_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstRoomHire.Count >= 1)
                {
                    //check it is not at the start of the list
                    if (posInRoomHireList != 0)
                    {
                        //The list is populated and should go to the previous position
                        posInRoomHireList--;

                        //Retrieve member at position
                        currentlySelectedRoomHire = lstRoomHire[posInRoomHireList];

                        //Display details
                        displayRoomHireDetails(currentlySelectedRoomHire);

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
                    errorToUser("No Room Hire Records exist.", "List Error");

                }//End If

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            } 

        }//End btn_RoomHireTabPreviousRoomHire_Click


        private void btn_RoomHireTabNextRoomHire_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstRoomHire.Count >= 1)
                {
                    //check it is not at the end of the list
                    if (posInRoomHireList != lstRoomHire.Count - 1)
                    {
                        //The list is populated and should go to the next position
                        posInRoomHireList++;

                        //Retrieve member at position
                        currentlySelectedRoomHire = lstRoomHire[posInRoomHireList];

                        //Display details
                        displayRoomHireDetails(currentlySelectedRoomHire);

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
                    errorToUser("No Room Hire Records exist.", "List Error");

                }//End If

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            } 
        }//End btn_RoomHireTabNextRoomHire_Click


        private void btn_RoomHireTabLastRoomHire_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstRoomHire.Count >= 1)
                {
                    //The list is populated and should go to position 0
                    posInRoomHireList = lstRoomHire.Count - 1;

                    //Retrieve member at position
                    currentlySelectedRoomHire = lstRoomHire[posInRoomHireList];

                    //Display details
                    displayRoomHireDetails(currentlySelectedRoomHire);

                }
                else
                {
                    //Inform user there are no members in list
                    errorToUser("No Room Hire Records exist.", "List Error");

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            } 

        }//End btn_RoomHireTabLastRoomHire_Click


        private void btn_RoomHireTabAddRoomHire_Click(object sender, EventArgs e)
        {
            try
            {
                addRoomHire();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }            

        }//End btn_RoomHireTabAddRoomHire_Click


        private void btn_RoomHireTabAddSubmit_Click(object sender, EventArgs e)
        {
            bool ifAllValid = true;

            try
            {
                validateRoomHire(ref ifAllValid);

                //If all inputs are valid
                if (ifAllValid)
                {
                    //Assign the ID
                    roomHireIDInput = nextRoomHireID;

                    //Increase for next room hire
                    roomHireIDInput++;

                    //Assign to the list
                    lstRoomHire[posInRoomHireList] = new RoomHire(roomHireIDInput, roomIDInput, externalCompanyIDInput, startDateInput, hireDurationInput, endDateInput, hoursPerWeek, monthlyHireCost, totalHireCost);

                    //Pass back to the database
                    roomHireTable.AddNewRoomHire(lstRoomHire[posInRoomHireList]);

                    //refresh Lists
                    refreshRoomHireList();

                    //Set min hire start date to today -60 years
                    dtp_RoomHireTabStartDate.MinDate = DateTime.Today.AddYears(-60);

                    //display hire record details
                    displayRoomHireDetails(lstRoomHire[posInRoomHireList]);

                    //enable the buttons
                    disableOrEnableAllRoomHireButtons(true);

                    //Disable the submit button and the groupboxes
                    btn_RoomHireTabAddSubmit.Enabled = false;
                    grp_RoomHireTabCompanyDetails.Enabled = false;
                    grp_RoomHireTabRoomDetails.Enabled = false;
                    grp_RoomHireTabRoomHireDetails.Enabled = false;

                    //Refresh data source
                    refreshRoomHireDataGrid();

                    //Inform user that the record has been made successfully
                    informUser("Room Hire Record made successfully", "Record Creation Successful");

                }//End If

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
        }//End btn_RoomHireTabAddSubmit_Click


        private void btn_RoomHireTabDeleteRoomHire_Click(object sender, EventArgs e)
        {
            try
            {
                deleteRoomHire();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_RoomHireTabDeleteRoomHire_Click


        private void btn_RoomHireTabEditRoomHire_Click(object sender, EventArgs e)
        {
            try
            {
                //activate the groupboxes that need to be edited
                grp_RoomHireTabRoomHireDetails.Enabled = true;
                grp_RoomHireTabRoomDetails.Enabled = true;
                grp_RoomHireTabCompanyDetails.Enabled = true;

                //Set min hire start date to today
                dtp_RoomHireTabStartDate.MinDate = DateTime.Today;

                //Enable Submit Button
                btn_RoomHireTabEditSubmit.Enabled = true;

                //Disable all of the other buttons
                disableOrEnableAllRoomHireButtons(false);

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_RoomHireTabEditRoomHire_Click


        private void btn_RoomHireTabEditSubmit_Click(object sender, EventArgs e)
        {
            bool ifAllValid = true;

            try
            {
                validateRoomHire(ref ifAllValid);

                if (ifAllValid)
                {
                    //Assign booking to update
                    RoomHire roomHireUpdating = lstRoomHire[posInRoomHireList];

                    //Update details
                    roomHireUpdating.ExternalCompanyID = externalCompanyIDInput;
                    roomHireUpdating.StartDate = startDateInput;
                    roomHireUpdating.HireDuration = hireDurationInput;
                    roomHireUpdating.EndDate = endDateInput;
                    roomHireUpdating.HoursPerWeek = hoursPerWeek;
                    roomHireUpdating.MonthlyHireCost = monthlyHireCost;
                    roomHireUpdating.TotalHireCost = totalHireCost;
                    
                    //Write Changes to the database
                    roomHireTable.UpdateRoomHireDatabase(roomHireUpdating);

                    //Set min hire start date to today -60 years
                    dtp_RoomHireTabStartDate.MinDate = DateTime.Today.AddYears(-60);

                    //Reactivate the buttons
                    disableOrEnableAllRoomHireButtons(true);

                    //Disable the edit submit and the group boxes
                    grp_RoomHireTabRoomHireDetails.Enabled = false;
                    grp_RoomHireTabRoomDetails.Enabled = false;
                    grp_RoomHireTabCompanyDetails.Enabled = false;
                    btn_RoomHireTabEditSubmit.Enabled = false;

                    //Refresh List
                    refreshRoomHireList();

                    //Refresh datasource
                    refreshRoomHireDataGrid();

                    //Inform user member has been updated
                    informUser("Update successful", "Successful Update");

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
        }//End btn_RoomHireTabEditSubmit_Click


        private void btn_RoomHireTabSort_Click(object sender, EventArgs e)
        {
            try
            {
                sortRoomHire();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
        }//End btn_RoomHireTabSort_Click


        private void btn_RoomHireTabShowFullList_Click(object sender, EventArgs e)
        {
            try
            {
                //Re-Order to show standard form
                lstRoomHire = lstRoomHire.OrderBy(RoomHire => RoomHire.RoomHireID).ToList();

                //Refresh
                refreshRoomHireDataGrid();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_RoomHireTabShowFullList_Click


        private void btn_RoomHireTabSearch_Click(object sender, EventArgs e)
        {
            try
            {
                searchForRoomHire();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_RoomHireTabSearch_Click


         private void dtp_RoomHireTabStartDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                //When the start date changes assign to the variable
                startDateInput = dtp_RoomHireTabStartDate.Value;

                //calculate the new end hire date
                calculateEndHiredate();

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
        }//End dtp_RoomHireTabStartDate_ValueChanged


        private void cmb_RoomHireTabHireDuration_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                calculateEndHiredate();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
        }//End cmb_RoomHireTabHireDuration_SelectedIndexChanged


        private void cmb_RoomHireTabRoomID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Declare Variables
            int selectedRoom = cmb_RoomHireTabRoomID.SelectedIndex;

            try
            {
                //Assign to a variable for ease of use
                Room currentlySelectedRoom = lstRooms[selectedRoom];

                //Assign to on screen controls
                txt_RoomHireTabDescription.Text = currentlySelectedRoom.RoomDescription;
                txt_RoomHireTabCapacity.Text = currentlySelectedRoom.Capacity.ToString();
                txt_RoomHireTabHourlyHireCost.Text = currentlySelectedRoom.HourlyHireCost.ToString("C2");

                //Calculate if possible
                calculateMonthlyAndTotalHireCosts();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
                        
        }//End cmb_RoomHireTabRoomID_SelectedIndexChanged


        private void cmb_RoomHireTabExternalCompanyID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ExternalCompany selectedCompany = lstExternalCompanies[cmb_RoomHireTabExternalCompanyID.SelectedIndex];

                txt_RoomHireTabCompanyName.Text = selectedCompany.CompanyName;
                txt_RoomHireTabCompanyPractice.Text = selectedCompany.CompanyPractice;
                txt_RoomHireTabContactName.Text = selectedCompany.ContactName;
                mst_RoomHireTabContactNo.Text = selectedCompany.ContactTelNo;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End cmb_RoomHireTabExternalCompanyID_SelectedIndexChanged


        private void cmb_RoomHireTabSortOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedIndexFieldForSort = cmb_RoomHireTabSearchFieldOptions.SelectedIndex;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End cmb_RoomHireTabSortOptions_SelectedIndexChanged


        private void cmb_RoomHireTabAscendOrDescend_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedAscendOrDescend = cmb_RoomHireTabAscendOrDescend.SelectedIndex;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End cmb_RoomHireTabAscendOrDescend_SelectedIndexChanged


        private void cmb_RoomHireTabSearchFieldOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedSearchField = cmb_RoomHireTabSearchFieldOptions.SelectedIndex;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End cmb_RoomHireTabSearchFieldOptions_SelectedIndexChanged


        private void nud_RoomHireTabHoursPerWeek_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                //Calculate the monthly and total hire cost for the room
                calculateMonthlyAndTotalHireCosts();

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End nud_RoomHireTabHoursPerWeek_ValueChanged


        private void calculateMonthlyAndTotalHireCosts()
        {
            try
            {
                //Check room, time period and hours per week has been chosen
                if (cmb_RoomHireTabRoomID.SelectedItem != null && cmb_RoomHireTabHireDuration.SelectedItem != null)
                {
                    //They have been therefore the calculation can continue
                    roomIDInput = (int)cmb_RoomHireTabRoomID.SelectedItem;
                    posInRoomsList = cmb_RoomHireTabRoomID.SelectedIndex;
                    hireDurationInput = Convert.ToInt32(cmb_RoomHireTabHireDuration.SelectedItem.ToString().Substring(0, 2).Trim());
                    hoursPerWeek = (int)nud_RoomHireTabHoursPerWeek.Value;

                    //Read in the hourly hire cost
                    hourlyHireCostInput = lstRooms[posInRoomsList].HourlyHireCost;

                    //Calculate the cost of a month
                    monthlyHireCost = hourlyHireCostInput * hoursPerWeek * 52m / 12;

                    //Multiply weekly cost by no of weeks
                    totalHireCost = hourlyHireCostInput * hoursPerWeek * hireDurationInput;

                    //display onscreen
                    txt_RoomHireTabHourlyHireCost.Text = hourlyHireCostInput.ToString("C2");
                    txt_RoomHireTabMonthlyHireCost.Text = monthlyHireCost.ToString("C2");
                    txt_RoomHireTabTotalHireCost.Text = totalHireCost.ToString("C2");

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
        }//End calculateMonthlyAndTotalHireCosts


        //--------------------------- External Company Tab ---------------------------\\

        private void btn_ExternalCompanyTabFirstCompany_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstExternalCompanies.Count >= 1)
                {
                    //The list is populated and should go to position 0
                    posInExternalCompanyList = 0;

                    //Retrieve member at position
                    currentlySelectedExternalCompany = lstExternalCompanies[posInExternalCompanyList];

                    //Display details
                    displayExternalCompanyDetails(currentlySelectedExternalCompany);

                }
                else
                {
                    //Inform user there are no members in list
                    errorToUser("No External Companies exist.", "List Error");

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            } 

        }//End btn_ExternalCompanyTabFirstCompany_Click


        private void btn_ExternalCompanyTabPreviousCompany_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstExternalCompanies.Count >= 1)
                {
                    //check it is not at the start of the list
                    if (posInExternalCompanyList != 0)
                    {
                        //The list is populated and should go to the previous position
                        posInExternalCompanyList--;

                        //Retrieve member at position
                        currentlySelectedExternalCompany = lstExternalCompanies[posInExternalCompanyList];

                        //Display details
                        displayExternalCompanyDetails(currentlySelectedExternalCompany);

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
                    errorToUser("No External Companies exist.", "List Error");

                }//End If

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            } 
        }//End btn_ExternalCompanyTabPreviousCompany_Click


        private void btn_ExternalCompanyTabNextCompany_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstExternalCompanies.Count >= 1)
                {
                    //check it is not at the end of the list
                    if (posInExternalCompanyList != lstExternalCompanies.Count - 1)
                    {
                        //The list is populated and should go to the next position
                        posInExternalCompanyList++;

                        //Retrieve member at position
                        currentlySelectedExternalCompany = lstExternalCompanies[posInExternalCompanyList];

                        //Display details
                        displayExternalCompanyDetails(currentlySelectedExternalCompany);

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
                    errorToUser("No External Companies exist.", "List Error");

                }//End If

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            } 
        }//End btn_ExternalCompanyTabNextCompany_Click


        private void btn_ExternalCompanyTabLastCompany_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstExternalCompanies.Count >= 1)
                {
                    //The list is populated and should go to position 0
                    posInExternalCompanyList = lstExternalCompanies.Count - 1;

                    //Retrieve member at position
                    currentlySelectedExternalCompany = lstExternalCompanies[posInExternalCompanyList];

                    //Display details
                    displayExternalCompanyDetails(currentlySelectedExternalCompany);

                }
                else
                {
                    //Inform user there are no members in list
                    errorToUser("No External Companies exist.", "List Error");

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            } 
        }//End btn_ExternalCompanyTabLastCompany_Click


        private void btn_ExternalCompanyTabAddCompany_Click(object sender, EventArgs e)
        {
            try
            {
                addExternalCompany();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_ExternalCompanyTabAddCompany_Click


        private void btn_ExternalCompanyTabAddSubmit_Click(object sender, EventArgs e)
        {
            bool ifAllValid = true;

            try
            {
                //Validate the entries
                validateExternalCompany(ref ifAllValid);

                if (ifAllValid)
                {
                    //Assign the ID
                    externalCompanyIDInput = nextExternalCompanyID;

                    //Increase for next room hire
                    nextExternalCompanyID++;

                    //Assign to the list
                    lstExternalCompanies[posInExternalCompanyList] = new ExternalCompany(externalCompanyIDInput, companyNameInput, companyAddressInput, companyTownInput, companyPostCodeInput, companyPracticeInput, contactNameInput, contactTelNoInput, contactEmailInput);

                    //Push to the SQL Database
                    extCompTable.AddNewExternalCompany(lstExternalCompanies[posInExternalCompanyList]);

                    //Refresh List
                    refreshExternalCompanyList();

                    //display hire record details
                    displayExternalCompanyDetails(lstExternalCompanies[posInExternalCompanyList]);

                    //enable the buttons
                    disableOrEnableAllExternalCompanyButtons(true);

                    //Disable the submit button and groupbox
                    btn_ExternalCompanyTabAddSubmit.Enabled = false;
                    grp_ExternalCompanyTabCompanyDetails.Enabled = false;

                    //Set up the exercise Class and room hire tabs
                    setUpClassTab();
                    setUpRoomHireTab();

                    //refresh the datasource
                    refreshExternalCompanyDataGrid();

                    //Inform user that the record has been made successfully
                    informUser("External Company made successfully", "Record Creation Successful");

                }//End If

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_ExternalCompanyTabAddSubmit_Click


        private void btn_ExternalCompanyTabDeleteCompany_Click(object sender, EventArgs e)
        {
            try
            {
                deleteExternalCompany();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_ExternalCompanyTabDeleteCompany_Click


        private void btn_ExternalCompanyTabEditCompany_Click(object sender, EventArgs e)
        {
            try
            {
                //activate the groupboxes that need to be edited
                grp_ExternalCompanyTabCompanyDetails.Enabled = true;

                //Enable Submit Button
                btn_ExternalCompanyTabEditSubmit.Enabled = true;

                //Disable all other buttons
                disableOrEnableAllExternalCompanyButtons(false);

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_ExternalCompanyTabEditCompany_Click


        private void btn_ExternalCompanyTabEditSubmit_Click(object sender, EventArgs e)
        {
            bool ifAllValid = true;

            try
            {
                validateExternalCompany(ref ifAllValid);

                if (ifAllValid)
                {
                    //Assign External to update
                    ExternalCompany externalCompanyUpdating = lstExternalCompanies[posInExternalCompanyList];

                    //Update details
                    externalCompanyUpdating.CompanyAddress = companyAddressInput;
                    externalCompanyUpdating.CompanyName = companyNameInput;
                    externalCompanyUpdating.CompanyPostCode = companyPostCodeInput;
                    externalCompanyUpdating.CompanyPractice = companyPracticeInput;
                    externalCompanyUpdating.CompanyTown = companyTownInput;
                    externalCompanyUpdating.ContactEmail = contactEmailInput;
                    externalCompanyUpdating.ContactName = contactNameInput;
                    externalCompanyUpdating.ContactTelNo = contactTelNoInput;
                    
                    //Push Update to the Database
                    extCompTable.UpdateExternalCompanyDatabase(externalCompanyUpdating);

                    //Reactivate the buttons
                    disableOrEnableAllExternalCompanyButtons(true);

                    //Disable the edit submit and the group boxes
                    grp_ExternalCompanyTabCompanyDetails.Enabled = false;
                    btn_ExternalCompanyTabEditSubmit.Enabled = false;

                    //Refresh List
                    refreshExternalCompanyList();

                    //Set up the exercise Class and room hire tabs
                    setUpClassTab();
                    setUpRoomHireTab();

                    //Refresh datasource
                    refreshExternalCompanyDataGrid();

                    //Inform user external company has been updated
                    informUser("Update successful", "Successful Update");

                }//End If
                
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_ExternalCompanyTabEditSubmit_Click


        private void btn_ExternalCompanyTabSort_Click(object sender, EventArgs e)
        {
            try
            {
                sortExternalCompanies();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_ExternalCompanyTabSort_Click


        private void btn_ExternalCompanyTabShowFullList_Click(object sender, EventArgs e)
        {
            try
            {
                refreshExternalCompanyDataGrid();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_ExternalCompanyTabShowFullList_Click


        private void btn_ExternalCompanyTabSearch_Click(object sender, EventArgs e)
        {
            try
            {
                searchForExternalCompany();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
        }//End btn_ExternalCompanyTabSearch_Click


        private void cmb_ExternalCompanyTabSortOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedIndexFieldForSort = cmb_ExternalCompanyTabSortOptions.SelectedIndex;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End cmb_ExternalCompanyTabSortOptions_SelectedIndexChanged


        private void cmb_ExternalCompanyTabAscendOrDescend_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedAscendOrDescend = cmb_ExternalCompanyTabAscendOrDescend.SelectedIndex;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End cmb_ExternalCompanyTabAscendOrDescend_SelectedIndexChanged


        private void cmb_ExternalCompanyTabSearchField_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedSearchField = cmb_ExternalCompanyTabSearchField.SelectedIndex;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End cmb_ExternalCompanyTabSearchField_SelectedIndexChanged


        //--------------------------- Employee Tab ---------------------------\\

        private void btn_EmployeeTabFirstEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstEmployees.Count >= 1)
                {
                    //The list is populated and should go to position 0
                    posInEmployeeList = 0;

                    //Retrieve Employee at position
                    currentlySelectedEmployee = lstEmployees[posInEmployeeList];

                    //Display details
                    displayEmployeeDetails(currentlySelectedEmployee);

                }
                else
                {
                    //Inform user there are no Employees in list
                    errorToUser("No Employee Records exist.", "List Error");

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            } 
        }//End btn_EmployeeTabFirstEmployee_Click


        private void btn_EmployeeTabPreviousEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstEmployees.Count >= 1)
                {
                    //check it is not at the start of the list
                    if (posInEmployeeList != 0)
                    {
                        //The list is populated and should go to the previous position
                        posInEmployeeList--;

                        //Retrieve Employee at position
                        currentlySelectedEmployee = lstEmployees[posInEmployeeList];

                        //Display details
                        displayEmployeeDetails(currentlySelectedEmployee);

                    }
                    else
                    {
                        //Inform user they are at the end of the list
                        informUser("You are at the start of the list", "Start of list");

                    }//End If

                }
                else
                {
                    //Inform user there are no Employees in list
                    errorToUser("No Employee Records exist.", "List Error");

                }//End If

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            } 
        }//End btn_EmployeeTabPreviousEmployee_Click


        private void btn_EmployeeTabNextEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstEmployees.Count >= 1)
                {
                    //check it is not at the end of the list
                    if (posInEmployeeList != lstEmployees.Count - 1)
                    {
                        //The list is populated and should go to the next position
                        posInEmployeeList++;

                        //Retrieve Employee at position
                        currentlySelectedEmployee = lstEmployees[posInEmployeeList];

                        //Display details
                        displayEmployeeDetails(currentlySelectedEmployee);

                    }
                    else
                    {
                        //Inform user they are at the end of the list
                        informUser("You are at the end of the list", "End of list");

                    }//End If

                }
                else
                {
                    //Inform user there are no Employees in list
                    errorToUser("No Employee Records exist.", "List Error");

                }//End If

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            } 
        }//End btn_EmployeeTabNextEmployee_Click


        private void btn_EmployeeTabLastEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if the list is populated
                if (lstEmployees.Count >= 1)
                {
                    //The list is populated and should go to position 0
                    posInEmployeeList = lstEmployees.Count - 1;

                    //Retrieve member at position
                    currentlySelectedEmployee = lstEmployees[posInEmployeeList];

                    //Display details
                    displayEmployeeDetails(currentlySelectedEmployee);

                }
                else
                {
                    //Inform user there are no Employees in list
                    errorToUser("No Employee Records exist.", "List Error");

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            } 
        }//End btn_EmployeeTabLastEmployee_Click


        private void btn_EmployeeTabAddEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                addEmployee();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_EmployeeTabAddEmployee_Click


        private void btn_EmployeeTabAddSubmit_Click(object sender, EventArgs e)
        {
            //declare variables
            bool ifAllValid = true;

            try
            {
                //Validate the inputs
                validateEmployee(ref ifAllValid);

                //If valid input
                if (ifAllValid)
                {
                    //Assign the ID
                    employeeIDInput = nextEmployeeID;

                    //Increase for next room hire
                    nextEmployeeID++;
                                        
                    //Assign info to list
                    lstEmployees[posInEmployeeList] = new Employee(employeeIDInput, titleInput, surnameInput, firstNameInput, dateOfBirthInput, addressInput, townInput, postCodeInput, telNoInput, emailInput, nationalInsuranceNumberInput, contractTypeInput);

                    //Re-enable all of the buttons again
                    disableOrEnableAllEmployeeButtons(true);

                    //Disable Submit Button
                    btn_EmployeeTabAddSubmit.Enabled = false;

                    //Disable the group box again
                    grp_EmployeeTabEmployeeDetails.Enabled = false;
                    grp_EmployeeTabPersonalDetails.Enabled = false;

                    //Add to the database
                    employeeTable.AddNewEmployee(lstEmployees[posInEmployeeList]);

                    //Set date time picker min date
                    dtp_EmployeeTabDOB.MinDate = DateTime.Today.AddYears(-100);

                    //Refresh List
                    refreshEmployeeList();

                    //Set up the exercise Class tab
                    setUpClassTab();

                    //refresh data source
                    refreshEmployeeDataGrid();

                    //Inform user that the employee has been added
                    informUser("Employee addition successful", "Addition Successful");

                }//End If

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_EmployeeTabAddSubmit_Click


        private void btn_EmployeeTabDeleteEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                deleteEmployee();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_EmployeeTabDeleteEmployee_Click


        private void btn_EmployeeTabEditEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                //Enable Submit Button and the groupbox
                btn_EmployeeTabEditSubmit.Enabled = true;
                grp_EmployeeTabEmployeeDetails.Enabled = true;
                grp_EmployeeTabPersonalDetails.Enabled = true;

                //disable all other buttons
                disableOrEnableAllEmployeeButtons(false);

                //Set date time picker max date
                dtp_EmployeeTabDOB.MaxDate = DateTime.Today.AddYears(-18);
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_EmployeeTabEditEmployee_Click


        private void btn_EmployeeTabEditSubmit_Click(object sender, EventArgs e)
        {
            //Declare variables
            bool ifAllValid = true;

            try
            {
                validateEmployee(ref ifAllValid);

                if (ifAllValid)
                {
                    //Assign employee to update
                    Employee employeeUpdating = lstEmployees[posInEmployeeList];

                    //Update details
                    employeeUpdating.Title = titleInput;
                    employeeUpdating.Surname = surnameInput;
                    employeeUpdating.FirstName = firstNameInput;
                    employeeUpdating.DOB = dateOfBirthInput;
                    employeeUpdating.Address = addressInput;
                    employeeUpdating.Town = townInput;
                    employeeUpdating.PostCode = postCodeInput;
                    employeeUpdating.TelNo = telNoInput;
                    employeeUpdating.Email = emailInput;
                    employeeUpdating.NationalInsuranceNumber = nationalInsuranceNumberInput;
                    employeeUpdating.ContractType = contractTypeInput;

                    //Reactivate the buttons
                    disableOrEnableAllEmployeeButtons(true);

                    //Disable the edit submit and the group box
                    btn_EmployeeTabEditSubmit.Enabled = false;
                    grp_EmployeeTabEmployeeDetails.Enabled = false;
                    grp_EmployeeTabPersonalDetails.Enabled = false;

                    //Update the database
                    employeeTable.UpdateEmployeeDatabase(employeeUpdating);

                    //Set date time picker Min date
                    dtp_EmployeeTabDOB.MinDate = DateTime.Today.AddYears(-100);

                    //Refresh List
                    refreshEmployeeList();

                    //Set up the exercise Class tab
                    setUpClassTab();

                    //Refresh datasource
                    refreshEmployeeDataGrid();

                    //Inform user employee has been updated
                    informUser("Update successful", "Successful Update");

                }//End If

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_EmployeeTabEditSubmit_Click


        private void btn_EmployeeTabSort_Click(object sender, EventArgs e)
        {
            try
            {
                sortEmployees();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_EmployeeTabSort_Click


        private void btn_EmployeeTabShowFullList_Click(object sender, EventArgs e)
        {
            try
            {
                refreshEmployeeDataGrid();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_EmployeeTabShowFullList_Click


        private void btn_EmployeeTabSearch_Click(object sender, EventArgs e)
        {
            try
            {
                searchForEmployee();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_EmployeeTabSearch_Click


        private void btn_EmployeeTabEditQualifications_Click(object sender, EventArgs e)
        {
            try
            {
                //Open the qualifications form
                frm_QualificationControl frm_EditQualifications = new frm_QualificationControl(staffQualTable, qualTable, lstStaffQualifications, lstQualifications, lstEmployees);

                //Show new form 
                frm_EditQualifications.Show();

                //Close main form
                this.Hide();

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }


        }//End btn_EmployeeTabEditQualifications_Click


        private void btn_EmployeeTabReport_Click(object sender, EventArgs e)
        {
            try
            {
                //Create an instance of the form
                //frm_EmployeeReport reportForm = new frm_EmployeeReport();

                //Show the form
                //reportForm.Show();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End btn_EmployeeTabReport_Click

        
        private void cmb_EmployeeTabSortOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedIndexFieldForSort = cmb_EmployeeTabSortOptions.SelectedIndex;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End cmb_EmployeeTabSortOptions_SelectedIndexChanged


        private void cmb_EmployeeTabAscendOrDescend_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedAscendOrDescend = cmb_EmployeeTabAscendOrDescend.SelectedIndex;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End cmb_EmployeeTabAscendOrDescend_SelectedIndexChanged


        private void cmb_EmployeeTabSearchField_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedSearchField = cmb_EmployeeTabSearchField.SelectedIndex;

                if (selectedSearchField == 8)
                {
                    //Set the search term mask
                    mst_EmployeeTabSearchTerm.Mask = ">LL00 0LL";
                }
                else if (selectedSearchField == 9)
                {
                    //Set the search term mask
                    mst_EmployeeTabSearchTerm.Mask = "00000000000";
                }
                else
                {
                    //Reset the mask
                    mst_EmployeeTabSearchTerm.Mask = "";

                }//End If

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End cmb_EmployeeTabSearchField_SelectedIndexChanged


        //--------------------------- Display Details ---------------------------\\

        private void displayFirstRecords()
        {
            try
            {
                //if there are any members show the first one
                if (lstMembers.Count > 0)
                {
                    displayMemberDetails(lstMembers[0]);
                }

                //if there are any classes show the first one
                if (lstExerciseClasses.Count > 0)
                {
                    displayClassDetails(lstExerciseClasses[0]);
                }

                //if there are any bookings show the first one
                if (lstBookings.Count > 0)
                {
                    displayBookingDetails(lstBookings[0]);
                }

                //if there are any Payments show the first one
                if (lstPayments.Count > 0)
                {
                    displayPaymentDetails(lstPayments[0]);
                }

                //if there are any Rooms show the first one
                if (lstRooms.Count > 0)
                {
                    displayRoomDetails(lstRooms[0]);
                }

                //if there are any Room Hire Records show the first one
                if (lstRoomHire.Count > 0)
                {
                    displayRoomHireDetails(lstRoomHire[0]);
                }

                //if there are any employees show the first one
                if (lstEmployees.Count > 0)
                {
                    displayEmployeeDetails(lstEmployees[0]);
                }

                //if there are any External Companies show the first one
                if (lstExternalCompanies.Count > 0)
                {
                    displayExternalCompanyDetails(lstExternalCompanies[0]);
                }

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
        }//End displayFirstRecords


        private void displayMemberDetails(Member currentMemberDisplayed)
        {
            try
            {
                //adjust on screen control objects to new member
                txt_MemberID.Text = currentMemberDisplayed.MemberID.ToString();
                cmb_MemberTabMembership.SelectedIndex = currentMemberDisplayed.MembershipTypeID - 1;
                cmb_Title.SelectedItem = currentMemberDisplayed.Title.ToString();
                txt_Surname.Text = currentMemberDisplayed.Surname.ToString();
                txt_FirstName.Text = currentMemberDisplayed.FirstName.ToString();
                dtp_DOB.Value = currentMemberDisplayed.DOB;
                txt_Address.Text = currentMemberDisplayed.Address.ToString();
                txt_Town.Text = currentMemberDisplayed.Town.ToString();
                mst_PostCode.Text = currentMemberDisplayed.PostCode.ToString();
                mst_TelNo.Text = currentMemberDisplayed.TelNo.ToString();
                txt_Email.Text = currentMemberDisplayed.Email.ToString();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End displayMemberDetails


        private void displayClassDetails(ExerciseClass exerciseClass)
        {
            try
            {
                //Assign class details the onscreen controls
                txt_ClassTabClassID.Text = exerciseClass.ExerciseClassID.ToString();
                cmb_ClassTabClassDescriptions.SelectedItem = exerciseClass.Description;
                cmb_ClassTabDifficultyLevels.SelectedItem = exerciseClass.Difficulty;
                dtp_ClassTabStartDateOfClass.Value = exerciseClass.StartDateOfClass;
                nud_ClassTabNumberOfWeeks.Value = exerciseClass.NoOfWeeks;
                dtp_ClassTabEndDateOfClass.Value = exerciseClass.EndDateOfClass;                
                txt_ClassTabCurrentNoOfParticipants.Text = exerciseClass.CurrentNumberOfParticipants.ToString();
                nud_ClassTabMaxNoOfParticipants.Value = exerciseClass.MaxNumberOfParticipants;
                cmb_ClassTabEmployeeID.SelectedItem = exerciseClass.EmployeeID;
                cmb_ClassTabRoomID.SelectedItem = exerciseClass.RoomID;
                chb_ClassTabExternalClass.Checked = exerciseClass.ExternalClass;
                nud_ClassTabWeeklyCostOfClass.Value = exerciseClass.WeeklyCostOfClass;
                txt_ClassTabTotalCostOfClass.Text = exerciseClass.TotalCostOfClass.ToString("C2");
                cmb_ClassTabExternalCompanyID.SelectedItem = exerciseClass.ExternalCompanyID;


                //To display sessions
                //foreach session
                foreach (Session session in lstSessions)
                {
                    //If they have the same Exercise Class ID then that is the correct class
                    if (session.ExerciseClassID == exerciseClass.ExerciseClassID)
                    {
                        //Display the details
                        displaySessionDetails(session);

                        //Then break as the session is found
                        break;

                    }//End If
                   
                }//End Foreach


            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
        }//End displayClassDetails


        private void displaySessionDetails(Session session)
        {
            try
            {
                //Assign Session Details to the onscreen controls
                cmb_ClassTabTimeOfClass.SelectedItem = session.StartTimeOfClass;
                nud_ClassTabLengthOfClass.Value = session.LengthOfClass;
                cmb_ClassTabTimeOfClass.SelectedItem = session.StartTimeOfClass;
                
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End displaySessionDetails


        private void displayBookingDetails(Booking currentlySelectedBooking)
        {
            try
            {
                //Assign the values to the onscreen controls
                txt_BookingsTabBookingID.Text = currentlySelectedBooking.BookingID.ToString();
                txt_BookingsTabEmployeeID.Text = currentlySelectedBooking.EmployeeID.ToString();
                cmb_BookingsTabMemberID.SelectedItem = currentlySelectedBooking.MemberID;
                cmb_BookingsTabExerciseClassID.SelectedItem = currentlySelectedBooking.ExerciseClassID;
                nud_BookingsTabNumberOfParticipantsBooking.Value = currentlySelectedBooking.NoOfPeopleBooking;                
                nud_BookingsTabCostOfBooking.Value = currentlySelectedBooking.AmountCharged;

                //Test to see if there is an exercise class ID
                if (currentlySelectedBooking.ExerciseClassID == 0)
                {
                    //Set to null
                    txt_BookingsTabCurrentNoOfParticipants.Text = "";
                    txt_BookingsTabMaxParticipants.Text = "";
                }
                else
                {
                    //Set onscreen controls to their values
                    txt_BookingsTabCurrentNoOfParticipants.Text = lstExerciseClasses.Find(exClass => exClass.ExerciseClassID.Equals(currentlySelectedBooking.ExerciseClassID)).CurrentNumberOfParticipants.ToString();
                    txt_BookingsTabMaxParticipants.Text = lstExerciseClasses.Find(exClass => exClass.ExerciseClassID.Equals(currentlySelectedBooking.ExerciseClassID)).MaxNumberOfParticipants.ToString();

                }//End If

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
        }//End displayBookingDetails


        private void displayPaymentDetails(Payment currentlySelectedPayment)
        {
            try
            {
                //Assign the values to the onscreen controls
                cmb_PaymentTabMemberID.SelectedItem = currentlySelectedPayment.MemberID;
                txt_PaymentTabPaymentID.Text = currentlySelectedPayment.PaymentID.ToString();                
                dtp_PaymentTabDateOfPayment.Value = currentlySelectedPayment.DateOfPayment;
                txt_PaymentTabAmountToPay.Text = currentlySelectedPayment.AmountPaid.ToString("C2");

                //If the booking ID is 0 there is no booking (i.e. it is for a membership)
                if (currentlySelectedPayment.BookingID == 0)
                {
                    //Clear text
                    cmb_PaymentTabBookingID.Text = "";

                    //Assign N/A to text
                    cmb_PaymentTabBookingID.Text = "N/A";
                }
                else
                {
                    //Clear text
                    cmb_PaymentTabBookingID.Text = "";

                    //Otherwise continue on and set both the selected item and the text as setting the item will not change the text as currently the value never changed
                    cmb_PaymentTabBookingID.Text = currentlySelectedPayment.BookingID.ToString();
                    cmb_PaymentTabBookingID.SelectedItem = currentlySelectedPayment.BookingID;

                }//End If


                //Check if they have used a card
                if (currentlySelectedPayment.PaymentMethodID != 0)
                {
                    //Set the check box to true
                    chb_PaymentTabCardUsed.Checked = true;

                    //Set the combobox to the ID
                    cmb_PaymentTabPaymentMethodID.SelectedItem = currentlySelectedPayment.PaymentMethodID;

                }
                else
                {
                    //Set the check box to false
                    chb_PaymentTabCardUsed.Checked = false;

                    //Set the text N/A
                    cmb_PaymentTabPaymentMethodID.Text = "N/A";

                }//End If

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End displayBookingDetails


        private void displayRoomDetails(Room currentlySelectedRoom)
        {
            try
            {
                //assign room details to onscreen controls
                txt_RoomTabRoomID.Text = currentlySelectedRoom.RoomID.ToString();
                cmb_RoomTabDescription.SelectedItem = currentlySelectedRoom.RoomDescription;
                cmb_RoomTabLocation.SelectedItem = currentlySelectedRoom.RoomLocation;
                nud_RoomTabCapacity.Value = currentlySelectedRoom.Capacity;
                nud_RoomTabHourlyHireCost.Value = currentlySelectedRoom.HourlyHireCost;
                chb_RoomTabAvailable.Checked = currentlySelectedRoom.AvailableToUse;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }            

        }//End displayRoomDetails


        private void displayRoomHireDetails(RoomHire currentlySelectedRoomHire)
        {
            try
            {
                //assign room details to onscreen controls
                txt_RoomHireTabRoomHireID.Text = currentlySelectedRoomHire.RoomHireID.ToString();
                dtp_RoomHireTabStartDate.Value = currentlySelectedRoomHire.StartDate;
                cmb_RoomHireTabHireDuration.SelectedItem = currentlySelectedRoomHire.HireDuration.ToString() + " Weeks";
                dtp_RoomHireTabEndDate.Value = currentlySelectedRoomHire.EndDate;
                nud_RoomHireTabHoursPerWeek.Value = currentlySelectedRoomHire.HoursPerWeek;
                txt_RoomHireTabMonthlyHireCost.Text = currentlySelectedRoomHire.MonthlyHireCost.ToString("C2");
                txt_RoomHireTabTotalHireCost.Text = currentlySelectedRoomHire.TotalHireCost.ToString("C2");
                cmb_RoomHireTabExternalCompanyID.SelectedItem = currentlySelectedRoomHire.ExternalCompanyID;
                cmb_RoomHireTabRoomID.SelectedItem = currentlySelectedRoomHire.RoomID;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            

        }//End displayRoomDetails


        private void displayExternalCompanyDetails(ExternalCompany currentlySelectedExternalCompany)
        {

            try
            {
                //Display details on screen
                txt_ExternalCompanyTabCompanyAddress.Text = currentlySelectedExternalCompany.CompanyAddress;
                txt_ExternalCompanyTabCompanyName.Text = currentlySelectedExternalCompany.CompanyName;
                cmb_ExternalCompanyTabCompanyPractice.SelectedItem = currentlySelectedExternalCompany.CompanyPractice;
                mst_ExternalCompanyTabCompanyPostCode.Text = currentlySelectedExternalCompany.CompanyPostCode;
                txt_ExternalCompanyTabCompanyTown.Text = currentlySelectedExternalCompany.CompanyTown;
                txt_ExternalCompanyTabContactEmail.Text = currentlySelectedExternalCompany.ContactEmail;
                txt_ExternalCompanyTabContactName.Text = currentlySelectedExternalCompany.ContactName;
                txt_ExternalCompanyTabExternalCompanyID.Text = currentlySelectedExternalCompany.ExternalCompanyID.ToString();
                mst_ExternalCompanyTabContactTelNo.Text = currentlySelectedExternalCompany.ContactTelNo;

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

            
        }//End displayExternalCompanyDetails


        private void displayEmployeeDetails(Employee currentEmployeeDisplayed)
        {
            try
            {
                //adjust on screen control objects to new member
                txt_EmployeeTabEmployeeID.Text = currentEmployeeDisplayed.EmployeeID.ToString();
                cmb_EmployeeTabTitle.SelectedItem = currentEmployeeDisplayed.Title.ToString();
                txt_EmployeeTabSurname.Text = currentEmployeeDisplayed.Surname.ToString();
                txt_EmployeeTabFirstName.Text = currentEmployeeDisplayed.FirstName.ToString();
                dtp_EmployeeTabDOB.Value = currentEmployeeDisplayed.DOB;
                txt_EmployeeTabAddress.Text = currentEmployeeDisplayed.Address.ToString();
                txt_EmployeeTabTown.Text = currentEmployeeDisplayed.Town.ToString();
                mst_EmployeeTabPostCode.Text = currentEmployeeDisplayed.PostCode.ToString();
                mst_EmployeeTabTelNo.Text = currentEmployeeDisplayed.TelNo.ToString();
                txt_EmployeeTabEmail.Text = currentEmployeeDisplayed.Email.ToString();
                mst_EmployeeTabNIN.Text = currentEmployeeDisplayed.NationalInsuranceNumber;
                cmb_EmployeeTabContractType.SelectedItem = currentEmployeeDisplayed.ContractType;

                //Clear the individual qualifications list
                lstIndividualQualifications.Clear();

                //To display the employee's qualifications find and add to the list
                loadIndividualQualifications(currentEmployeeDisplayed);

                //Set the data source of the data grid view
                dgv_QualificationsList.DataSource = "";
                dgv_QualificationsList.DataSource = lstIndividualQualifications;

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End displayEmployeeDetails


        //--------------------------- Disable Or Enable Buttons ---------------------------\\

        private void disableOrEnableAllMemberButtons(bool onOrOff)
        {
            try
            {
                //Disable/Enable all of the necessary controls
                btn_MemberTabAddMember.Enabled = onOrOff;
                btn_MemberTabDelete.Enabled = onOrOff;
                btn_MemberTabEdit.Enabled = onOrOff;
                btn_MemberTabFirstMember.Enabled = onOrOff;
                btn_MemberTabLastMember.Enabled = onOrOff;
                btn_MemberTabNextName.Enabled = onOrOff;
                btn_MemberTabPreviousName.Enabled = onOrOff;
                grp_MemberSearchSortOptions.Enabled = onOrOff;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }


        }//End disableOrEnableAllMemberButtons


        private void disableOrEnableAllExerciseClassButtons(bool onOrOff)
        {
            try
            {
                //Disable/Enable all of the necessary controls
                grp_ClassSearchAndSortOptions.Enabled = onOrOff;
                btn_ClassTabAddClass.Enabled = onOrOff;
                btn_ClassTabDeleteClass.Enabled = onOrOff;
                btn_ClassTabEditClass.Enabled = onOrOff;
                btn_ClassTabFirstClass.Enabled = onOrOff;
                btn_ClassTabLastClass.Enabled = onOrOff;
                btn_ClassTabNextClass.Enabled = onOrOff;
                btn_ClassTabPreviousClass.Enabled = onOrOff;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
        } //End disableOrEnableAllExerciseClassButtons


        private void disableOrEnableAllBookingButtons(bool onOrOff)
        {
            try
            {
                //Disable/Enable all of the necessary controls
                grp_BookingTabSearchAndSortOptions.Enabled = onOrOff;
                btn_BookingsTabAddBooking.Enabled = onOrOff;
                btn_BookingsTabDeleteBooking.Enabled = onOrOff;
                btn_BookingsTabEditBooking.Enabled = onOrOff;
                btn_BookingsTabFirstBooking.Enabled = onOrOff;
                btn_BookingsTabLastBooking.Enabled = onOrOff;
                btn_BookingsTabNextBooking.Enabled = onOrOff;
                btn_BookingsTabPreviousBooking.Enabled = onOrOff;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
        }//End disableOrEnableAllBookingButtons


        private void disableOrEnableAllPaymentButtons(bool onOrOff)
        {
            try
            {
                //Disable/Enable all of the necessary controls
                cmb_PaymentTabAscendOrDescend.Enabled = onOrOff;
                cmb_PaymentTabSortOptions.Enabled = onOrOff;
                cmb_PaymentTabSearchField.Enabled = onOrOff;
                mst_PaymentTabSearchTerm.Enabled = onOrOff;                
                btn_PaymentTabSearch.Enabled = onOrOff;
                btn_PaymentTabShowFullList.Enabled = onOrOff;
                btn_PaymentTabSort.Enabled = onOrOff;
                btn_PaymentTabAddPayment.Enabled = onOrOff;
                btn_PaymentTabDeletePayment.Enabled = onOrOff;
                btn_PaymentTabEditPayment.Enabled = onOrOff;
                btn_PaymentTabFirstPayment.Enabled = onOrOff;
                btn_PaymentTabLastPayment.Enabled = onOrOff;
                btn_PaymentTabNextPayment.Enabled = onOrOff;
                btn_PaymentTabPreviousPayment.Enabled = onOrOff;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
        }//End disableOrEnableAllPaymentButtons


        private void disableOrEnableAllRoomButtons(bool onOrOff)
        {
            try
            {
                //Disable/Enable all of the necessary controls
                grp_RoomTabSearchAndSortOptions.Enabled = onOrOff;
                btn_RoomTabAddRoom.Enabled = onOrOff;
                btn_RoomTabDeleteRoom.Enabled = onOrOff;
                btn_RoomTabEditRoom.Enabled = onOrOff;
                btn_RoomTabFirstRoom.Enabled = onOrOff;
                btn_RoomTabLastRoom.Enabled = onOrOff;
                btn_RoomTabNextRoom.Enabled = onOrOff;
                btn_RoomTabPreviousRoom.Enabled = onOrOff;

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
        }//End disableOrEnableAllRoomButtons


        private void disableOrEnableAllRoomHireButtons(bool onOrOff)
        {
            try
            {
                //Disable/Enable all of the necessary controls
                grp_RoomHireTabSearchAndSortOptions.Enabled = onOrOff;
                btn_RoomHireTabAddRoomHire.Enabled = onOrOff;
                btn_RoomHireTabDeleteRoomHire.Enabled = onOrOff;
                btn_RoomHireTabEditRoomHire.Enabled = onOrOff;
                btn_RoomHireTabFirstRoomHire.Enabled = onOrOff;
                btn_RoomHireTabLastRoomHire.Enabled = onOrOff;
                btn_RoomHireTabNextRoomHire.Enabled = onOrOff;
                btn_RoomHireTabPreviousRoomHire.Enabled = onOrOff;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
        }//End disableOrEnableAllRoomHireButtons


        private void disableOrEnableAllExternalCompanyButtons(bool onOrOff)
        {
            try
            {
                //Disable/Enable all of the necessary controls
                btn_ExternalCompanyTabAddCompany.Enabled = onOrOff;
                btn_ExternalCompanyTabDeleteCompany.Enabled = onOrOff;
                btn_ExternalCompanyTabEditCompany.Enabled = onOrOff;
                btn_ExternalCompanyTabFirstCompany.Enabled = onOrOff;
                btn_ExternalCompanyTabLastCompany.Enabled = onOrOff;
                btn_ExternalCompanyTabNextCompany.Enabled = onOrOff;
                btn_ExternalCompanyTabPreviousCompany.Enabled = onOrOff;
                grp_ExternalCompanyTabSearchAndSortOptions.Enabled = onOrOff;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }


        }//End disableOrEnableAllExternalCompanyButtons


        private void disableOrEnableAllEmployeeButtons(bool onOrOff)
        {
            try
            {
                //Disable/Enable all of the necessary controls
                btn_EmployeeTabAddEmployee.Enabled = onOrOff;
                btn_EmployeeTabDeleteEmployee.Enabled = onOrOff;
                btn_EmployeeTabEditEmployee.Enabled = onOrOff;
                btn_EmployeeTabFirstEmployee.Enabled = onOrOff;
                btn_EmployeeTabLastEmployee.Enabled = onOrOff;
                btn_EmployeeTabNextEmployee.Enabled = onOrOff;
                btn_EmployeeTabPreviousEmployee.Enabled = onOrOff;
                grp_EmployeeTabSearchAndSortOptions.Enabled = onOrOff;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }


        }//End disableOrEnableAllEmployeeButtons


        //------------------------------------ Refresh Data Sources ------------------------------------\\

        private void refreshMemberDataGrid()
        {
            try
            {
                //Refresh List from the database
                //lstMembers = memberTable.ReadMemberRecordFromTable();

                //refresh list
                dgv_MembersList.DataSource = "";
                dgv_MembersList.DataSource = lstMembers;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End refreshMemberDataGrid


        private void refreshMemberList()
        {
            try
            {
                //Create a new instance of the member table class
                memberTable = new MemberTable();

                //Readn in the new values and assign to the member list
                lstMembers = memberTable.ReadMemberRecordFromTable();

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End refreshMemberList


        private void refreshClassDataGrid()
        {
            try
            {
                //refresh list
                dgv_ExerciseClassList.DataSource = "";
                dgv_ExerciseClassList.DataSource = lstExerciseClasses;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End refreshClassDataGrid


        private void refreshExerciseClassList()
        {
            try
            {
                //Create a new instance of the ExerciseClass table class
                exClassTable = new ExerciseClassTable();

                //Readn in the new values and assign to the ExerciseClass list
                lstExerciseClasses = exClassTable.ReadExerciseClassRecordFromTable();

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End refreshExerciseClassList


        private void refreshSessionDataGrid()
        {
            try
            {
                //refresh list
                dgv_SessionList.DataSource = "";
                dgv_SessionList.DataSource = lstSessions;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End refreshSessionDataGrid


        private void refreshSessionList()
        {
            try
            {
                //Create a new instance of the Session table class
                sesTable = new SessionTable();

                //Read in the new values and assign to the Session list
                lstSessions = sesTable.ReadSessionRecordFromTable();

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End refreshSessionList


        private void refreshBookingDataGrid()
        {
            try
            {
                //refresh list
                dgv_BookingList.DataSource = "";
                dgv_BookingList.DataSource = lstBookings;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End refreshBookingDataGrid


        private void refreshBookingList()
        {
            try
            {
                //Create a new instance of the Booking table class
                bookingTable = new BookingTable();

                //Readn in the new values and assign to the Booking list
                lstBookings = bookingTable.ReadBookingRecordFromTable();

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End refreshBookingList


        private void refreshPaymentDataGrid()
        {
            try
            {
                //refresh list
                dgv_PaymentList.DataSource = "";
                dgv_PaymentList.DataSource = lstPayments;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End refreshPaymentDataGrid


        private void refreshPaymentList()
        {
            try
            {
                //Create a new instance of the Payment table class
                payTable = new PaymentTable();

                //Readn in the new values and assign to the Payment list
                lstPayments = payTable.ReadPaymentRecordFromTable();

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End refreshPaymentList


        private void refreshRoomDataGrid()
        {
            try
            {
                dgv_RoomList.DataSource = "";
                dgv_RoomList.DataSource = lstRooms;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
        }//End refreshRoomDataGrid


        private void refreshRoomList()
        {
            try
            {
                //Create a new instance of the Room table class
                roomTable = new RoomTable();

                //Readn in the new values and assign to the Room list
                lstRooms = roomTable.ReadRoomRecordFromTable();

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End refreshRoomList


        private void refreshRoomHireDataGrid()
        {
            try
            {
                dgv_RoomHireList.DataSource = "";
                dgv_RoomHireList.DataSource = lstRoomHire;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
        }//End refreshRoomHireDataGrid


        private void refreshRoomHireList()
        {
            try
            {
                //Create a new instance of the RoomHire table class
                roomHireTable = new RoomHireTable();

                //Readn in the new values and assign to the RoomHire list
                lstRoomHire = roomHireTable.ReadRoomHireRecordFromTable();

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End refreshRoomHireList


        private void refreshExternalCompanyDataGrid()
        {
            try
            {
                dgv_ExternalCompanyList.DataSource = "";
                dgv_ExternalCompanyList.DataSource = lstExternalCompanies;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End refreshExternalCompanyDataGrid


        private void refreshExternalCompanyList()
        {
            try
            {
                //Create a new instance of the ExternalCompany table class
                extCompTable = new ExternalCompanyTable();
                
                //Readn in the new values and assign to the ExternalCompany list
                lstExternalCompanies = extCompTable.ReadExternalCompanyRecordFromTable();

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End refreshExternalCompanyList


        private void refreshEmployeeDataGrid()
        {
            try
            {
                dgv_EmployeeList.DataSource = "";
                dgv_EmployeeList.DataSource = lstEmployees;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End refreshEmpllDataGrid


        private void refreshEmployeeList()
        {
            try
            {
                //Create a new instance of the Employee table class
                employeeTable = new EmployeeTable();

                //Readn in the new values and assign to the Employee list
                lstEmployees = employeeTable.ReadEmployeeRecordFromTable();

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End refreshEmployeeList

        

        //------------------------------------ Set Up Methods ------------------------------------\\

        private void tbc_PaymentTab_Click(object sender, EventArgs e)
        {
            try
            {
                //Re-set-up the payment tab
                setUpPaymentTab();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
        }//End tbc_PaymentTab_Click


        private void tab_RoomHireTab_Click(object sender, EventArgs e)
        {
            try
            {
                //Re-set-up the room hire tab
                setUpRoomHireTab();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
        }//End tab_RoomHireTab_Click


        private void setUpClassTab()
        {
            try
            {
                //set up the employee ID list for the exercise class
                if (lstEmployees.Count > 0)
                {
                    //Order the list
                    lstEmployees.OrderBy(employee => employee.EmployeeID);

                    //Clear the combobox
                    cmb_ClassTabEmployeeID.Items.Clear();

                    foreach (Employee employee in lstEmployees)
                    {
                        //Add to the combobox
                        cmb_ClassTabEmployeeID.Items.Add(employee.EmployeeID);

                    }//End Foreach

                }
                else
                {
                    //Inform user
                    errorToUser("There are no employees in the list", "Employees Missing");

                }//End If


                //set up the room ID list for the exercise class
                if (lstRooms.Count > 0)
                {
                    //Order the list
                    lstRooms.OrderBy(room => room.RoomID);

                    //Clear the combobox
                    cmb_ClassTabRoomID.Items.Clear();

                    foreach (Room room in lstRooms)
                    {
                        //Add to the combobox
                        cmb_ClassTabRoomID.Items.Add(room.RoomID);

                    }//End Foreach

                }
                else
                {
                    //Inform user
                    errorToUser("There are no rooms in the list", "Rooms Missing");

                }//End If


                //If There are any external companies show them and add to the combobox
                if (lstExternalCompanies.Count > 0)
                {
                    //Order the list
                    lstExternalCompanies.OrderBy(exCompany => exCompany.ExternalCompanyID);

                    //Clear the combobox
                    cmb_ClassTabExternalCompanyID.Items.Clear();

                    foreach (ExternalCompany extCompany in lstExternalCompanies)
                    {
                        //Add to the combobox
                        cmb_ClassTabExternalCompanyID.Items.Add(extCompany.ExternalCompanyID);

                    }//End Foreach
                }
                else
                {
                    //inform User
                    errorToUser("There are no companies in the list", "Companies Missing");

                }//End If



                //If There are any classes show them and add to the combobox
                if (lstExerciseClasses.Count > 0)
                {
                    //Display to screen
                    displayClassDetails(lstExerciseClasses[0]);

                }
                else
                {
                    //inform User
                    errorToUser("There are no classes in the list", "Classes Missing");

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
        }//End setUpClassTab


        private void setUpBookingTab()
        {
            try
            {
                //Add Members in to combo box
                if (lstMembers.Count > 0)
                {
                    //Order the list
                    lstMembers.OrderBy(member => member.MemberID);

                    //Clear the combobox
                    cmb_BookingsTabMemberID.Items.Clear();

                    foreach (Member member in lstMembers)
                    {                        
                        //Add ID to control
                        cmb_BookingsTabMemberID.Items.Add(member.MemberID);

                    }//End foreach

                }
                else
                {
                    //Show error
                    errorToUser("No members in list", "List error");

                }//End If


                //Add exercise classes to combo box
                if (lstExerciseClasses.Count > 0)
                {
                    //Order the list
                    lstExerciseClasses.OrderBy(exClass => exClass.ExerciseClassID);

                    //Clear the combobox
                    cmb_BookingsTabExerciseClassID.Items.Clear();

                    foreach (ExerciseClass exerciseClass in lstExerciseClasses)
                    {
                        //Add ID to control
                        cmb_BookingsTabExerciseClassID.Items.Add(exerciseClass.ExerciseClassID);

                    }//End foreach

                }
                else
                {
                    //Show error
                    errorToUser("No exercise classes in list", "List error");

                }//End If

                //Assing the date of booking
                dtp_BookingsTabDateOfBooking.Value = DateTime.Today;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
        }//End setUpBookingTab


        private void setUpPaymentTab()
        {
            try
            {
                //Add Members in to combo box
                if (lstMembers.Count > 0)
                {
                    //Order the list
                    lstMembers.OrderBy(member => member.MemberID);

                    //Clear the combobox
                    cmb_PaymentTabMemberID.Items.Clear();

                    foreach (Member member in lstMembers)
                    {
                        //Add ID to control
                        cmb_PaymentTabMemberID.Items.Add(member.MemberID);

                    }//End foreach

                }
                else
                {
                    //Show error
                    errorToUser("No members in list", "List error");

                }//End If


                //Add bookings to combo box
                if (lstBookings.Count > 0)
                {
                    //Order the list
                    lstBookings.OrderBy(booking => booking.BookingID);

                    //Clear the combobox
                    cmb_PaymentTabBookingID.Items.Clear();

                    foreach (Booking booking in lstBookings)
                    {
                        //Add ID to control
                        cmb_PaymentTabBookingID.Items.Add(booking.BookingID);

                    }//End foreach

                }
                else
                {
                    //Show error
                    errorToUser("No bookings in list", "List error");

                }//End If

                //Assign Payment methods to combobox
                if (lstPaymentMethods.Count > 0)
                {
                    //Order the list
                    lstPaymentMethods.OrderBy(payMethod => payMethod.PaymentMethodID);

                    //Clear the combobox
                    cmb_PaymentTabPaymentMethodID.Items.Clear();

                    foreach (PaymentMethod method in lstPaymentMethods)
                    {
                        //Add ID to control
                        cmb_PaymentTabPaymentMethodID.Items.Add(method.PaymentMethodID);

                    }//End Foreach

                }
                else
                {
                    //Show error
                    errorToUser("No payment methods in list", "List error");

                }//End If

                //Assing the date of payment
                dtp_PaymentTabDateOfPayment.Value = DateTime.Today;
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
        }//End setUpBookingTab


        private void setUpRoomHireTab()
        {
            try
            {
                //Add Rooms to combobox
                if (lstRooms.Count > 0)
                {
                    //Order the list
                    lstRooms.OrderBy(room => room.RoomID);

                    //Clear the combobox
                    cmb_RoomHireTabRoomID.Items.Clear();

                    foreach (Room room in lstRooms)
                    {
                        //Add to combobox control
                        cmb_RoomHireTabRoomID.Items.Add(room.RoomID);

                    }//End Foreach
                }
                else
                {
                    errorToUser("No Rooms In List", "List Error");

                }//End If


                //Add External Companies to combobox
                if (lstExternalCompanies.Count > 0)
                {
                    //Order the list
                    lstExternalCompanies.OrderBy(exCompany => exCompany.ExternalCompanyID);

                    //Clear the combobox
                    cmb_RoomHireTabExternalCompanyID.Items.Clear();

                    foreach (ExternalCompany externalCompany in lstExternalCompanies)
                    {
                        //Add to combobox control
                        cmb_RoomHireTabExternalCompanyID.Items.Add(externalCompany.ExternalCompanyID);

                    }//End Foreach
                }
                else
                {
                    errorToUser("No Companies In List", "List Error");

                }//End If
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
     
        }//End setUpRoomHireTab


        //------------------------------------ Search Result Methods ------------------------------------\\

        private void messageForMemberFound(bool memberFound, string fieldSearched, string searchTerm)
        {
            try
            {
                if (!memberFound)
                {
                    //Member not in list. Inform User
                    errorToUser("A member with the " + fieldSearched + ": " + searchTerm + " does not exist in this list", "Search Failed");

                }//End If
            }
            catch (Exception ex)
            {
                //print error message
                printErrorMessage(ex);
            }

        }//End messageForMemberFound


        private void messageForClassFound(bool classFound, string fieldSearched, string searchTerm)
        {
            try
            {
                if (!classFound)
                {
                    //Class not in list. Inform User
                    errorToUser(("An exercise class with the " + fieldSearched + ": " + searchTerm + " does not exist in this list"), "Search Failed");

                }//End If
            }
            catch (Exception ex)
            {
                //print error message
                printErrorMessage(ex);
            }

        }//End messageForClassFound


        private void messageForBookingFound(bool bookingFound, string fieldSearched, string searchTerm)
        {
            try
            {
                if (!bookingFound)
                {
                    //Booking not in list. Inform User
                    errorToUser(("A booking with the " + fieldSearched + ": " + searchTerm + " does not exist in this list"), "Search Failed");

                }//End If
            }
            catch (Exception ex)
            {
                //print error message
                printErrorMessage(ex);
            }

        }//End messageForBookingFound


        private void messageForPaymentFound(bool paymentFound, string fieldSearched, string searchTerm)
        {
            try
            {
                if (!paymentFound)
                {
                    //Payment not in list. Inform User
                    errorToUser(("A payment with the " + fieldSearched + ": " + searchTerm + " does not exist in this list"), "Search Failed");

                }//End If
            }
            catch (Exception ex)
            {
                //print error message
                printErrorMessage(ex);
            }

        }//End messageForPaymentFound


        private void messageForRoomFound(bool roomFound, string fieldSearched, string searchTerm)
        {
            try
            {
                if (!roomFound)
                {
                    //Room not in list. Inform User
                    errorToUser(("A room with the " + fieldSearched + ": " + searchTerm + " does not exist in this list"), "Search Failed");

                }//End If
            }
            catch (Exception ex)
            {
                //print error message
                printErrorMessage(ex);
            }

        }//End messageForRoomFound


        private void messageForRoomHireFound(bool roomHireFound, string fieldSearched, string searchTerm)
        {
            try
            {
                if (!roomHireFound)
                {
                    //Room Hire not in list. Inform User
                    errorToUser(("A room hire record with the " + fieldSearched + ": " + searchTerm + " does not exist in this list"), "Search Failed");

                }//End If
            }
            catch (Exception ex)
            {
                //print error message
                printErrorMessage(ex);
            }

        }//End messageForRoomHireFound


        private void messageForExternalCompanyFound(bool externalCompanyFound, string fieldSearched, string searchTerm)
        {
            try
            {
                if (!externalCompanyFound)
                {
                    //External Company not in list. Inform User
                    errorToUser(("An external company with the " + fieldSearched + ": " + searchTerm + " does not exist in this list"), "Search Failed");

                }//End If
            }
            catch (Exception ex)
            {
                //print error message
                printErrorMessage(ex);
            }

        }//End messageForExternalCompanyFound


        private void messageForEmployeeFound(bool employeeFound, string fieldSearched, string searchTerm)
        {
            try
            {
                if (!employeeFound)
                {
                    //Employee not in list. Inform User
                    errorToUser(("An employee with the " + fieldSearched + ": " + searchTerm + " does not exist in this list"), "Search Failed");

                }//End If
            }
            catch (Exception ex)
            {
                //print error message
                printErrorMessage(ex);
            }

        }//End messageForEmployeeFound
        
        //------------------------------------ Other ------------------------------------\\

        private void validateAStringWithOutNumbersOrSpecialCharacters(ref bool ifAllValid, string inputFromCmb, string fieldName, ref string inputVariable)
        {
            //Declare variables
            bool validInput = true;

            try
            {
                //Check all of the characters are letters
                foreach (char character in inputFromCmb)
                {
                    if (!char.IsLetter(character) && !char.IsWhiteSpace(character))
                    {
                        //Invalid Name Input
                        validInput = false;

                        //Break out of the loop
                        break;

                    }//End If

                }//End Foreach

                //If the input is valid
                if (validInput)
                {
                    //Write to the referenced variable
                    inputVariable = inputFromCmb.Trim();

                }
                else
                {
                    //mark invalid
                    ifAllValid = false;

                    //Inform user of error
                    errorToUser("The " + fieldName + " you entered was not valid.\nIt either contained numbers or special characters\nPlease Try Again", fieldName + " Entry Invalid");

                }//End If
                
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End validateAStringWithOutNumbersOrSpecialCharacters


        private void validateAStringWithOutSpecialCharacters(ref bool ifAllValid, string inputFromCmb, string fieldName, ref string inputVariable)
        {
            //Declare variables
            bool validInput = true;

            try
            {
                //Check all of the characters are letters or numbers
                foreach (char character in inputFromCmb)
                {
                    if (!char.IsLetterOrDigit(character) && !char.IsWhiteSpace(character))
                    {
                        //Invalid Name Input
                        validInput = false;

                        //Break out of the loop
                        break;

                    }//End If

                }//End Foreach


                //If the input is valid
                if (validInput)
                {
                    //Write to the referenced variable
                    inputVariable = inputFromCmb.Trim();

                }
                else
                {
                    //mark invalid
                    ifAllValid = false;

                    //Inform user of error
                    errorToUser("The " + fieldName + " you entered was not valid\nPlease Try Again", fieldName + " Entry Invalid");

                }//End If                

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End validateAStringWithOutSpecialCharacters


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


        private void calculateEndTimeOfClass()
        {
            try
            {
                //Read in the start time
                startTimeCalculationInput = (TimeSpan)cmb_ClassTabTimeOfClass.SelectedItem;

                //Read in the length of the class
                classLengthInput = (int)nud_ClassTabLengthOfClass.Value;

                //Calculate end time
                endTimeCalculationInput = startTimeCalculationInput.Add(new TimeSpan(0, Convert.ToInt32(classLengthInput), 0));

                //Assign the end time to the textbox
                txt_ClassTabEndTimeOfClass.Text = endTimeCalculationInput.ToString();

            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            

        }//End calculateEndTimeOfClass


        private void calculateEndHiredate()
        {
            try
            {
                if (cmb_RoomHireTabHireDuration.SelectedItem != null)
                {
                    //Read in the duration
                    string hireDurationStringInput = cmb_RoomHireTabHireDuration.SelectedItem.ToString().Substring(0, 2).Trim();

                    //Convert to the integer format to add the start date
                    hireDurationInput = Convert.ToInt32(hireDurationStringInput);

                    //Add to the start date - hire duration is the number of weeks therefore * 7 to find the number of days
                    endDateInput = startDateInput.AddDays(hireDurationInput * 7);

                    //Display to screen
                    dtp_RoomHireTabEndDate.Value = endDateInput;

                }//End If
                
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End calculateEndHiredate


        private void calculateEndDate()
        {
            try
            {
                //Read in the start date
                startDateInput = dtp_ClassTabStartDateOfClass.Value;

                //Calculate the number of days to add one less week as it starts that week
                int daysToAdd = (noOfWeeksInput - 1) * 7;

                //add the number of weeks to the value and assign
                endDateInput = dtp_ClassTabStartDateOfClass.Value.AddDays(daysToAdd);
                                
                //display onscreen
                dtp_ClassTabEndDateOfClass.Value = endDateInput;
               
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End calculateEndDate


        private void calculatePrice()
        {
            try
            {                
                //Calculate the total cost of the class
                //Read in the value for weekly cost
                weeklyCostOfClassInput = nud_ClassTabWeeklyCostOfClass.Value;

                //Calculate the cost of the class in total
                totalCostOfClassInput = weeklyCostOfClassInput * noOfWeeksInput;

                //display onscreen                
                txt_ClassTabTotalCostOfClass.Text = totalCostOfClassInput.ToString("C2");
                
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }

        }//End calculateEndDate


        private void loadIndividualQualifications(Employee currentEmployeeDisplayed)
        {
            try
            {
                //Clear the list before the assignation begins
                lstIndividualQualifications.Clear();

                foreach (StaffQualification staffQual in lstStaffQualifications)
                {
                    //If the EmployeeID match add to the list
                    if (staffQual.EmployeeID == currentEmployeeDisplayed.EmployeeID)
                    {
                        //Add to the lsit of individual qualifications
                        lstIndividualQualifications.Add(staffQual);

                    }//End If

                }//End Foreach
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
        }//End loadIndividualQualifications

        
    }//End of Class

}//End of namespace
