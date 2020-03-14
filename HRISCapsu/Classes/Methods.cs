using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRISCapsu.Classes
{
    public static class Methods
    {
        public static void ClearItems(Control panel)
        {
            try
            {
                foreach (Control control in panel.Controls)
                {
                    if (control is TextBox)
                    {
                        control.ResetText();
                    }
                    else if (control is ComboBox)
                    {
                        ((ComboBox)control).SelectedItem = null;
                    }
                    else if (control is DateTimePicker)
                    {
                        ((DateTimePicker)control).ResetText();
                    }
                    else if (control is ProgressBar)
                    {
                        ((ProgressBar)control).Value = 0;
                    }
                    else if (control is Label)
                    {

                        if (((Label)control).Text == "100%")
                            ((Label)control).Text = "0%";
                    }
                }
            }
            catch (Exception exception)
            {
                //MessageBox.Show("Failed! " + exception.Message, "Error",
                //    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
