using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio_2_Management_System.Business_Access_Layer
{
    public class Employee
    {
        //------------------------------ Fields ------------------------------\\
        int _employeeID = 0;
        string _title = "";
        string _surname = "";
        string _firstName = "";
        string _address = "";
        string _town = "";
        string _postCode = "";
        string _telNo = "";
        string _email = "";
        DateTime _DOB = DateTime.Today.AddYears(-18);
        string _nationalInsuranceNumber = "";
        string _contractType = "";

        //------------------------------ Constructors ------------------------------\\

        public Employee() { } //End Default Constructor


        public Employee(int employeeID, string title, string surname, string firstName, DateTime DOB, string address, string town, string postCode, string telNo, string email, string nationalInsuranceNumber, string contractType)
        {
            //Assign fields
            _employeeID = employeeID;
            _title = title;
            _surname = surname;
            _firstName = firstName;
            _DOB = DOB;
            _address = address;
            _town = town;
            _postCode = postCode;
            _telNo = telNo;
            _email = email;
            _nationalInsuranceNumber = nationalInsuranceNumber;
            _contractType = contractType;

        }//End Overloaded Constructor


        //------------------------------ Properties ------------------------------\\

        public int EmployeeID
        {
            get { return _employeeID; }
            set { _employeeID = value; }
        }


        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }


        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }


        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }


        public DateTime DOB
        {
            get { return _DOB; }
            set { _DOB = value; }
        }


        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }


        public string Town
        {
            get { return _town; }
            set { _town = value; }
        }


        public string PostCode
        {
            get { return _postCode; }
            set { _postCode = value; }
        }


        public string TelNo
        {
            get { return _telNo; }
            set { _telNo = value; }
        }


        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }


        public string NationalInsuranceNumber
        {
            get { return _nationalInsuranceNumber; }
            set { _nationalInsuranceNumber = value; }

        }


        public string ContractType
        {
            get { return _contractType; }
            set { _contractType = value; }

        }


    }
}
