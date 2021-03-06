﻿namespace VisualPlus.Localization
{
    #region Namespace

    using System.ComponentModel;

    using VisualPlus.Structure;

    #endregion

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class GlobalStrings : GlobalId
    {
        #region Variables

        private readonly string _default_Abort;
        private readonly string _default_Cancel;
        private readonly string _default_Close;
        private readonly string _default_Ignore;
        private readonly string _default_No;
        private readonly string _default_Ok;
        private readonly string _default_Retry;
        private readonly string _default_Today;
        private readonly string _default_Yes;
        private string _abort;
        private string _cancel;
        private string _close;
        private string _ignore;
        private string _no;
        private string _ok;
        private string _retry;
        private string _today;
        private string _yes;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="GlobalStrings" /> class.</summary>
        public GlobalStrings()
        {
            _default_Ok = "OK";
            _default_Cancel = "Cancel";
            _default_Yes = "Yes";
            _default_No = "No";
            _default_Abort = "Abort";
            _default_Retry = "Retry";
            _default_Ignore = "Ignore";
            _default_Close = "Close";
            _default_Today = "Today";
            Reset();
        }

        #endregion

        #region Properties

        /// <summary>Gets and sets the Abort string used in message box buttons.</summary>
        [Localizable(true)]
        [Category(PropertyCategory.Data)]
        [Description("Abort string used for message box buttons.")]
        [DefaultValue("Abort")]
        [RefreshProperties(RefreshProperties.All)]
        public string Abort
        {
            get
            {
                return _abort;
            }

            set
            {
                _abort = value;
            }
        }

        /// <summary>Gets and sets the Cancel string used in message box buttons.</summary>
        [Localizable(true)]
        [Category(PropertyCategory.Data)]
        [Description("Cancel string used for message box buttons.")]
        [DefaultValue("Cancel")]
        [RefreshProperties(RefreshProperties.All)]
        public string Cancel
        {
            get
            {
                return _cancel;
            }

            set
            {
                _cancel = value;
            }
        }

        /// <summary>Gets and sets the Close string used in message box buttons.</summary>
        [Localizable(true)]
        [Category(PropertyCategory.Data)]
        [Description("Close string used for message box buttons.")]
        [DefaultValue("Close")]
        [RefreshProperties(RefreshProperties.All)]
        public string Close
        {
            get
            {
                return _close;
            }

            set
            {
                _close = value;
            }
        }

        /// <summary>Gets and sets the Ignore string used in message box buttons.</summary>
        [Localizable(true)]
        [Category(PropertyCategory.Data)]
        [Description("Ignore string used for message box buttons.")]
        [DefaultValue("Ignore")]
        [RefreshProperties(RefreshProperties.All)]
        public string Ignore
        {
            get
            {
                return _ignore;
            }

            set
            {
                _ignore = value;
            }
        }

        /// <summary>Gets a value indicating if all the strings are default values.</summary>
        /// <returns>The <see cref="bool" />.</returns>
        [Browsable(false)]
        public bool IsDefault
        {
            get
            {
                return _ok.Equals(_default_Ok) &&
                       _cancel.Equals(_default_Cancel) &&
                       _yes.Equals(_default_Yes) &&
                       _no.Equals(_default_No) &&
                       _abort.Equals(_default_Abort) &&
                       _retry.Equals(_default_Retry) &&
                       _ignore.Equals(_default_Ignore) &&
                       _close.Equals(_default_Close) &&
                       _today.Equals(_default_Today);
            }
        }

        /// <summary>Gets and sets the No string used in message box buttons.</summary>
        [Localizable(true)]
        [Category(PropertyCategory.Data)]
        [Description("No string used for message box buttons.")]
        [DefaultValue("No")]
        [RefreshProperties(RefreshProperties.All)]
        public string No
        {
            get
            {
                return _no;
            }

            set
            {
                _no = value;
            }
        }

        /// <summary>Gets and sets the OK string used in message box buttons.</summary>
        [Localizable(true)]
        [Category(PropertyCategory.Data)]
        [Description("OK string used for message box buttons.")]
        [DefaultValue("OK")]
        [RefreshProperties(RefreshProperties.All)]
        public string OK
        {
            get
            {
                return _ok;
            }

            set
            {
                _ok = value;
            }
        }

        /// <summary>Gets and sets the Retry string used in message box buttons.</summary>
        [Localizable(true)]
        [Category(PropertyCategory.Data)]
        [Description("Retry string used for message box buttons.")]
        [DefaultValue("Retry")]
        [RefreshProperties(RefreshProperties.All)]
        public string Retry
        {
            get
            {
                return _retry;
            }

            set
            {
                _retry = value;
            }
        }

        /// <summary>Gets and sets the Close string used in calendars.</summary>
        [Localizable(true)]
        [Category(PropertyCategory.Data)]
        [Description("Today string used for calendars.")]
        [DefaultValue("Today")]
        [RefreshProperties(RefreshProperties.All)]
        public string Today
        {
            get
            {
                return _today;
            }

            set
            {
                _today = value;
            }
        }

        /// <summary>Gets and sets the Yes string used in message box buttons.</summary>
        [Localizable(true)]
        [Category(PropertyCategory.Data)]
        [Description("Yes string used for message box buttons.")]
        [DefaultValue("Yes")]
        [RefreshProperties(RefreshProperties.All)]
        public string Yes
        {
            get
            {
                return _yes;
            }

            set
            {
                _yes = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>Reset all strings to default values.</summary>
        public void Reset()
        {
            _ok = _default_Ok;
            _cancel = _default_Cancel;
            _yes = _default_Yes;
            _no = _default_No;
            _abort = _default_Abort;
            _retry = _default_Retry;
            _ignore = _default_Ignore;
            _close = _default_Close;
            _today = _default_Today;
        }

        #endregion
    }
}