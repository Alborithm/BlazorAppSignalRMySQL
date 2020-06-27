using System;

namespace BlazorSignalRApp.Shared.Models.OEE
{
    public class RealTime
    {
        private string _department;
        public string Department
        {
            get { return _department; }
            set { _department = value; }
        }
        
        private string _area;
        public string Area
        {
            get { return _area; }
            set { _area = value; }
        }
        
        private string _lineName;
        public string LineName
        {
            get { return _lineName; }
            set { _lineName = value; }
        }
        
        private int _lineId;
        public int LineId
        {
            get { return _lineId; }
            set { _lineId = value; }
        }
        
        private int _opNumber;
        public int OpNumber
        {
            get { return _opNumber; }
            set { _opNumber = value; }
        }
        
        private string _opName;
        public string OpName
        {
            get { return _opName; }
            set { _opName = value; }
        }
        
        private bool _available;
        public bool Available
        {
            get { return _available; }
            set { _available = value; }
        }
        
        private int _failCode;
        public int FailCode
        {
            get { return _failCode; }
            set { _failCode = value; }
        }
        
        
    }
}