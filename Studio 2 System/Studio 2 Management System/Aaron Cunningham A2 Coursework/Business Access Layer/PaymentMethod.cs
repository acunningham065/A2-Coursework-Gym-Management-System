using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio_2_Management_System.Business_Access_Layer
{
    public class PaymentMethod
    {
        //---------------------------- Fields ----------------------------\\
        int _paymentMethodID = 0;
        int _memberID = 0;
        int _paymentDetailsID = 0;        

        //---------------------------- Constructors ----------------------------\\

        public PaymentMethod() { } //End Default Constructor


        public PaymentMethod(int paymentMethodID, int memberID, int paymentDetailsID)
        {
            //Assign the variables
            _paymentMethodID = paymentMethodID;
            _memberID = memberID;
            _paymentDetailsID = paymentDetailsID;

        }//End Overloaded Constructor

        //---------------------------- Properties ----------------------------\\

        public int PaymentMethodID
        {
            get { return _paymentMethodID; }
            set { _paymentMethodID = value; }

        }//End Property


        public int MemberID
        {
            get { return _memberID; }
            set { _memberID = value; }

        }//End Property


        public int PaymentDetailsID
        {
            get { return _paymentDetailsID; }
            set { _paymentDetailsID = value; }

        }//End Property

    }
}
