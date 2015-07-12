using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eclipse_Tech_Dashboard
{
    public partial class ChangeNameForm : Form
    {
        public string ActiveChangingBtn;
        public ChangeNameForm()
        {
            InitializeComponent();
            OkBtn.DialogResult = DialogResult.OK;
        }

        private void SaveSetting(string setting, string change)
        {
            Properties.Settings.Default[setting] = change;
            Properties.Settings.Default.Save();
        }


        private void MakeNewProperty(string property, string value)
        {
            if (Properties.Settings.Default[property] != null)
            {
                Properties.Settings.Default[property] = value;
                SaveSetting(property, value);

            }

        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            MakeNewProperty(ActiveChangingBtn, NewValueTextBox.Text);

        }

        private void Change_form_keydown(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                MessageBox.Show("Hey");
                OkBtn_Click(sender, e);
            }
        }

        private void NewValueTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox_KeyDown_Handler(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                MakeNewProperty(ActiveChangingBtn, NewValueTextBox.Text);
                this.DialogResult = DialogResult.OK;
            }
            else if (e.KeyValue == (char)Keys.Escape){
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
