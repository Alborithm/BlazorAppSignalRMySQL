using System;

namespace BlazorSignalRApp.Shared.Models.OEE
{
    public class Availability
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private int _operationNumber;
        public int OperationNumber
        {
            get { return _operationNumber; }
            set { _operationNumber = value; }
        }
        private int _operationLine;
        public int OperationLine
        {
            get { return _operationLine; }
            set { _operationLine = value; }
        }
        private bool _available;
        public bool Available
        {
            get { return _available; }
            set { _available = value; }
        }
        
        private DateTime _eventTime;
        public DateTime EventTime
        {
            get { return _eventTime; }
            set { _eventTime = value; }
        }
        
        private int _code;
        public int Code
        {
            get { return _code; }
            set { _code = value; }
        }
        
    }
}