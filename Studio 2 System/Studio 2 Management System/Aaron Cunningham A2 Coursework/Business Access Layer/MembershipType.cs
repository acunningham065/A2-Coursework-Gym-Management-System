using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio_2_Management_System.Business_Access_Layer
{
    class MembershipType
    {
        //------------------------------ Fields ------------------------------\\

        int _membershipTypeID = 0;
        string _description = "";
        decimal _membershipCost = 0;


        //--------------------- Constructors ---------------------\\

        public MembershipType() { }//End Default Constructor


        public MembershipType(int membershipTypeID, string description, decimal membershipCost)
        {
            _membershipTypeID = membershipTypeID;
            _description = description;
            _membershipCost = membershipCost;

        }//End Overloaded Constructor


        //--------------------- Properties ---------------------\\

        public int MembershipTypeID
        {
            get { return _membershipTypeID; }
            set { _membershipTypeID = value; }

        }//End Property


        public string Description
        {
            get { return _description; }
            set { _description = value; }

        }//End Property


        public decimal MembershipCost
        {
            get { return _membershipCost; }
            set { _membershipCost = value; }

        }//End Property

    }
}
