using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio_2_Management_System.Business_Access_Layer
{
    class RoomHire
    {
        //------------------------------ Fields ------------------------------\\

        int _roomHireID = 0;
        int _roomID = 0;
        int _externalCompanyID = 0;
        DateTime _startDate = DateTime.Today;
        int _hireDuration = 13;
        DateTime _endDate = DateTime.Today;
        int _hoursPerWeek = 1;
        decimal _monthlyHireCost = 0;
        decimal _totalHireCost = 0;

        //------------------------------ Constructors ------------------------------\\

        public RoomHire(){ }//End Default Constructor
        

        public RoomHire(int roomHireID, int roomID, int externalCompanyID, DateTime startDate, int hireDuration, DateTime endDate, int hoursPerWeek, decimal monthlyHireCost, decimal totalHireCost)
        {
            _roomHireID = roomHireID;
            _roomID = roomID;
            _externalCompanyID = externalCompanyID;
            _startDate = startDate;
            _hireDuration = hireDuration;
            _endDate = endDate;
            _hoursPerWeek = hoursPerWeek;
            _monthlyHireCost = monthlyHireCost;
            _totalHireCost = totalHireCost;

        }//End Overloaded Constructor

        //------------------------------ Properties ------------------------------\\

        public int RoomHireID
        {
            get { return _roomHireID; }
            set { _roomHireID = value; }

        }//End Property


        public int RoomID
        {
            get { return _roomID; }
            set { _roomID = value; }

        }//End Property


        public int ExternalCompanyID
        {
            get { return _externalCompanyID; }
            set { _externalCompanyID = value; }

        }//End Property


        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }

        }//End Property


        public int HireDuration
        {
            get { return _hireDuration; }
            set { _hireDuration = value; }

        }//End Property


        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }

        }//End Property


        public int HoursPerWeek
        {
            get { return _hoursPerWeek; }
            set { _hoursPerWeek = value; }

        }//End Property


        public decimal MonthlyHireCost
        {
            get { return _monthlyHireCost; }
            set { _monthlyHireCost = value; }

        }//End Property


        public decimal TotalHireCost
        {
            get { return _totalHireCost; }
            set { _totalHireCost = value; }

        }//End Property


    }
}
