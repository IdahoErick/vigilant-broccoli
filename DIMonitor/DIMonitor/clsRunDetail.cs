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
            DateTimeLabel=4,
            TextBox=5
        };

        private string _name;
        private string _dbValue = "";
        private bool _usesP = true;
        private DetailType _runDetailType;
        private CheckBox _cbPeilDatumNull;
        

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
              else if (_runDetailType == DetailType.TextBox)
              {
                  newValue = ((TextBox)_control).Text.ToString();
              }
              else if (_runDetailType == DetailType.DateTimePicker)
              {
                  if ((this._cbPeilDatumNull != null) && (this._cbPeilDatumNull.Checked == true))
                      newValue = "";
                  else
                  {
                    DateTime dt = DateTime.Parse(((DateTimePicker)_control).Text);
                    newValue = dt.ToString();
                  }
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
                    if (newValue == "")
                        newValue = "null";
                    else
                        newValue = "'" + DateTime.Parse(newValue).ToString("yyyy-MM-dd") + "'";
                }
                else
                    newValue = "'" + newValue + "'";

                return newValue;
            }
        }

        public bool HasChanged {
            get {
                return _dbValue != this.NewValue; 
            }
        }
        public clsRunDetail(string name, DetailType detailType, Control control, bool usesP=false, CheckBox cbPeilDatumNull=null)
        {
            this._name = name;
            this._runDetailType = detailType;
            this._control = control;
            this._usesP = usesP;
            this._cbPeilDatumNull = cbPeilDatumNull;
        }
        public clsRunDetail(string name, string value, DetailType detailType)
        {
            this._name = name;
            this._dbValue = value;
            this._runDetailType = detailType;
        }
        public void SetValue(string value)
        {
            this._dbValue = value;
            if ((value == "") && this._cbPeilDatumNull != null)
            {
                this._control.Enabled = false;
                this._cbPeilDatumNull.Checked = true;
            }
            else if ((value != "null") && this._cbPeilDatumNull != null)
            {
                this._control.Enabled = true;
                this._cbPeilDatumNull.Checked = false;
            }
        }
    }
}
