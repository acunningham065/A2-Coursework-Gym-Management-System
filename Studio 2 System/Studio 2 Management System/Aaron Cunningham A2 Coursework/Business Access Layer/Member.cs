using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio_2_Management_System.Business_Access_Layer
{
    public class Member
    {
        //------------------------------ Fields ------------------------------\\
        int _memberID = 0;
        int _membershipTypeID = 0;
        string _title = "";
        string _surname = "";
        string _firstName = "";
        string _address = "";
        string _town = "";
        string _postCode = "";
        string _telNo = "";
        string _email = "";
        DateTime _DOB = DateTime.Today.AddYears(-16);

        //------------------------------ Constructors ------------------------------\\

        public Member() { }//End Constructor


        public Member(int memberID, int membershipTypeID, string title, string Surname, string FirstName, DateTime DOB, string Address, string Town, string PostCode, string TelNo, string Email)        
        {
            _memberID = memberID;
            _membershipTypeID = membershipTypeID;
            _title = title;
            _surname = Surname;
            _firstName = FirstName;
            _DOB = DOB;
            _address = Address;
            _town = Town;
            _postCode = PostCode;
            _telNo = TelNo;
            _email = Email;

        }//End Constructor


        //------------------------------ Properties ------------------------------\\

        public int MemberID
        {
            get { return _memberID; }
            set { _memberID = value; }

        }//End Property


        public int MembershipTypeID
        {
            get { return _membershipTypeID; }
            set { _membershipTypeID = value; }

        }//End Property


        public string Title
        {
            get { return _title; }
            set { _title = value; }

        }//End Property


        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }

        }//End Property


        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }

        }//End Property


        public DateTime DOB
        {
            get { return _DOB; }
            set { _DOB = value; }

        }//End Property


        public string Address
        {
            get { return _address; }
            set { _address = value; }

        }//End Property


        public string Town
        {
            get { return _town; }
            set { _town = value; }

        }//End Property


        public string PostCode
        {
            get { return _postCode; }
            set { _postCode = value; }

        }//End Property


        public string TelNo
        {
            get { return _telNo; }
            set { _telNo = value; }

        }//End Property


        public string Email
        {
            get { return _email; }
            set { _email = value; }

        }//End Property

    }
}
