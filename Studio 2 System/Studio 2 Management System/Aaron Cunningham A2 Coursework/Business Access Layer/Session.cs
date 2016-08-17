using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio_2_Management_System.Business_Access_Layer
{
    class Session
    {
        //------------------------ Fields ------------------------\\
        int _sessionID = 1;
        int _exerciseClassID = 1;
        DateTime _dateOfClass = DateTime.Today;
        TimeSpan _startTimeOfClass = new TimeSpan(7, 30, 0);
        int _lengthOfClass = 60;
        TimeSpan _endTimeOfClass = new TimeSpan(8, 30, 0);


        //------------------------ Constructors ------------------------\\

        public Session() { }//End Default Constructor


        public Session(int sessionID, int exerciseClassID, DateTime dateOfClass, TimeSpan startTimeOfClass, int lengthOfClass, TimeSpan endTimeOfClass ) 
        {
            _sessionID = sessionID;
            _exerciseClassID = exerciseClassID;
            _dateOfClass = dateOfClass;
            _startTimeOfClass = startTimeOfClass;
            _lengthOfClass = lengthOfClass;
            _endTimeOfClass = endTimeOfClass;

        }//End Overloaded Constructor

        //------------------------ Properties ------------------------\\

        public int SessionID
        {
            get { return _sessionID; }
            set { _sessionID = value; }

        }//End Property


        public int ExerciseClassID
        {
            get { return _exerciseClassID; }
            set { _exerciseClassID = value; }

        }//End Property


        public DateTime DateOfClass
        {
            get { return _dateOfClass; }
            set { _dateOfClass = value; }

        }//End Property

        public TimeSpan StartTimeOfClass
        {
            get { return _startTimeOfClass; }
            set { _startTimeOfClass = value; }

        }//End Property


        public int LengthOfClass
        {
            get { return _lengthOfClass; }
            set { _lengthOfClass = value; }

        }//End Property


        public TimeSpan EndTimeOfClass
        {
            get { return _endTimeOfClass; }
            set { _endTimeOfClass = value; }

        }//End Property

    }
}
