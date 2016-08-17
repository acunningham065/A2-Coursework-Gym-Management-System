using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio_2_Management_System.Business_Access_Layer
{
    class ExerciseClass
    {
        //--------------------------- Declaration of Fields ---------------------------\\
        int _exerciseClassID = 1;
        int _employeeID = 1;
        int _externalCompanyID = 0;
        int _roomID = 1;
        string _description = "";
        string _difficulty = "";
        DateTime _startDateOfClass = DateTime.Today;
        int _noOfWeeks = 1;
        DateTime _endDateOfClass = DateTime.Today;
        int _currentNumberOfParticipants = 0;
        int _maxNumberOfParticipants = 0;
        bool _externalClass = false;
        decimal _weeklyCostOfClass = 1m;
        decimal _totalCostOfClass = 1m;

        //--------------------------- Constructors ---------------------------\\

        
        public ExerciseClass(){ }//End Default Constructor


        public ExerciseClass(int exerciseClassID, int employeeID, int externalCompanyID, int roomID, string description, string difficulty, DateTime startDateOfClass, int noOfWeeks, DateTime endDateOfClass, int currentNumberOfParticipants, int maxNumberOfParticipants, bool externalClass, decimal weeklyCostOfClass, decimal totalCostOfClass)
        {
            //Assign values
            _exerciseClassID = exerciseClassID;
            _employeeID = employeeID;
            _externalCompanyID = externalCompanyID;
            _roomID = roomID;
            _description = description;
            _difficulty = difficulty;
            _startDateOfClass = startDateOfClass;
            _noOfWeeks = noOfWeeks;
            _endDateOfClass = endDateOfClass;
            _currentNumberOfParticipants = currentNumberOfParticipants;
            _maxNumberOfParticipants = maxNumberOfParticipants;
            _externalClass = externalClass;
            _weeklyCostOfClass = weeklyCostOfClass;
            _totalCostOfClass = totalCostOfClass;

        }//End Overloaded Constructor
        
        //--------------------------- Properties ---------------------------\\

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


        public int ExternalCompanyID
        {
            get { return _externalCompanyID; }
            set { _externalCompanyID = value; }

        }//End Property


        public int RoomID
        {
            get { return _roomID; }
            set { _roomID = value; }

        }//End Property


        public string Description
        {
            get { return _description; }
            set { _description = value; }

        }//End Property


        public string Difficulty
        {
            get { return _difficulty; }
            set { _difficulty = value; }

        }//End Property


        public DateTime StartDateOfClass
        {
            get { return _startDateOfClass; }
            set { _startDateOfClass = value; }

        }//End Property


        public int NoOfWeeks
        {
            get { return _noOfWeeks; }
            set { _noOfWeeks = value; }

        }//End Property


        public DateTime EndDateOfClass
        {
            get { return _endDateOfClass; }
            set { _endDateOfClass = value; }

        }//End Property


        public int CurrentNumberOfParticipants
        {
            get { return _currentNumberOfParticipants; }
            set { _currentNumberOfParticipants = value; }

        }//End Property


        public int MaxNumberOfParticipants
        {
            get { return _maxNumberOfParticipants; }
            set { _maxNumberOfParticipants = value; }

        }//End Property


        public bool ExternalClass
        {
            get { return _externalClass; }
            set { _externalClass = value; }

        }//End Property


        public decimal WeeklyCostOfClass
        {
            get { return _weeklyCostOfClass; }
            set { _weeklyCostOfClass = value; }

        }//End Property


        public decimal TotalCostOfClass
        {
            get { return _totalCostOfClass; }
            set { _totalCostOfClass = value; }

        }//End Property

    }
}
