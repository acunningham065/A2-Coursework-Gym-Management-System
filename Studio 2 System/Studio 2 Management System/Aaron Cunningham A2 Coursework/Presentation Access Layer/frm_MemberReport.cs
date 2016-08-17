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
    public partial class frm_MemberReport : Form
    {
        public frm_MemberReport()
        {
            InitializeComponent();
        }

        private void frm_MemberReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'STUDIO2DataSet.Member' table. You can move, or remove it, as needed.
            this.memberTableAdapter.Fill(this.STUDIO2DataSet.Member);
            this.rpt_MemberReportViewer.RefreshReport();
        }
    }
}
