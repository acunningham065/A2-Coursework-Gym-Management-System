using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio_2_Management_System.Business_Access_Layer
{
    public class PaymentDetails
    {
        //------------------- Fields -------------------\\
        int _paymentDetailsID = 0;
        string _cardType = "";
        string _cardNumber = "";
        string _expiryDate = "";
        string _securityCode = "";

        //---------------------------- Constructors ----------------------------\\

        public PaymentDetails() { } //End Default Constructor


        public PaymentDetails(string cardType, string cardNumber, string expiryDate, string securityCode)
        {
            //Assign the variables
            _cardType = cardType;
            _cardNumber = cardNumber;
            _expiryDate = expiryDate;
            _securityCode = securityCode;

        }//End Overloaded Constructor

        //---------------------------- Properties ----------------------------\\

        public int PaymentDetailsID
        {
            get { return _paymentDetailsID; }
            set { _paymentDetailsID = value; }

        }//End Property


        public string CardType
        {
            get { return _cardType; }
            set { _cardType = value; }

        }//End Property


        public string CardNumber
        {
            get { return _cardNumber; }
            set { _cardNumber = value; }

        }//End Property


        public string ExpiryDate
        {
            get { return _expiryDate; }
            set { _expiryDate = value; }

        }//End Property


        public string SecurityCode
        {
            get { return _securityCode; }
            set { _securityCode = value; }

        }//End Property




    }
}
