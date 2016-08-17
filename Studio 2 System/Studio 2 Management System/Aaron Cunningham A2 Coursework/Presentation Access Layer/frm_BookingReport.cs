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
    public partial class frm_BookingReport : Form
    {
        public frm_BookingReport()
        {
            InitializeComponent();
        }

        private void frm_BookingReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sTUDIO2DataSet.Booking' table. You can move, or remove it, as needed.
            this.bookingTableAdapter.Fill(this.sTUDIO2DataSet.Booking);

            this.rpv_BookingReportViewer.RefreshReport();
        }
    }
}
