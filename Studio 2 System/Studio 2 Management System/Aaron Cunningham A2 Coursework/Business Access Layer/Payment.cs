using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio_2_Management_System.Business_Access_Layer
{
    public class Payment
    {
        //------------------------------ Fields ------------------------------\\

        int _paymentID = 0;
        int _memberID = 0;
        int _bookingID = 0;
        int _paymentMethodID = 0;
        decimal _amountPaid = 0;
        DateTime _dateOfPayment = DateTime.Now;

        //------------------------------ Constructors ------------------------------\\

        public Payment() { }//End Default Constructor

        //For Memberships
        public Payment(int paymentID, int memberID, int paymentMethodID, decimal amountPaid)
        {
            _paymentID = paymentID;
            _memberID = memberID;
            _paymentMethodID = paymentMethodID;
            _amountPaid = amountPaid;

        }//End Overloaded Constructor

        //For Bookings
        public Payment(int paymentID, int memberID, int bookingID, int paymentMethodID, decimal amountPaid)
        {
            _paymentID = paymentID;
            _memberID = memberID;
            _bookingID = bookingID;
            _paymentMethodID = paymentMethodID;
            _amountPaid = amountPaid;

        }//End Overloaded Constructor


        //------------------------------ Properties ------------------------------\\

        public int PaymentID
        {
            get { return _paymentID; }
            set { _paymentID = value; }

        }//End Property


        public int MemberID
        {
            get { return _memberID; }
            set { _memberID = value; }

        }//End Property


        public int BookingID
        {
            get { return _bookingID; }
            set { _bookingID = value; }

        }//End Property


        public int PaymentMethodID
        {
            get { return _paymentMethodID; }
            set { _paymentMethodID = value; }

        }//End Property


        public DateTime DateOfPayment
        {
            get { return _dateOfPayment; }
            set { _dateOfPayment = value; }

        }//End Property


        public decimal AmountPaid
        {
            get { return _amountPaid; }
            set { _amountPaid = value; }

        }//End Property




    }
}
