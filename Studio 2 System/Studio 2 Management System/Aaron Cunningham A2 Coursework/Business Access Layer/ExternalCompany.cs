using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio_2_Management_System.Business_Access_Layer
{
    class ExternalCompany
    {
        //------------------------------ Fields ------------------------------\\
        int _externalCompanyID = 0;
        string _companyName = "";
        string _companyAddress = "";
        string _companyTown = "";
        string _companyPostCode = "";
        string _companyPractice = "";
        string _contactName = "";
        string _contactTelNo = "";
        string _contactEmail = "";


        //------------------------------ Constructor ------------------------------\\

        public ExternalCompany() { }//End Default Constructor


        public ExternalCompany(int externalCompanyID, string companyName)
        {
            _externalCompanyID = externalCompanyID;
            _companyName = companyName;

        }//End Overloaded Constructor


        public ExternalCompany(int externalCompanyID, string companyName, string companyAddress, string companyTown, string companyPostCode, string companyPractice, string contactName, string contactTelNo, string contactEmail) 
        {
            //Assign values to fields
            _externalCompanyID = externalCompanyID;
            _companyName = companyName;
            _companyAddress = companyAddress;
            _companyTown = companyTown;
            _companyPostCode = companyPostCode;
            _companyPractice = companyPractice;
            _contactName = contactName;
            _contactTelNo = contactTelNo;
            _contactEmail = contactEmail;

        }//End Overloaded Constructor


        //------------------------------ Properties ------------------------------\\

        public int ExternalCompanyID
        {
            get { return _externalCompanyID; }
            set { _externalCompanyID = value; }

        }//End Property


        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }

        }//End Property


        public string CompanyAddress
        {
            get { return _companyAddress; }
            set { _companyAddress = value; }

        }//End Property


        public string CompanyTown
        {
            get { return _companyTown; }
            set { _companyTown = value; }

        }//End Property


        public string CompanyPostCode
        {
            get { return _companyPostCode; }
            set { _companyPostCode = value; }

        }//End Property


        public string CompanyPractice
        {
            get { return _companyPractice; }
            set { _companyPractice = value; }

        }//End Property


        public string ContactName
        {
            get { return _contactName; }
            set { _contactName = value; }

        }//End Property


        public string ContactTelNo
        {
            get { return _contactTelNo; }
            set { _contactTelNo = value; }

        }//End Property


        public string ContactEmail
        {
            get { return _contactEmail; }
            set { _contactEmail = value; }

        }//End Property



    }//End Class
}
