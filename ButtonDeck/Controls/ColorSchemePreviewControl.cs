﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NickAc.Backend.Utils.AppSettings;
using ButtonDeck.Misc;

namespace ButtonDeck.Controls
{
    public partial class ColorSchemePreviewControl : UserControl
    {
        private void ModifyColorScheme(IEnumerable<Control> cccc)
        {
            cccc.All(c => {
                ModifyColorScheme(c.Controls.OfType<Control>());
                try {
                    dynamic cc = c;
                    cc.ForeColor = AppTheme.ForeColorShaded;
                    cc.ColorScheme = AppTheme;
                    return true;
                } catch (Exception) {
                    return true;
                }
            });
            Refresh();
        }

        public void Recenter(Control c, bool horizontal = true, bool vertical = true)
        {
            if (c == null) return;
            if (horizontal)
                c.Left = (c.Parent.ClientSize.Width - c.Width) / 2;
            if (vertical)
                c.Top = (c.Parent.ClientSize.Height - c.Height) / 2;
        }

        private ApplicationColorScheme _appTheme = ColorSchemeCentral.Neptune;

        public ColorSchemePreviewControl()
        {
            InitializeComponent();
            Text = "Window Title";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AppTheme = _appTheme;
        }

        public string DescriptionText {
            get { return label1.Text; }
            set {
                label1.Text = value;
                Recenter(label1, vertical: false);
            }
        }

        public ApplicationColorScheme AppTheme {
            get { return _appTheme; }
            set {
                _appTheme = value;
                ModifyColorScheme(Controls.OfType<Control>());
                titlebarPanel.BackColor = value.PrimaryColor;
                BackColor = value.BackgroundColor;
            }
        }

    }
}
