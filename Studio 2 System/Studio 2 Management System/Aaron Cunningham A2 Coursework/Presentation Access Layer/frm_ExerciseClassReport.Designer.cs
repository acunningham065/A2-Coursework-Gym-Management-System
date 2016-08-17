namespace Studio_2_Management_System.Presentation_Access_Layer
{
    partial class frm_ExerciseClassReport
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
            this.exerciseClassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.STUDIO2DataSet = new Studio_2_Management_System.STUDIO2DataSet();
            this.rpv_ExerciseClassReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.exerciseClassTableAdapter = new Studio_2_Management_System.STUDIO2DataSetTableAdapters.ExerciseClassTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.exerciseClassBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.STUDIO2DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // exerciseClassBindingSource
            // 
            this.exerciseClassBindingSource.DataMember = "ExerciseClass";
            this.exerciseClassBindingSource.DataSource = this.STUDIO2DataSet;
            // 
            // STUDIO2DataSet
            // 
            this.STUDIO2DataSet.DataSetName = "STUDIO2DataSet";
            this.STUDIO2DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rpv_ExerciseClassReportViewer
            // 
            this.rpv_ExerciseClassReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsExerciseClass";
            reportDataSource1.Value = this.exerciseClassBindingSource;
            this.rpv_ExerciseClassReportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.rpv_ExerciseClassReportViewer.LocalReport.ReportEmbeddedResource = "Studio_2_Management_System.Presentation Access Layer.ExerciseClassReport.rdlc";
            this.rpv_ExerciseClassReportViewer.LocalReport.ReportPath = "Presentation Access Layer\\ExerciseClassReport.rdlc";
            this.rpv_ExerciseClassReportViewer.Location = new System.Drawing.Point(0, 0);
            this.rpv_ExerciseClassReportViewer.Name = "rpv_ExerciseClassReportViewer";
            this.rpv_ExerciseClassReportViewer.Size = new System.Drawing.Size(1358, 523);
            this.rpv_ExerciseClassReportViewer.TabIndex = 0;
            // 
            // exerciseClassTableAdapter
            // 
            this.exerciseClassTableAdapter.ClearBeforeFill = true;
            // 
            // frm_ExerciseClassReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1358, 523);
            this.Controls.Add(this.rpv_ExerciseClassReportViewer);
            this.Name = "frm_ExerciseClassReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_ExerciseClassReport";
            this.Load += new System.EventHandler(this.frm_ExerciseClassReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exerciseClassBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.STUDIO2DataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpv_ExerciseClassReportViewer;
        private STUDIO2DataSet STUDIO2DataSet;
        private System.Windows.Forms.BindingSource exerciseClassBindingSource;
        private STUDIO2DataSetTableAdapters.ExerciseClassTableAdapter exerciseClassTableAdapter;
    }
}