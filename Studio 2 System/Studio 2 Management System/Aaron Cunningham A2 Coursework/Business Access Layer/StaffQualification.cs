using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio_2_Management_System.Business_Access_Layer
{
    public class StaffQualification
    {

        //------------------------------ Fields ------------------------------\\
        int _staffQualificationID = 1;
        int _qualificationID = 1;
        int _employeeID = 1;
        DateTime _issueDate = DateTime.Today;
        DateTime _expiryDate = DateTime.Today.AddYears(1);
        

        //------------------------------ Constructors ------------------------------\\

        public StaffQualification() { }//End Default Constructor


        public StaffQualification(int staffQualificationID, int qualificationID, int employeeID, DateTime issueDate, DateTime expiryDate)
        {
            _staffQualificationID = staffQualificationID;
            _qualificationID = qualificationID;
            _employeeID = employeeID;
            _issueDate = issueDate;
            _expiryDate = expiryDate;

        }//End Overloaded Constructor


        //------------------------------ Properties ------------------------------\\

        public int StaffQualificationID
        {
            get { return _staffQualificationID; }
            set { _staffQualificationID = value; }

        }//End Property


        public int QualificationID
        {
            get { return _qualificationID; }
            set { _qualificationID = value; }

        }//End Property


        public int EmployeeID
        {
            get { return _employeeID; }
            set { _employeeID = value; }

        }//End Property


        public DateTime IssueDate
        {
            get { return _issueDate; }
            set { _issueDate = value; }

        }//End Property


        public DateTime ExpiryDate
        {
            get { return _expiryDate; }
            set { _expiryDate = value; }

        }//End Property

    }
}
