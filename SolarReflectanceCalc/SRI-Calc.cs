﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Deployment.Application;
using Microsoft.Win32;
using System.IO;

namespace SolarReflectanceCalc
    {
    public partial class SRI : Form
        {
        public SRI()
            {
            InitializeComponent();
            }

        private void Calculate_Click(object sender, EventArgs e)
            {
            try
                {
                //Initialize my variables
                double E, A, dblOut5, dblOut12, dblOut30, X5, X12, X30,Tb, Ts, Tw;

                //Convert text to double
                E = double.Parse(tbE.Text);
                A = double.Parse(tbAlpha.Text);

                //Reset color of text box to default in case it was changed to yellow earlier
                tbAlpha.BackColor = default(Color);
                tbE.BackColor = default(Color);
                //Hide error message label if it was set to visible
                lblError.Visible = false;

                // Check all our inputs first
                if ((string.IsNullOrEmpty(tbE.Text) == true) && (string.IsNullOrEmpty(tbAlpha.Text) == true))
                    {
                    if (string.IsNullOrEmpty(tbE.Text) == true)
                        {
                        tbE.BackColor = System.Drawing.Color.Yellow;
                        lblError.Visible = true;
                        }
                    if (string.IsNullOrEmpty(tbAlpha.Text) == true)
                        {
                        tbAlpha.BackColor = System.Drawing.Color.Yellow;
                        lblError.Visible = true;
                        }
                    }

                //If tbE out of range then change it yellow and displays error message
                if ((E > .999) || (E < .001))
                    {
                    tbE.BackColor = System.Drawing.Color.Yellow;
                    lblError.Visible = true;
                    }
                //if tbAlpha out of range change it yellow and display error message
                if ((A > .999) || (A < .001))
                    {
                    tbAlpha.BackColor = System.Drawing.Color.Yellow;
                    lblError.Visible = true;
                    }
                //Validate inputs again.
                //Dumb, but I'm too lazy to fix it to an else as of yet
                //TODO: fix it!
                if (((E < 1.000) && (E > .000)) && ((A < 1.000) && (A > .000)) && (string.IsNullOrEmpty(tbE.Text) != true) && (string.IsNullOrEmpty(tbAlpha.Text) != true))
                    {

                    Ts = (309.7 + ((1066.07*A) - (31.98*E)) / ((6.78*E)+5)) - ((890.94*A*A) + (2153.86*A*E))/((6.78*E+5)*(6.78*E+5));
                    Tb = (309.7 + ((1066.07 * 0.95) - (31.98 * 0.9)) / ((6.78 * 0.9) + 5)) - ((890.94 * 0.95 * 0.95) + (2153.86 * 0.95 * 0.9)) / ((6.78 * 0.90 + 5) * (6.78 * 0.90 + 5));
                    Tw = (309.7 + ((1066.07 * 0.20) - (31.98 * 0.9)) / ((6.78 * 0.9) + 5)) - ((890.94 * 0.20 * 0.20) + (2153.86 * 0.20 * 0.9)) / ((6.78 * 0.90 + 5) * (6.78 * 0.90 + 5));
                    X5 = 100.0 * (Tb - Ts) / (Tb - Tw);
                    dblOut5 = Convert.ToInt32(X5);
                    tbOut5.Text = dblOut5.ToString();


                    Ts = (309.7 + ((1066.07 * A) - (31.98 * E)) / ((6.78 * E) + 12)) - ((890.94 * A * A) + (2153.86 * A * E)) / ((6.78 * E + 12) * (6.78 * E + 12));
                    Tb = (309.7 + ((1066.07 * 0.95) - (31.98 * 0.9)) / ((6.78 * 0.9) + 12)) - ((890.94 * 0.95 * 0.95) + (2153.86 * 0.95 * 0.9)) / ((6.78 * 0.90 + 12) * (6.78 * 0.90 + 12));
                    Tw = (309.7 + ((1066.07 * 0.20) - (31.98 * 0.9)) / ((6.78 * 0.9) + 12)) - ((890.94 * 0.20 * 0.20) + (2153.86 * 0.20 * 0.9)) / ((6.78 * 0.90 + 12) * (6.78 * 0.90 + 12));
                    X12 = 100.0 * (Tb - Ts) / (Tb - Tw);
                    dblOut12 = Convert.ToInt32(X12);
                    tbOut12.Text = dblOut12.ToString();

                    Ts = (309.7 + ((1066.07 * A) - (31.98 * E)) / ((6.78 * E) + 30)) - ((890.94 * A * A) + (2153.86 * A * E)) / ((6.78 * E + 30) * (6.78 * E + 30));
                    Tb = (309.7 + ((1066.07 * 0.95) - (31.98 * 0.9)) / ((6.78 * 0.9) + 30)) - ((890.94 * 0.95 * 0.95) + (2153.86 * 0.95 * 0.9)) / ((6.78 * 0.90 + 30) * (6.78 * 0.90 + 30));
                    Tw = (309.7 + ((1066.07 * 0.20) - (31.98 * 0.9)) / ((6.78 * 0.9) + 30)) - ((890.94 * 0.20 * 0.20) + (2153.86 * 0.20 * 0.9)) / ((6.78 * 0.90 + 30) * (6.78 * 0.90 + 30));
                    X30 = 100.0 * (Tb - Ts) / (Tb - Tw);
                    dblOut30 = Convert.ToInt32(X30);
                    tbOut30.Text = dblOut30.ToString();
                    }

                }

            catch (Exception err)
                {
                System.Diagnostics.Debug.WriteLine("An error occurred: '{0}'", err.Message);
                }
            }

        }
    }
