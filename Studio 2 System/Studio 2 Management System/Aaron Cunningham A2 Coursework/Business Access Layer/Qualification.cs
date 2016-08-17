using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio_2_Management_System.Business_Access_Layer
{
    public class Qualification
    {
        //------------------------------ Fields ------------------------------\\
        int _qualificationID = 1;
        string _description = "";

        //------------------------------ Constructors ------------------------------\\

        public Qualification() { }//End Default Constructor

        public Qualification(int qualificationID, string description)
        {
            _qualificationID = qualificationID;
            _description = description;

        }//End Overloaded Constructor


        //------------------------------ Properties ------------------------------\\

        public int QualificationID
        {
            get { return _qualificationID; }
            set { _qualificationID = value; }

        }//End Property


        public string Description
        {
            get { return _description; }
            set { _description = value; }

        }//End Property

    }
}
