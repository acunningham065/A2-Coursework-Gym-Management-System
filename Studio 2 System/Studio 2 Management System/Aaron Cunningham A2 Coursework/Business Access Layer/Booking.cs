using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio_2_Management_System.Business_Access_Layer
{
    class Booking
    {
        //------------------------------ Fields ------------------------------\\
        int _bookingID = 0;
        int _memberID = 0;
        int _exerciseClassID = 0;
        int _employeeID = 0;
        DateTime _dateOfBooking = DateTime.Today;
        decimal _amountCharged = 0;
        int _noOfPeopleBooking = 1;


        //------------------------------ Constructor ------------------------------\\

        public Booking() { }//End Default


        public Booking(int bookingID, int memberID, int exerciseClassID, int employeeID, decimal amountCharged, int noOfPeopleBooking) //No date as it will ALWAYS BE TODAY
        {
            _bookingID = bookingID;
            _memberID = memberID;
            _exerciseClassID = exerciseClassID;
            _employeeID = employeeID;
            _amountCharged = amountCharged;
            _noOfPeopleBooking = noOfPeopleBooking;

        }//End Overloaded


        //------------------------------ Properties ------------------------------\\

        public int BookingID
        {
            get { return _bookingID; }
            set { _bookingID = value; }

        }//End Property


        public int MemberID
        {
            get { return _memberID; }
            set { _memberID = value; }

        }//End Property


        public int ExerciseClassID
        {
            get { return _exerciseClassID; }
            set { _exerciseClassID = value; }

        }//End Property


        public int EmployeeID
        {
            get { return _employeeID; }
            set { _employeeID = value; }

        }//End Property


        public DateTime DateOfBooking
        {
            get { return _dateOfBooking; }
            set { _dateOfBooking = value; }

        }//End Property


        public decimal AmountCharged
        {
            get { return _amountCharged; }
            set { _amountCharged = value; }

        }//End Property


        public int NoOfPeopleBooking
        {
            get { return _noOfPeopleBooking; }
            set { _noOfPeopleBooking = value; }

        }//End Property

    }
}
