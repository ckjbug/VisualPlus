﻿namespace VisualPlus.Designer
{
    #region Namespace

    using System.Collections;
    using System.Windows.Forms.Design;

    #endregion

    internal class VisualTabPageDesigner : ScrollableControlDesigner
    {
        #region Overrides

        protected override void PreFilterProperties(IDictionary properties)
        {
            properties.Remove("BackgroundImageLayout");
            properties.Remove("RightToLeft");
            properties.Remove("ImeMode");
            properties.Remove("BorderStyle");
            properties.Remove("Margin");
            properties.Remove("Padding");
            properties.Remove("UseVisualStyleBackColor");

            base.PreFilterProperties(properties);
        }

        #endregion
    }
}