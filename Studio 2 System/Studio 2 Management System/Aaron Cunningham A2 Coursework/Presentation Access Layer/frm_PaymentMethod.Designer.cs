namespace Studio_2_Management_System.Presentation_Access_Layer
{
    partial class frm_PaymentMethod
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grp_AccountDetails = new System.Windows.Forms.GroupBox();
            this.dtp_DOB = new System.Windows.Forms.DateTimePicker();
            this.lbl_DOBTitle = new System.Windows.Forms.Label();
            this.txt_Address = new System.Windows.Forms.TextBox();
            this.txt_Town = new System.Windows.Forms.TextBox();
            this.txt_Surname = new System.Windows.Forms.TextBox();
            this.txt_FirstName = new System.Windows.Forms.TextBox();
            this.mst_PostCode = new System.Windows.Forms.MaskedTextBox();
            this.lbl_PostCodeTitle = new System.Windows.Forms.Label();
            this.lbl_TownTitle = new System.Windows.Forms.Label();
            this.lbl_AddressTitle = new System.Windows.Forms.Label();
            this.lbl_FirstNameTitle = new System.Windows.Forms.Label();
            this.lbl_SurnameTitle = new System.Windows.Forms.Label();
            this.cmb_MemberID = new System.Windows.Forms.ComboBox();
            this.lbl_MemberIDTitle = new System.Windows.Forms.Label();
            this.mst_ExpiryDate = new System.Windows.Forms.MaskedTextBox();
            this.mst_SecurityCode = new System.Windows.Forms.MaskedTextBox();
            this.lbl_SecurityCodeTitle = new System.Windows.Forms.Label();
            this.lbl_ExpiryDateTitle = new System.Windows.Forms.Label();
            this.lbl_CardNumberTitle = new System.Windows.Forms.Label();
            this.lbl_CardTypeTitle = new System.Windows.Forms.Label();
            this.lbl_PaymentMethodIDTitle = new System.Windows.Forms.Label();
            this.grp_UserButtons = new System.Windows.Forms.GroupBox();
            this.btn_EditSubmit = new System.Windows.Forms.Button();
            this.btn_EditPaymentMethod = new System.Windows.Forms.Button();
            this.btn_DeletePaymentMethod = new System.Windows.Forms.Button();
            this.btn_FirstPaymentMethod = new System.Windows.Forms.Button();
            this.btn_PreviousPaymentMethod = new System.Windows.Forms.Button();
            this.btn_NextPaymentMethod = new System.Windows.Forms.Button();
            this.btn_LastPaymentMethod = new System.Windows.Forms.Button();
            this.btn_AddPaymentMethod = new System.Windows.Forms.Button();
            this.btn_AddSubmit = new System.Windows.Forms.Button();
            this.cmb_CardType = new System.Windows.Forms.ComboBox();
            this.mst_CardNumber = new System.Windows.Forms.MaskedTextBox();
            this.grp_PaymentMethodDetails = new System.Windows.Forms.GroupBox();
            this.txt_PaymentMethodID = new System.Windows.Forms.TextBox();
            this.dgv_PaymentMethodList = new System.Windows.Forms.DataGridView();
            this.grp_SearchSortOptions = new System.Windows.Forms.GroupBox();
            this.btn_DisplayDetails = new System.Windows.Forms.Button();
            this.btn_DisplayMethods = new System.Windows.Forms.Button();
            this.btn_UpdateAndClose = new System.Windows.Forms.Button();
            this.cmb_SortOptions = new System.Windows.Forms.ComboBox();
            this.btn_FullList = new System.Windows.Forms.Button();
            this.btn_Search = new System.Windows.Forms.Button();
            this.mst_SearchTerm = new System.Windows.Forms.MaskedTextBox();
            this.cmb_AscendOrDescend = new System.Windows.Forms.ComboBox();
            this.lbl_SortTitle = new System.Windows.Forms.Label();
            this.lbl_SearchTitle = new System.Windows.Forms.Label();
            this.lbl_SearchTermTitle = new System.Windows.Forms.Label();
            this.btn_SubmitSort = new System.Windows.Forms.Button();
            this.cmb_SearchTermOptions = new System.Windows.Forms.ComboBox();
            this.grp_AccountDetails.SuspendLayout();
            this.grp_UserButtons.SuspendLayout();
            this.grp_PaymentMethodDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PaymentMethodList)).BeginInit();
            this.grp_SearchSortOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp_AccountDetails
            // 
            this.grp_AccountDetails.Controls.Add(this.dtp_DOB);
            this.grp_AccountDetails.Controls.Add(this.lbl_DOBTitle);
            this.grp_AccountDetails.Controls.Add(this.txt_Address);
            this.grp_AccountDetails.Controls.Add(this.txt_Town);
            this.grp_AccountDetails.Controls.Add(this.txt_Surname);
            this.grp_AccountDetails.Controls.Add(this.txt_FirstName);
            this.grp_AccountDetails.Controls.Add(this.mst_PostCode);
            this.grp_AccountDetails.Controls.Add(this.lbl_PostCodeTitle);
            this.grp_AccountDetails.Controls.Add(this.lbl_TownTitle);
            this.grp_AccountDetails.Controls.Add(this.lbl_AddressTitle);
            this.grp_AccountDetails.Controls.Add(this.lbl_FirstNameTitle);
            this.grp_AccountDetails.Controls.Add(this.lbl_SurnameTitle);
            this.grp_AccountDetails.Controls.Add(this.cmb_MemberID);
            this.grp_AccountDetails.Controls.Add(this.lbl_MemberIDTitle);
            this.grp_AccountDetails.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_AccountDetails.Location = new System.Drawing.Point(14, 12);
            this.grp_AccountDetails.Name = "grp_AccountDetails";
            this.grp_AccountDetails.Size = new System.Drawing.Size(282, 301);
            this.grp_AccountDetails.TabIndex = 116;
            this.grp_AccountDetails.TabStop = false;
            this.grp_AccountDetails.Text = "Account Details";
            // 
            // dtp_DOB
            // 
            this.dtp_DOB.Enabled = false;
            this.dtp_DOB.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_DOB.Location = new System.Drawing.Point(138, 143);
            this.dtp_DOB.MinDate = new System.DateTime(1920, 1, 1, 0, 0, 0, 0);
            this.dtp_DOB.Name = "dtp_DOB";
            this.dtp_DOB.Size = new System.Drawing.Size(125, 29);
            this.dtp_DOB.TabIndex = 132;
            // 
            // lbl_DOBTitle
            // 
            this.lbl_DOBTitle.AutoSize = true;
            this.lbl_DOBTitle.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DOBTitle.Location = new System.Drawing.Point(23, 146);
            this.lbl_DOBTitle.Name = "lbl_DOBTitle";
            this.lbl_DOBTitle.Size = new System.Drawing.Size(53, 21);
            this.lbl_DOBTitle.TabIndex = 139;
            this.lbl_DOBTitle.Text = "DOB:";
            // 
            // txt_Address
            // 
            this.txt_Address.Enabled = false;
            this.txt_Address.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Address.Location = new System.Drawing.Point(138, 180);
            this.txt_Address.Name = "txt_Address";
            this.txt_Address.Size = new System.Drawing.Size(125, 29);
            this.txt_Address.TabIndex = 134;
            // 
            // txt_Town
            // 
            this.txt_Town.Enabled = false;
            this.txt_Town.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Town.Location = new System.Drawing.Point(138, 217);
            this.txt_Town.Name = "txt_Town";
            this.txt_Town.Size = new System.Drawing.Size(125, 29);
            this.txt_Town.TabIndex = 136;
            // 
            // txt_Surname
            // 
            this.txt_Surname.Enabled = false;
            this.txt_Surname.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Surname.Location = new System.Drawing.Point(138, 69);
            this.txt_Surname.Name = "txt_Surname";
            this.txt_Surname.Size = new System.Drawing.Size(125, 29);
            this.txt_Surname.TabIndex = 129;
            // 
            // txt_FirstName
            // 
            this.txt_FirstName.Enabled = false;
            this.txt_FirstName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_FirstName.Location = new System.Drawing.Point(138, 106);
            this.txt_FirstName.Name = "txt_FirstName";
            this.txt_FirstName.Size = new System.Drawing.Size(125, 29);
            this.txt_FirstName.TabIndex = 130;
            // 
            // mst_PostCode
            // 
            this.mst_PostCode.Enabled = false;
            this.mst_PostCode.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mst_PostCode.Location = new System.Drawing.Point(138, 254);
            this.mst_PostCode.Mask = ">LL00 0LL";
            this.mst_PostCode.Name = "mst_PostCode";
            this.mst_PostCode.Size = new System.Drawing.Size(125, 29);
            this.mst_PostCode.TabIndex = 137;
            // 
            // lbl_PostCodeTitle
            // 
            this.lbl_PostCodeTitle.AutoSize = true;
            this.lbl_PostCodeTitle.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PostCodeTitle.Location = new System.Drawing.Point(23, 257);
            this.lbl_PostCodeTitle.Name = "lbl_PostCodeTitle";
            this.lbl_PostCodeTitle.Size = new System.Drawing.Size(94, 21);
            this.lbl_PostCodeTitle.TabIndex = 138;
            this.lbl_PostCodeTitle.Text = "Post Code:";
            // 
            // lbl_TownTitle
            // 
            this.lbl_TownTitle.AutoSize = true;
            this.lbl_TownTitle.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TownTitle.Location = new System.Drawing.Point(23, 220);
            this.lbl_TownTitle.Name = "lbl_TownTitle";
            this.lbl_TownTitle.Size = new System.Drawing.Size(57, 21);
            this.lbl_TownTitle.TabIndex = 135;
            this.lbl_TownTitle.Text = "Town:";
            // 
            // lbl_AddressTitle
            // 
            this.lbl_AddressTitle.AutoSize = true;
            this.lbl_AddressTitle.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_AddressTitle.Location = new System.Drawing.Point(23, 183);
            this.lbl_AddressTitle.Name = "lbl_AddressTitle";
            this.lbl_AddressTitle.Size = new System.Drawing.Size(77, 21);
            this.lbl_AddressTitle.TabIndex = 133;
            this.lbl_AddressTitle.Text = "Address:";
            // 
            // lbl_FirstNameTitle
            // 
            this.lbl_FirstNameTitle.AutoSize = true;
            this.lbl_FirstNameTitle.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FirstNameTitle.Location = new System.Drawing.Point(23, 109);
            this.lbl_FirstNameTitle.Name = "lbl_FirstNameTitle";
            this.lbl_FirstNameTitle.Size = new System.Drawing.Size(96, 21);
            this.lbl_FirstNameTitle.TabIndex = 131;
            this.lbl_FirstNameTitle.Text = "First Name:";
            // 
            // lbl_SurnameTitle
            // 
            this.lbl_SurnameTitle.AutoSize = true;
            this.lbl_SurnameTitle.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SurnameTitle.Location = new System.Drawing.Point(23, 72);
            this.lbl_SurnameTitle.Name = "lbl_SurnameTitle";
            this.lbl_SurnameTitle.Size = new System.Drawing.Size(79, 21);
            this.lbl_SurnameTitle.TabIndex = 128;
            this.lbl_SurnameTitle.Text = "Surname:";
            // 
            // cmb_MemberID
            // 
            this.cmb_MemberID.Enabled = false;
            this.cmb_MemberID.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_MemberID.FormattingEnabled = true;
            this.cmb_MemberID.Location = new System.Drawing.Point(138, 32);
            this.cmb_MemberID.Name = "cmb_MemberID";
            this.cmb_MemberID.Size = new System.Drawing.Size(125, 29);
            this.cmb_MemberID.TabIndex = 0;
            this.cmb_MemberID.SelectedIndexChanged += new System.EventHandler(this.cmb_MemberID_SelectedIndexChanged);
            // 
            // lbl_MemberIDTitle
            // 
            this.lbl_MemberIDTitle.AutoSize = true;
            this.lbl_MemberIDTitle.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MemberIDTitle.Location = new System.Drawing.Point(23, 35);
            this.lbl_MemberIDTitle.Name = "lbl_MemberIDTitle";
            this.lbl_MemberIDTitle.Size = new System.Drawing.Size(100, 21);
            this.lbl_MemberIDTitle.TabIndex = 126;
            this.lbl_MemberIDTitle.Text = "Member ID:";
            // 
            // mst_ExpiryDate
            // 
            this.mst_ExpiryDate.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mst_ExpiryDate.Location = new System.Drawing.Point(250, 197);
            this.mst_ExpiryDate.Mask = "00/00";
            this.mst_ExpiryDate.Name = "mst_ExpiryDate";
            this.mst_ExpiryDate.Size = new System.Drawing.Size(62, 29);
            this.mst_ExpiryDate.TabIndex = 2;
            // 
            // mst_SecurityCode
            // 
            this.mst_SecurityCode.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mst_SecurityCode.Location = new System.Drawing.Point(250, 252);
            this.mst_SecurityCode.Mask = "000";
            this.mst_SecurityCode.Name = "mst_SecurityCode";
            this.mst_SecurityCode.Size = new System.Drawing.Size(62, 29);
            this.mst_SecurityCode.TabIndex = 3;
            // 
            // lbl_SecurityCodeTitle
            // 
            this.lbl_SecurityCodeTitle.AutoSize = true;
            this.lbl_SecurityCodeTitle.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SecurityCodeTitle.Location = new System.Drawing.Point(17, 255);
            this.lbl_SecurityCodeTitle.Name = "lbl_SecurityCodeTitle";
            this.lbl_SecurityCodeTitle.Size = new System.Drawing.Size(121, 21);
            this.lbl_SecurityCodeTitle.TabIndex = 121;
            this.lbl_SecurityCodeTitle.Text = "Security Code:";
            // 
            // lbl_ExpiryDateTitle
            // 
            this.lbl_ExpiryDateTitle.AutoSize = true;
            this.lbl_ExpiryDateTitle.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ExpiryDateTitle.Location = new System.Drawing.Point(17, 200);
            this.lbl_ExpiryDateTitle.Name = "lbl_ExpiryDateTitle";
            this.lbl_ExpiryDateTitle.Size = new System.Drawing.Size(102, 21);
            this.lbl_ExpiryDateTitle.TabIndex = 120;
            this.lbl_ExpiryDateTitle.Text = "Expiry Date:";
            // 
            // lbl_CardNumberTitle
            // 
            this.lbl_CardNumberTitle.AutoSize = true;
            this.lbl_CardNumberTitle.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CardNumberTitle.Location = new System.Drawing.Point(17, 145);
            this.lbl_CardNumberTitle.Name = "lbl_CardNumberTitle";
            this.lbl_CardNumberTitle.Size = new System.Drawing.Size(116, 21);
            this.lbl_CardNumberTitle.TabIndex = 119;
            this.lbl_CardNumberTitle.Text = "Card Number:";
            // 
            // lbl_CardTypeTitle
            // 
            this.lbl_CardTypeTitle.AutoSize = true;
            this.lbl_CardTypeTitle.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CardTypeTitle.Location = new System.Drawing.Point(17, 90);
            this.lbl_CardTypeTitle.Name = "lbl_CardTypeTitle";
            this.lbl_CardTypeTitle.Size = new System.Drawing.Size(94, 21);
            this.lbl_CardTypeTitle.TabIndex = 118;
            this.lbl_CardTypeTitle.Text = "Card Type:";
            // 
            // lbl_PaymentMethodIDTitle
            // 
            this.lbl_PaymentMethodIDTitle.AutoSize = true;
            this.lbl_PaymentMethodIDTitle.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PaymentMethodIDTitle.Location = new System.Drawing.Point(16, 35);
            this.lbl_PaymentMethodIDTitle.Name = "lbl_PaymentMethodIDTitle";
            this.lbl_PaymentMethodIDTitle.Size = new System.Drawing.Size(165, 21);
            this.lbl_PaymentMethodIDTitle.TabIndex = 116;
            this.lbl_PaymentMethodIDTitle.Text = "Payment Method ID:";
            // 
            // grp_UserButtons
            // 
            this.grp_UserButtons.Controls.Add(this.btn_EditSubmit);
            this.grp_UserButtons.Controls.Add(this.btn_EditPaymentMethod);
            this.grp_UserButtons.Controls.Add(this.btn_DeletePaymentMethod);
            this.grp_UserButtons.Controls.Add(this.btn_FirstPaymentMethod);
            this.grp_UserButtons.Controls.Add(this.btn_PreviousPaymentMethod);
            this.grp_UserButtons.Controls.Add(this.btn_NextPaymentMethod);
            this.grp_UserButtons.Controls.Add(this.btn_LastPaymentMethod);
            this.grp_UserButtons.Controls.Add(this.btn_AddPaymentMethod);
            this.grp_UserButtons.Controls.Add(this.btn_AddSubmit);
            this.grp_UserButtons.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_UserButtons.Location = new System.Drawing.Point(14, 326);
            this.grp_UserButtons.Name = "grp_UserButtons";
            this.grp_UserButtons.Size = new System.Drawing.Size(282, 147);
            this.grp_UserButtons.TabIndex = 117;
            this.grp_UserButtons.TabStop = false;
            this.grp_UserButtons.Text = "User Buttons";
            // 
            // btn_EditSubmit
            // 
            this.btn_EditSubmit.Enabled = false;
            this.btn_EditSubmit.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_EditSubmit.Location = new System.Drawing.Point(189, 107);
            this.btn_EditSubmit.Name = "btn_EditSubmit";
            this.btn_EditSubmit.Size = new System.Drawing.Size(75, 32);
            this.btn_EditSubmit.TabIndex = 91;
            this.btn_EditSubmit.Text = "Submit";
            this.btn_EditSubmit.UseVisualStyleBackColor = true;
            this.btn_EditSubmit.Click += new System.EventHandler(this.btn_EditSubmit_Click);
            // 
            // btn_EditPaymentMethod
            // 
            this.btn_EditPaymentMethod.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_EditPaymentMethod.Location = new System.Drawing.Point(189, 69);
            this.btn_EditPaymentMethod.Name = "btn_EditPaymentMethod";
            this.btn_EditPaymentMethod.Size = new System.Drawing.Size(75, 32);
            this.btn_EditPaymentMethod.TabIndex = 91;
            this.btn_EditPaymentMethod.Text = "Edit";
            this.btn_EditPaymentMethod.UseVisualStyleBackColor = true;
            this.btn_EditPaymentMethod.Click += new System.EventHandler(this.btn_EditPaymentMethod_Click);
            // 
            // btn_DeletePaymentMethod
            // 
            this.btn_DeletePaymentMethod.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DeletePaymentMethod.Location = new System.Drawing.Point(103, 69);
            this.btn_DeletePaymentMethod.Name = "btn_DeletePaymentMethod";
            this.btn_DeletePaymentMethod.Size = new System.Drawing.Size(75, 32);
            this.btn_DeletePaymentMethod.TabIndex = 75;
            this.btn_DeletePaymentMethod.Text = "Delete";
            this.btn_DeletePaymentMethod.UseVisualStyleBackColor = true;
            this.btn_DeletePaymentMethod.Click += new System.EventHandler(this.btn_DeletePaymentMethod_Click);
            // 
            // btn_FirstPaymentMethod
            // 
            this.btn_FirstPaymentMethod.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_FirstPaymentMethod.Location = new System.Drawing.Point(18, 20);
            this.btn_FirstPaymentMethod.Name = "btn_FirstPaymentMethod";
            this.btn_FirstPaymentMethod.Size = new System.Drawing.Size(57, 32);
            this.btn_FirstPaymentMethod.TabIndex = 66;
            this.btn_FirstPaymentMethod.Text = "| <<";
            this.btn_FirstPaymentMethod.UseVisualStyleBackColor = true;
            this.btn_FirstPaymentMethod.Click += new System.EventHandler(this.btn_FirstPaymentMethod_Click);
            // 
            // btn_PreviousPaymentMethod
            // 
            this.btn_PreviousPaymentMethod.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PreviousPaymentMethod.Location = new System.Drawing.Point(81, 20);
            this.btn_PreviousPaymentMethod.Name = "btn_PreviousPaymentMethod";
            this.btn_PreviousPaymentMethod.Size = new System.Drawing.Size(57, 32);
            this.btn_PreviousPaymentMethod.TabIndex = 67;
            this.btn_PreviousPaymentMethod.Text = "<";
            this.btn_PreviousPaymentMethod.UseVisualStyleBackColor = true;
            this.btn_PreviousPaymentMethod.Click += new System.EventHandler(this.btn_PreviousPaymentMethod_Click);
            // 
            // btn_NextPaymentMethod
            // 
            this.btn_NextPaymentMethod.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_NextPaymentMethod.Location = new System.Drawing.Point(144, 20);
            this.btn_NextPaymentMethod.Name = "btn_NextPaymentMethod";
            this.btn_NextPaymentMethod.Size = new System.Drawing.Size(57, 32);
            this.btn_NextPaymentMethod.TabIndex = 69;
            this.btn_NextPaymentMethod.Text = ">";
            this.btn_NextPaymentMethod.UseVisualStyleBackColor = true;
            this.btn_NextPaymentMethod.Click += new System.EventHandler(this.btn_NextPaymentMethod_Click);
            // 
            // btn_LastPaymentMethod
            // 
            this.btn_LastPaymentMethod.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_LastPaymentMethod.Location = new System.Drawing.Point(207, 20);
            this.btn_LastPaymentMethod.Name = "btn_LastPaymentMethod";
            this.btn_LastPaymentMethod.Size = new System.Drawing.Size(57, 32);
            this.btn_LastPaymentMethod.TabIndex = 71;
            this.btn_LastPaymentMethod.Text = ">> |";
            this.btn_LastPaymentMethod.UseVisualStyleBackColor = true;
            this.btn_LastPaymentMethod.Click += new System.EventHandler(this.btn_LastPaymentMethod_Click);
            // 
            // btn_AddPaymentMethod
            // 
            this.btn_AddPaymentMethod.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddPaymentMethod.Location = new System.Drawing.Point(18, 69);
            this.btn_AddPaymentMethod.Name = "btn_AddPaymentMethod";
            this.btn_AddPaymentMethod.Size = new System.Drawing.Size(75, 32);
            this.btn_AddPaymentMethod.TabIndex = 73;
            this.btn_AddPaymentMethod.Text = "Add";
            this.btn_AddPaymentMethod.UseVisualStyleBackColor = true;
            this.btn_AddPaymentMethod.Click += new System.EventHandler(this.btn_AddPaymentMethod_Click);
            // 
            // btn_AddSubmit
            // 
            this.btn_AddSubmit.Enabled = false;
            this.btn_AddSubmit.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddSubmit.Location = new System.Drawing.Point(18, 107);
            this.btn_AddSubmit.Name = "btn_AddSubmit";
            this.btn_AddSubmit.Size = new System.Drawing.Size(75, 32);
            this.btn_AddSubmit.TabIndex = 80;
            this.btn_AddSubmit.Text = "Submit";
            this.btn_AddSubmit.UseVisualStyleBackColor = true;
            this.btn_AddSubmit.Click += new System.EventHandler(this.btn_AddSubmit_Click);
            // 
            // cmb_CardType
            // 
            this.cmb_CardType.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_CardType.FormattingEnabled = true;
            this.cmb_CardType.Items.AddRange(new object[] {
            "Visa Debit",
            "Visa Credit",
            "Mastercard"});
            this.cmb_CardType.Location = new System.Drawing.Point(188, 87);
            this.cmb_CardType.Name = "cmb_CardType";
            this.cmb_CardType.Size = new System.Drawing.Size(125, 29);
            this.cmb_CardType.TabIndex = 0;
            this.cmb_CardType.SelectedIndexChanged += new System.EventHandler(this.cmb_CardType_SelectedIndexChanged);
            // 
            // mst_CardNumber
            // 
            this.mst_CardNumber.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mst_CardNumber.Location = new System.Drawing.Point(139, 142);
            this.mst_CardNumber.Mask = "0000000000000000";
            this.mst_CardNumber.Name = "mst_CardNumber";
            this.mst_CardNumber.Size = new System.Drawing.Size(173, 29);
            this.mst_CardNumber.TabIndex = 1;
            // 
            // grp_PaymentMethodDetails
            // 
            this.grp_PaymentMethodDetails.Controls.Add(this.txt_PaymentMethodID);
            this.grp_PaymentMethodDetails.Controls.Add(this.mst_CardNumber);
            this.grp_PaymentMethodDetails.Controls.Add(this.mst_SecurityCode);
            this.grp_PaymentMethodDetails.Controls.Add(this.cmb_CardType);
            this.grp_PaymentMethodDetails.Controls.Add(this.lbl_PaymentMethodIDTitle);
            this.grp_PaymentMethodDetails.Controls.Add(this.lbl_CardTypeTitle);
            this.grp_PaymentMethodDetails.Controls.Add(this.mst_ExpiryDate);
            this.grp_PaymentMethodDetails.Controls.Add(this.lbl_CardNumberTitle);
            this.grp_PaymentMethodDetails.Controls.Add(this.lbl_ExpiryDateTitle);
            this.grp_PaymentMethodDetails.Controls.Add(this.lbl_SecurityCodeTitle);
            this.grp_PaymentMethodDetails.Enabled = false;
            this.grp_PaymentMethodDetails.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_PaymentMethodDetails.Location = new System.Drawing.Point(302, 12);
            this.grp_PaymentMethodDetails.Name = "grp_PaymentMethodDetails";
            this.grp_PaymentMethodDetails.Size = new System.Drawing.Size(327, 301);
            this.grp_PaymentMethodDetails.TabIndex = 118;
            this.grp_PaymentMethodDetails.TabStop = false;
            this.grp_PaymentMethodDetails.Text = "Payment Details:";
            // 
            // txt_PaymentMethodID
            // 
            this.txt_PaymentMethodID.Enabled = false;
            this.txt_PaymentMethodID.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PaymentMethodID.Location = new System.Drawing.Point(187, 32);
            this.txt_PaymentMethodID.Name = "txt_PaymentMethodID";
            this.txt_PaymentMethodID.Size = new System.Drawing.Size(125, 29);
            this.txt_PaymentMethodID.TabIndex = 130;
            this.txt_PaymentMethodID.TextChanged += new System.EventHandler(this.txt_PaymentMethodID_TextChanged);
            // 
            // dgv_PaymentMethodList
            // 
            this.dgv_PaymentMethodList.AllowUserToAddRows = false;
            this.dgv_PaymentMethodList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgv_PaymentMethodList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_PaymentMethodList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_PaymentMethodList.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgv_PaymentMethodList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_PaymentMethodList.Location = new System.Drawing.Point(635, 12);
            this.dgv_PaymentMethodList.Name = "dgv_PaymentMethodList";
            this.dgv_PaymentMethodList.ReadOnly = true;
            this.dgv_PaymentMethodList.Size = new System.Drawing.Size(608, 301);
            this.dgv_PaymentMethodList.TabIndex = 119;
            // 
            // grp_SearchSortOptions
            // 
            this.grp_SearchSortOptions.Controls.Add(this.btn_DisplayDetails);
            this.grp_SearchSortOptions.Controls.Add(this.btn_DisplayMethods);
            this.grp_SearchSortOptions.Controls.Add(this.btn_UpdateAndClose);
            this.grp_SearchSortOptions.Controls.Add(this.cmb_SortOptions);
            this.grp_SearchSortOptions.Controls.Add(this.btn_FullList);
            this.grp_SearchSortOptions.Controls.Add(this.btn_Search);
            this.grp_SearchSortOptions.Controls.Add(this.mst_SearchTerm);
            this.grp_SearchSortOptions.Controls.Add(this.cmb_AscendOrDescend);
            this.grp_SearchSortOptions.Controls.Add(this.lbl_SortTitle);
            this.grp_SearchSortOptions.Controls.Add(this.lbl_SearchTitle);
            this.grp_SearchSortOptions.Controls.Add(this.lbl_SearchTermTitle);
            this.grp_SearchSortOptions.Controls.Add(this.btn_SubmitSort);
            this.grp_SearchSortOptions.Controls.Add(this.cmb_SearchTermOptions);
            this.grp_SearchSortOptions.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_SearchSortOptions.Location = new System.Drawing.Point(302, 326);
            this.grp_SearchSortOptions.Name = "grp_SearchSortOptions";
            this.grp_SearchSortOptions.Size = new System.Drawing.Size(941, 147);
            this.grp_SearchSortOptions.TabIndex = 120;
            this.grp_SearchSortOptions.TabStop = false;
            this.grp_SearchSortOptions.Text = "Search and Sort Options";
            // 
            // btn_DisplayDetails
            // 
            this.btn_DisplayDetails.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DisplayDetails.Location = new System.Drawing.Point(699, 69);
            this.btn_DisplayDetails.Name = "btn_DisplayDetails";
            this.btn_DisplayDetails.Size = new System.Drawing.Size(236, 32);
            this.btn_DisplayDetails.TabIndex = 98;
            this.btn_DisplayDetails.Text = "Show Payment Details";
            this.btn_DisplayDetails.UseVisualStyleBackColor = true;
            this.btn_DisplayDetails.Click += new System.EventHandler(this.btn_DisplayDetails_Click);
            // 
            // btn_DisplayMethods
            // 
            this.btn_DisplayMethods.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DisplayMethods.Location = new System.Drawing.Point(699, 22);
            this.btn_DisplayMethods.Name = "btn_DisplayMethods";
            this.btn_DisplayMethods.Size = new System.Drawing.Size(236, 32);
            this.btn_DisplayMethods.TabIndex = 97;
            this.btn_DisplayMethods.Text = "Show Payment Methods";
            this.btn_DisplayMethods.UseVisualStyleBackColor = true;
            this.btn_DisplayMethods.Click += new System.EventHandler(this.btn_DisplayMethods_Click);
            // 
            // btn_UpdateAndClose
            // 
            this.btn_UpdateAndClose.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_UpdateAndClose.Location = new System.Drawing.Point(392, 107);
            this.btn_UpdateAndClose.Name = "btn_UpdateAndClose";
            this.btn_UpdateAndClose.Size = new System.Drawing.Size(169, 32);
            this.btn_UpdateAndClose.TabIndex = 96;
            this.btn_UpdateAndClose.Text = "Update And Close";
            this.btn_UpdateAndClose.UseVisualStyleBackColor = true;
            this.btn_UpdateAndClose.Click += new System.EventHandler(this.btn_UpdateAndClose_Click);
            // 
            // cmb_SortOptions
            // 
            this.cmb_SortOptions.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_SortOptions.FormattingEnabled = true;
            this.cmb_SortOptions.Items.AddRange(new object[] {
            "Payment Method ID",
            "MemberID"});
            this.cmb_SortOptions.Location = new System.Drawing.Point(146, 25);
            this.cmb_SortOptions.Name = "cmb_SortOptions";
            this.cmb_SortOptions.Size = new System.Drawing.Size(148, 29);
            this.cmb_SortOptions.TabIndex = 0;
            this.cmb_SortOptions.SelectedIndexChanged += new System.EventHandler(this.cmb_SortOptions_SelectedIndexChanged);
            // 
            // btn_FullList
            // 
            this.btn_FullList.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_FullList.Location = new System.Drawing.Point(545, 22);
            this.btn_FullList.Name = "btn_FullList";
            this.btn_FullList.Size = new System.Drawing.Size(148, 32);
            this.btn_FullList.TabIndex = 95;
            this.btn_FullList.Text = "Show Full List";
            this.btn_FullList.UseVisualStyleBackColor = true;
            this.btn_FullList.Click += new System.EventHandler(this.btn_FullList_Click);
            // 
            // btn_Search
            // 
            this.btn_Search.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Search.Location = new System.Drawing.Point(618, 69);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(75, 32);
            this.btn_Search.TabIndex = 77;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // mst_SearchTerm
            // 
            this.mst_SearchTerm.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mst_SearchTerm.Location = new System.Drawing.Point(464, 72);
            this.mst_SearchTerm.Name = "mst_SearchTerm";
            this.mst_SearchTerm.Size = new System.Drawing.Size(148, 29);
            this.mst_SearchTerm.TabIndex = 3;
            // 
            // cmb_AscendOrDescend
            // 
            this.cmb_AscendOrDescend.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_AscendOrDescend.FormattingEnabled = true;
            this.cmb_AscendOrDescend.Items.AddRange(new object[] {
            "Ascending",
            "Descending"});
            this.cmb_AscendOrDescend.Location = new System.Drawing.Point(309, 25);
            this.cmb_AscendOrDescend.Name = "cmb_AscendOrDescend";
            this.cmb_AscendOrDescend.Size = new System.Drawing.Size(149, 29);
            this.cmb_AscendOrDescend.TabIndex = 1;
            this.cmb_AscendOrDescend.SelectedIndexChanged += new System.EventHandler(this.cmb_AscendOrDescend_SelectedIndexChanged);
            // 
            // lbl_SortTitle
            // 
            this.lbl_SortTitle.AutoSize = true;
            this.lbl_SortTitle.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SortTitle.Location = new System.Drawing.Point(7, 28);
            this.lbl_SortTitle.Name = "lbl_SortTitle";
            this.lbl_SortTitle.Size = new System.Drawing.Size(137, 21);
            this.lbl_SortTitle.TabIndex = 85;
            this.lbl_SortTitle.Text = "Fields to sort by:";
            // 
            // lbl_SearchTitle
            // 
            this.lbl_SearchTitle.AutoSize = true;
            this.lbl_SearchTitle.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SearchTitle.Location = new System.Drawing.Point(305, 75);
            this.lbl_SearchTitle.Name = "lbl_SearchTitle";
            this.lbl_SearchTitle.Size = new System.Drawing.Size(153, 21);
            this.lbl_SearchTitle.TabIndex = 93;
            this.lbl_SearchTitle.Text = "Enter Search Term:";
            // 
            // lbl_SearchTermTitle
            // 
            this.lbl_SearchTermTitle.AutoSize = true;
            this.lbl_SearchTermTitle.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SearchTermTitle.Location = new System.Drawing.Point(7, 75);
            this.lbl_SearchTermTitle.Name = "lbl_SearchTermTitle";
            this.lbl_SearchTermTitle.Size = new System.Drawing.Size(133, 21);
            this.lbl_SearchTermTitle.TabIndex = 92;
            this.lbl_SearchTermTitle.Text = "Field To Search:";
            // 
            // btn_SubmitSort
            // 
            this.btn_SubmitSort.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SubmitSort.Location = new System.Drawing.Point(464, 22);
            this.btn_SubmitSort.Name = "btn_SubmitSort";
            this.btn_SubmitSort.Size = new System.Drawing.Size(75, 32);
            this.btn_SubmitSort.TabIndex = 89;
            this.btn_SubmitSort.Text = "Sort";
            this.btn_SubmitSort.UseVisualStyleBackColor = true;
            this.btn_SubmitSort.Click += new System.EventHandler(this.btn_SubmitSort_Click);
            // 
            // cmb_SearchTermOptions
            // 
            this.cmb_SearchTermOptions.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_SearchTermOptions.FormattingEnabled = true;
            this.cmb_SearchTermOptions.Items.AddRange(new object[] {
            "Payment Method ID",
            "Member ID"});
            this.cmb_SearchTermOptions.Location = new System.Drawing.Point(146, 72);
            this.cmb_SearchTermOptions.Name = "cmb_SearchTermOptions";
            this.cmb_SearchTermOptions.Size = new System.Drawing.Size(148, 29);
            this.cmb_SearchTermOptions.TabIndex = 2;
            this.cmb_SearchTermOptions.SelectedIndexChanged += new System.EventHandler(this.cmb_SearchTermOptions_SelectedIndexChanged);
            // 
            // frm_PaymentMethod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 485);
            this.Controls.Add(this.grp_SearchSortOptions);
            this.Controls.Add(this.dgv_PaymentMethodList);
            this.Controls.Add(this.grp_PaymentMethodDetails);
            this.Controls.Add(this.grp_UserButtons);
            this.Controls.Add(this.grp_AccountDetails);
            this.Name = "frm_PaymentMethod";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_PaymentMethod";
            this.Load += new System.EventHandler(this.frm_PaymentMethod_Load);
            this.grp_AccountDetails.ResumeLayout(false);
            this.grp_AccountDetails.PerformLayout();
            this.grp_UserButtons.ResumeLayout(false);
            this.grp_PaymentMethodDetails.ResumeLayout(false);
            this.grp_PaymentMethodDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PaymentMethodList)).EndInit();
            this.grp_SearchSortOptions.ResumeLayout(false);
            this.grp_SearchSortOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp_AccountDetails;
        private System.Windows.Forms.ComboBox cmb_MemberID;
        private System.Windows.Forms.Label lbl_MemberIDTitle;
        private System.Windows.Forms.MaskedTextBox mst_ExpiryDate;
        private System.Windows.Forms.MaskedTextBox mst_SecurityCode;
        private System.Windows.Forms.Label lbl_SecurityCodeTitle;
        private System.Windows.Forms.Label lbl_ExpiryDateTitle;
        private System.Windows.Forms.Label lbl_CardNumberTitle;
        private System.Windows.Forms.Label lbl_CardTypeTitle;
        private System.Windows.Forms.Label lbl_PaymentMethodIDTitle;
        private System.Windows.Forms.MaskedTextBox mst_CardNumber;
        private System.Windows.Forms.ComboBox cmb_CardType;
        private System.Windows.Forms.GroupBox grp_UserButtons;
        private System.Windows.Forms.Button btn_EditSubmit;
        private System.Windows.Forms.Button btn_EditPaymentMethod;
        private System.Windows.Forms.Button btn_DeletePaymentMethod;
        private System.Windows.Forms.Button btn_FirstPaymentMethod;
        private System.Windows.Forms.Button btn_PreviousPaymentMethod;
        private System.Windows.Forms.Button btn_NextPaymentMethod;
        private System.Windows.Forms.Button btn_LastPaymentMethod;
        private System.Windows.Forms.Button btn_AddPaymentMethod;
        private System.Windows.Forms.Button btn_AddSubmit;
        private System.Windows.Forms.GroupBox grp_PaymentMethodDetails;
        private System.Windows.Forms.DateTimePicker dtp_DOB;
        private System.Windows.Forms.Label lbl_DOBTitle;
        private System.Windows.Forms.TextBox txt_Address;
        private System.Windows.Forms.TextBox txt_Town;
        private System.Windows.Forms.TextBox txt_Surname;
        private System.Windows.Forms.TextBox txt_FirstName;
        private System.Windows.Forms.MaskedTextBox mst_PostCode;
        private System.Windows.Forms.Label lbl_PostCodeTitle;
        private System.Windows.Forms.Label lbl_TownTitle;
        private System.Windows.Forms.Label lbl_AddressTitle;
        private System.Windows.Forms.Label lbl_FirstNameTitle;
        private System.Windows.Forms.Label lbl_SurnameTitle;
        private System.Windows.Forms.DataGridView dgv_PaymentMethodList;
        private System.Windows.Forms.GroupBox grp_SearchSortOptions;
        private System.Windows.Forms.ComboBox cmb_SortOptions;
        private System.Windows.Forms.Button btn_FullList;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.MaskedTextBox mst_SearchTerm;
        private System.Windows.Forms.ComboBox cmb_AscendOrDescend;
        private System.Windows.Forms.Label lbl_SortTitle;
        private System.Windows.Forms.Label lbl_SearchTitle;
        private System.Windows.Forms.Label lbl_SearchTermTitle;
        private System.Windows.Forms.Button btn_SubmitSort;
        private System.Windows.Forms.ComboBox cmb_SearchTermOptions;
        private System.Windows.Forms.Button btn_UpdateAndClose;
        private System.Windows.Forms.TextBox txt_PaymentMethodID;
        private System.Windows.Forms.Button btn_DisplayDetails;
        private System.Windows.Forms.Button btn_DisplayMethods;
    }
}