namespace Studio_2_Management_System.Presentation_Access_Layer
{
    partial class frm_EmployeeReport
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
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.STUDIO2DataSet = new Studio_2_Management_System.STUDIO2DataSet();
            this.rpv_EmployeeReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.employeeTableAdapter = new Studio_2_Management_System.STUDIO2DataSetTableAdapters.EmployeeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.STUDIO2DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // employeeBindingSource
            // 
            this.employeeBindingSource.DataMember = "Employee";
            this.employeeBindingSource.DataSource = this.STUDIO2DataSet;
            // 
            // STUDIO2DataSet
            // 
            this.STUDIO2DataSet.DataSetName = "STUDIO2DataSet";
            this.STUDIO2DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rpv_EmployeeReportViewer
            // 
            this.rpv_EmployeeReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsEmployee";
            reportDataSource1.Value = this.employeeBindingSource;
            this.rpv_EmployeeReportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.rpv_EmployeeReportViewer.LocalReport.ReportEmbeddedResource = "Studio_2_Management_System.Presentation Access Layer.EmployeeReport.rdlc";
            this.rpv_EmployeeReportViewer.LocalReport.ReportPath = "Presentation Access Layer\\EmployeeReport.rdlc";
            this.rpv_EmployeeReportViewer.Location = new System.Drawing.Point(0, 0);
            this.rpv_EmployeeReportViewer.Name = "rpv_EmployeeReportViewer";
            this.rpv_EmployeeReportViewer.Size = new System.Drawing.Size(1342, 523);
            this.rpv_EmployeeReportViewer.TabIndex = 0;
            // 
            // employeeTableAdapter
            // 
            this.employeeTableAdapter.ClearBeforeFill = true;
            // 
            // frm_EmployeeReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1342, 523);
            this.Controls.Add(this.rpv_EmployeeReportViewer);
            this.Name = "frm_EmployeeReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_EmployeeReport";
            this.Load += new System.EventHandler(this.frm_EmployeeReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.STUDIO2DataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpv_EmployeeReportViewer;
        private STUDIO2DataSet STUDIO2DataSet;
        private System.Windows.Forms.BindingSource employeeBindingSource;
        private STUDIO2DataSetTableAdapters.EmployeeTableAdapter employeeTableAdapter;
    }
}