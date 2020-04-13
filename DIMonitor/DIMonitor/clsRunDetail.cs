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

            // Register OnCheckedChanged event
            if (cbPeilDatumNull != null)
            {
                cbPeilDatumNull.CheckedChanged += new System.EventHandler(this.cbCheckedChanged);
            }
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
        }

        // Update all controls on form
        public void UpdateControls(string value=null, bool setCheckBox=true)
        {
            if (value == null)
                value = this._dbValue;

            if (this._runDetailType == DetailType.DateTimePicker)
            {
                bool nullPeilDatumValue = ((value == "") && this._cbPeilDatumNull != null);

                this._control.Enabled = !nullPeilDatumValue;
                if ((this._cbPeilDatumNull != null) && setCheckBox == true)
                    this._cbPeilDatumNull.Checked = nullPeilDatumValue;

                if (this._control is DateTimePicker)
                {
                    DateTimePicker dtp = (DateTimePicker)this._control;
                    dtp.Format = DateTimePickerFormat.Custom;

                    if (nullPeilDatumValue)
                    {   // null value peildatum: disable peildatum control and set null value checkbox
                        // Empty peildatum picker
                        dtp.CustomFormat = " ";
                    }
                    else if (this._cbPeilDatumNull != null)
                    {
                        dtp.CustomFormat = "yyyy-MM-dd";
                        dtp.Value = DateTime.Parse(value);
                    }
                }
            }
            else if (this._runDetailType == DetailType.DateTimeLabel)
            {
                this._control.Text = Convert.ToDateTime(value).ToString("dd-MM-yyyy");
            }
            else if (this._runDetailType == DetailType.Checkbox)
                ((CheckBox)this._control).Checked = (value.ToString() == (_usesP ? "P" : "J"));
            else if (this._runDetailType == DetailType.DateTimePicker)
                this._control.Text = value.ToString();
            else if (this._runDetailType == DetailType.Label)
                this._control.Text = value.ToString();
            else if (this._runDetailType == DetailType.TextBox)
                this._control.Text = value.ToString();
        }

        private void cbCheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.CheckState == CheckState.Checked)
                UpdateControls("", false);
            else
            {
                string newValue = this._dbValue;
                if (newValue == "")
                    newValue = DateTime.Now.ToShortDateString();
                UpdateControls(newValue, false);
            }
        }
    }
}
