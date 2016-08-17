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
    public partial class frm_EmployeeReport : Form
    {
        public frm_EmployeeReport()
        {
            InitializeComponent();
        }

        private void frm_EmployeeReport_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'STUDIO2DataSet.Employee' table. You can move, or remove it, as needed.
                this.employeeTableAdapter.Fill(this.STUDIO2DataSet.Employee);

                this.rpv_EmployeeReportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                printErrorMessage(ex);
            }
            
        }


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
    }
}
