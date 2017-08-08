﻿namespace VisualPlus.Toolkit.Controls
{
    #region Namespace

    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    using VisualPlus.Enumerators;
    using VisualPlus.EventArgs;
    using VisualPlus.Managers;
    using VisualPlus.Renders;
    using VisualPlus.Structure;
    using VisualPlus.Toolkit.VisualBase;

    #endregion

    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(Control))]
    [DefaultEvent("ToggledChanged")]
    [DefaultProperty("Toggled")]
    [Description("The Visual Toggle")]
    [Designer(ControlManager.FilterProperties.VisualToggle)]
    public class VisualToggle : ToggleBase
    {
        #region Variables

        private readonly Timer animationTimer = new Timer
            {
                Interval = 1
            };

        private Border buttonBorder;
        private Gradient buttonDisabledGradient;
        private Gradient buttonGradient;
        private Rectangle buttonRectangle;
        private Size buttonSize;
        private GraphicsPath controlGraphicsPath;
        private Point endPoint;
        private Point startPoint;
        private string textProcessor;
        private int toggleLocation;
        private ToggleTypes toggleType;

        #endregion

        #region Constructors

        public VisualToggle()
        {
            BackColor = Color.Transparent;
            Size = new Size(50, 25);
            Font = StyleManager.Font;
            animationTimer.Tick += AnimationTimerTick;

            toggleType = ToggleTypes.YesNo;
            buttonSize = new Size(20, 20);

            ControlBorder = new Border
                {
                    Rounding = Settings.DefaultValue.Rounding.ToggleBorder
                };

            buttonBorder = new Border
                {
                    Rounding = Settings.DefaultValue.Rounding.ToggleButton
                };

            UpdateTheme(this, Settings.DefaultValue.DefaultStyle);
        }

        // public delegate void ToggledChangedEventHandler();

        // public event ToggledChangedEventHandler ToggledChanged;
        public enum ToggleTypes
        {
            /// <summary>Yes / No toggle.</summary>
            YesNo,

            /// <summary>On / Off toggle.</summary>
            OnOff,

            /// <summary>I / O toggle.</summary>
            IO
        }

        #endregion

        #region Properties

        [TypeConverter(typeof(BorderConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category(Localization.Category.Property.Appearance)]
        public Border Border
        {
            get
            {
                return ControlBorder;
            }

            set
            {
                ControlBorder = value;
                Invalidate();
            }
        }

        [TypeConverter(typeof(BorderConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category(Localization.Category.Property.Appearance)]
        public Border ButtonBorder
        {
            get
            {
                return buttonBorder;
            }

            set
            {
                buttonBorder = value;
                Invalidate();
            }
        }

        [TypeConverter(typeof(GradientConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category(Localization.Category.Property.Appearance)]
        public Gradient ButtonDisabled
        {
            get
            {
                return buttonDisabledGradient;
            }

            set
            {
                buttonDisabledGradient = value;
                Invalidate();
            }
        }

        [TypeConverter(typeof(GradientConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category(Localization.Category.Property.Appearance)]
        public Gradient ButtonGradient
        {
            get
            {
                return buttonGradient;
            }

            set
            {
                buttonGradient = value;
                Invalidate();
            }
        }

        [Category(Localization.Category.Property.Layout)]
        [Description(Localization.Descriptions.Property.Description.Common.Size)]
        public Size ButtonSize
        {
            get
            {
                return buttonSize;
            }

            set
            {
                buttonSize = value;
                Invalidate();
            }
        }

        [DefaultValue(false)]
        [Category(Localization.Category.Property.Behavior)]
        [Description(Localization.Descriptions.Property.Description.Common.Toggle)]
        public bool Toggled
        {
            get
            {
                return Toggle;
            }

            set
            {
                Toggle = value;
                Invalidate();
                OnToggleChanged(new ToggleEventArgs(Toggle));
            }
        }

        [Category(Localization.Category.Property.Appearance)]
        [Description(Localization.Descriptions.Property.Description.Common.Type)]
        public ToggleTypes Type
        {
            get
            {
                return toggleType;
            }

            set
            {
                toggleType = value;
                Invalidate();
            }
        }

        #endregion

        #region Events

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            animationTimer.Start();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            MouseState = MouseStates.Hover;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            MouseState = MouseStates.Normal;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Toggled = !Toggled;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graphics = e.Graphics;
            controlGraphicsPath = VisualBorderRenderer.GetBorderShape(ClientRectangle, ControlBorder.Type, ControlBorder.Rounding);

            // Update button location points
            startPoint = new Point(0 + 2, (ClientRectangle.Height / 2) - (buttonSize.Height / 2));
            endPoint = new Point(ClientRectangle.Width - buttonSize.Width - 2, (ClientRectangle.Height / 2) - (buttonSize.Height / 2));

            Gradient buttonTemp = Enabled ? buttonGradient : buttonDisabledGradient;

            var gradientPoints = new[] { new Point { X = ClientRectangle.Width, Y = 0 }, new Point { X = ClientRectangle.Width, Y = ClientRectangle.Height } };
            LinearGradientBrush buttonGradientBrush = Gradient.CreateGradientBrush(buttonTemp.Colors, gradientPoints, buttonTemp.Angle, buttonTemp.Positions);

            // Determines button state to draw
            Point buttonPoint = Toggle ? endPoint : startPoint;
            buttonRectangle = new Rectangle(buttonPoint, buttonSize);

            DrawToggleType(graphics);

            GraphicsPath buttonPath = VisualBorderRenderer.GetBorderShape(buttonRectangle, buttonBorder.Type, buttonBorder.Rounding);
            graphics.FillPath(buttonGradientBrush, buttonPath);

            VisualBorderRenderer.DrawBorderStyle(graphics, buttonBorder, MouseState, buttonPath);
        }

        protected override void OnThemeChanged(ThemeEventArgs e)
        {
            buttonGradient = StyleManager.ControlStatesStyle.ControlEnabled;
            buttonDisabledGradient = StyleManager.ControlStatesStyle.ControlDisabled;

            base.OnThemeChanged(e);
        }

        /// <summary>Create a slide animation when toggled.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void AnimationTimerTick(object sender, EventArgs e)
        {
            if (Toggle)
            {
                if (toggleLocation >= 100)
                {
                    return;
                }

                toggleLocation += 10;
                Invalidate(false);
            }
            else if (toggleLocation > 0)
            {
                toggleLocation -= 10;
                Invalidate(false);
            }
        }

        private void DrawToggleType(Graphics graphics)
        {
            // Determines the type of toggle to draw.
            switch (toggleType)
            {
                case ToggleTypes.YesNo:
                    {
                        textProcessor = Toggled ? "Yes" : "No";

                        break;
                    }

                case ToggleTypes.OnOff:
                    {
                        textProcessor = Toggled ? "On" : "Off";

                        break;
                    }

                case ToggleTypes.IO:
                    {
                        textProcessor = Toggled ? "I" : "O";

                        break;
                    }
            }

            // Draw string
            Rectangle textBoxRectangle;

            const int XOff = 5;
            const int XOn = 7;

            if (Toggle)
            {
                textBoxRectangle = new Rectangle(XOff, 0, Width - 1, Height - 1);
            }
            else
            {
                Size textSize = GDI.MeasureText(graphics, textProcessor, Font);
                textBoxRectangle = new Rectangle(Width - (textSize.Width / 2) - (XOn * 2), 0, Width - 1, Height - 1);
            }

            StringFormat stringFormat = new StringFormat
                {
                    // Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

            graphics.DrawString(
                textProcessor,
                new Font(Font.FontFamily, 7f, Font.Style),
                new SolidBrush(ForeColor),
                textBoxRectangle,
                stringFormat);
        }

        #endregion
    }
}