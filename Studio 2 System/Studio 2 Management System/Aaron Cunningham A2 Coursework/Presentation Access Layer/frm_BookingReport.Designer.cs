namespace Studio_2_Management_System.Presentation_Access_Layer
{
    partial class frm_BookingReport
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.bookingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sTUDIO2DataSet = new Studio_2_Management_System.STUDIO2DataSet();
            this.rpv_BookingReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bookingTableAdapter = new Studio_2_Management_System.STUDIO2DataSetTableAdapters.BookingTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bookingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTUDIO2DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // bookingBindingSource
            // 
            this.bookingBindingSource.DataMember = "Booking";
            this.bookingBindingSource.DataSource = this.sTUDIO2DataSet;
            // 
            // sTUDIO2DataSet
            // 
            this.sTUDIO2DataSet.DataSetName = "STUDIO2DataSet";
            this.sTUDIO2DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rpv_BookingReportViewer
            // 
            this.rpv_BookingReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsBookings";
            reportDataSource1.Value = this.bookingBindingSource;
            this.rpv_BookingReportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.rpv_BookingReportViewer.LocalReport.ReportEmbeddedResource = "";
            this.rpv_BookingReportViewer.LocalReport.ReportPath = "Presentation Access Layer\\BookingReport.rdlc";
            this.rpv_BookingReportViewer.Location = new System.Drawing.Point(0, 0);
            this.rpv_BookingReportViewer.Name = "rpv_BookingReportViewer";
            this.rpv_BookingReportViewer.Size = new System.Drawing.Size(872, 523);
            this.rpv_BookingReportViewer.TabIndex = 0;
            // 
            // bookingTableAdapter
            // 
            this.bookingTableAdapter.ClearBeforeFill = true;
            // 
            // frm_BookingReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 523);
            this.Controls.Add(this.rpv_BookingReportViewer);
            this.Name = "frm_BookingReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_BookingReport";
            this.Load += new System.EventHandler(this.frm_BookingReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bookingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTUDIO2DataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpv_BookingReportViewer;
        private STUDIO2DataSet sTUDIO2DataSet;
        private System.Windows.Forms.BindingSource bookingBindingSource;
        private STUDIO2DataSetTableAdapters.BookingTableAdapter bookingTableAdapter;
    }
}