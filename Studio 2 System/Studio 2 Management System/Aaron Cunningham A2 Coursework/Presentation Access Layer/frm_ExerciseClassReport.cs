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
    public partial class frm_ExerciseClassReport : Form
    {
        public frm_ExerciseClassReport()
        {
            InitializeComponent();
        }

        private void frm_ExerciseClassReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'STUDIO2DataSet.ExerciseClass' table. You can move, or remove it, as needed.
            this.exerciseClassTableAdapter.Fill(this.STUDIO2DataSet.ExerciseClass);

            this.rpv_ExerciseClassReportViewer.RefreshReport();
        }
    }
}
