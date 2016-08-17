using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio_2_Management_System.Business_Access_Layer
{
    class Room
    {
        //------------------------ Fields ------------------------\\

        int _roomID = 0;
        string _roomDescription = "";
        string _roomLocation = "";
        int _capacity = 1;
        decimal _hourlyHireCost = 1;
        bool _availableToUse = true;

        //------------------------ Constructors ------------------------\\

        public Room() { } //End Default constructor


        public Room(int roomID, string roomDescription, string roomLocation, int capacity, decimal hourlyHireCost, bool availableToUse)
        {
            _roomID = roomID;
            _roomDescription = roomDescription;
            _roomLocation = roomLocation;
            _capacity = capacity;
            _hourlyHireCost = hourlyHireCost;
            _availableToUse = availableToUse;            

        }//End Overloaded Constructor


        //------------------------ Properties ------------------------\\

        public int RoomID
        {
            get { return _roomID; }
            set { _roomID = value; }

        }//End Property


        public string RoomLocation
        {
            get { return _roomLocation; }
            set { _roomLocation = value; }

        }//End Property


        public string RoomDescription
        {
            get { return _roomDescription; }
            set { _roomDescription = value; }

        }//End Property


        public int Capacity
        {
            get { return _capacity; }
            set { _capacity = value; }

        }//End Property


        public decimal HourlyHireCost
        {
            get { return _hourlyHireCost; }
            set { _hourlyHireCost = value; }

        }//End Property


        public bool AvailableToUse
        {
            get { return _availableToUse; }
            set { _availableToUse = value; }

        }//End Property

    }
}
