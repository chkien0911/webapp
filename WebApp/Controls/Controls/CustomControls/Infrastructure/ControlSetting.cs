using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ivs.Core.Interface;
using Ivs.Core.Common;
using Ivs.Core.Data;
using System.Data;
using DevExpress.Utils;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace Ivs.Controls.CustomControls.Infrastructure
{
    public enum DateTimeFormat
    {
        Date = 1,
        DateTime = 2,
        Time = 3,
        Custom = 0,
    }

    /// <summary>
    /// DropDown: show list with autocomplete
    /// DropDownList: show list without autocomplete
    /// </summary>
    public enum DropDownStyle
    {
        DropDown = 1,
        DropDownList = 2,
    }

    public class Data
    {
        public const int DefaultWidth = 200;
    }

    public class ControlSetting 
    {
        #region Properties

        public DropDownStyle DropDownStyle { get; set; }


        private DateTime? _maxDate = DateTime.MaxValue;
        //
        // Summary:
        //     Gets or sets a value indicating whether the control can respond to user interaction.
        //
        // Returns:
        //     true if the control can respond to user interaction; otherwise, false. The
        //     default is true.
        public DateTime? MaxDate 
        { 
            get 
            { 
                return _maxDate; 
            } 
            set 
            { 
                _maxDate = value; 
            } 
        }

        private DateTime _minDate = DateTime.MinValue;
        //
        // Summary:
        //     Gets or sets a value indicating whether the control can respond to user interaction.
        //
        // Returns:
        //     true if the control can respond to user interaction; otherwise, false. The
        //     default is true.
        public DateTime MinDate { get { return _minDate; } set { _minDate = value; } }

        //
        // Summary:
        //     Gets or sets a value indicating whether the control can respond to user interaction.
        //
        // Returns:
        //     true if the control can respond to user interaction; otherwise, false. The
        //     default is true.
        public virtual DateTimeFormat DateTimeFormat { get; set; }

        private bool _allowInput = true;
        //
        // Summary:
        //     Gets or sets a value indicating whether the control can respond to user interaction.
        //
        // Returns:
        //     true if the control can respond to user interaction; otherwise, false. The
        //     default is true.
        [DefaultValue(true)]
        public bool AllowInput { get { return _allowInput; } set { _allowInput = value; } }

        private bool _allowNull = true;
        //
        // Summary:
        //     Gets or sets a value indicating whether the control can respond to user interaction.
        //
        // Returns:
        //     true if the control can respond to user interaction; otherwise, false. The
        //     default is true.
        [DefaultValue(true)]
        public bool AllowNull { get { return _allowNull; } set { _allowNull = value; } }

        private bool _enable = true;
        //
        // Summary:
        //     Gets or sets a value indicating whether the control can respond to user interaction.
        //
        // Returns:
        //     true if the control can respond to user interaction; otherwise, false. The
        //     default is true.
        [DefaultValue(true)]
        public bool Enabled { get { return _enable; } set { _enable = value; } }

        //
        // Summary:
        //     Gets or sets the name of the control.
        //
        // Returns:
        //     The name of the control. The default is an empty string ("").
        public virtual string Name { get; set; }

        //
        // Summary:
        //     Gets or sets the height and width of the control.
        //
        // Returns:
        //     The System.Drawing.Size that represents the height and width of the control
        //     in pixels.
        public virtual System.Drawing.Size Size { get; set; }

        //
        // Summary:
        //     Gets or sets the tab order of the control within its container.
        //
        // Returns:
        //     The index value of the control within the set of controls within its container.
        //     The controls in the container are included in the tab order.
        public virtual short TabIndex { get; set; }

        //
        // Summary:
        //     Gets or sets a value indicating whether the user can give the focus to this
        //     control using the TAB key.
        //
        // Returns:
        //     true if the user can give the focus to the control using the TAB key; otherwise,
        //     false. The default is true.NoteThis property will always return true for
        //     an instance of the System.Windows.Forms.Form class.
        public virtual bool TabStop { get; set; }

        //
        // Summary:
        //     Gets or sets the object that contains data about the control.
        //
        // Returns:
        //     An System.Object that contains data about the control. The default is null.
        public virtual object Tag { get; set; }

        //
        // Summary:
        //     Gets or sets the text associated with this control.
        //
        // Returns:
        //     The text associated with this control.
        public virtual string Text { get; set; }

        //
        // Summary:
        //     Gets or sets a value indicating whether the control and all its child controls
        //     are displayed.
        //
        // Returns:
        //     true if the control and all its child controls are displayed; otherwise,
        //     false. The default is true.
        public virtual bool Visible { get; set; }

        private int _width = Data.DefaultWidth;
        //
        // Summary:
        //     Gets or sets the width of the control.
        //
        // Returns:
        //     The width of the control in pixels.
        [DefaultValue(Data.DefaultWidth)]
        public int Width 
        { 
            get 
            { 
                return _width; 
            } 
            set 
            {
                if (value >= 0)
                {
                    _width = value;
                }
            } 
        }

        //
        // Summary:
        //     Gets a string that describes the visual appearance of the specified object.
        //     Not all objects have a description.
        //
        // Returns:
        //     A description of the object's visual appearance to the user, or null if the
        //     object does not have a description.
        //
        public virtual string Description { get; set; }

        //
        // Summary:
        //     Gets or sets the value of an accessible object.
        //
        // Returns:
        //     The value of an accessible object, or null if the object has no value set.
        //
        public virtual object Value { get; set; }

        //
        // Summary:
        //     Gets or sets the DataSource of an accessible object.
        //
        // Returns:
        //     The value of an accessible object, or null if the object has no value set.
        //
        public object DataSource { get; private set; }

        //
        // Summary:
        //     Gets or sets the FieldName of an accessible object.
        //
        // Returns:
        //     The value of an accessible object, or null if the object has no value set.
        //
        public virtual string FieldName { get; set; }

        //
        // Summary:
        //     Gets or sets the DisplayMember of an Combobox or DropdownControl object.
        //
        // Returns:
        //     The value of an accessible object, or null if the object has no value set.
        //
        public virtual string DisplayMember { get; set; }

        //
        // Summary:
        //     Gets or sets the ValueMember of an Combobox or DropdownControl object.
        //
        // Returns:
        //     The value of an accessible object, or null if the object has no value set.
        //
        public virtual string ValueMember { get; set; }


        //
        // Summary:
        //     Gets a value indicating whether the control can be null.
        //
        // Returns:
        //     true if the control can be null; otherwise, false.
        public virtual bool HasNull { get; set; }

        //
        // Summary:
        //     Gets or sets the FunctionCode to receive DataSource of an Combobox or DropdownControl object.
        //
        // Returns:
        //     The value of an accessible object, or null if the object has no value set.
        //
        private string _functionCode = CommonData.StringEmpty;
        public virtual string FunctionCode 
        {
            get
            {
                return _functionCode;
            }
            set
            {
                _functionCode = value;
                if (!CommonMethod.IsNullOrEmpty(value))
                {
                    string editValue = CommonMethod.ParseString(this.EditValue);
                    this.FillData();
                    this.SetLanguage();
                }
            }
        }

        //
        // Summary:
        //     Gets or sets the SelectedIndex of an Combobox or DropdownControl object.
        //
        // Returns:
        //     The value of an accessible object, or null if the object has no value set.
        //
        public virtual int SelectedIndex { get; set; }

        //
        // Summary:
        //     Gets or sets the NullText of an accessible object.
        //
        // Returns:
        //     The value of an accessible object, or null if the object has no value set.
        //
        public virtual string NullText { get; set; }

        //
        // Summary:
        //     Gets or sets the MaxLength of an accessible object.
        //
        // Returns:
        //     The value of an accessible object, or 0 if the object has no value set.
        //
        public virtual int MaxLength { get; set; }

        //
        // Summary:
        //     Gets a value indicating whether the control can be readonly.
        //
        // Returns:
        //     true if the control can be null; otherwise, false.
        public bool ReadOnly { get; set; }

        //
        // Summary:
        //     Gets a value indicating whether the control can be password.
        //
        // Returns:
        //     true if the control can be null; otherwise, false.
        public virtual bool Password { get; set; }

        //
        // Summary:
        //     Gets or sets the PasswordChar of an accessible object.
        //
        // Returns:
        //     The value of an accessible object, or null if the object has no value set.
        //
        public virtual string PasswordChar { get; set; }

        //
        // Summary:
        //     Gets the pattern for formatting values.
        public virtual string FormatString { get; set; }

        //
        // Summary:
        //     Gets a value indicating whether the control can be checked.
        //
        // Returns:
        //     true if the control can be null; otherwise, false.
        public virtual bool Checked { get; set; }

        //
        // Summary:
        //     Gets or sets the EditValue of an accessible object.
        //
        // Returns:
        //     The value of an accessible object, or null if the object has no value set.
        //
        public virtual object EditValue { get; set; }

        //
        // Summary:
        //     Gets or sets the background image.
        public virtual Image Image { get; set; }

        //
        // Summary:
        //     Gets or sets the Icon.
        public virtual Image Icon { get; set; }

        //
        // Summary:
        //     Gets or sets a regular tooltip's content.
        public virtual string ToolTip { get; set; }

        //
        // Summary:
        //     Gets or sets the horizontal alignment of text.
        public HorizontalAlign HAlignment { get; set; }

        //
        // Summary:
        //     Gets or sets the vetical alignment of text.
        public virtual VerticalAlign VAlignment { get; set; }

        //
        // Summary:
        //     Gets or sets the HeaderText of an accessible object.
        //
        // Returns:
        //     The value of an accessible object, or null if the object has no value set.
        //
        public virtual string HeaderText { get; set; }

        //
        // Summary:
        //     Gets a value indicating whether the control can be showed.
        //
        // Returns:
        //     true if the control can be null; otherwise, false.
        public virtual bool ShowHeader { get; set; }

        #endregion

        #region Construction

        public ControlSetting() { }

        public ControlSetting(string name)
        {
            this.Name = name;
        }

        public ControlSetting(string name, string functionCode, bool hasNull = true)
        {
            this.Name = name;
            this.HasNull = hasNull;

            //Set datasource
            this.FunctionCode = functionCode;
        }

        

        #endregion

        #region Methods

        protected virtual void FillData()
        {
            DataTable dtResult = new System.Data.DataTable();
            //CommonBl commonBl = new CommonBl();
            //commonBl.SelectDataForControl(this.FunctionCode, out dtResult);

            if (this.HasNull && dtResult.Columns.Count > 0)
            {
                DataRow newRow = dtResult.NewRow();
                //newRow[0] = CommonData.StringEmpty;
                dtResult.Rows.InsertAt(newRow, 0);
            }

            this.DataSource = dtResult;
            this.EditValue = CommonData.StringEmpty;
            this.NullText = CommonData.StringEmpty;
        }

        protected virtual void SetLanguage()
        {
            if (UserSession.LangId.Equals((CommonData.Language.VietNamese)))
            {
                this.DisplayMember = CommonKey.Name1;
                this.ValueMember = CommonData.CommonCode;
            }
            else if (UserSession.LangId.Equals((CommonData.Language.English)))
            {
                this.DisplayMember = CommonKey.Name2;
                this.ValueMember = CommonData.CommonCode;
            }
            else if (UserSession.LangId.Equals((CommonData.Language.Japanese)))
            {
                this.DisplayMember = CommonKey.Name3;
                this.ValueMember = CommonData.CommonCode;
            }
        }

        #endregion
    }
}
