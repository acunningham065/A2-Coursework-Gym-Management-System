namespace Studio_2_Management_System.Presentation_Access_Layer
{
    partial class frm_MemberReport
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
            this.memberBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.STUDIO2DataSet = new Studio_2_Management_System.STUDIO2DataSet();
            this.rpt_MemberReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.memberTableAdapter = new Studio_2_Management_System.STUDIO2DataSetTableAdapters.MemberTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.memberBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.STUDIO2DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // memberBindingSource
            // 
            this.memberBindingSource.DataMember = "Member";
            this.memberBindingSource.DataSource = this.STUDIO2DataSet;
            // 
            // STUDIO2DataSet
            // 
            this.STUDIO2DataSet.DataSetName = "STUDIO2DataSet";
            this.STUDIO2DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rpt_MemberReportViewer
            // 
            this.rpt_MemberReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsMember";
            reportDataSource1.Value = this.memberBindingSource;
            this.rpt_MemberReportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.rpt_MemberReportViewer.LocalReport.ReportEmbeddedResource = "Studio_2_Management_System.Presentation Access Layer.MemberReport.rdlc";
            this.rpt_MemberReportViewer.LocalReport.ReportPath = "Presentation Access Layer\\MemberReport.rdlc";
            this.rpt_MemberReportViewer.Location = new System.Drawing.Point(0, 0);
            this.rpt_MemberReportViewer.Name = "rpt_MemberReportViewer";
            this.rpt_MemberReportViewer.Size = new System.Drawing.Size(1147, 523);
            this.rpt_MemberReportViewer.TabIndex = 0;
            // 
            // memberTableAdapter
            // 
            this.memberTableAdapter.ClearBeforeFill = true;
            // 
            // frm_MemberReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 523);
            this.Controls.Add(this.rpt_MemberReportViewer);
            this.Name = "frm_MemberReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_MemberReport";
            this.Load += new System.EventHandler(this.frm_MemberReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.memberBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.STUDIO2DataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpt_MemberReportViewer;
        private STUDIO2DataSet STUDIO2DataSet;
        private System.Windows.Forms.BindingSource memberBindingSource;
        private STUDIO2DataSetTableAdapters.MemberTableAdapter memberTableAdapter;
    }
}