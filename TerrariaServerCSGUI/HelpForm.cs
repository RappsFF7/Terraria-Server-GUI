﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TerrariaServerCS
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
        }

        private void Help_Load(object sender, EventArgs e)
        {
            string tsUrl = "";
            Uri toUri = null;

            // Parse the url
            tsUrl = Path.GetFullPath(TerrariaServerCS.Properties.Resources.HelpDirectory + TerrariaServerCS.Properties.Resources.HelpHomepage);
            Uri.TryCreate(tsUrl, UriKind.RelativeOrAbsolute, out toUri);

            // Navigate to the help page
            webBrowser_Main.Navigate(toUri);
        }
    }
}
