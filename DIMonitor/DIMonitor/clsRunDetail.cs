using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIMonitor
{
    class clsRunDetail
    {
        public enum DetailType
        {
            Unknown=0,
            Checkbox = 1,
            DateTimePicker = 2,
            Label = 3,
            DateTimeLabel=4
        };

        private string _name;
        private string _dbValue = "";
        private bool _usesP = true;
        private DetailType _runDetailType;
        

        internal DetailType RunDetailType
        {
            get { return _runDetailType; }
            set { _runDetailType = value; }
        }
        private Control _control; 

        public string DBValue
        {
            get { return _dbValue; }
            set { _dbValue = value; }
        }
        public string Name
        {
          get { return _name; }
          set { _name = value; }
        }

        public string NewValue
        {
          get {
              string newValue = "";

              if (_runDetailType == DetailType.Checkbox)
              {
                  newValue = ((CheckBox)_control).Checked ? (_usesP ? "P" : "J") : "N";
              }
              else if (_runDetailType == DetailType.Label)
              {
                  newValue = ((Label)_control).Text.ToString();
              }
              else if (_runDetailType == DetailType.DateTimePicker)
              {
                  DateTime dt = DateTime.Parse(((DateTimePicker)_control).Text);
                  newValue = dt.ToString();
              }
              else if (_runDetailType == DetailType.DateTimeLabel)
              {
                  DateTime dt = DateTime.Parse(((Label)_control).Text);
                  newValue = dt.ToString();
              }
              return newValue;
          }
        }

        public string NewValueDBFormatted
        {
            get
            {
                string newValue = NewValue;
                if ((_runDetailType == DetailType.DateTimeLabel) || (_runDetailType == DetailType.DateTimePicker))
                {
                    newValue = DateTime.Parse(newValue).ToString("yyyy-MM-dd");
                }
                return "'" + newValue + "'";
            }
        }

        public bool HasChanged {
            get {
                return _dbValue != this.NewValue; 
            }
        }
        public clsRunDetail(string name, DetailType detailType, Control control, bool usesP=false)
        {
            this._name = name;
            this._runDetailType = detailType;
            this._control = control;
            this._usesP = usesP;
        }
        public clsRunDetail(string name, string value, DetailType detailType)
        {
            this._name = name;
            this._dbValue = value;
            this._runDetailType = detailType;
        }
    }
}
